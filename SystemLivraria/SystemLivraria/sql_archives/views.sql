create view View_Produtos as
select
	P.Id_Pro,
    A.Id_Autor,
    C.Id_Cat,
    E.Id_Edi,
    P.Nome_Pro,
    P.Preco_Pro,
    P.ISBN_Pro,
    A.Nome_Autor,
    A.Pais_Autor,
    E.Nome_Edi,
    E.Email_Edi,
    E.Site_Edi,
    E.Telefone_Edi,
    C.Nome_Cat,
    C.Desc_Cat
from Produtos P
inner join Autores A
on P.Id_Autor = A.Id_Autor
inner join Categorias C
on P.Id_Cat = C.Id_Cat
inner join Editoras E
on P.Id_Edi = E.Id_Edi;
go
	
create view View_Estoque as
select
    P.Id_Pro,
    P.Nome_Pro,
    F.Id_Forne,
    F.Nome_Forne,
    E.Est_Min,
    E.Est_Max,
    E.QTD_Est,
case
    when E.QTD_Est = 0 then 'Sem Estoque'
    when E.QTD_Est <= E.Est_Min then 'Estoque Baixo'
    when E.QTD_Est > E.Est_Max then 'Estoque Alto'
    else 'Normal'
    end as Status_Est
from Estoque E
inner join Produtos P
on E.Id_Pro = P.Id_Pro
inner join Fornecedores F
on E.Id_Forne = F.Id_Forne;
go
	
create view View_VDSdetalhadas as
select
    V.Id_VDS,
    V.Data_VDS,
    C.Id_Cli,
    C.Nome_Cli,
    P.Id_Pro,
    P.Nome_Pro,
    IV.QTD_Item, 
    IV.Preco_Uni, 
    (IV.QTD_Item * IV.Preco_Uni) AS Subtotal
from Vendas V
inner join Cliente C
on V.Id_Cli = C.Id_Cli
inner join Itens_Vendas IV
on V.Id_VDS = IV.Id_VDS
inner join Produtos P
on IV.Id_Pro = P.Id_Pro;
go
	
create view View_CMPdetalhadas as
select
    C.Id_CMP,
    C.Data_CMP,
    F.Id_Forne,
    F.Nome_Forne,
    P.Id_Pro,
    P.Nome_Pro,
    IC.QTD_Item,
    IC.Preco_Unitario,
    (IC.QTD_Item * IC.Preco_Unitario) AS Subtotal
from Compras C
inner join Fornecedores F
on C.Id_Forne = F.Id_Forne
inner join Itens_CMP IC
on C.Id_CMP = IC.Id_CMP
inner join Produtos P
on IC.Id_Pro = P.Id_Pro;
go

create view View_Financeiro as
select
    F.Id_Fin,
    F.Data_VDS,
    F.Tipo_VDS,
    F.Desc_VDS,
    F.Valor_VDS,
case
    when F.Id_CMP is not null then 'Compra'
    when F.Id_VDS is not null then 'Venda'
    else 'Outra'
    end as Origem
from Financeiro F
left join Compras C
on F.Id_CMP = C.Id_CMP
left join Vendas V
on F.Id_VDS = V.Id_VDS;
go
	
create view View_UsuPermissoes as
select
    F.Nome_Funci,
    F.CPF_Funci,
    U.Login_usu,
    U.Perfil_usu,
    P.Nome_Permi,
case
    when U.Ativo_usu = 1 then 'Ativo'
    else 'Inativo'
    end as Situacao
from Funcionarios F
inner join Usuarios U
on F.Id_Funci = U.Id_Funci
inner join Permissoes P
on U.Id_Permi = P.Id_Permi;
go
	
create view View_VendasPorCli as
select
    C.Id_Cli,
    C.Nome_Cli,
    COUNT(V.Id_VDS) AS Quantidade_Vendas,
    SUM(V.Valor_Total) AS Valor_Total_Gasto
from Cliente C
inner join Vendas V
on C.Id_Cli = V.Id_Cli
group by C.Id_Cli, C.Nome_Cli;
go
	
create view View_ProMaisVendidos as
select
    P.Id_Pro,
    P.Nome_Pro,
    sum(IV.QTD_Item) as QTD_TotalVendida
from Itens_Vendas IV
inner join Produtos P
on IV.Id_Pro = P.Id_Pro
group by P.Id_Pro, P.Nome_Pro;
go
	
CREATE OR ALTER VIEW dbo.View_ContasFinanceiras AS
SELECT
    f.Id_Fin, f.Id_VDS, f.Id_CMP,
    COALESCE(f.Categoria_Fin, CASE WHEN f.Id_VDS IS NOT NULL THEN 'Venda'
                                  WHEN f.Id_CMP IS NOT NULL THEN 'Compra'
                                  ELSE 'Outros' END) AS Categoria,
    f.Tipo_VDS, f.Desc_VDS, f.Valor_VDS AS Valor_Original,
    COALESCE(p.Valor_Pago,0) AS Valor_Realizado,
    f.Valor_VDS-COALESCE(p.Valor_Pago,0) AS Saldo_Pendente,
    f.Situacao_Fin, f.Data_VDS, f.Data_Vencimento, f.Data_Quitacao, f.Id_UsuFin
FROM dbo.Financeiro f
OUTER APPLY (
    SELECT SUM(CONVERT(DECIMAL(19,2),m.Valor_Mov)) AS Valor_Pago
    FROM dbo.Movimentacoes_Financeiro m WHERE m.Id_Fin=f.Id_Fin
) p;
GO

CREATE OR ALTER VIEW dbo.View_FluxoCaixa AS
SELECT m.Id_Mov,m.Id_Fin,m.Data_Mov,
       CASE WHEN UPPER(LTRIM(RTRIM(f.Tipo_VDS))) IN ('RECEITA','ENTRADA')
                 THEN 'Entrada' ELSE 'Saida' END AS Tipo_Movimento,
       m.Valor_Mov,
       CASE WHEN UPPER(LTRIM(RTRIM(f.Tipo_VDS))) IN ('RECEITA','ENTRADA')
                 THEN m.Valor_Mov ELSE -m.Valor_Mov END AS Valor_Assinado,
       m.Id_Usu
FROM dbo.Movimentacoes_Financeiro m
JOIN dbo.Financeiro f ON f.Id_Fin=m.Id_Fin;
GO

CREATE VIEW vw_Historico_Estoque AS
SELECT
    Id_Historico,
    Id_Est,
    Id_Pro,
    Tipo_Operacao,
    Qtd_Anterior,
    Qtd_Nova,
    Data_Alteracao
FROM Historico_Estoque;
GO
