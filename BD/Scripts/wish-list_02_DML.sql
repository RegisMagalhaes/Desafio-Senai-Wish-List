-- DML 

USE wish_list_senai;
GO

INSERT INTO usuarios (email, senha)
VALUES			('usuario@usuario.com', '123456')
			   ,('misamisa@gmail.com', '123456')
GO

INSERT INTO desejos (descricao, idUsuario)
VALUES			('Se formar', 1)
			   ,('Trabalhar', 2)
			   ,('Ter nota 10', 1)
GO