-- 2.1 fn_CalcularSubtotal
-- Function escalar: quantidade x preço unitário.

CREATE FUNCTION fn_CalcularSubtotal
(
    @Quantidade INT,
    @Preco      DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Quantidade * @Preco;
END;
GO
SELECT dbo.fn_CalcularSubtotal(5, 29.90);
GO

-- 2.2 fn_TotalVenda
-- Function escalar: soma dos subtotais dos itens de uma venda.

CREATE FUNCTION fn_TotalVenda
(
    @Id_VDS INT
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @Total DECIMAL(10,2);

    SELECT @Total = SUM(QTD_Item * Preco_Uni)
    FROM Itens_Vendas
    WHERE Id_VDS = @Id_VDS;

    RETURN ISNULL(@Total, 0);
END;
GO

SELECT dbo.fn_TotalVenda(3);
GO

-- 2.3 fn_EstoqueProduto
-- Function escalar: quantidade TOTAL em estoque de um produto,
-- somando todos os fornecedores que o abastecem 

CREATE FUNCTION fn_EstoqueProduto
(
    @Id_Pro INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Total INT;

    SELECT @Total = SUM(QTD_Est)
    FROM Estoque
    WHERE Id_Pro = @Id_Pro;

    RETURN ISNULL(@Total, 0);
END;
GO

SELECT dbo.fn_EstoqueProduto(10);
GO


-- 2.4 fn_StatusEstoque
-- Function escalar: classifica a situação do estoque com base na
-- quantidade atual, mínima e máxima informadas.

CREATE FUNCTION fn_StatusEstoque
(
    @QTD_Est INT,
    @Est_Min INT,
    @Est_Max INT
)
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @Status VARCHAR(20);

    IF @QTD_Est <= 0
        SET @Status = 'SEM ESTOQUE';
    ELSE IF @QTD_Est <= @Est_Min
        SET @Status = 'ESTOQUE BAIXO';
    ELSE IF @QTD_Est > @Est_Max
        SET @Status = 'ESTOQUE ALTO';
    ELSE
        SET @Status = 'NORMAL';

    RETURN @Status;
END;
GO

SELECT dbo.fn_StatusEstoque(3, 5, 20);  -> 'ESTOQUE BAIXO'
GO


-- 2.5 fn_ProdutosPorCategoria
-- Function table-valued (inline): retorna os produtos de uma
-- categoria, já com autor e editora.

CREATE FUNCTION fn_ProdutosPorCategoria
(
    @Id_Cat INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        P.Id_Pro,
        P.Nome_Pro,
        P.Preco_Pro,
        P.ISBN_Pro,
        A.Nome_Autor,
        E.Nome_Edi
    FROM Produtos P
    INNER JOIN Autores  A ON A.Id_Autor = P.Id_Autor
    INNER JOIN Editoras E ON E.Id_Edi   = P.Id_Edi
    WHERE P.Id_Cat = @Id_Cat
);
GO

SELECT * FROM dbo.fn_ProdutosPorCategoria(2);
GO


-- 2.6 fn_VendasPorPeriodo
-- Function table-valued (inline): retorna as vendas realizadas
-- dentro de um intervalo de datas, já com o nome do cliente.

CREATE FUNCTION fn_VendasPorPeriodo
(
    @DataInicial DATE,
    @DataFinal   DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        V.Id_VDS,
        V.Data_VDS,
        V.Valor_Total,
        C.Nome_Cli
    FROM Vendas V
    INNER JOIN Cliente C ON C.Id_Cli = V.Id_Cli
    WHERE V.Data_VDS BETWEEN @DataInicial AND @DataFinal
);
GO

SELECT * FROM dbo.fn_VendasPorPeriodo('2026-01-01', '2026-12-31');
GO
