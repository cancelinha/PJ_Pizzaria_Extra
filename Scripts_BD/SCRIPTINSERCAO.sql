USE Senai_Pizzarias

SELECT * FROM USUARIO
SELECT * FROM PIZZARIAS
SELECT * FROM TIPO_USUARIO
SELECT * FROM CATEGORIA_PRECO

INSERT INTO TIPO_USUARIO(NOME)
VALUES ('ADMINISTRADOR'),('USUARIO');

INSERT INTO USUARIO(NOME, EMAIL, SENHA, TIPO_DE_USUARIO)
VALUES ('Gandolf', 'gandolf@admin.com','132', 1),
       ('Helena','helena@user.com','2325', 2),
	   ('Fernando', 'fernando@user.com','dev132',2);

INSERT INTO CATEGORIA_PRECO(PRECO, CATEGORIA)
VALUES('Até R$30,00','$'),('De R$31,00 até R$50,00','$$'),('Mais de R$50,00','$$$')

INSERT INTO PIZZARIAS(NOME,ENDERECO,TELEFONE_COMERCIAL,OPCAO_VEGANA, CATEGORIA_DO_PRECO )
VALUES ('Pizzaria Esquillos','R Hortências,720-SA','44510276',1 , 2),
       ('Palácio da Pizza','R Gertrudes, 91- SA','44538231',1 , 3),
	   ('Don Fernando','R Dracena, 07-SA','44767588',0 , 1),
       ('Piu Belle','Av da Paz, 1593- SBC','23249001',0 , 1),
       ('Don Manuel','Av Utinga, 5062-SA','25314467',1 , 2),
       ('Adrilena','R Videira, 99-SCS','49756728',0, 3),
       ('Don Adriano','R dos Expedicionários, 9001-SBC','22598172',1 , 3);