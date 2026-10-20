SELECT * FROM Estoque;

BEGIN TRANSACTION;
UPDATE Estoque
SET Qtd_Est = Qtd_Est + 10
WHERE Id_Est = 3;

SELECT *
FROM Historico_Estoque
ORDER BY Id_Historico DESC;
