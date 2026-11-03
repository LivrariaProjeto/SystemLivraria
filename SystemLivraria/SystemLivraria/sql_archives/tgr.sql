create trigger trg_AtualizarValorTotal
on Itens_Vendas
after insert, update, delete
as
begin
	set nocount on;

	update Vendas
	set Valor_Total = (
		select isnull(sum(iv.QTD_Item * iv.Preco_Uni), 0)
		from Itens_VDS iv
		where iv.Id_VDS = Vendas.Id_VDS
	)
	where Vendas.Id_VDS in (
		select Id_VDS from inserted
		union
		select Id_VDS from deleted
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

CREATE OR ALTER TRIGGER dbo.trg_HistoricoFinanceiro
ON dbo.Financeiro
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Historico_Financeiro
       (Id_Fin, Operacao, Valor_Anterior, Valor_Novo,
        Situacao_Anterior, Situacao_Nova, Categoria_Anterior, Categoria_Nova, Usuario_SQL)
    SELECT
        COALESCE(i.Id_Fin,d.Id_Fin),
        CASE WHEN d.Id_Fin IS NULL THEN 'INSERT'
             WHEN i.Id_Fin IS NULL THEN 'DELETE'
             ELSE 'UPDATE' END,
        d.Valor_VDS, i.Valor_VDS,
        d.Situacao_Fin, i.Situacao_Fin,
        d.Categoria_Fin, i.Categoria_Fin,
        ORIGINAL_LOGIN()
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.Id_Fin=d.Id_Fin
    WHERE i.Id_Fin IS NULL OR d.Id_Fin IS NULL
       OR EXISTS (
           SELECT i.Valor_VDS,i.Situacao_Fin,i.Categoria_Fin,i.Data_Quitacao,i.Data_Vencimento,i.Id_UsuFin,i.Tipo_VDS,i.Desc_VDS,i.Id_CMP,i.Id_VDS
           EXCEPT
           SELECT d.Valor_VDS,d.Situacao_Fin,d.Categoria_Fin,d.Data_Quitacao,d.Data_Vencimento,d.Id_UsuFin,d.Tipo_VDS,d.Desc_VDS,d.Id_CMP,d.Id_VDS
       );
END;
GO
