create database Senai_Pizzarias
use Senai_Pizzarias

CREATE TABLE  TIPO_USUARIO(
ID_TIPO_USUARIO INT IDENTITY PRIMARY KEY,
NOME VARCHAR(50) NOT NULL UNIQUE 
);

CREATE TABLE USUARIO (
ID_USUARIO INT IDENTITY PRIMARY KEY,
NOME VARCHAR(150) NOT NULL,
EMAIL VARCHAR(100) NOT NULL UNIQUE,
SENHA VARCHAR(150) NOT NULL,
TIPO_DE_USUARIO INT NOT NULL FOREIGN KEY REFERENCES TIPO_USUARIO(ID_TIPO_USUARIO)
);

CREATE TABLE CATEGORIA_PRECO(
ID_CATEGORIA INT IDENTITY PRIMARY KEY,
PRECO VARCHAR(50) NOT NULL UNIQUE,
CATEGORIA VARCHAR(5) NOT NULL UNIQUE
);

CREATE TABLE PIZZARIAS (
ID_PIZZARIA INT IDENTITY PRIMARY KEY,
NOME VARCHAR(150) NOT NULL UNIQUE,
ENDERECO VARCHAR(150) NOT NULL UNIQUE,
TELEFONE_COMERCIAL VARCHAR(20) NOT NULL UNIQUE,
OPCAO_VEGANA BIT DEFAULT(1) NOT NULL,
CATEGORIA_DO_PRECO INT FOREIGN KEY REFERENCES CATEGORIA_PRECO(ID_CATEGORIA)
);