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

INSERT INTO Categorias (Nome_Cat, Desc_Cat) VALUES
('Material Escolar','Materiais escolares variados');

INSERT INTO Editoras (Nome_Edi, Email_Edi, Site_Edi, Telefone_Edi) VALUES
('materiais escolares',      'materiais escolares',    'materiais escolares',    '0000000000'),

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
('Mundo dos Livros', 'Rua Central, 85 - Campinas/SP', '34.567.890/0001-03', '(19) 3444-3003', 'contato@mundodoslivros.com.br'),
('Distribuidora Saber', 'Av. da Educação, 710 - Jundiaí/SP', '45.678.901/0001-04', '(11) 3555-4004', 'atendimento@distribuidorasaber.com.br'),
('Book Center Distribuidora', 'Rua dos Escritores, 230 - Itu/SP', '56.789.012/0001-05', '(11) 3666-5005', 'comercial@bookcenter.com.br'),
('Nova Página Livros', 'Av. Literária, 560 - São Roque/SP', '67.890.123/0001-06', '(11) 3777-6006', 'contato@novapagina.com.br'),
('Universo Literário', 'Rua Machado de Assis, 340 - São Paulo/SP', '78.901.234/0001-07', '(11) 3888-7007', 'vendas@universoliterario.com.br'),
('Central dos Livros', 'Rua da Leitura, 175 - Votorantim/SP', '89.012.345/0001-08', '(15) 3999-8008', 'central@centraldoslivros.com.br'),
('Distribuidora Estante', 'Av. dos Autores, 920 - Sorocaba/SP', '90.123.456/0001-09', '(15) 3111-9009', 'contato@distribuidoraestante.com.br'),
('Ponto do Livro Distribuidora', 'Rua das Letras, 415 - Campinas/SP', '10.234.567/0001-10', '(19) 3222-1010', 'vendas@pontodolivro.com.br'),
('Papelaria Escolar Brasil', 'Rua das Acácias, 180 - Sorocaba/SP', '21.345.678/0001-11', '(15) 3232-1111', 'contato@papelariaescolarbrasil.com.br'),
('Mundo Escolar Distribuidora', 'Av. das Escolas, 520 - Votorantim/SP', '32.456.789/0001-12', '(15) 3242-2222', 'vendas@mundoescolar.com.br'),
('Acadêmica Livros e Distribuição', 'Rua das Universidades, 310 - São Paulo/SP', '43.567.890/0001-13', '(11) 3252-3333', 'contato@academicalivros.com.br');

--AUTORES
INSERT INTO Autores (Nome_Autor, Pais_Autor) VALUES ('mat escolar', 'mat escolar');
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


--MATERIAL ESCOLAR
INSERT INTO Produtos
(Nome_Pro, Id_Autor, Id_Cat, Id_Edi, Preco_Pro, ISBN_Pro)
VALUES
('Caderno Universitário 10 Matérias', 1, 1, 1, 34.90, '101'),
('Caderno Universitário 1 Matéria', 1, 1, 1, 14.90, '102'),
('Caderno Inteligente Médio', 1, 1, 1, 89.90, '103'),
('Agenda Escolar 2027', 1, 1, 1, 29.90, '104'),

('Caneta Esferográfica Azul', 1, 1, 1, 3.50, '105'),
('Caneta Esferográfica Preta', 1, 1, 1, 3.50, '106'),
('Caneta Esferográfica Vermelha', 1, 1, 1, 3.50, '107'),
('Caneta Gel Preta 0.5mm', 1, 1, 1, 7.90, '108'),
('Kit Canetas Coloridas 12 Cores', 1, 1, 1, 24.90, '109'),

('Marca-Texto Amarelo', 1, 1, 1, 6.90, '110'),
('Marca-Texto Rosa', 1, 1, 1, 6.90, '111'),
('Kit Marca-Texto Pastel 6 Cores', 1, 1, 1, 29.90, '112'),

('Lápis Preto HB', 1, 1, 1, 2.50, '113'),
('Lapiseira 0.5mm', 1, 1, 1, 12.90, '114'),
('Grafite 0.5mm HB', 1, 1, 1, 5.90, '115'),
('Borracha Branca', 1, 1, 1, 3.90, '116'),
('Apontador com Depósito', 1, 1, 1, 6.50, '117'),

('Estojo Escolar Grande', 1, 1, 1, 39.90, '118'),
('Estojo Escolar Simples', 1, 1, 1, 19.90, '119'),
('Mochila Escolar', 1, 1, 1, 119.90, '120'),

('Régua 30cm', 1, 1, 1, 4.90, '121'),
('Transferidor 180 Graus', 1, 1, 1, 6.90, '122'),
('Compasso Escolar', 1, 1, 1, 14.90, '123'),
('Kit Geométrico Escolar', 1, 1, 1, 19.90, '124'),

('Cola Bastão 20g', 1, 1, 1, 7.90, '125'),
('Cola Branca 90g', 1, 1, 1, 6.90, '126'),
('Tesoura Escolar sem Ponta', 1, 1, 1, 9.90, '127'),

('Bloco de Notas Adesivas', 1, 1, 1, 9.90, '128'),
('Post-it Colorido 5 Blocos', 1, 1, 1, 19.90, '129'),
('Fichário Universitário', 1, 1, 1, 49.90, '130'),
('Pasta Catálogo 50 Plásticos', 1, 1, 1, 28.90, '131'),
('Pasta Sanfonada A4', 1, 1, 1, 24.90, '132'),

('Papel Sulfite A4 500 Folhas', 1, 1, 1, 32.90, '133'),
('Papel Colorido A4 100 Folhas', 1, 1, 1, 18.90, '134'),
('Cartolina Branca', 1, 1, 1, 2.50, '135'),
('Cartolina Colorida', 1, 1, 1, 2.90, '136'),

('Kit Washi Tape 10 Unidades', 1, 1, 1, 24.90, '137'),
('Cartela de Adesivos Decorativos', 1, 1, 1, 8.90, '138'),
('Planner Semanal', 1, 1, 1, 24.90, '139'),
('Planner Mensal', 1, 1, 1, 29.90, '140'),
('Kit Sticky Notes Pastel', 1, 1, 1, 14.90, '141'),
('Caderno Pontilhado para Bullet Journal', 1, 1, 1, 39.90, '142'),
('Kit Canetas Brush 12 Cores', 1, 1, 1, 49.90, '143'),
('Mini Grampeador', 1, 1, 1, 14.90, '144'),
('Clips Coloridos Caixa com 100', 1, 1, 1, 9.90, '145');

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
-- PRODUTOS 1 a 8
(1, 'Caderno Universitário 10 Matérias', 11, 10, 50, 32),
(2, 'Caderno Universitário 1 Matéria', 11, 10, 50, 28),
(3, 'Caderno Inteligente Médio', 11, 5, 25, 14),
(4, 'Agenda Escolar 2027', 11, 5, 30, 18),
(5, 'Caneta Esferográfica Azul', 12, 20, 100, 65),
(6, 'Caneta Esferográfica Preta', 12, 20, 100, 70),
(7, 'Caneta Esferográfica Vermelha', 12, 20, 100, 55),
(8, 'Caneta Gel Preta 0.5mm', 12, 10, 50, 27),

-- PRODUTOS 9 a 17
(9, 'Kit Canetas Coloridas 12 Cores', 12, 8, 40, 22),
(10, 'Marca-Texto Amarelo', 12, 10, 60, 34),
(11, 'Marca-Texto Rosa', 12, 10, 60, 31),
(12, 'Kit Marca-Texto Pastel 6 Cores', 12, 8, 40, 19),
(13, 'Lápis Preto HB', 12, 20, 120, 80),
(14, 'Lapiseira 0.5mm', 12, 10, 50, 29),
(15, 'Grafite 0.5mm HB', 12, 10, 50, 26),
(16, 'Borracha Branca', 11, 15, 70, 43),
(17, 'Apontador com Depósito', 11, 10, 50, 25),

-- PRODUTOS 18 a 24
(18, 'Estojo Escolar Grande', 11, 5, 30, 16),
(19, 'Estojo Escolar Simples', 11, 5, 30, 21),
(20, 'Mochila Escolar', 11, 3, 20, 9),
(21, 'Régua 30cm', 12, 10, 50, 33),
(22, 'Transferidor 180 Graus', 12, 8, 40, 24),
(23, 'Compasso Escolar', 11, 5, 25, 13),
(24, 'Kit Geométrico Escolar', 11, 5, 25, 15),

-- PRODUTOS 25 a 32
(25, 'Cola Bastão 20g', 11, 10, 50, 30),
(26, 'Cola Branca 90g', 11, 10, 50, 37),
(27, 'Tesoura Escolar sem Ponta', 11, 8, 35, 17),
(28, 'Bloco de Notas Adesivas', 11, 10, 50, 26),
(29, 'Post-it Colorido 5 Blocos', 11, 10, 60, 39),
(30, 'Fichário Universitário', 11, 5, 30, 18),
(31, 'Pasta Catálogo 50 Plásticos', 11, 5, 25, 12),
(32, 'Pasta Sanfonada A4', 11, 5, 25, 14),

-- PRODUTOS 33 a 40
(33, 'Papel Sulfite A4 500 Folhas', 12, 10, 50, 23),
(34, 'Papel Colorido A4 100 Folhas', 12, 10, 50, 29),
(35, 'Cartolina Branca', 12, 10, 60, 35),
(36, 'Cartolina Colorida', 12, 10, 60, 41),
(37, 'Kit Washi Tape 10 Unidades', 11, 5, 25, 11),
(38, 'Cartela de Adesivos Decorativos', 11, 10, 50, 24),
(39, 'Planner Semanal', 11, 5, 30, 16),
(40, 'Planner Mensal', 11, 5, 30, 18),

-- PRODUTOS 41 a 45
(41, 'Kit Sticky Notes Pastel', 11, 8, 40, 22),
(42, 'Caderno Pontilhado para Bullet Journal', 11, 5, 25, 13),
(43, 'Kit Canetas Brush 12 Cores', 11, 5, 25, 10),
(44, 'Mini Grampeador', 11, 8, 35, 21),
(45, 'Clips Coloridos Caixa com 100', 11, 10, 60, 38),

-- LIVROS: PRODUTOS 46 a 63
(46, 'Orgulho e Preconceito', 12, 5, 30, 18),
(47, 'O Jardim Secreto', 12, 5, 30, 21),
(48, 'O Chamado de Cthulhu', 12, 5, 25, 12),
(49, 'A Empregada', 12, 5, 25, 15),
(50, 'O Senhor dos Anéis: A Sociedade do Anel', 12, 10, 50, 32),
(51, 'A Máquina do Tempo', 12, 5, 30, 17),
(52, 'E Não Sobrou Nenhum', 12, 5, 30, 19),
(53, 'Viagem ao Centro da Terra', 12, 5, 25, 14),
(54, 'Alice no País das Maravilhas', 12, 5, 25, 13),
(55, 'As Aventuras de Tom Sawyer', 12, 5, 30, 16),
(56, 'A Hora da Estrela', 12, 5, 25, 11),
(57, 'A História do Mundo para Quem Tem Pressa', 12, 5, 25, 14),
(58, 'Ecce Homo', 12, 5, 25, 10),
(59, 'A Metamorfose', 12, 5, 30, 18),
(60, 'O Manifesto Comunista', 12, 5, 30, 20),
(61, 'As Formas Elementares da Vida Religiosa', 12, 5, 20, 9),
(62, 'Filosofia do Direito', 12, 5, 20, 8),
(63, 'A Riqueza das Nações', 12, 5, 20, 11);

GO
