using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace SystemLivraria.classes
{
    internal sealed class UsuarioSessao
    {
        public int IdUsuario { get; set; }
        public int Nivel { get; set; }
    }

    internal static class SenhaUsuarios
    {
        private const string Prefixo = "PBKDF2-SHA256$";
        private const int Iteracoes = 600000;

        internal static bool TemHash(string valor)
        {
            return valor != null &&
                valor.StartsWith(Prefixo, StringComparison.Ordinal);
        }

        internal static void ValidarNova(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha) ||
                senha.Length < 8 ||
                senha.Length > 128)
            {
                throw new InvalidOperationException(
                    "A senha deve ter de 8 a 128 caracteres " +
                    "e não pode conter somente espaços.");
            }
        }

        internal static string Gerar(string senha)
        {
            ValidarNova(senha);
            return Derivar(senha);
        }

        // Também permite converter senhas antigas sem alterá-las.
        internal static string Derivar(string senha)
        {
            var salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            using (var kdf = new Rfc2898DeriveBytes(
                senha, salt, Iteracoes, HashAlgorithmName.SHA256))
            {
                return Prefixo +
                    Iteracoes.ToString(CultureInfo.InvariantCulture) +
                    "$" + Convert.ToBase64String(salt) +
                    "$" + Convert.ToBase64String(kdf.GetBytes(32));
            }
        }

        private static bool Iguais(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int diferenca = 0;

            for (int i = 0; i < a.Length; i++)
                diferenca |= a[i] ^ b[i];

            return diferenca == 0;
        }

        internal static bool Verificar(
            string senha, string armazenada)
        {
            if (senha == null || armazenada == null)
                return false;

            // Compatibilidade temporária com contas antigas.
            if (!TemHash(armazenada))
            {
                return Iguais(
                    Encoding.UTF8.GetBytes(senha),
                    Encoding.UTF8.GetBytes(armazenada));
            }

            try
            {
                string[] p = armazenada.Split('$');
                int n;

                if (p.Length != 4 ||
                    !int.TryParse(
                        p[1],
                        NumberStyles.None,
                        CultureInfo.InvariantCulture,
                        out n) ||
                    n < 100000 ||
                    n > 1000000)
                {
                    return false;
                }

                byte[] salt = Convert.FromBase64String(p[2]);
                byte[] hash = Convert.FromBase64String(p[3]);

                if (salt.Length != 16 || hash.Length != 32)
                    return false;

                using (var kdf = new Rfc2898DeriveBytes(
                    senha, salt, n, HashAlgorithmName.SHA256))
                {
                    return Iguais(kdf.GetBytes(32), hash);
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

    internal static class UsuariosService
    {
        private static string Conexao
        {
            get
            {
                var c = ConfigurationManager.ConnectionStrings[
                    "SystemLivraria.Properties.Settings.db_250064ConnectionString"];

                if (c == null ||
                    string.IsNullOrWhiteSpace(c.ConnectionString))
                {
                    throw new ConfigurationErrorsException(
                        "Configure a conexão no App.config.");
                }

                return c.ConnectionString;
            }
        }

        private static SqlParameter P(
            string nome, SqlDbType tipo, object valor)
        {
            var p = new SqlParameter(nome, tipo)
            {
                Value = valor ?? DBNull.Value
            };

            if (tipo == SqlDbType.VarChar)
                p.Size = 255;

            return p;
        }

        private static SqlCommand Cmd(
            SqlConnection c,
            SqlTransaction t,
            string sql,
            params SqlParameter[] p)
        {
            var cmd = new SqlCommand(sql, c, t)
            {
                CommandTimeout = 30
            };

            cmd.Parameters.AddRange(p);
            return cmd;
        }

        private static object Exec(
            SqlConnection c,
            SqlTransaction t,
            string sql,
            params SqlParameter[] p)
        {
            using (var cmd = Cmd(c, t, sql, p))
                return cmd.ExecuteScalar();
        }

        private static DataTable Ler(
            SqlConnection c,
            SqlTransaction t,
            string sql,
            params SqlParameter[] p)
        {
            using (var cmd = Cmd(c, t, sql, p))
            using (var da = new SqlDataAdapter(cmd))
            {
                var tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
        }

        private static void Autorizar(
            SqlConnection c,
            SqlTransaction t,
            int administrador)
        {
            object id = Exec(c, t, @"
SELECT Id_Usu
FROM dbo.Usuarios
WHERE Id_Usu=@id
  AND Ativo_usu=1
  AND Id_Permi=1;",
                P("@id", SqlDbType.Int, administrador));

            if (id == null)
            {
                throw new UnauthorizedAccessException(
                    "Somente um Administrador ativo pode " +
                    "gerenciar usuários.");
            }
        }

        private static DataTable Consultar(
            int administrador, string sql)
        {
            using (var c = new SqlConnection(Conexao))
            {
                c.Open();
                Autorizar(c, null, administrador);
                return Ler(c, null, sql);
            }
        }

        internal static DataTable Listar(int administrador)
        {
            // A senha não é retornada para a interface.
            return Consultar(administrador, @"
SELECT
    U.Id_Usu,
    U.Id_Funci,
    F.Nome_Funci,
    U.Login_usu,
    U.Id_Permi,
    P.Nome_Permi,
    U.Ativo_usu
FROM dbo.Usuarios U
JOIN dbo.Funcionarios F ON F.Id_Funci=U.Id_Funci
JOIN dbo.Permissoes P ON P.Id_Permi=U.Id_Permi
ORDER BY F.Nome_Funci,U.Login_usu;");
        }

        internal static DataTable FuncionariosDisponiveis(
            int administrador)
        {
            return Consultar(administrador, @"
SELECT
    F.Id_Funci,
    CONVERT(varchar(12),F.Id_Funci)+' - '+F.Nome_Funci AS Rotulo
FROM dbo.Funcionarios F
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.Usuarios U
    WHERE U.Id_Funci=F.Id_Funci
)
ORDER BY F.Nome_Funci;");
        }

        internal static DataTable Permissoes(int administrador)
        {
            return Consultar(administrador, @"
            SELECT Id_Permi,Nome_Permi
            FROM dbo.Permissoes
            WHERE Id_Permi IN (1,2,3)
            ORDER BY Id_Permi;");
        }

        private static int Gravar(
            int administrador,
            Func<SqlConnection, SqlTransaction, int> acao)
        {
            using (var c = new SqlConnection(Conexao))
            {
                c.Open();

                using (var t = c.BeginTransaction(
                    IsolationLevel.Serializable))
                {
                    bool confirmando = false;
                    int id = 0;

                    try
                    {
                        // Serializa alterações administrativas para
                        // proteger as regras mesmo com duas telas abertas.
                        Exec(c, t, @"
                        SET XACT_ABORT ON;

                        DECLARE @r int;

                        EXEC @r=sys.sp_getapplock
                            @Resource='SystemLivraria:GerenciarUsuarios',
                            @LockMode='Exclusive',
                            @LockOwner='Transaction',
                            @LockTimeout=10000;

                        IF @r<0
                            THROW 51200,
                            'Outro usuário está gerenciando contas. Tente novamente.', 1;");

                        Autorizar(c, t, administrador);

                        id = acao(c, t);

                        confirmando = true;
                        t.Commit();

                        return id;
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            t.Rollback();
                        }
                        catch
                        {
                        }

                        if (confirmando)
                        {
                            throw new InvalidOperationException(
                                "A resposta da confirmação foi perdida. " +
                                "Atualize a lista e confira o usuário " +
                                id + " antes de repetir.", ex);
                        }

                        throw;
                    }
                }
            }
        }

        private static string ValidarCadastro(
            SqlConnection c,
            SqlTransaction t,
            int id,
            string login,
            int nivel)
        {
            if (string.IsNullOrWhiteSpace(login) ||
                login.Length > 50)
            {
                throw new InvalidOperationException(
                    "Informe um login de até 50 caracteres.");
            }

            object perfil = Exec(c, t, @"
                SELECT Nome_Permi
                FROM dbo.Permissoes
                WHERE Id_Permi=@nivel
                  AND Id_Permi IN (1,2,3);",
                P("@nivel", SqlDbType.Int, nivel));

            if (perfil == null)
            {
                throw new InvalidOperationException(
                    "Selecione uma permissão válida.");
            }

            object duplicado = Exec(c, t, @"
                SELECT Id_Usu
                FROM dbo.Usuarios
                WHERE Login_usu=@login
                  AND Id_Usu<>@id;",
                P("@login", SqlDbType.VarChar, login),
                P("@id", SqlDbType.Int, id));

            if (duplicado != null)
            {
                throw new InvalidOperationException(
                    "Este login já está sendo utilizado.");
            }

            return Convert.ToString(perfil);
        }

        internal static int Cadastrar(
            int administrador,
            int funcionario,
            string login,
            int nivel,
            bool ativo,
            string senha)
        {
            login = (login ?? "").Trim();
            string hash = SenhaUsuarios.Gerar(senha);

            return Gravar(administrador, (c, t) =>
            {
                string perfil = ValidarCadastro(
                    c, t, 0, login, nivel);

                object existe = Exec(c, t, @"
                    SELECT Id_Funci
                    FROM dbo.Funcionarios
                    WHERE Id_Funci=@f;",
                    P("@f", SqlDbType.Int, funcionario));

                if (existe == null)
                {
                    throw new InvalidOperationException(
                        "Selecione um funcionário cadastrado.");
                }

                object conta = Exec(c, t, @"
                    SELECT Id_Usu
                    FROM dbo.Usuarios
                    WHERE Id_Funci=@f;",
                    P("@f", SqlDbType.Int, funcionario));

                if (conta != null)
                {
                    throw new InvalidOperationException(
                        "Este funcionário já possui uma conta, " +
                        "mesmo que esteja inativa.");
                }

                return Convert.ToInt32(Exec(c, t, @"
                    INSERT INTO dbo.Usuarios
                        (Id_Funci,Id_Permi,Login_usu,Senha_usu,Ativo_usu,Perfil_usu)
                    VALUES
                        (@f,@nivel,@login,@senha,@ativo,@perfil);

                    SELECT CONVERT(int,SCOPE_IDENTITY());",
                    P("@f", SqlDbType.Int, funcionario),
                    P("@nivel", SqlDbType.Int, nivel),
                    P("@login", SqlDbType.VarChar, login),
                    P("@senha", SqlDbType.VarChar, hash),
                    P("@ativo", SqlDbType.Bit, ativo),
                    P("@perfil", SqlDbType.VarChar, perfil)));
            });
        }

        internal static void Alterar(
            int administrador,
            int usuario,
            string login,
            int nivel,
            bool ativo)
        {
            login = (login ?? "").Trim();

            Gravar(administrador, (c, t) =>
            {
                string perfil = ValidarCadastro(
                    c, t, usuario, login, nivel);

                var atual = Ler(c, t, @"
                    SELECT Id_Permi,Ativo_usu
                    FROM dbo.Usuarios
                    WHERE Id_Usu=@id;",
                    P("@id", SqlDbType.Int, usuario));

                if (atual.Rows.Count != 1)
                {
                    throw new InvalidOperationException(
                        "Usuário não encontrado.");
                }

                bool retirandoAdmin =
                    Convert.ToInt32(
                        atual.Rows[0]["Id_Permi"]) == 1 &&
                    Convert.ToBoolean(
                        atual.Rows[0]["Ativo_usu"]) &&
                    (!ativo || nivel != 1);

                if (retirandoAdmin)
                {
                    int quantidade = Convert.ToInt32(Exec(c, t, @"
                    SELECT COUNT(*)
                    FROM dbo.Usuarios
                    WHERE Id_Permi=1 AND Ativo_usu=1;"));

                    if (quantidade <= 1)
                    {
                        throw new InvalidOperationException(
                            "O sistema precisa manter pelo menos " +
                            "um Administrador ativo.");
                    }
                }

                if (usuario == administrador &&
                    (!ativo || nivel != 1))
                {
                    throw new InvalidOperationException(
                        "Você não pode desativar nem " +
                        "rebaixar sua própria conta.");
                }

                // O funcionário vinculado não é alterado.
                Exec(c, t, @"
                    UPDATE dbo.Usuarios
                    SET Login_usu=@login,
                        Id_Permi=@nivel,
                        Ativo_usu=@ativo,
                        Perfil_usu=@perfil
                    WHERE Id_Usu=@id;",
                    P("@id", SqlDbType.Int, usuario),
                    P("@login", SqlDbType.VarChar, login),
                    P("@nivel", SqlDbType.Int, nivel),
                    P("@ativo", SqlDbType.Bit, ativo),
                    P("@perfil", SqlDbType.VarChar, perfil));

                return usuario;
            });
        }

        internal static void RedefinirSenha(
            int administrador, int usuario, string senha)
        {
            string hash = SenhaUsuarios.Gerar(senha);

            Gravar(administrador, (c, t) =>
            {
                object existe = Exec(c, t, @"
                    SELECT Id_Usu
                    FROM dbo.Usuarios
                    WHERE Id_Usu=@id;",
                    P("@id", SqlDbType.Int, usuario));

                if (existe == null)
                {
                    throw new InvalidOperationException(
                        "Usuário não encontrado.");
                }

                Exec(c, t, @"
                    UPDATE dbo.Usuarios
                    SET Senha_usu=@senha
                    WHERE Id_Usu=@id;",
                    P("@senha", SqlDbType.VarChar, hash),
                    P("@id", SqlDbType.Int, usuario));

                return usuario;
            });
        }

        internal static UsuarioSessao Autenticar(
            string login, string senha)
        {
            login = (login ?? "").Trim();

            if (login.Length == 0 ||
                login.Length > 50 ||
                string.IsNullOrEmpty(senha) ||
                senha.Length > 255)
            {
                return null;
            }

            using (var c = new SqlConnection(Conexao))
            {
                c.Open();

                var dados = Ler(c, null, @"
                    SELECT Id_Usu,Senha_usu
                    FROM dbo.Usuarios
                    WHERE Login_usu=@login
                      AND Ativo_usu=1;",
                    P("@login", SqlDbType.VarChar, login));

                if (dados.Rows.Count != 1)
                    return null;

                int id = Convert.ToInt32(
                    dados.Rows[0]["Id_Usu"]);

                string armazenada = Convert.ToString(
                    dados.Rows[0]["Senha_usu"]);

                if (!SenhaUsuarios.Verificar(senha, armazenada))
                    return null;

                // Preserva a senha das contas antigas,
                // incluindo aquelas com menos de oito caracteres.
                string migrada = null;

                if (!SenhaUsuarios.TemHash(armazenada))
                    migrada = SenhaUsuarios.Derivar(senha);

                using (var t = c.BeginTransaction())
                {
                    try
                    {
                        // Confere novamente caso a conta tenha sido
                        // alterada enquanto a senha era verificada.
                        var atual = Ler(c, t, @"
                            SELECT Id_Usu,Id_Permi
                            FROM dbo.Usuarios WITH (UPDLOCK,HOLDLOCK)
                            WHERE Id_Usu=@id
                              AND Ativo_usu=1
                              AND Id_Permi IN (1,2,3)
                              AND Senha_usu COLLATE Latin1_General_100_BIN2=@anterior;",
                            P("@id", SqlDbType.Int, id),
                            P("@anterior",
                                SqlDbType.VarChar, armazenada));

                        if (atual.Rows.Count != 1)
                        {
                            t.Rollback();
                            return null;
                        }

                        if (migrada != null)
                        {
                            Exec(c, t, @"
                            UPDATE dbo.Usuarios
                            SET Senha_usu=@hash
                            WHERE Id_Usu=@id;",
                                P("@hash",
                                    SqlDbType.VarChar, migrada),
                                P("@id", SqlDbType.Int, id));
                        }

                        var sessao = new UsuarioSessao
                        {
                            IdUsuario = id,
                            Nivel = Convert.ToInt32(
                                atual.Rows[0]["Id_Permi"])
                        };

                        t.Commit();
                        return sessao;
                    }
                    catch
                    {
                        try
                        {
                            t.Rollback();
                        }
                        catch
                        {
                        }

                        throw;
                    }
                }
            }
        }
    }
}