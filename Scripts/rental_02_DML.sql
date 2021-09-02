USE LOCADORA2;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Koga Veiculos'), ('Ford');
GO


DELETE FROM EMPRESA
WHERE idEmpresa = 2


INSERT INTO MARCA (nomeMarca)
VALUES ('Ford'), ('GM'), ('Fiat');
GO

INSERT INTO CLIENTE (nomeCliente)
VALUES ('Andrey'), ('Amanda');
GO

INSERT INTO MODELO (idMarca, nomeModelo)
VALUES (1,'Fiesta'), (2,'Onix'), (3,'Argo');
GO

INSERT INTO VEICULO ( idEmpresa, idModelo, placaVeiculo)
VALUES (1, 1, 'BEAQQQQ'),
       (1, 2, 'ANDFFFF'),
	   (2, 3, 'RALDDDD'), 
	   (2, 1, 'MMMAAAA');
GO

INSERT INTO ALUGUEL (idCliente, idVeiculo, dataInicio, dataFim)
VALUES (6,1,'19/08/2021','19/10/2021'),
       (6,2,'20/08/2021','20/10/2021'), 
       (7,3,'21/08/2021','21/10/2021'),
	   (7,4,'22/08/2021','22/10/2021');
GO