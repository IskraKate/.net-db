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

CREATE TABLE Sellers
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
	SellerFk int,
	MoneySum int,
	[Date]  date
)
Go

INSERT INTO Buyers(Id, FirstName, LastName) VALUES (1, 'Шамиль',	'Власов')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (2, 'Стефан',	'Лебедев')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (3, 'Ярослав',	'Пономаренко')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (4, 'Борис',		'Ильин')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (5, 'Орландо',	'Юдин')
INSERT INTO Buyers(Id, FirstName, LastName) VALUES (6, 'Егор',		'Зайцев')

INSERT INTO Sellers(Id, FirstName, LastName) VALUES (1, 'Ростислав',	 'Наумов')
INSERT INTO Sellers(Id, FirstName, LastName) VALUES (2, 'Зиновий',	     'Рыбаков')
INSERT INTO Sellers(Id, FirstName, LastName) VALUES (3, 'Платон',	     'Шамрыло')
INSERT INTO Sellers(Id, FirstName, LastName) VALUES (4, 'Сергей',	     'Чикольба')
INSERT INTO Sellers(Id, FirstName, LastName) VALUES (5, 'Жерар',		 'Василенко')
INSERT INTO Sellers(Id, FirstName, LastName) VALUES (6, 'Зенон',		 'Коломоец')

INSERT INTO Sales(Id, BuyerFk, SellerFk, MoneySum, [Date]) VALUES (1, 6,	1, 100, '2020-04-03')
INSERT INTO Sales(Id, BuyerFk, SellerFk, MoneySum, [Date]) VALUES (2, 5,	2, 250, '2020-03-24')
INSERT INTO Sales(Id, BuyerFk, SellerFk, MoneySum, [Date]) VALUES (3, 4,	3, 300, '2020-03-23')
INSERT INTO Sales(Id, BuyerFk, SellerFk, MoneySum, [Date]) VALUES (4, 3,	4, 350, '2020-03-21')
INSERT INTO Sales(Id, BuyerFk, SellerFk, MoneySum, [Date]) VALUES (5, 2,	5, 400, '2020-03-22')
INSERT INTO Sales(Id, BuyerFk, SellerFk, MoneySum, [Date]) VALUES (6, 1,	6, 500, '2020-03-22')