-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 01/05/2025 às 19:59
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dbosemeador`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbemprestimo`
--

CREATE TABLE `tbemprestimo` (
  `codEmp` int(11) NOT NULL,
  `dataEmp` datetime DEFAULT NULL,
  `dataDev` date DEFAULT NULL,
  `nomeVendedor` varchar(100) DEFAULT NULL,
  `nomeLivro` varchar(100) DEFAULT NULL,
  `prontuario` int(11) DEFAULT NULL,
  `codLivro` int(11) NOT NULL,
  `codLoc` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbestoque`
--

CREATE TABLE `tbestoque` (
  `codEsto` int(11) NOT NULL,
  `entradaVen` int(11) DEFAULT 0 CHECK (`entradaVen` >= 0),
  `saidaVen` int(11) DEFAULT 0 CHECK (`saidaVen` >= 0),
  `entradaEmp` int(11) DEFAULT 0 CHECK (`entradaEmp` >= 0),
  `saidaEmp` int(11) DEFAULT 0 CHECK (`saidaEmp` >= 0),
  `empVen` char(3) NOT NULL CHECK (`empVen` in ('Emp','Ven')),
  `nomeLivro` varchar(100) DEFAULT NULL,
  `codLivro` int(11) NOT NULL,
  `disponibilidade` char(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tbestoque`
--

INSERT INTO `tbestoque` (`codEsto`, `entradaVen`, `saidaVen`, `entradaEmp`, `saidaEmp`, `empVen`, `nomeLivro`, `codLivro`, `disponibilidade`) VALUES
(1, 5, 0, 0, 0, 'Ven', 'Outro lar- uma viagem muitos ensinamentos-Turma da Monica', 1, NULL),
(2, 5, 0, 0, 0, 'Ven', 'Magali em Outras Vidas -Turma da Monica ', 2, NULL),
(3, 4, 0, 0, 0, 'Ven', 'Chico bento Além Da Vida -Turma De Monica ', 3, NULL),
(4, 5, 0, 0, 0, 'Ven', 'Turma Da Monica Jovem Conhece Violetas na Janela ', 4, NULL),
(5, 2, 0, 0, 0, 'Ven', 'Os Dois Franciscos', 5, NULL),
(6, 2, 0, 0, 0, 'Ven', 'Meu Avo Desencarnou', 6, NULL),
(7, 10, 0, 0, 0, 'Ven', 'Um por todos por um: a vida em grupo dos mamíferos ', 7, NULL),
(8, 5, 0, 0, 0, 'Ven', 'Sopa de Letrinhas', 8, NULL),
(9, 5, 0, 0, 0, 'Ven', 'O Semeador do bem', 9, NULL),
(10, 5, 0, 0, 0, 'Ven', 'O bom é brincar de viver', 10, NULL),
(11, 5, 0, 0, 0, 'Ven', 'Descoberta dos dons', 11, NULL),
(12, 4, 0, 0, 0, 'Ven', 'Chico Bento Além Da Vida -Turma De Monica ', 12, NULL),
(13, 5, 0, 0, 0, 'Ven', 'Girassol que Não Acompanahava o Sol', 13, NULL),
(14, 4, 0, 0, 0, 'Ven', 'Acolhimento Fraterno na Casa Espírita', 14, NULL),
(15, 4, 0, 0, 0, 'Ven', 'A Evangelização de Portas Abertas para o Autismo', 15, NULL),
(16, 5, 0, 0, 0, 'Ven', 'Martinha Quer Saber, e Você?', 16, NULL),
(17, 5, 0, 0, 0, 'Ven', 'Allan Kardec: Princípios e Valores – Turma da Mônica', 17, NULL),
(18, 4, 0, 0, 0, 'Ven', 'Dorinha: A Tartaruga Marinha', 18, NULL),
(19, 5, 0, 0, 0, 'Ven', 'Meu Pequeno Evangelho – Turma da Mônica', 19, NULL),
(20, 1, 0, 0, 0, 'Ven', 'Cartilha do bem', 20, NULL),
(21, 1, 0, 0, 0, 'Ven', 'A Volta de Mariana', 21, NULL),
(22, 3, 0, 0, 0, 'Ven', 'Mamãe de Barriga... Mamãe de Coração', 22, NULL),
(23, 5, 0, 0, 0, 'Ven', 'Mônica:Jesus no meu lar', 23, NULL),
(24, 4, 0, 0, 0, 'Ven', 'Estudo sobre obsessão infantil', 24, NULL),
(25, 3, 0, 0, 0, 'Ven', 'Autismo e Espiritismo', 25, NULL),
(26, 2, 0, 0, 0, 'Ven', 'Mãos Unidas', 26, NULL),
(27, 15, 0, 0, 0, 'Ven', 'Coragem', 27, NULL),
(28, 15, 0, 0, 0, 'Ven', 'Segue-me', 28, NULL),
(29, 30, 0, 0, 0, 'Ven', 'Fonte Viva', 29, NULL),
(30, 6, 0, 0, 0, 'Ven', 'Pão Nosso', 30, NULL),
(31, 6, 0, 0, 0, 'Ven', 'Vinha de Luz', 31, NULL),
(32, 35, 0, 0, 0, 'Ven', 'O que é o Espiritismo basico 1', 32, NULL),
(33, 35, 0, 0, 0, 'Ven', 'O que é o Espiritismo basico 2', 33, NULL),
(34, 10, 0, 0, 0, 'Ven', 'Brasil,coração do mundo Pátria do Evangelho', 34, NULL),
(35, 10, 0, 0, 0, 'Ven', 'Convite da Vida', 35, NULL),
(36, 5, 0, 0, 0, 'Ven', 'Há doisil anos', 36, NULL),
(37, 5, 0, 0, 0, 'Ven', 'Paulo e Estevão', 37, NULL),
(38, 40, 0, 0, 0, 'Ven', 'Dos hippies aos problemas mundo', 38, NULL),
(39, 6, 0, 0, 0, 'Ven', 'Libertação', 39, NULL),
(40, 6, 0, 0, 0, 'Ven', 'Os mensageiros', 40, NULL),
(41, 12, 0, 0, 0, 'Ven', 'Missionários da luz', 41, NULL),
(42, 10, 0, 0, 0, 'Ven', 'Sinal verde', 42, NULL),
(43, 4, 0, 0, 0, 'Ven', 'Chico bento Além Da Vida -Turma De Monica ', 3, NULL),
(44, 5, 0, 0, 0, 'Ven', 'Um por todos por um: a vida em grupo dos mamíferos ', 44, NULL),
(45, 2, 0, 0, 0, 'Ven', 'Mãos Unidas', 45, NULL),
(46, 6, 0, 0, 0, 'Ven', 'Libertação', 46, NULL);

-- --------------------------------------------------------

--
-- Estrutura para tabela `tblivro`
--

CREATE TABLE `tblivro` (
  `codLivro` int(11) NOT NULL,
  `empVen` char(3) NOT NULL CHECK (`empVen` in ('Emp','Ven')),
  `isbn` char(20) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `autor` varchar(100) NOT NULL,
  `quant` int(11) NOT NULL DEFAULT 0 CHECK (`quant` >= 0),
  `valor` decimal(9,2) NOT NULL DEFAULT 0.00 CHECK (`valor` >= 0),
  `editora` varchar(50) DEFAULT NULL,
  `anoPublicacao` int(11) DEFAULT NULL,
  `foto` varchar(200) DEFAULT NULL,
  `dataCadastro` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tblivro`
--

INSERT INTO `tblivro` (`codLivro`, `empVen`, `isbn`, `nome`, `autor`, `quant`, `valor`, `editora`, `anoPublicacao`, `foto`, `dataCadastro`) VALUES
(1, 'Ven', '9788583530855', 'Outro lar- uma viagem muitos ensinamentos-Turma da Monica', 'Mauricio De Souza ', 5, 44.20, 'Boa Nova ', 2017, '', '2025-05-01 13:48:35'),
(2, 'Ven', '9788583530572', 'Magali em Outras Vidas -Turma da Monica ', 'Mauricio De Souza ', 5, 43.33, 'Boa Nova ', 2015, '', '2025-05-01 13:49:21'),
(3, 'Ven', '‎9788583531357', 'Chico bento Além Da Vida -Turma De Monica ', 'Mauricio De Souza ', 4, 45.30, 'Boa Nova', 2019, '', '2025-05-01 13:50:43'),
(4, 'Ven', '9788572533492', 'Turma Da Monica Jovem Conhece Violetas na Janela ', 'Mauricio De Souza ', 5, 42.90, 'Boa Nova', 2019, '', '2025-05-01 13:52:09'),
(5, 'Ven', '9788573286533', 'Os Dois Franciscos', 'Etna Lacerda', 2, 35.00, 'FEB', 2017, '', '2025-05-01 13:53:59'),
(6, 'Ven', '9788573285758', 'Meu Avo Desencarnou', 'Daniella Priolli Fonseca e Carvalho', 2, 32.14, 'FEB', 2017, '', '2025-05-01 13:54:41'),
(7, 'Ven', '‎9788524918438', 'Um por todos por um: a vida em grupo dos mamíferos ', 'Cristina Santos', 5, 42.12, 'Cortez', 2013, '', '2025-05-01 14:49:08'),
(8, 'Ven', '9788516107666', 'Sopa de Letrinhas', 'Teresa Noronha', 5, 54.99, 'Moderna Literatura', 2002, '', '2025-05-01 14:01:24'),
(9, 'Ven', '9788583531227', 'O Semeador do bem', 'Cleber Galhardi', 5, 15.09, 'Boa Nova', 2019, '', '2025-05-01 14:02:08'),
(10, 'Ven', '9786586374414', 'O bom é brincar de viver', 'Karina Almeida', 5, 15.30, 'Boa Nova', 2024, '', '2025-05-01 14:08:01'),
(11, 'Ven', '9788595201194', 'Descoberta dos dons', 'Luara Almeida', 5, 17.00, 'Pé de Letra', 2018, '', '2025-05-01 14:08:59'),
(12, 'Ven', '9788583530329', 'Chico Bento Além Da Vida -Turma De Monica ', 'Cleber Galhardi', 4, 18.00, 'Boa Nova', 2015, '', '2025-05-01 14:10:00'),
(13, 'Ven', '9788599772959', 'Girassol que Não Acompanahava o Sol', 'Etna Lacerda', 5, 13.57, 'Boa Nova', 2013, '', '2025-05-01 14:10:49'),
(14, 'Ven', '9788578000547', 'Acolhimento Fraterno na Casa Espírita', 'Daisy Jurgensen Machado', 4, 13.00, 'Allan Kardec', 2014, '', '2025-05-01 14:11:41'),
(15, 'Ven', '9786555430806', 'A Evangelização de Portas Abertas para o Autismo', 'Lúcia Moysés', 4, 48.40, 'EME Editora', 2023, '', '2025-05-01 14:12:22'),
(16, 'Ven', '9788583530336', 'Martinha Quer Saber, e Você?', 'Danielle V. M. Carvalho', 5, 15.00, 'Boa Nova', 2015, '', '2025-05-01 14:13:45'),
(17, 'Ven', '9788583531111', 'Allan Kardec: Princípios e Valores – Turma da Mônica', 'Luis Hu Rivas, Ala Mitchell e Mauricio de Sousa', 5, 41.82, 'Boa Nova', 2018, '', '2025-05-01 14:14:26'),
(18, 'Ven', '9788583640233', 'Dorinha: A Tartaruga Marinha', 'Roberto de Carvalho', 4, 30.20, 'Aliança', 2015, '', '2025-05-01 14:15:12'),
(19, 'Ven', '9788583530206', 'Meu Pequeno Evangelho – Turma da Mônica', 'Luis Hu Rivas e Ala Mitchell', 5, 30.00, 'Boa Nova', 2018, '', '2025-05-01 14:15:47'),
(20, 'Ven', '9788573284690', 'Cartilha do bem', 'Francisco Cândido Xavier', 1, 26.20, 'FEB', 2018, '', '2025-05-01 14:16:22'),
(21, 'Ven', '9788573285666', 'A Volta de Mariana', 'Cecília Rocha e Clara Lila Gonzalez de Araújo', 1, 33.82, 'FEB', 2020, '', '2025-05-01 14:17:56'),
(22, 'Ven', '9788573415001', 'Mamãe de Barriga... Mamãe de Coração', 'Regina Timbó', 3, 19.81, 'IDE', 2021, '', '2025-05-01 14:18:55'),
(23, 'Ven', '9788583531128', 'Mônica:Jesus no meu lar', 'Luis Hu Rivas e Ala Mitchell', 5, 39.56, 'Boa Nova', 2018, '', '2025-05-01 14:19:32'),
(24, 'Ven', '9788578000752', 'Estudo sobre obsessão infantil', 'Clara Lila Gonzalez de Araújo', 4, 36.02, 'Allan Kardec', 2024, '', '2025-05-01 14:20:09'),
(25, 'Ven', '9786588278055', 'Autismo e Espiritismo', 'Gustavo Henrique de Lucena', 3, 9.99, 'Clarim', 2021, '', '2025-05-01 14:20:44'),
(26, 'Ven', '‎9788573412291', 'Mãos Unidas', 'Francisco Cândido Xavier', 2, 38.00, 'IDE', 1972, '', '2025-05-01 14:22:08'),
(27, 'Ven', '9786555704990', 'Coragem', 'Francisco Cândido Xavier', 15, 34.02, 'FEB', 2023, '', '2025-05-01 14:22:40'),
(28, 'Ven', '9788573571882', 'Segue-me', 'Francisco Cândido Xavier', 15, 44.90, 'Boa Nova', 2020, '', '2025-05-01 14:23:30'),
(29, 'Ven', '9788569452454', 'Fonte Viva', 'Francisco Cândido Xavier', 30, 24.10, 'FEB', 2019, '', '2025-05-01 14:24:07'),
(30, 'Ven', '9788569452416', 'Pão Nosso', 'Francisco Cândido Xavier', 6, 24.40, 'FEB', 2019, '', '2025-05-01 14:24:40'),
(31, 'Ven', '9788569452522', 'Vinha de Luz', 'Francisco Cândido Xavier', 6, 22.40, 'FEB', 2019, '', '2025-05-01 14:25:25'),
(32, 'Ven', '9786586112160', 'O que é o Espiritismo basico 1', 'Allan Kardec', 35, 21.30, 'IDE', 2021, '', '2025-05-01 14:26:09'),
(33, 'Ven', '9788573287660', 'O que é o Espiritismo basico 2', 'Allan Kardec', 35, 28.80, 'FEB', 2019, '', '2025-05-01 14:26:41'),
(34, 'Ven', '9788573287967', 'Brasil,coração do mundo Pátria do Evangelho', 'Francisco Cândido Xavier', 10, 43.00, 'FEB', 2019, '', '2025-05-01 14:27:22'),
(35, 'Ven', '9788500024160', 'Convite da Vida', 'Divaldo Franco', 10, 265.53, 'Ediouro', 2008, '', '2025-05-01 14:28:03'),
(36, 'Ven', '9788573286977', 'Há doisil anos', 'Francisco Cândido Xavier', 5, 50.38, 'FEB', 2019, '', '2025-05-01 14:28:37'),
(37, 'Ven', '9788573286960', 'Paulo e Estevão', 'Francisco Cândido Xavier', 5, 55.00, 'FEB', 2019, '', '2025-05-01 14:29:20'),
(38, 'Ven', '9788573601459', 'Dos hippies aos problemas mundo', 'Francisco Cândido Xavier', 40, 25.00, 'Boa Nova', 2020, '', '2025-05-01 14:29:54'),
(39, 'Ven', '‎9788573288186', 'Libertação', 'Francisco Cândido Xavier', 6, 48.80, 'FEB', 2019, '', '2025-05-01 14:30:41'),
(40, 'Ven', '9788573287943', 'Os mensageiros', 'Francisco Cândido Xavier', 6, 48.30, 'FEB', 2019, '', '2025-05-01 14:31:13'),
(41, 'Ven', '9788573288018', 'Missionários da luz', 'Francisco Cândido Xavier', 12, 49.90, 'FEB', 2019, '', '2025-05-01 14:31:44'),
(42, 'Ven', '9786555705188', 'Sinal verde', 'Francisco Cândido Xavier', 10, 39.10, 'FEB', 2023, '', '2025-05-01 14:32:14'),
(43, 'Ven', '‎9788583531357', 'Chico bento Além Da Vida -Turma De Monica ', 'Mauricio De Souza ', 4, 45.30, 'Boa Nova', 2019, '', '2025-05-01 14:33:38'),
(44, 'Ven', '‎9788524918438', 'Um por todos por um: a vida em grupo dos mamíferos ', 'Cristina Santos', 5, 42.12, 'Cortez', 2013, '', '2025-05-01 14:33:56'),
(45, 'Ven', '9788573412291', 'Mãos Unidas', 'Francisco Cândido Xavier', 2, 38.00, 'IDE', 1972, '', '2025-05-01 14:34:17'),
(46, 'Ven', '9788573288186', 'Libertação', 'Francisco Cândido Xavier', 6, 48.80, 'FEB', 2019, '', '2025-05-01 14:34:31');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tblocatario`
--

CREATE TABLE `tblocatario` (
  `codLoc` int(11) NOT NULL,
  `pront` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `cpf` char(14) NOT NULL,
  `telCel` char(15) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `dataCadastro` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbusuario`
--

CREATE TABLE `tbusuario` (
  `codUsu` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `cargo` varchar(50) DEFAULT 'Voluntario' CHECK (`cargo` in ('Voluntario','Dirigente','Diretor')),
  `cpf` char(14) NOT NULL,
  `diaTrabalho` varchar(15) DEFAULT NULL CHECK (`diaTrabalho` in ('Segunda-feira','Terca-feira','Quarta-feira','Quinta-feira','Sexta-feira','Sabado','Domingo')),
  `telCel` char(15) NOT NULL,
  `login` varchar(50) NOT NULL,
  `senha` varchar(20) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `cep` char(9) DEFAULT NULL,
  `logradouro` varchar(100) DEFAULT NULL,
  `numero` char(10) DEFAULT NULL,
  `complemento` varchar(100) DEFAULT NULL,
  `bairro` varchar(50) DEFAULT NULL,
  `cidade` varchar(50) DEFAULT NULL,
  `estado` char(2) DEFAULT NULL,
  `foto` varchar(200) DEFAULT NULL,
  `dataCadastro` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tbusuario`
--

INSERT INTO `tbusuario` (`codUsu`, `nome`, `cargo`, `cpf`, `diaTrabalho`, `telCel`, `login`, `senha`, `email`, `cep`, `logradouro`, `numero`, `complemento`, `bairro`, `cidade`, `estado`, `foto`, `dataCadastro`) VALUES
(1, 'Eduardo Fascini', 'Diretor', '004.564.158-74', 'Segunda-feira', '(11)98624-2300', 'admin', '123', 'eduardo@conversoft.com.br', '04805-340', 'Rua Gomes Pedrosa', '56', 'Nenhum', 'Cidade Dutra', 'Sao Paulo', 'SP', NULL, '2025-05-01 13:48:31');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbvendas`
--

CREATE TABLE `tbvendas` (
  `codVenda` int(11) NOT NULL,
  `dataVenda` datetime DEFAULT NULL,
  `nomeLivro` varchar(100) DEFAULT NULL,
  `valorTotal` decimal(9,2) DEFAULT 0.00 CHECK (`valorTotal` >= 0),
  `pagamento` varchar(20) DEFAULT NULL,
  `nomeVendedor` varchar(100) DEFAULT NULL,
  `codLivro` int(11) NOT NULL,
  `codUsu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `tbemprestimo`
--
ALTER TABLE `tbemprestimo`
  ADD PRIMARY KEY (`codEmp`),
  ADD KEY `codLivro` (`codLivro`),
  ADD KEY `codLoc` (`codLoc`);

--
-- Índices de tabela `tbestoque`
--
ALTER TABLE `tbestoque`
  ADD PRIMARY KEY (`codEsto`),
  ADD KEY `codLivro` (`codLivro`);

--
-- Índices de tabela `tblivro`
--
ALTER TABLE `tblivro`
  ADD PRIMARY KEY (`codLivro`);

--
-- Índices de tabela `tblocatario`
--
ALTER TABLE `tblocatario`
  ADD PRIMARY KEY (`codLoc`),
  ADD UNIQUE KEY `cpf` (`cpf`);

--
-- Índices de tabela `tbusuario`
--
ALTER TABLE `tbusuario`
  ADD PRIMARY KEY (`codUsu`),
  ADD UNIQUE KEY `cpf` (`cpf`),
  ADD UNIQUE KEY `login` (`login`);

--
-- Índices de tabela `tbvendas`
--
ALTER TABLE `tbvendas`
  ADD PRIMARY KEY (`codVenda`),
  ADD KEY `codLivro` (`codLivro`),
  ADD KEY `codUsu` (`codUsu`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tbemprestimo`
--
ALTER TABLE `tbemprestimo`
  MODIFY `codEmp` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tbestoque`
--
ALTER TABLE `tbestoque`
  MODIFY `codEsto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT de tabela `tblivro`
--
ALTER TABLE `tblivro`
  MODIFY `codLivro` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT de tabela `tblocatario`
--
ALTER TABLE `tblocatario`
  MODIFY `codLoc` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tbusuario`
--
ALTER TABLE `tbusuario`
  MODIFY `codUsu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `tbvendas`
--
ALTER TABLE `tbvendas`
  MODIFY `codVenda` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `tbemprestimo`
--
ALTER TABLE `tbemprestimo`
  ADD CONSTRAINT `tbemprestimo_ibfk_1` FOREIGN KEY (`codLivro`) REFERENCES `tblivro` (`codLivro`),
  ADD CONSTRAINT `tbemprestimo_ibfk_2` FOREIGN KEY (`codLoc`) REFERENCES `tblocatario` (`codLoc`);

--
-- Restrições para tabelas `tbestoque`
--
ALTER TABLE `tbestoque`
  ADD CONSTRAINT `tbestoque_ibfk_1` FOREIGN KEY (`codLivro`) REFERENCES `tblivro` (`codLivro`);

--
-- Restrições para tabelas `tbvendas`
--
ALTER TABLE `tbvendas`
  ADD CONSTRAINT `tbvendas_ibfk_1` FOREIGN KEY (`codLivro`) REFERENCES `tblivro` (`codLivro`),
  ADD CONSTRAINT `tbvendas_ibfk_2` FOREIGN KEY (`codUsu`) REFERENCES `tbusuario` (`codUsu`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
