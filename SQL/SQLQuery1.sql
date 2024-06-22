CREATE TABLE Unidade (Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
                    Nome NVARCHAR(50) NOT NULL,
					Cidade NVARCHAR(50) NOT NULL,
					Estado NCHAR(2) NOT NULL);
--ALTER TABLE Cliente
--ADD IdUnidade int null;

INSERT INTO Unidade (Nome, Cidade, Estado) VALUES ('Unidade1', 'Juiz de Fora', 'MG');
INSERT INTO Unidade (Nome, Cidade, Estado) VALUES ('Unidade2', 'São Paulo', 'SP');
INSERT INTO Unidade (Nome, Cidade, Estado) VALUES ('Unidade3', 'Rio de Janeiro', 'RJ');
INSERT INTO Unidade (Nome, Cidade, Estado) VALUES ('Unidade4', 'Brasilia', 'DF');
INSERT INTO Unidade (Nome, Cidade, Estado) VALUES ('Unidade5', 'Salvador', 'BA');

ALTER TABLE Cliente
ADD FOREIGN KEY (IdUnidade) REFERENCES Unidade(Id);