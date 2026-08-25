-- =====================================================================
-- TABELAS SEM DEPENDÊNCIAS (entidades "raiz")
-- =====================================================================

CREATE TABLE Editoras (
    Id_Edi              INT IDENTITY(1,1) PRIMARY KEY,
    Nome_Edi            VARCHAR(100) NOT NULL,
    Email_Edi           VARCHAR(100) NULL,
    Site_Edi            VARCHAR(150) NULL,
    Telefone_Edi        VARCHAR(20)  NULL
);
GO

CREATE TABLE Autores (
    Id_Autor            INT IDENTITY(1,1) PRIMARY KEY,
    Nome_Autor          VARCHAR(100) NOT NULL,
    Pais_Autor          VARCHAR(50)  NULL
);
GO

CREATE TABLE Categorias (
    Id_Cat      INT IDENTITY(1,1) PRIMARY KEY,
    Nome_Cat    VARCHAR(50)  NOT NULL,
    Desc_Cat    VARCHAR(255) NULL
);
GO

CREATE TABLE Funcionarios (
    Id_Funci            INT IDENTITY(1,1) PRIMARY KEY,
    Nome_Funci          VARCHAR(100) NOT NULL,
    CPF_Funci           VARCHAR(14)  NOT NULL UNIQUE,
    Cargo_Funci         VARCHAR(50)  NULL,
    Tel_Funci           VARCHAR(20)  NULL,
    DataAdmissao_Funci  DATE         NULL,
    Email_Funci         VARCHAR(100) NULL
);
GO

CREATE TABLE Permissoes (
    Id_Permi        INT IDENTITY(1,1) PRIMARY KEY,
    Nome_Permi      VARCHAR(50)  NOT NULL,
    Descricao_Permi VARCHAR(255) NULL
);
GO

CREATE TABLE Cliente (
    Id_Cli        INT IDENTITY(1,1) PRIMARY KEY,
    Nome_Cli      VARCHAR(100) NOT NULL,
    Tel_Cli       VARCHAR(20)  NULL,
    CPF_Cli       VARCHAR(14)  NOT NULL UNIQUE,
    Email_Cli     VARCHAR(100) NULL,
    Endereco_Cli  VARCHAR(200) NULL
);
GO

CREATE TABLE Fornecedores (
    Id_Forne        INT IDENTITY(1,1) PRIMARY KEY,
    Nome_Forne      VARCHAR(100) NOT NULL,
    Endereco_Forne  VARCHAR(200) NULL,
    CNPJ_Forne      VARCHAR(18)  NOT NULL UNIQUE,
    Tel_Forne       VARCHAR(20)  NULL,
    Email_Forne     VARCHAR(100) NULL
);
GO

-- =====================================================================
-- TABELAS DEPENDENTES DE 1º NÍVEL
-- =====================================================================

-- Usuarios: 1 Funcionario -> 1 Usuario ; 1 Permissao -> N Usuarios
CREATE TABLE Usuarios (
    Id_Usu     INT IDENTITY(1,1) PRIMARY KEY,
    Id_Funci INT NOT NULL UNIQUE,   -- UNIQUE garante o relacionamento (1,1)
    Id_Permi    INT NOT NULL,
    Login_usu           VARCHAR(50)  NOT NULL UNIQUE,
    Senha_usu           VARCHAR(255) NOT NULL,
    Ativo_usu           BIT NOT NULL DEFAULT 1,
    Perfil_usu          VARCHAR(50)  NULL,
    CONSTRAINT FK_Usuarios_Funcionarios FOREIGN KEY (Id_Funci) REFERENCES Funcionarios(Id_Funci),
    CONSTRAINT FK_Usuarios_Permissoes   FOREIGN KEY (Id_Permi)    REFERENCES Permissoes(Id_Permi)
);
GO

-- Produtos: N:1 com Autores, Categorias e Editoras
CREATE TABLE Produtos (
    Id_Pro        INT IDENTITY(1,1) PRIMARY KEY,
    Id_Autor      INT NOT NULL,
    Id_Cat        INT NOT NULL,
    Id_Edi        INT NOT NULL,
    Nome_Pro      VARCHAR(150) NOT NULL,
    Preco_Pro     DECIMAL(10,2) NOT NULL,
    ISBN_Pro      VARCHAR(20) NULL UNIQUE,
    CONSTRAINT FK_Produtos_Autores     FOREIGN KEY (Id_Autor)     REFERENCES Autores(Id_Autor),
    CONSTRAINT FK_Produtos_Cat  FOREIGN KEY (Id_Cat) REFERENCES Categorias(Id_Cat),
    CONSTRAINT FK_Produtos_Edi    FOREIGN KEY (Id_Edi)   REFERENCES Editoras(Id_Edi)
);
GO

-- Compras: N:1 com Fornecedores
CREATE TABLE Compras (
    Id_CMP      INT IDENTITY(1,1) PRIMARY KEY,
    Id_Forne    INT NOT NULL,
    Valor_CMP   DECIMAL(10,2) NOT NULL,
    Data_CMP    DATE NOT NULL,
    CONSTRAINT FK_Compras_Forne FOREIGN KEY (Id_Forne) REFERENCES Fornecedores(Id_Forne)
);
GO

-- Vendas: N:1 com Clientes
CREATE TABLE Vendas (
    Id_VDS        INT IDENTITY(1,1) PRIMARY KEY,
    Id_Cli        INT NOT NULL,
    Data_VDS      DATE NOT NULL,
    Valor_Total   DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_Vendas_Clientes FOREIGN KEY (Id_Cli) REFERENCES Cliente(Id_Cli)
);
GO

-- =====================================================================
-- TABELAS DEPENDENTES DE 2º NÍVEL
-- =====================================================================

-- Estoque: N:1 com Produtos e Fornecedores
CREATE TABLE Estoque (
    Id_Est          INT IDENTITY(1,1) PRIMARY KEY,
    Id_Pro          INT NOT NULL,
    Id_Forne        INT NOT NULL,
    Est_Min         INT NOT NULL DEFAULT 0,
    Est_Max         INT NOT NULL DEFAULT 0,
    QTD_Est         INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Estoque_Produtos     FOREIGN KEY (Id_Pro)    REFERENCES Produtos(Id_Pro),
    CONSTRAINT FK_Estoque_Fornecedores FOREIGN KEY (Id_Forne) REFERENCES Fornecedores(Id_Forne)
);
GO

-- Itens_Vendas: itens de cada venda (N:1 com Vendas e Produtos)
CREATE TABLE Itens_Vendas (
    Id_Item_VDS   INT IDENTITY(1,1) PRIMARY KEY,
    Id_VDS        INT NOT NULL,
    Id_Pro        INT NOT NULL,
    QTD_Item      INT NOT NULL,
    Preco_Uni     DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_ItensVendas_Vendas   FOREIGN KEY (Id_VDS)   REFERENCES Vendas(Id_VDS),
    CONSTRAINT FK_ItensVendas_Produtos FOREIGN KEY (Id_Pro) REFERENCES Produtos(Id_Pro)
);
GO

-- Itens_CMP: itens de cada compra (N:1 com Compras e Produtos)
CREATE TABLE Itens_CMP (
    Id_Item         INT IDENTITY(1,1) PRIMARY KEY,
    Id_CMP          INT NOT NULL,
    Id_Pro          INT NOT NULL,
    QTD_Item        INT NOT NULL,
    Preco_Unitario  DECIMAL(10,2) NOT NULL,
    Subtotal        DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_ItensCMP_Compras  FOREIGN KEY (Id_CMP)   REFERENCES Compras(Id_CMP),
    CONSTRAINT FK_ItensCMP_Produtos FOREIGN KEY (Id_PrO) REFERENCES Produtos(Id_Pro)
);
GO

-- Financeiro: registra Entradas (ligadas a Vendas) e Saídas (ligadas a Compras)
CREATE TABLE Financeiro (
    Id_Fin      INT IDENTITY(1,1) PRIMARY KEY,
    Id_CMP      INT NULL,
    Id_VDS      INT NULL,
    Tipo_VDS    VARCHAR(20)  NOT NULL, -- 'Entrada' ou 'Saida'
    Desc_VDS    VARCHAR(255) NULL,
    Valor_VDS   DECIMAL(10,2) NOT NULL,
    Data_VDS    DATE NOT NULL,
    CONSTRAINT FK_Financeiro_Compras FOREIGN KEY (Id_CMP) REFERENCES Compras(Id_CMP),
    CONSTRAINT FK_Financeiro_Vendas  FOREIGN KEY (Id_VDS)  REFERENCES Vendas(Id_VDS),
    -- garante que o registro seja OU uma entrada (venda) OU uma saída (compra), nunca os dois nem nenhum
    CONSTRAINT CK_Financeiro_Origem CHECK (
        (Id_CMP IS NOT NULL AND Id_VDS IS NULL) OR
        (Id_CMP IS NULL AND Id_VDS IS NOT NULL)
    )
);
GO