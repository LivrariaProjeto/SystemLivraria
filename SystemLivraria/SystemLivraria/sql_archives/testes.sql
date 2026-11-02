SELECT * FROM Estoque;

BEGIN TRANSACTION;
UPDATE Estoque
SET Qtd_Est = Qtd_Est + 10
WHERE Id_Est = 3;

SELECT *
FROM Historico_Estoque
ORDER BY Id_Historico DESC;

--execute separado e troque o ID
BEGIN TRANSACTION;
EXEC dbo.Proc_RegistrarMovFinanceira @Id_Fin=123,@Valor_Mov=10.00,@Id_Usu=NULL,@Referencia_Mov='TESTE-123-1';
SELECT * FROM dbo.View_ContasFinanceiras WHERE Id_Fin=123;
SELECT * FROM dbo.View_FluxoCaixa WHERE Id_Fin=123;
SELECT * FROM dbo.Historico_Financeiro WHERE Id_Fin=123;
ROLLBACK TRANSACTION;
