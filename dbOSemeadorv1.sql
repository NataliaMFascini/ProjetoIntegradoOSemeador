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
telCel char(14)not null,
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
	values ('Eduardo Fascini', 'Diretor', '004.564.158-74', 'Segunda-feira', '(11)98624-2300', 'admin', '123', 'eduardo@conversoft.com.br', '04805-340', 'Rua Gomes Pedrosa', '56', 'Nenhum', 'Cidade Dutra', 'Sao Paulo', 'SP', 'foto aqui', CURRENT_TIMESTAMP);

--tabela locatarios
create table tbLocatario(
codLoc int not null auto_increment,
pront int not null,
nome varchar(100) not null,
cpf char(14) not null unique,
telCel char(10),
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
primary key(codEsto),
foreign key (codLivro) references tbLivro(codLivro)
);

insert into tbLivro (empVen, isbn, nome, autor, quant, valor, editora, anoPublicacao, foto)
	values ('Ven', '9788592793388', 'Livros dos Mediuns (o) - Letras Grandes', 'Guillon Ribeiro', 1, 30.00, 'Nova Visao 1a Edicao', 2020, 'foto aqui');

insert into tbLivro (empVen, isbn, nome, autor, quant, valor, editora, anoPublicacao, foto)	values ('Ven', '9788539604579', 'Logica de Programacao', 'Gley Fabiano Cardoso Xavier', 5, 70.00, 'Senac', 2024, 'foto aqui');

insert into tbEstoque(entradaVen, empVen, codLivro, nomeLivro) values (100, 'Ven', 2, 'Logica de Programacao');
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