IF DB_ID('FridgeShopDb') IS NOT NULL 
BEGIN
	USE master
	ALTER DATABASE FridgeShopDb set single_user with rollback immediate
	DROP DATABASE FridgeShopDb
END
GO

CREATE DATABASE FridgeShopDb
GO

USE FridgeShopDb
GO

CREATE TABLE Fridges
(
	Id bigint PRIMARY KEY IDENTITY(1,1),
	Brand nvarchar(50),
	Number nvarchar(50)
)

CREATE TABLE Sellers
(
	Id bigint PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50)
)

CREATE TABLE Buyers
(
	Id bigint PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50)
)

CREATE TABLE Checks
(
	Id bigint PRIMARY KEY IDENTITY(1,1),
	Number int,
	[Date] date,
	BuyerFk bigint,
	SellerFk bigint,
	FridgeFk bigint
)

INSERT INTO Fridges(Brand, Number) VALUES ('Vestfrost', ' CW286W')
INSERT INTO Fridges(Brand, Number) VALUES ('Bosch', ' KGN36XL306')
INSERT INTO Fridges(Brand, Number) VALUES ('LG', ' GA-B509SLKM')
INSERT INTO Fridges(Brand, Number) VALUES ('Vestfrost', ' CW286W')
INSERT INTO Fridges(Brand, Number) VALUES ('Vestfrost', ' CX263W')
INSERT INTO Fridges(Brand, Number) VALUES ('Vestfrost', 'CNF289X')

INSERT INTO Sellers([Name]) VALUES ('First Seller')
INSERT INTO Sellers([Name]) VALUES ('Second Seller')
INSERT INTO Sellers([Name]) VALUES ('Third Seller')

INSERT INTO Buyers([Name]) VALUES ('First Buyer')
INSERT INTO Buyers([Name]) VALUES ('Second Buyer')
INSERT INTO Buyers([Name]) VALUES ('Third Buyer')

INSERT INTO Checks(Number, [Date], BuyerFk, SellerFk, FridgeFk) VALUES (123456, '2020-01-02', 1, 1, 1)
INSERT INTO Checks(Number, [Date], BuyerFk, SellerFk, FridgeFk) VALUES (234567, '2019-10-03', 2, 2, 2)
INSERT INTO Checks(Number, [Date], BuyerFk, SellerFk, FridgeFk) VALUES (345678, '2018-05-04', 3, 3, 3)
INSERT INTO Checks(Number, [Date], BuyerFk, SellerFk, FridgeFk) VALUES (567891, '2020-07-05', 1, 1, 4)
INSERT INTO Checks(Number, [Date], BuyerFk, SellerFk, FridgeFk) VALUES (111213, '2017-04-06', 2, 2, 5)
INSERT INTO Checks(Number, [Date], BuyerFk, SellerFk, FridgeFk) VALUES (141516, '2019-01-07', 3, 3, 6)