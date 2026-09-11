create trigger trg_AtualizarValorTotal
on Itens_Vendas
after insert, update, delete
as
begin
	set nocount on;

	update Vendas
	set Valor_Total = (
		select isnull(sum(iv.QTD_Item * iv.Preco_Unitario), 0)
		from Itens_Vendas iv
		where iv.Id_Vendas = Vendas.Id_Vendas
	)
	where Vendas.Id_Vendas in (
		select Id_Vendas from inserted
		union
		select Id_Vendas from deleted
	);
end;
go