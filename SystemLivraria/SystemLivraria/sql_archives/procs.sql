EXEC nome_da_procedure 'valor1', 123;

--> Alterar Produto <--
create procedure Proc_AlterarLivro
	@idpro int,
	@nomepro varchar(150),
	@autor int,
	@categoria int,
	@editora int,
	@preco decimal(10,2),
	@isbn varchar(20)
as
begin
	update Produtos
	set
	Nome_Pro = @nomepro,
	Id_Autor = @autor,
	Id_Cat = @categoria,
	Id_Edi = @editora,
	Preco_Pro = @preco,
	ISBN_Pro = @isbn
	where Id_Pro = @idpro
end
go
--=> TESTE
EXEC Proc_AlterarLivro
    1,
    'Dom Casmurro',
    1,
    6,
    1,
    39.90,
    '9780000000001';
SELECT * FROM Produtos
WHERE Id_Pro = 1;

--> Excluir Produto <--
--(pode dar problema se existir algum registro relacionado a esse produto, o SQL Server pode impedir a exclusão por causa das FKs)
alter procedure Proc_ExcluirPro
	@idpro int
as 
begin
	delete from Itens_Vendas
	where Id_Pro = @idpro;
	delete from Itens_CMP
	where Id_Pro = @idpro;
	delete from Estoque
	where Id_Pro = @idpro;
	delete from Produtos
	where Id_Pro = @idpro;
	select @idpro AS Id_Pro, 'Produto excluído com sucesso.' AS Mensagem;
end 
go
--=> TESTE
EXEC Proc_ExcluirPro 2;
SELECT * FROM Produtos
WHERE Id_Pro = 2;

--> Cadastros <--
create procedure Proc_CadastroPro
	@nomepro varchar(150),
	@autor int,
	@categoria int,
	@editora int,
	@preco decimal(10,2),
	@isbn varchar(20)
as
begin
	insert into Produtos
	(Nome_Pro, Id_Autor, Id_Cat, Id_Edi, Preco_Pro, ISBN_Pro)
	values
	(@nomepro, @autor, @categoria, @editora, @preco, @isbn);
end
go
--=> TESTE
EXEC Proc_CadastroPro
    'A Mansão Hollow',
    10,
    4,
    2,
    49.90,
    '9780000000123';
SELECT * FROM Produtos;

alter procedure Proc_CadastroCli
	@nomecli varchar(100),
	@telcli varchar(20),
	@cpfcli varchar(14),
	@emailcli varchar(100),
	@enderecocli varchar(200)
as
begin
	insert into Cliente
	(Nome_Cli, Tel_Cli, CPF_Cli, Email_Cli, Endereco_Cli)
	values
	(@nomecli, @telcli, @cpfcli, @emailcli, @enderecocli);
end
go
--=> TESTE
EXEC Proc_CadastroCli
    'Michelle',
    '15999999999',
    '111.111.111-11',
    'michelle@email.com',
    'Rua das Flores, 100';
select * from Cliente

alter procedure Proc_CadastroForne
	@nomeforne varchar(100),
	@enderecoforne varchar(200),
	@cnpjforne varchar(18),
	@emailforne varchar(100),
	@telforne varchar(20)
as
begin
	insert into Fornecedores
	(Nome_Forne, Endereco_Forne, CNPJ_Forne, Email_Forne, Tel_Forne)
	values
	(@nomeforne, @enderecoforne, @cnpjforne, @emailforne, @telforne);
end
go
--=> TESTE
EXEC Proc_CadastroForne
    'Fornecedor ABC',
    'Rua Principal, 100',
    '11.111.111/0001-11',
    'fornecedor@email.com',
    '15988888888';
select * from Fornecedores

alter procedure Proc_CadastroFunci
	@nomefunci varchar(100),
	@cpffunci varchar(14),
	@cargofunci varchar(50),
	@telfunci varchar(20),
	@dataadmissaofunci date,
	@emailfunci varchar(100)
as
begin
	insert into Funcionarios
	(Nome_Funci, CPF_Funci, Cargo_Funci, Tel_Funci, DataAdmissao_Funci, Email_Funci)
	values
	(@nomefunci, @cpffunci, @cargofunci, @telfunci, @dataadmissaofunci, @emailfunci);
end
go
--=> TESTE
EXEC Proc_CadastroFunci
    'João Silva',
    '222.222.222-22',
    'Vendedor',
    '15977777777',
    '2026-09-04',
    'joao@email.com';
select * from Funcionarios

alter procedure Proc_CadastroUsu
	@idfunci int,
	@idpermi int,
	@loginusu varchar(50),
	@senhausu varchar(255),
	@perfilusu varchar(50),
	@ativousu bit
as
begin
	insert into Usuarios
	(Id_Funci, Id_Permi, Login_usu, Senha_usu, Ativo_usu, Perfil_usu)
	values
	(@idfunci, @idpermi, @loginusu, @senhausu, @ativousu, @perfilusu);
end
go
--=> TESTE
EXEC Proc_CadastroUsu
    7,
    5,
    'joao',
    '123456',
    'Caixa',
    1;
select * from Usuarios

--> Realizar Venda <--
create type ItensVDS as table
(
	Id_Pro int,
	QTD_Item int
);
go
create procedure Proc_RealizarVDS
	@idcli int,
	@itensvds ItensVDS readonly--pode consultar a tabelinha mas não mudar
as
begin
	set nocount on;--pra não retornar mensagens
	set xact_abort on;--cancela/encerra se der algum problema

	declare
	@idvds int,
	@valortotal decimal(10,2) = 0;

	begin try
	begin transaction;

	-- 1. VALIDAR CLIENTE
	if not exists (
	select 1 from Cliente
	where Id_Cli = @idcli )
	begin
		throw 50001, 'Cliente não encontrado.', 1;
	end;

	-- 2. VALIDAR SE EXISTEM ITENS
	if not exists (
	select 1 from @itensvds )
	begin
		throw 50002, 'Nenhum produto foi informado.', 1;
	end;

	-- 3. VALIDAR QUANTIDADES
	if exists (
	select 1 from @itensvds
	where QTD_Item <= 0 )
	begin
		throw 50003, 'A quantidade dos produtos deve ser maior que zero.', 1;
	end;

	-- 4. VALIDAR SE TODOS OS PRODUTOS EXISTEM
	if exists (
	select 1 from @itensvds I
	left join Produtos P
	on P.Id_Pro = I.Id_Pro
	where P.Id_Pro is null )
	begin
		throw 50004, 'Um ou mais produtos não existem.', 1;
	end;

	-- 5. CRIAR A VENDA
	insert into Vendas
	(Id_Cli, Data_VDS, Valor_Total)
	values
	(@idcli, GETDATE(), 0);

	set @idvds = scope_identity();

	-- 6. SELECIONAR O ESTOQUE
	create table #ItensSelecionados (
		Id_Pro int,
		QTD_Item int,
		Id_Est int,
		Id_Forne int,
		Preco_Uni decimal(10,2)
	);

	insert into #ItensSelecionados
	(Id_Pro, QTD_Item, Id_Est, Id_Forne, Preco_Uni)
	select
	I.Id_Pro,
	I.QTD_Item,
	E.Id_Est,
	E.Id_Forne,
	P.Preco_Pro
	from @itensvds I
	inner join Produtos P
	on P.Id_Pro = I.Id_Pro
	inner join Estoque E
	on E.Id_Pro = I.Id_Pro
	and E.QTD_Est >= I.QTD_Item;

	-- 7. VERIFICAR SE TODOS OS PRODUTOS POSSUEM ESTOQUE
	if (
	select count(*) from #ItensSelecionados)
	<>
	(select count(*) from @itensvds)
	begin
		throw 50006, 'Estoque insuficiente para um ou mais produtos.', 1;
	end;

	-- 8. REGISTRAR OS ITENS DA VENDA
	insert into Itens_Vendas
	(Id_VDS, Id_Pro, Id_Est, QTD_Item, Preco_Uni)
	select
	@idvds,
	Id_Pro,
	Id_Est,
	QTD_Item,
	Preco_Uni
	from #ItensSelecionados;

	-- 9. BAIXAR O ESTOQUE
	update E
	set E.QTD_Est = E.QTD_Est - I.QTD_Item
	from Estoque E
	inner join #ItensSelecionados I
	on I.Id_Est = E.Id_Est;

	-- 10. RECALCULAR O VALOR TOTAL DA VENDA
	select @valortotal = sum(QTD_Item * Preco_Uni)
	from Itens_Vendas
	where Id_VDS = @idvds;

	update Vendas
	set Valor_Total = @valortotal
	where Id_VDS = @idvds;

	-- 11. GERAR LANÇAMENTO FINANCEIRO
	insert into Financeiro
	(Id_VDS, Tipo_VDS, Data_VDS, Valor_VDS, Desc_VDS)
	values
	(@idvds, 'RECEITA', GETDATE(), @valortotal, 'Venda realizada');

	-- 12. FINALIZAR
	commit transaction;

	select
	@idvds as Id_VDS,
	@valortotal as Valor_Total,
	'Venda realizada com sucesso.' as Mensagem;

	end try
	begin catch
		if @@trancount > 0
		rollback transaction;
		throw;
	end catch;
end;
go
--=> TESTE
declare @itens ItensVDS;
insert into @itens values (1, 2), (2, 1);
exec Proc_RealizarVDS @idcli = 3, @itensvds = @itens;

--> Registrar Compra <--
create type ItensCMP as table
(
	Id_Pro int,
	QTD_Item int,
	Preco_Unitario decimal(10,2)
);
go
create procedure Proc_RealizarCMP
    @idforne int,
    @itenscmp ItensCMP readonly
as
begin
	set nocount on;
	set xact_abort on;

	declare
        @idcmp int,
        @valortotal decimal(10,2) = 0;
begin try
begin transaction;

        -- valida fornecedor
	if not exists (
	select 1 from Fornecedores
	where Id_Forne = @idforne )
        begin
            throw 50001, 'Fornecedor não encontrado.', 1;
        end;

        -- valida se existem itens
        if not exists (
	select 1 from @itenscmp)
        begin
            throw 50002, 'Nenhum produto foi informado.', 1;
        end;

        -- valida quantidades e preços
	if exists (
	select 1 from @itenscmp
	where QTD_Item <= 0 or Preco_Unitario <= 0 )
        begin
            throw 50003, 'A quantidade e o preço devem ser maiores que zero.', 1;
        end;

        -- valida se todos os produtos existem
	if exists (
	select 1 from @itenscmp I
	left join Produtos P
	on P.Id_Pro = I.Id_Pro
	where P.Id_Pro is null )
        begin
            throw 50004, 'Um ou mais produtos não existem.', 1;
        end;

        -- cria a compra
        insert into Compras
	(Id_Forne, Valor_CMP, Data_CMP)
        values
	(@idforne, 0, GETDATE());

        set @idcmp = scope_identity();

        -- registra os itens da compra
        insert into Itens_CMP
        (Id_CMP, Id_Pro, QTD_Item, Preco_Unitario, Subtotal)
        select @idcmp, Id_Pro, QTD_Item, Preco_Unitario, QTD_Item * Preco_Unitario
        from @itenscmp;

        -- calcula o valor da compra
        select @valortotal = sum(QTD_Item * Preco_Unitario)
        from @itenscmp;

        update Compras
        set Valor_CMP = @valortotal
        where Id_CMP = @idcmp;

        -- atualiza ou cria o estoque
        update E
        set E.QTD_Est = E.QTD_Est + I.QTD_Item 
	from Estoque E
        inner join @itenscmp I
        on E.Id_Pro = I.Id_Pro
        where E.Id_Forne = @idforne;

        insert into Estoque
        (Id_Pro, Id_Forne, Est_Min, Est_Max, QTD_Est)
        select I.Id_Pro, @idforne, 0, 0, I.QTD_Item
        from @itenscmp I
        where not exists (
	select 1 from Estoque E
	where E.Id_Pro = I.Id_Pro and E.Id_Forne = @idforne
        );

        -- gera o lançamento financeiro
        insert into Financeiro
        (Id_CMP, Tipo_VDS, Data_VDS, Valor_VDS, Desc_VDS)
        values
        (@idcmp, 'DESPESA', GETDATE(), @valortotal, 'Compra realizada');

        -- finaliza
        commit transaction;

        -- retorno
        select @idcmp as Id_CMP,
	@valortotal as Valor_CMP,
	'Compra realizada com sucesso.' as Mensagem;
end try
begin catch
	if @@trancount > 0
	rollback transaction;
        throw;
end catch;
end;
go
--> Cancelar Venda <--
create procedure Proc_EstornarVDS
    @idvds int
as
begin
	set nocount on;
	set xact_abort on;

	declare
        @idfin int;

begin try
begin transaction;

        -- valida a venda
	if not exists (
	select 1 from Vendas
	where Id_VDS = @idvds )
        begin
            throw 50001, 'Venda não encontrada.', 1;
        end;

	--valida o lançamento financeiro
	if not exists (
	select 1 from Financeiro
	where Id_VDS = @idvds )
        begin
            throw 50002, 'Lançamento financeiro da venda não encontrado.', 1;
        end;

	--devolve as quantidades ao estoque
        update E
        set E.QTD_Est = E.QTD_Est + I.QTD_Item
        from Estoque E
        inner join Itens_Vendas I
        on I.Id_Est = E.Id_Est
        where I.Id_VDS = @idvds;

	--remove os itens da venda
        delete from Itens_Vendas
        where Id_VDS = @idvds;

	--reverte o lançamento financeiro
        delete from Financeiro
        where Id_VDS = @idvds;

	--remove a venda
        delete from Vendas
        where Id_VDS = @idvds;

	--finaliza
        commit transaction;

	--retorno
        select @idvds as Id_VDS,
	'Estorno realizado com sucesso.' as Mensagem;
end try
begin catch
	if @@trancount > 0
	rollback transaction;
        throw;
end catch;
end;
go
--> Entrada Estoque <--
create procedure Proc_EntradaEsto
    @idpro int,
    @idforne int,
    @quantidade int
as
begin
	set nocount on;
	set xact_abort on;

begin try
begin transaction;

	--valida produto
	if not exists (
	select 1 from Produtos
	where Id_Pro = @idpro )
        begin
            throw 50001, 'Produto não encontrado.', 1;
        end;

	--valida forne
	if not exists (
	select 1 from Fornecedores
	where Id_Forne = @idforne )
        begin
            throw 50002, 'Fornecedor não encontrado.', 1;
        end;

	--valida qntd
	if @quantidade <= 0
        begin
            throw 50003, 'A quantidade deve ser maior que zero.', 1;
        end;

	--atualiza o estoque
        update Estoque
        set QTD_Est = QTD_Est + @quantidade
        where Id_Pro = @idpro
        and Id_Forne = @idforne;

	--cria estoque caso nn exista
        if not exists (
	select 1 from Estoque
	where Id_Pro = @idpro
	and Id_Forne = @idforne )
        begin
            insert into Estoque
            (Id_Pro, Id_Forne, Est_Min, Est_Max, QTD_Est)
            values
            (@idpro, @idforne, 0, 0, @quantidade);
        end;

	--finaliza
        commit transaction;

	--retorno
        select @idpro as Id_Pro,
	@idforne as Id_Forne,
	@quantidade as QTD_Entrada,
	'Entrada de estoque realizada com sucesso.' as Mensagem;
end try
begin catch
	if @@trancount > 0
	rollback transaction;
        throw;
end catch;
end;
go
--> Saida Estoque <--
create procedure Proc_SaidaEsto
    @idpro int,
    @idforne int,
    @quantidade int
as
begin
	set nocount on;
	set xact_abort on;

begin try
begin transaction;

	--valida produto
	if not exists (
	select 1 from Produtos
	where Id_Pro = @idpro )
        begin
            throw 50001, 'Produto não encontrado.', 1;
        end;

	--valida forne
	if not exists (
	select 1 from Fornecedores
	where Id_Forne = @idforne )
        begin
            throw 50002, 'Fornecedor não encontrado.', 1;
        end;

        --valida qntd
	if @quantidade <= 0
        begin
            throw 50003, 'A quantidade deve ser maior que zero.', 1;
        end;

	--valida se o estoque existe
	if not exists (
	select 1 from Estoque
	where Id_Pro = @idpro
	and Id_Forne = @idforne )
        begin
            throw 50004, 'Registro de estoque não encontrado.', 1;
        end;

	--valida se há estoque o suficiente
	if not exists (
	select 1 from Estoque
	where Id_Pro = @idpro
	and Id_Forne = @idforne
	and QTD_Est >= @quantidade )
        begin
            throw 50005, 'Estoque insuficiente para realizar a saída.', 1;
        end;

	--realiza a saida do esto
        update Estoque
        set QTD_Est = QTD_Est - @quantidade
        where Id_Pro = @idpro
        and Id_Forne = @idforne;

        commit transaction;

        select @idpro as Id_Pro,
	@idforne as Id_Forne,
	@quantidade as QTD_Saida,
	'Saída de estoque realizada com sucesso.' as Mensagem;
end try
begin catch
	if @@trancount > 0
	rollback transaction;
        throw;
end catch;
end;
go
--> Produtos Estoque Baixo <--
create procedure Proc_ProEstoqBaixo
as
begin
	set nocount on;

	select P.Id_Pro, P.Nome_Pro, E.Id_Est, E.Id_Forne, E.QTD_Est, E.Est_Min, E.Est_Max
	from Estoque E
	inner join Produtos P
	on P.Id_Pro = E.Id_Pro
	where E.QTD_Est <= E.Est_Min
	order by E.QTD_Est asc;
end;
go
--> Vendas por Período <--
create procedure Proc_VendasPorPeriodo
    @dataini date,
    @datafin date
as
begin
	set nocount on;

	--verifica o intervalo entre as datas
	if @dataini > @datafin
        begin
            throw 50001, 'A data inicial não pode ser maior que a data final.', 1;
        end;

	--retorna vendas por periodo
        select V.Id_VDS, V.Id_Cli, C.Nome_Cli, V.Data_VDS, V.Valor_Total
	from Vendas V
	inner join Cliente C
	on C.Id_Cli = V.Id_Cli
	where V.Data_VDS between @dataini and @datafin
	order by V.Data_VDS asc;
end;
go
--> Compras por Período <--
create procedure Proc_ComprasPorPeriodo
    @dataini date,
    @datafin date
as
begin
	set nocount on;

	if @dataini > @datafin
        begin
            throw 50001, 'A data inicial não pode ser maior que a data final.', 1;
        end;

        select C.Id_CMP, C.Id_Forne, F.Nome_Forne, C.Data_CMP, C.Valor_CMP 
	from Compras C 
	inner join Fornecedores F 
	on F.Id_Forne = C.Id_Forne 
	where C.Data_CMP between @dataini and @datafin 
	order by C.Data_CMP asc;
end;
go
--> Faturamento por Período <--
create procedure Proc_FaturamentoPorPeriodo
    @dataini date,
    @datafin date
as
begin
	set nocount on;

	if @dataini > @datafin
        begin
            throw 50001, 'A data inicial não pode ser maior que a data final.', 1;
        end;

	--calcula faturamento do periodo

        select coalesce(sum(Valor_Total), 0) as Faturamento_Total from Vendas
	where Data_VDS between @dataini and @datafin;
end;
go