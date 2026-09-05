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

create view View_ProMaisVendidos as
select
    P.Id_Pro,
    P.Nome_Pro,
    sum(IV.QTD_Item) as QTD_TotalVendida
from Itens_Vendas IV
inner join Produtos P
on IV.Id_Pro = P.Id_Pro
group by P.Id_Pro, P.Nome_Pro;
