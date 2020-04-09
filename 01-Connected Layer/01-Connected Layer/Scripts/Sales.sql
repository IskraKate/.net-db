IF DB_ID('Sales') IS NOT NULL
BEGIN
	USE master
	 ALTER DATABASE Sales SET single_user with rollback immediate
    DROP DATABASE Sales
END
GO 

CREATE DATABASE Sales
GO

USE Sales
Go

CREATE TABLE Buyers
(
	Id int NOT NULL PRIMARY KEY,
	FirstName varchar(25),
	LastName varchar(50)
)
Go

CREATE TABLE Salers
(
	Id int NOT NULL PRIMARY KEY,
	FirstName varchar(25),
	LastName varchar(50)
)
Go

CREATE TABLE Sales
(
	Id int NOT NULL PRIMARY KEY,
	BuyerFk int,
	SalerFk int,
	MoneySum int,
	[Date]  date
)
Go

INSERT INTO Buyers(Id, FirstName, LastName) VALUES (1, '������',	'������')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (2, '������',	'�������')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (3, '�������',	'�����������')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (4, '�����',		'�����')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (5, '�������',	'����')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (6, '����',		'������')

INSERT INTO Salers(Id, FirstName, LastName) VALUES (1, '���������',	 '������')
INSERT INTO Salers(Id, FirstName, LastName) VALUES (2, '�������',	 '�������')
INSERT INTO Salers(Id, FirstName, LastName) VALUES (3, '������',	 '�������')
INSERT INTO Salers(Id, FirstName, LastName) VALUES (4, '������',	 '��������')
INSERT INTO Salers(Id, FirstName, LastName) VALUES (5, '�����',		 '���������')
INSERT INTO Salers(Id, FirstName, LastName) VALUES (6, '�����',		 '��������')

INSERT INTO Sales(Id, BuyerFk, SalerFk, MoneySum, [Date]) VALUES (1, 6,	1, 100, '2020-04-03')
INSERT INTO Sales(Id, BuyerFk, SalerFk, MoneySum, [Date]) VALUES (2, 5,	2, 250, '2020-03-24')
INSERT INTO Sales(Id, BuyerFk, SalerFk, MoneySum, [Date]) VALUES (3, 4,	3, 300, '2020-03-23')
INSERT INTO Sales(Id, BuyerFk, SalerFk, MoneySum, [Date]) VALUES (4, 3,	4, 350, '2020-03-21')
INSERT INTO Sales(Id, BuyerFk, SalerFk, MoneySum, [Date]) VALUES (5, 2,	5, 400, '2020-03-22')
INSERT INTO Sales(Id, BuyerFk, SalerFk, MoneySum, [Date]) VALUES (6, 1,	6, 500, '2020-03-22')


SELECT Buyers.FirstName As BFirstname, Buyers.LastName As BLastname, Salers.FirstName As SFirstname, Salers.LastName As SLastname, MoneySum, Date 
FROM Sales, Salers, Buyers 
WHERE Sales.SalerFk = Salers.Id AND Sales.BuyerFk = Buyers.Id