IF DB_ID('UsersDb') IS NOT NULL
BEGIN
	USE master
	 ALTER DATABASE UsersDb SET single_user with rollback immediate
    DROP DATABASE UsersDb
END
GO 

CREATE DATABASE UsersDb
GO

USE UsersDb
Go

CREATE TABLE Users 
(
	Id bigint PRIMARY KEY IDENTITY(1,1),
	[Login] nvarchar(50),
	[Password] nvarchar(50),
	[Address] nvarchar (200),
	[TelephoneNumber] bigint,
	[Admin] bit
)

INSERT INTO Users([Login], [Password], [Address], [TelephoneNumber], [Admin]) VALUES ('MyLogin', 'MyPassword', 'some@gmail.com', 0123456789, 0);
INSERT INTO Users([Login], [Password], [Address], [TelephoneNumber], [Admin]) VALUES ('MyLogin1', 'MyPassword1', 'some1@gmail.com', 0123456789, 0);
INSERT INTO Users([Login], [Password], [Address], [TelephoneNumber], [Admin]) VALUES ('MyLogin1', 'MyPassword1', 'some1@gmail.com', 0123456789, 1);
