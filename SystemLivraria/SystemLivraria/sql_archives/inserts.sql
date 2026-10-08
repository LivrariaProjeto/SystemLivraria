select * from Estoque;

-- 10 gêneros literários
INSERT INTO Categorias (Nome_Cat, Desc_Cat) VALUES
('Romance',             'Obras de ficção centradas em relações humanas'),
('Drama',                'Obras que exploram conflitos emocionais e existenciais'),
('Terror',               'Obras que exploram medo, suspense e o sobrenatural'),
('Suspense',             'Obras construídas em torno de tensão e mistério'),
('Fantasia',             'Obras com elementos sobrenaturais ou mundos imaginários'),
('Ficção Científica',    'Obras especulativas baseadas em ciência e tecnologia'),
('Policial',             'Obras centradas em investigações e crimes'),
('Aventura',             'Obras com foco em jornadas e desafios físicos'),
('Comédia',              'Obras com tom humorístico'),
('Poesia',               'Obras em verso, com foco em linguagem e sentimento');

-- 5 áreas acadêmicas
INSERT INTO Categorias (Nome_Cat, Desc_Cat) VALUES
('História',             'Obras acadêmicas sobre eventos e processos históricos'),
('Filosofia',            'Obras acadêmicas sobre pensamento e teorias filosóficas'),
('Sociologia',           'Obras acadêmicas sobre estrutura e comportamento social'),
('Direito',              'Obras acadêmicas sobre legislação e ciências jurídicas'),
('Economia',             'Obras acadêmicas sobre teoria econômica e mercado');

INSERT INTO Editoras (Nome_Edi, Email_Edi, Site_Edi, Telefone_Edi) VALUES
('Editora Drama Real',          'contato@dramareal.com.br',        'www.dramareal.com.br',        '1130000011'),
('Editora Sombras',             'contato@sombraseditora.com.br',   'www.sombraseditora.com.br',   '1130000012'),
('Editora Enigma',              'contato@enigmaeditora.com.br',    'www.enigmaeditora.com.br',    '1130000013'),
('Editora Mundos Imaginários',  'contato@mundosimaginarios.com.br','www.mundosimaginarios.com.br','1130000014'),
('Editora Nova Ciência',        'contato@novaciencia.com.br',      'www.novaciencia.com.br',      '1130000015'),
('Editora Pista Fria',          'contato@pistafria.com.br',        'www.pistafria.com.br',        '1130000016'),
('Editora Horizonte',           'contato@horizonteeditora.com.br', 'www.horizonteeditora.com.br', '1130000017'),
('Editora Risos',               'contato@risoseditora.com.br',     'www.risoseditora.com.br',     '1130000018'),
('Editora Verso Livre',         'contato@versolivre.com.br',       'www.versolivre.com.br',       '1130000019'),
('Editora Memória Histórica',   'contato@memoriahistorica.com.br', 'www.memoriahistorica.com.br', '1130000020'),
('Editora Pensar',              'contato@pensareditora.com.br',    'www.pensareditora.com.br',    '1130000021'),
('Editora Sociedade',           'contato@sociedadeeditora.com.br', 'www.sociedadeeditora.com.br', '1130000022'),
('Editora Justiça',             'contato@justicaeditora.com.br',   'www.justicaeditora.com.br',   '1130000023'),
('Editora Mercado',             'contato@mercadoeditora.com.br',   'www.mercadoeditora.com.br',   '1130000024');

INSERT INTO Fornecedores 
(Nome_Forne, Endereco_Forne, CNPJ_Forne, Tel_Forne, Email_Forne)
VALUES
('Distribuidora Livro & Cia', 'Rua das Flores, 120 - Sorocaba/SP', '12.345.678/0001-01', '(15) 3222-1001', 'contato@livroecia.com.br'),
('Brasil Books Distribuidora', 'Av. Brasil, 450 - São Paulo/SP', '23.456.789/0001-02', '(11) 3333-2002', 'vendas@brasilbooks.com.br'),
('Acadêmica Livros e Distribuição', 'Rua das Universidades, 310 - São Paulo/SP', '43.567.890/0001-13', '(11) 3252-3333', 'contato@academicalivros.com.br');

--AUTORES
-- Romance
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Jane Austen', 'Reino Unido');
-- Drama
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Frances Hodgson Burnett', 'França');
-- Terror
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('H.P Lovecraft', 'Estados Unidos');
-- Suspense
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES (' Freida McFadden', 'Estados Unidos');
-- Fantasia
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('J.R.R. Tolkien', 'Reino Unido');
-- Ficção Científica
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('H.G. wells', 'Estados Unidos');
-- Policial
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Agatha Christie', 'Reino Unido');
-- Aventura
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Jules Verne', 'França');
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Lewis Carrol', 'Reino Unido');
-- Comédia
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Mark Twain', 'Estados Unidos');
-- Poesia
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Clarice Lispector', 'Brasil');
-- História
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Emma Marriott ', 'Reino Unido');
-- Filosofia
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Friedrich Nietzsche', 'Alemanha');
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Franz kafka', 'Rep. tcheca');
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Karl Marx', 'Alemanha');
-- Sociologia
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Émile Durkheim', 'França');
-- Direito
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Miguel Reale', 'Brasil');
-- Economia
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Adam Smith', 'Reino Unido');

INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('J. K. Rowling', 'Reino Unido');
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('Holly Black', 'Estados Unidos');
GO

--LIVROS
INSERT INTO Produtos (Id_Autor, Id_Cat, Id_Edi, Nome_Pro, Preco_Pro, ISBN_Pro) VALUES 
-- 1. Jane Austen
(2, 1, 5, 'Orgulho e Preconceito', 49.90, '9788525434149'),
-- 2. Frances Hodgson Burnett
(3, 2, 5, 'O Jardim Secreto', 39.90, '9788574066912'),
-- 3. H.P. Lovecraft
(4, 3, 3, 'O Chamado de Cthulhu', 59.90, '9788594540773'),
-- 4. Freida McFadden
(5, 4, 6, 'A Empregada', 44.90, '9788556511451'),
-- 5. J.R.R. Tolkien
(6, 5, 5, 'O Senhor dos Anéis: A Sociedade do Anel', 79.90, '9788595084759'),
-- 6. H.G. Wells
(7, 6, 2, 'A Máquina do Tempo', 34.90, '9788537814895'),
-- 7. Agatha Christie
(8, 7, 5, 'E Não Sobrou Nenhum', 49.90, '9788555341238'),
-- 8. Jules Verne
(9, 8, 7, 'Viagem ao Centro da Terra', 29.90, '9788525422894'),
-- 9. Lewis Carroll
(10, 2, 2, 'Alice no País das Maravilhas', 39.90, '9786558170012'),
-- 10. Mark Twain
(11, 8, 7, 'As Aventuras de Tom Sawyer', 32.90, '9788525411232'),
-- 11. Clarice Lispector
(12, 9, 8, 'A Hora da Estrela', 42.90, '9788535931228'),
-- 12. Emma Marriott
(13, 10, 4, 'A História do Mundo para Quem Tem Pressa', 49.90, '9788501108258'),
-- 13. Friedrich Nietzsche
(14, 11, 2, 'Ecce Homo', 54.90, '9788537813256'),
-- 14. Franz Kafka
(15, 1, 2, 'A Metamorfose', 39.90, '9786580309141'),
-- 15. Karl Marx
(16, 12, 2, 'O Manifesto Comunista', 29.90, '9788537803622'),
-- 16. Émile Durkheim
(17, 13, 4, 'As Formas Elementares da Vida Religiosa', 69.90, '9788535231427'),
-- 17. Miguel Reale
(18, 11, 4, 'Filosofia do Direito', 119.90, '9788502154825'),
-- 18. Adam Smith
(19, 12, 2, 'A Riqueza das Nações', 89.90, '9788537817452'),
-- 19. J.K. Rowling
(20, 5, 4, 'Harry Potter e a Pedra Filosofal', 45.42, '9788532511010'),
-- 20. Holly Black
(21, 5, 4, 'O Principe Cruel', 89.90, '9788501115553');

--ESTOQUE
ALTER TABLE Estoque
ADD Nome_Pro VARCHAR(255);
GO
INSERT INTO Estoque
(Id_Pro, Nome_Pro, Id_Forne, Est_Min, Est_Max, QTD_Est)
VALUES
-- LIVROS: PRODUTOS 46 a 63
(1, 'Orgulho e Preconceito', 12, 5, 30, 18),
(2, 'O Jardim Secreto', 12, 5, 30, 21),
(3, 'O Chamado de Cthulhu', 12, 5, 25, 12),
(4, 'A Empregada', 12, 5, 25, 15),
(5, 'O Senhor dos Anéis: A Sociedade do Anel', 12, 10, 50, 32),
(6, 'A Máquina do Tempo', 12, 5, 30, 17),
(7, 'E Não Sobrou Nenhum', 12, 5, 30, 19),
(8, 'Viagem ao Centro da Terra', 12, 5, 25, 14),
(9, 'Alice no País das Maravilhas', 12, 5, 25, 13),
(10, 'As Aventuras de Tom Sawyer', 12, 5, 30, 16),
(11, 'A Hora da Estrela', 12, 5, 25, 11),
(12, 'A História do Mundo para Quem Tem Pressa', 12, 5, 25, 14),
(13, 'Ecce Homo', 12, 5, 25, 10),
(14, 'A Metamorfose', 12, 5, 30, 18),
(15, 'O Manifesto Comunista', 12, 5, 30, 20),
(16, 'As Formas Elementares da Vida Religiosa', 12, 5, 20, 9),
(17, 'Filosofia do Direito', 12, 5, 20, 8),
(18, 'A Riqueza das Nações', 12, 5, 20, 11),
(19, 5, 4, 'Harry Potter e a Pedra Filosofal', 45.42, '9788532511010'),
(20, 5, 4, 'O Principe Cruel', 89.90, '9788501115553');

GO
