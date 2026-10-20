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

CREATE TRIGGER trg_HistoricoEstoque
ON Estoque
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Historico_Estoque (
        Id_Est,
        Id_Pro,
        Tipo_Operacao,
        Qtd_Anterior,
        Qtd_Nova
    )
    SELECT
        i.Id_Est,
        i.Id_Pro,
        'UPDATE',
        d.QTD_Est,
        i.QTD_Est
    FROM inserted i
    INNER JOIN deleted d
        ON i.Id_Est = d.Id_Est
    WHERE i.QTD_Est <> d.QTD_Est;
END;
go
