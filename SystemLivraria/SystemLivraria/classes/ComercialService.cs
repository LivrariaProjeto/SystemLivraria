using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SystemLivraria.classes
{
    internal sealed class ItemComercial
    {
        public int IdProduto { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public decimal Subtotal
        {
            get { return Quantidade * Preco; }
        }
    }

    internal sealed class ResultadoIncertoException : Exception
    {
        public ResultadoIncertoException(string mensagem, Exception causa)
            : base(mensagem, causa) { }
    }

    internal static class ComercialService
    {
        internal const decimal LimiteValor = 99999999.99m;

        private static string Conexao
        {
            get
            {
                var config = ConfigurationManager.ConnectionStrings[
                    "SystemLivraria.Properties.Settings.db_250064ConnectionString"];

                if (config == null ||
                    string.IsNullOrWhiteSpace(config.ConnectionString))
                    throw new ConfigurationErrorsException(
                        "Configure a conexão no App.config.");

                return config.ConnectionString;
            }
        }

        private static SqlParameter P(
            string nome, SqlDbType tipo, object valor)
        {
            var p = new SqlParameter(nome, tipo)
            {
                Value = valor ?? DBNull.Value
            };

            if (tipo == SqlDbType.Decimal)
            {
                p.Precision = 10;
                p.Scale = 2;
            }

            if (tipo == SqlDbType.VarChar)
                p.Size = 255;

            return p;
        }

        private static SqlCommand Comando(
            SqlConnection c, SqlTransaction t,
            string sql, params SqlParameter[] parametros)
        {
            var cmd = new SqlCommand(sql, c, t)
            {
                CommandTimeout = 60
            };

            cmd.Parameters.AddRange(parametros);
            return cmd;
        }

        private static object Executar(
            SqlConnection c, SqlTransaction t,
            string sql, params SqlParameter[] parametros)
        {
            using (var cmd = Comando(c, t, sql, parametros))
                return cmd.ExecuteScalar();
        }

        private static DataTable Ler(
            SqlConnection c, SqlTransaction t,
            string sql, params SqlParameter[] parametros)
        {
            using (var cmd = Comando(c, t, sql, parametros))
            using (var da = new SqlDataAdapter(cmd))
            {
                var tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
        }

        internal static DataTable Produtos()
        {
            using (var c = new SqlConnection(Conexao))
                return Ler(c, null, @"
SELECT P.Id_Pro, P.Nome_Pro, P.Preco_Pro,
       P.Nome_Pro + ' | ISBN: ' +
           COALESCE(P.ISBN_Pro, 'sem ISBN') AS Rotulo,
       COALESCE((
           SELECT SUM(CONVERT(bigint, E.QTD_Est))
           FROM dbo.Estoque E
           WHERE E.Id_Pro=P.Id_Pro
       ), 0) AS Disponivel
FROM dbo.Produtos P
ORDER BY P.Nome_Pro, P.Id_Pro;");
        }

        internal static DataTable Parceiros(bool venda)
        {
            using (var c = new SqlConnection(Conexao))
                return Ler(c, null, venda
                    ? @"SELECT Id_Cli AS Id,
                               Nome_Cli + ' | ' + CPF_Cli AS Rotulo
                        FROM dbo.Cliente
                        ORDER BY Nome_Cli;"
                    : @"SELECT Id_Forne AS Id,
                               Nome_Forne + ' | ' + CNPJ_Forne AS Rotulo
                        FROM dbo.Fornecedores
                        ORDER BY Nome_Forne;");
        }

        internal static decimal ValidarItens(IList<ItemComercial> itens)
        {
            if (itens == null || itens.Count == 0)
                throw new InvalidOperationException(
                    "Adicione pelo menos um produto.");

            var ids = new HashSet<int>();
            decimal total = 0;

            foreach (var i in itens)
            {
                if (i == null || i.IdProduto <= 0 ||
                    !ids.Add(i.IdProduto))
                    throw new InvalidOperationException(
                        "Produto inválido ou repetido na lista.");

                if (i.Quantidade <= 0 || i.Preco <= 0 ||
                    i.Preco > LimiteValor ||
                    decimal.Round(i.Preco, 2) != i.Preco)
                    throw new InvalidOperationException(
                        "Informe quantidade e preço positivos, " +
                        "com até duas casas decimais.");

                total += i.Subtotal;

                if (total > LimiteValor)
                    throw new InvalidOperationException(
                        "O total ultrapassa o limite de " +
                        "decimal(10,2) do banco.");
            }

            return total;
        }

        internal static int Registrar(
            bool venda, int parceiro, int usuario,
            DateTime data, bool quitado,
            IList<ItemComercial> itens)
        {
            decimal total = ValidarItens(itens);

            if (parceiro <= 0 || usuario <= 0)
                throw new InvalidOperationException(
                    "Selecione o parceiro e entre com um usuário válido.");

            if (data.Date > DateTime.Today || data.Year < 1753)
                throw new InvalidOperationException(
                    "Informe uma data válida, até hoje.");

            using (var c = new SqlConnection(Conexao))
            {
                c.Open();

                using (var t = c.BeginTransaction(
                    IsolationLevel.Serializable))
                {
                    bool confirmando = false;
                    int documento = 0;

                    try
                    {
                        // As três triggers fazem parte desta versão.
                        Executar(c, t, @"
SET XACT_ABORT ON;

IF (
    SELECT COUNT(*)
    FROM sys.triggers
    WHERE is_disabled=0
      AND is_instead_of_trigger=0
      AND (
        (name='trg_AtualizarValorTotal'
         AND parent_id=OBJECT_ID('dbo.Itens_Vendas'))
        OR
        (name='trg_HistoricoEstoque'
         AND parent_id=OBJECT_ID('dbo.Estoque'))
        OR
        (name='trg_HistoricoFinanceiro'
         AND parent_id=OBJECT_ID('dbo.Financeiro'))
      )
) <> 3
    THROW 51001,
    'As três triggers precisam estar instaladas, habilitadas e visíveis para esta conexão.', 1;

IF NOT EXISTS (
    SELECT 1
    FROM dbo.Usuarios
    WHERE Id_Usu=@usuario
      AND Ativo_usu=1
      AND Id_Permi IN (1,2)
)
    THROW 51002,
    'Usuário sem permissão para registrar compras ou vendas.', 1;",
                            P("@usuario", SqlDbType.Int, usuario));

                        object existe = Executar(c, t, venda
                            ? @"SELECT Id_Cli FROM dbo.Cliente
                                WHERE Id_Cli=@id;"
                            : @"SELECT Id_Forne FROM dbo.Fornecedores
                                WHERE Id_Forne=@id;",
                            P("@id", SqlDbType.Int, parceiro));

                        if (existe == null)
                            throw new InvalidOperationException(
                                "Cliente ou fornecedor não encontrado.");

                        documento = Convert.ToInt32(
                            Executar(c, t, venda
                                ? @"
INSERT INTO dbo.Vendas(Id_Cli,Data_VDS,Valor_Total)
VALUES(@parceiro,@data,0);
SELECT CONVERT(int,SCOPE_IDENTITY());"
                                : @"
INSERT INTO dbo.Compras(Id_Forne,Data_CMP,Valor_CMP)
VALUES(@parceiro,@data,@total);
SELECT CONVERT(int,SCOPE_IDENTITY());",
                                P("@parceiro", SqlDbType.Int, parceiro),
                                P("@data", SqlDbType.Date, data.Date),
                                P("@total", SqlDbType.Decimal, total)));

                        foreach (var item in itens.OrderBy(
                            i => i.IdProduto))
                        {
                            var produto = Ler(c, t, @"
SELECT Nome_Pro, Preco_Pro
FROM dbo.Produtos WITH (UPDLOCK,HOLDLOCK)
WHERE Id_Pro=@id;",
                                P("@id", SqlDbType.Int, item.IdProduto));

                            if (produto.Rows.Count != 1)
                                throw new InvalidOperationException(
                                    "Produto não encontrado: " +
                                    item.Produto);

                            string nome = Convert.ToString(
                                produto.Rows[0]["Nome_Pro"]);

                            if (venda &&
                                Convert.ToDecimal(
                                    produto.Rows[0]["Preco_Pro"]) !=
                                item.Preco)
                                throw new InvalidOperationException(
                                    "O preço de " + nome +
                                    " mudou. Atualize a lista " +
                                    "e confira a venda.");

                            var estoques = Ler(c, t, venda
                                ? @"
SELECT Id_Est,QTD_Est
FROM dbo.Estoque WITH (UPDLOCK,HOLDLOCK)
WHERE Id_Pro=@produto
ORDER BY Id_Est;"
                                : @"
SELECT Id_Est,QTD_Est
FROM dbo.Estoque WITH (UPDLOCK,HOLDLOCK)
WHERE Id_Pro=@produto AND Id_Forne=@fornecedor
ORDER BY Id_Est;",
                                P("@produto",
                                    SqlDbType.Int, item.IdProduto),
                                P("@fornecedor",
                                    SqlDbType.Int, parceiro));

                            if (estoques.Rows.Cast<DataRow>().Any(
                                r => Convert.ToInt32(r["QTD_Est"]) < 0))
                                throw new InvalidOperationException(
                                    "Existe estoque negativo para " +
                                    nome +
                                    ". Corrija-o antes de continuar.");

                            if (venda)
                            {
                                long disponivel =
                                    estoques.Rows.Cast<DataRow>()
                                    .Sum(r => (long)Convert.ToInt32(
                                        r["QTD_Est"]));

                                if (disponivel < item.Quantidade)
                                    throw new InvalidOperationException(
                                        "Estoque insuficiente de " +
                                        nome + ". Disponível: " +
                                        disponivel);

                                int restante = item.Quantidade;

                                foreach (DataRow estoque in estoques.Rows)
                                {
                                    int quantidade = Math.Min(
                                        restante,
                                        Convert.ToInt32(
                                            estoque["QTD_Est"]));

                                    if (quantidade == 0)
                                        continue;

                                    int idEstoque = Convert.ToInt32(
                                        estoque["Id_Est"]);

                                    Executar(c, t, @"
INSERT INTO dbo.Itens_Vendas
    (Id_VDS,Id_Pro,Id_Est,QTD_Item,Preco_Uni)
VALUES(@doc,@produto,@estoque,@quantidade,@preco);",
                                        P("@doc",
                                            SqlDbType.Int, documento),
                                        P("@produto",
                                            SqlDbType.Int, item.IdProduto),
                                        P("@estoque",
                                            SqlDbType.Int, idEstoque),
                                        P("@quantidade",
                                            SqlDbType.Int, quantidade),
                                        P("@preco",
                                            SqlDbType.Decimal, item.Preco));

                                    AlterarEstoque(
                                        c, t, idEstoque,
                                        -quantidade, nome);

                                    restante -= quantidade;

                                    if (restante == 0)
                                        break;
                                }
                            }
                            else
                            {
                                Executar(c, t, @"
INSERT INTO dbo.Itens_CMP
    (Id_CMP,Id_Pro,QTD_Item,Preco_Unitario,Subtotal)
VALUES(@doc,@produto,@quantidade,@preco,@subtotal);",
                                    P("@doc",
                                        SqlDbType.Int, documento),
                                    P("@produto",
                                        SqlDbType.Int, item.IdProduto),
                                    P("@quantidade",
                                        SqlDbType.Int, item.Quantidade),
                                    P("@preco",
                                        SqlDbType.Decimal, item.Preco),
                                    P("@subtotal",
                                        SqlDbType.Decimal, item.Subtotal));

                                int idEstoque;

                                if (estoques.Rows.Count == 0)
                                    idEstoque = Convert.ToInt32(
                                        Executar(c, t, @"
INSERT INTO dbo.Estoque
    (Id_Pro,Id_Forne,Est_Min,Est_Max,QTD_Est,Nome_Pro)
VALUES(@produto,@fornecedor,0,0,0,@nome);
SELECT CONVERT(int,SCOPE_IDENTITY());",
                                            P("@produto",
                                                SqlDbType.Int,
                                                item.IdProduto),
                                            P("@fornecedor",
                                                SqlDbType.Int,
                                                parceiro),
                                            P("@nome",
                                                SqlDbType.VarChar,
                                                nome)));
                                else
                                    idEstoque = Convert.ToInt32(
                                        estoques.Rows[0]["Id_Est"]);

                                // Um único acréscimo.
                                // A trigger registra inclusive 0 -> quantidade.
                                AlterarEstoque(
                                    c, t, idEstoque,
                                    item.Quantidade, nome);
                            }
                        }

                        decimal totalBanco = Convert.ToDecimal(
                            Executar(c, t, venda
                                ? @"SELECT Valor_Total
                                    FROM dbo.Vendas
                                    WHERE Id_VDS=@doc;"
                                : @"SELECT SUM(Subtotal)
                                    FROM dbo.Itens_CMP
                                    WHERE Id_CMP=@doc;",
                                P("@doc", SqlDbType.Int, documento)));

                        if (totalBanco != total)
                            throw new InvalidOperationException(
                                "O total gravado difere dos itens. " +
                                "A operação foi cancelada.");

                        int financeiro = Convert.ToInt32(
                            Executar(c, t, @"
INSERT INTO dbo.Financeiro
    (Id_CMP,Id_VDS,Tipo_VDS,Desc_VDS,Valor_VDS,Data_VDS,
     Categoria_Fin,Situacao_Fin,Id_UsuFin)
VALUES
    (@compra,@venda,@tipo,@descricao,@total,@data,
     @categoria,'Pendente',@usuario);
SELECT CONVERT(int,SCOPE_IDENTITY());",
                                P("@compra", SqlDbType.Int,
                                    venda ? null : (object)documento),
                                P("@venda", SqlDbType.Int,
                                    venda ? (object)documento : null),
                                P("@tipo", SqlDbType.VarChar,
                                    venda ? "RECEITA" : "DESPESA"),
                                P("@descricao", SqlDbType.VarChar,
                                    (venda ? "Venda " : "Compra ") +
                                    documento),
                                P("@total",
                                    SqlDbType.Decimal, totalBanco),
                                P("@data", SqlDbType.Date, data.Date),
                                P("@categoria", SqlDbType.VarChar,
                                    venda ? "Venda" : "Compra"),
                                P("@usuario", SqlDbType.Int, usuario)));

                        if (quitado)
                            Executar(c, t, @"
INSERT INTO dbo.Movimentacoes_Financeiro
    (Id_Fin,Valor_Mov,Data_Mov,Id_Usu,Referencia_Mov)
VALUES(@fin,@valor,@data,@usuario,@referencia);

UPDATE dbo.Financeiro
SET Situacao_Fin=@situacao,
    Data_Quitacao=CONVERT(date,@data)
WHERE Id_Fin=@fin;",
                                P("@fin", SqlDbType.Int, financeiro),
                                P("@valor",
                                    SqlDbType.Decimal, totalBanco),
                                P("@data",
                                    SqlDbType.DateTime2, data.Date),
                                P("@usuario", SqlDbType.Int, usuario),
                                P("@referencia", SqlDbType.VarChar,
                                    (venda ? "VDS:" : "CMP:") +
                                    documento + ":INICIAL"),
                                P("@situacao", SqlDbType.VarChar,
                                    venda ? "Recebido" : "Pago"));

                        confirmando = true;
                        t.Commit();

                        return documento;
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            t.Rollback();
                        }
                        catch
                        {
                            // Preservar a falha original.
                        }

                        if (confirmando)
                            throw new ResultadoIncertoException(
                                "Não foi possível confirmar a resposta " +
                                "do banco. Consulte " +
                                (venda ? "a venda " : "a compra ") +
                                documento +
                                " antes de tentar novamente; " +
                                "ela pode ter sido gravada.", ex);

                        throw;
                    }
                }
            }
        }

        private static void AlterarEstoque(
            SqlConnection c, SqlTransaction t,
            int estoque, int variacao, string nome)
        {
            Executar(c, t, @"
DECLARE @alterados TABLE (Id_Est int);

UPDATE dbo.Estoque
SET QTD_Est=QTD_Est+@variacao, Nome_Pro=@nome
OUTPUT inserted.Id_Est INTO @alterados
WHERE Id_Est=@estoque
  AND CONVERT(bigint,QTD_Est)+@variacao
      BETWEEN 0 AND 2147483647;

IF (SELECT COUNT(*) FROM @alterados) <> 1
    THROW 51003,
    'Saldo de estoque inválido para esta operação.', 1;",
                P("@estoque", SqlDbType.Int, estoque),
                P("@variacao", SqlDbType.Int, variacao),
                P("@nome", SqlDbType.VarChar, nome));
        }
    }
}