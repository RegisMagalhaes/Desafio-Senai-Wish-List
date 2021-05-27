-- DQL

USE wish_list_senai;

SELECT * FROM usuarios;

SELECT * FROM desejos;

SELECT idDesejo, descricao, email FROM desejos D
INNER JOIN usuarios U
ON D.idDesejo = U.idUsuario