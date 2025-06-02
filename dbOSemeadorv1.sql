-- deletar depois
drop database dbOSemeador;
-- deletar depois
create database dbOSemeador;

use dbOSemeador;

-- Tabela usuario
create table tbUsuario(
codUsu int not null auto_increment,
nome varchar(100) not null,
cargo varchar(50) default 'Voluntário' check(cargo in('Voluntário', 'Dirigente', 'Diretor')),
cpf char(15) not null unique,
diaTrabalho varchar(15) check(diaTrabalho in ('Segunda-feira', 'Terca-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado', 'Domingo')),
telCel char(16)not null,
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

-- tabela locatarios
create table tbLocatario(
codLoc int not null auto_increment,
pront int not null,
nome varchar(100) not null,
cpf char(15) not null unique,
telCel char(16),
email varchar(50),
dataCadastro dateTime,
primary key(codLoc)
);

-- Tabela Livraria(Vendas)
create table tbLivroL(
codLivro int not null auto_increment,
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

-- Tabela Biblioteca(Emprestimos)
create table tbLivroB(
codLivro int not null auto_increment,
isbn char(20) not null,
nome varchar(100) not null,
autor varchar(100) not null,
quant int not null default 0 check(quant >= 0),
editora varchar(50),
anoPublicacao int,
foto varchar(200),
dataCadastro dateTime,
primary key (codLivro)
);

-- Tabela Emprestimo
create table tbEmprestimo(
codEmp int not null auto_increment,
dataEmp dateTime,
dataDev dateTime,
nomeLivro varchar(100),
prontuario int,
nomeLocatario varchar(100),
nomeVendedor varchar(100),
dataCadastro dateTime,
codLivro int not null,
primary key(codEmp),
foreign key(codLivro) references tbLivroB(codLivro)
);

-- tabela vendas
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
foreign key (codLivro) references tbLivroL(codLivro),
foreign key (codUsu) references tbUsuario(codUsu)
);

-- tabela estoque(talvez mudar)
create table tbEstoqueL(
codEsto int not null auto_increment,
entradaVen int default 0 check(entradaVen >= 0),
saidaVen int default 0 check(saidaVen >= 0),
nomeLivro varchar(100),
disponibilidade char(1) default 'S' check (disponibilidade in ('S', 'N')),
codLivro int not null,
primary key (codEsto),
foreign key (codLivro) references tbLivroL(codLivro)
);

create table tbEstoqueB(
codEsto int not null auto_increment,
entradaEmp int default 0 check(entradaEmp >= 0),
saidaEmp int default 0 check(saidaEmp >= 0),
nomeLivro varchar(100),
disponibilidade char(1) default 'S' check (disponibilidade in ('S', 'N')),
codLivro int not null,
primary key (codEsto),
foreign key (codLivro) references tbLivroB(codLivro)
);

-- visualizar
desc tbUsuario;
desc tbLocatario;
desc tbLivroL;
desc tbLivroB;
desc tbEmprestimo;
desc tbVendas;
desc tbEstoqueL;
desc tbEstoqueB;

select * from tbLivroL;
select * from tbLivroB;
select * from tbUsuario;
select * from tbLocatario;
select * from tbVendas;
select * from tbEmprestimo;
select * from tbEstoqueL;
select * from tbEstoqueB;
