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
telCel char(10)not null,
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
foto varbinary(255),
dataCadastro dateTime,
primary key (codUsu)
);

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
foto varbinary(255),
dataCadastro dateTime,
primary key (codLivro)
);

--Tabela Emprestimo
create table tbEmprestimo(
codEmp int not null auto_increment,
dataEmp dateTime,
dataDev date,
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
quantidade int default 0,
valorTotal decimal(9,2) default 0 check(valorTotal >=0),
codLivro int not null,
codUsu int not null,
primary key(codVenda),
foreign key (codLivro) references tbLivro(codLivro),
foreign key (codUsu) references tbUsuario(codUsu)
);

--tabela estoque(talvez mudar)
create table tbEstoque(
codEsto int not null,
quantidade int default 0,
empVen bool,
codLivro int not null,
primary key(codEsto),
foreign key (codLivro) references tbLivro(codLivro)
);

insert into tbLivro (empVen, isbn, nome, autor, quant, valor, editora, anoPublicacao, foto)
	values ('Ven', '9788592793388', 'Livros dos Mediuns (o) - Letras Grandes', 'Guillon Ribeiro', 1, 30.00, 'Nova Visao 1a Edicao', 2020, 'foto aqui');

insert into tbLivro (empVen, isbn, nome, autor, quant, valor, editora, anoPublicacao, foto)	values ('Ven', '9788539604579', 'Logica de Programacao', 'Gley Fabiano Cardoso Xavier', 5, 70.00, 'Senac', 2024, 'foto aqui');

--visualizar
desc tbUsuario;
desc tbLocatario;
desc tbLivro;
desc tbEmprestimo;
desc tbVendas;
desc tbEstoque;

select * from tbLivro;