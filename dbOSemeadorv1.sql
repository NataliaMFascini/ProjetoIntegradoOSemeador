--deletar depois
drop database dbOSemeador;
--deletar depois
create database dbOSemeador;

use dbOSemeador;

--Tabela usuario
create table tbUsuario(
codUsu int not null auto_increment,
nome varchar(100) not null,
cargo varchar(50) default 'Voluntario' check(cargo in('Voluntario', 'Dirigente', 'Diretor')),
cpf char(14) not null unique,
diaTrabalho varchar(15) check(diaTrabalho in ('Segunda-feira', 'Terca-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado', 'Domingo')),
telCel char(15)not null,
login varchar(50) not null unique,
senha varchar(20) not null,
email varchar(100),
cep char(9),
logradouro varchar(100),
numero char(10),
complemento varchar(100),
bairro varchar(50),
cidade varchar(50),
estado char(2),
foto varchar(200),
dataCadastro dateTime,
primary key (codUsu)
);

insert into tbUsuario(nome, cargo, cpf, diaTrabalho, telCel, login, senha, email, cep, logradouro, numero, complemento, bairro, cidade, estado, foto, dataCadastro) 
	values ('Eduardo Fascini', 'Diretor', '004.564.158-74', 'Segunda-feira', '(11)98624-2300', 'admin', '123', 'eduardo@conversoft.com.br', '04805-340', 'Rua Gomes Pedrosa', '56', 'Nenhum', 'Cidade Dutra', 'Sao Paulo', 'SP', null, CURRENT_TIMESTAMP);

--tabela locatarios
create table tbLocatario(
codLoc int not null auto_increment,
pront int not null,
nome varchar(100) not null,
cpf char(14) not null unique,
telCel char(15),
email varchar(50),
dataCadastro dateTime,
primary key(codLoc)
);

--Tabela livros
create table tbLivro(
codLivro int not null auto_increment,
empVen char(3) not null check (empVen in ('Emp', 'Ven')),
isbn char(20) not null,
nome varchar(100) not null,
autor varchar(100) not null,
quant int not null default 0 check(quant >= 0),
valor decimal(9,2) not null default 0 check(valor >= 0),
editora varchar(50),
anoPublicacao int,
foto varchar(200),
dataCadastro dateTime,
primary key (codLivro)
);

--Tabela Emprestimo
create table tbEmprestimo(
codEmp int not null auto_increment,
dataEmp dateTime,
dataDev date,
nomeVendedor varchar(100),
nomeLivro varchar(100),
prontuario int,
dataCadastro dateTime,
codLivro int not null,
codLoc int not null,
primary key(codEmp),
foreign key(codLivro) references tbLivro(codLivro),
foreign key(codLoc) references tbLocatario(codLoc)
);

--tabela vendas
create table tbVendas(
codVenda int not null auto_increment,
dataVenda dateTime,
nomeLivro varchar(100),
valorTotal decimal(9,2) default 0 check(valorTotal >=0),
pagamento varchar(20),
nomeVendedor varchar(100),
dataCadastro dateTime,
codLivro int not null,
codUsu int not null,
primary key(codVenda),
foreign key (codLivro) references tbLivro(codLivro),
foreign key (codUsu) references tbUsuario(codUsu)
);

--insert into tbVendas(dataVenda, quantidade, valorTotal) values (@dataVenda, @quantidade, @valorTotal);

--tabela estoque(talvez mudar)
create table tbEstoque(
codEsto int not null auto_increment,
entradaVen int default 0 check(entradaVen >= 0),
saidaVen int default 0 check(saidaVen >= 0),
entradaEmp int default 0 check(entradaEmp >= 0),
saidaEmp int default 0 check(saidaEmp >= 0),
empVen char(3) not null check (empVen in ('Emp', 'Ven')),
nomeLivro varchar(100),
codLivro int not null,
disponibilidade char(1) default null,
primary key(codEsto),
foreign key (codLivro) references tbLivro(codLivro)
);

--insert into tbLivro (empVen, isbn, nome, autor, quant, valor, editora, anoPublicacao, foto, dataCadastro)	values ('Ven', '9788592793388', 'Livros dos Mediuns (o) - Letras Grandes', 'Guillon Ribeiro', 1, 30.00, 'Nova Visao 1a Edicao', 2020, null, CURRENT_TIMESTAMP);

--insert into tbLivro (empVen, isbn, nome, autor, quant, valor, editora, anoPublicacao, foto, dataCadastro)	values ('Ven', '9788539604579', 'Logica de Programacao', 'Gley Fabiano Cardoso Xavier', 5, 70.00, 'Senac', 2024, null, CURRENT_TIMESTAMP);

--insert into tbEstoque(entradaVen, empVen, codLivro, nomeLivro) values (100, 'Ven', 2, 'Logica de Programacao');

INSERT INTO `tblivro` (`codLivro`, `empVen`, `isbn`, `nome`, `autor`, `quant`, `valor`, `editora`, `anoPublicacao`, `foto`, `dataCadastro`) VALUES
(1, 'Ven', '9788583530855', 'Outro lar- uma viagem muitos ensinamentos-Turma da Monica', 'Mauricio De Souza ', 5, 44.20, 'Boa Nova ', 2017, '', '2025-05-01 13:48:35'),
(2, 'Ven', '9788583530572', 'Magali em Outras Vidas -Turma da Monica ', 'Mauricio De Souza ', 5, 43.33, 'Boa Nova ', 2015, '', '2025-05-01 13:49:21'),
(3, 'Ven', '9788583531357', 'Chico bento Além Da Vida -Turma De Monica ', 'Mauricio De Souza ', 4, 45.30, 'Boa Nova', 2019, '', '2025-05-01 13:50:43'),
(4, 'Ven', '9788572533492', 'Turma Da Monica Jovem Conhece Violetas na Janela ', 'Mauricio De Souza ', 5, 42.90, 'Boa Nova', 2019, '', '2025-05-01 13:52:09'),
(5, 'Ven', '9788573286533', 'Os Dois Franciscos', 'Etna Lacerda', 2, 35.00, 'FEB', 2017, '', '2025-05-01 13:53:59'),
(6, 'Ven', '9788573285758', 'Meu Avo Desencarnou', 'Daniella Priolli Fonseca e Carvalho', 2, 32.14, 'FEB', 2017, '', '2025-05-01 13:54:41'),
(7, 'Ven', '9788524918438', 'Um por todos por um: a vida em grupo dos mamíferos ', 'Cristina Santos', 5, 42.12, 'Cortez', 2013, '', '2025-05-01 14:49:08'),
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
(26, 'Ven', '9788573412291', 'Mãos Unidas', 'Francisco Cândido Xavier', 2, 38.00, 'IDE', 1972, '', '2025-05-01 14:22:08'),
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
(39, 'Ven', '9788573288186', 'Libertação', 'Francisco Cândido Xavier', 6, 48.80, 'FEB', 2019, '', '2025-05-01 14:30:41'),
(40, 'Ven', '9788573287943', 'Os mensageiros', 'Francisco Cândido Xavier', 6, 48.30, 'FEB', 2019, '', '2025-05-01 14:31:13'),
(41, 'Ven', '9788573288018', 'Missionários da luz', 'Francisco Cândido Xavier', 12, 49.90, 'FEB', 2019, '', '2025-05-01 14:31:44'),
(42, 'Ven', '9786555705188', 'Sinal verde', 'Francisco Cândido Xavier', 10, 39.10, 'FEB', 2023, '', '2025-05-01 14:32:14'),
(43, 'Ven', '9788583531357', 'Chico bento Além Da Vida -Turma De Monica ', 'Mauricio De Souza ', 4, 45.30, 'Boa Nova', 2019, '', '2025-05-01 14:33:38'),
(44, 'Ven', '9788524918438', 'Um por todos por um: a vida em grupo dos mamíferos ', 'Cristina Santos', 5, 42.12, 'Cortez', 2013, '', '2025-05-01 14:33:56'),
(45, 'Ven', '9788573412291', 'Mãos Unidas', 'Francisco Cândido Xavier', 2, 38.00, 'IDE', 1972, '', '2025-05-01 14:34:17'),
(46, 'Ven', '9788573288186', 'Libertação', 'Francisco Cândido Xavier', 6, 48.80, 'FEB', 2019, '', '2025-05-01 14:34:31');

--visualizar
desc tbUsuario;
desc tbLocatario;
desc tbLivro;
desc tbEmprestimo;
desc tbVendas;
desc tbEstoque;

select * from tbLivro;
select * from tbUsuario;
select * from tbLocatario;
select * from tbVendas;
select * from tbEmprestimo;
select * from tbEstoque;