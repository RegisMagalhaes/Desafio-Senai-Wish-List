-- DDL

-- Cria o banco de dados wish_list_senai
CREATE DATABASE wish_list_senai;
GO

-- Define o uso do banco de dados wish_list_senai
USE wish_list_senai;
GO

-- Cria a tabela de usuarios
CREATE TABLE usuarios
(
	idUsuario	INT PRIMARY KEY IDENTITY
	,email		VARCHAR(255) UNIQUE NOT NULL
	,senha		VARCHAR(255) NOT NULL
);
GO


-- Cria a tabela de desejos
CREATE TABLE desejos
(
	idDesejo	INT PRIMARY KEY IDENTITY
	,idUsuario	INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,descricao	VARCHAR(255) UNIQUE
);
GO