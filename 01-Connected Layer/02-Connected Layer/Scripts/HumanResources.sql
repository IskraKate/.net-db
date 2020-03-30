IF DB_ID('HumanResources') IS NOT NULL
BEGIN
	USE master
	 ALTER DATABASE HumanResources SET single_user with rollback immediate
    DROP DATABASE HumanResources
END
GO 

CREATE DATABASE HumanResources
GO

USE HumanResources
Go

CREATE TABLE Persons
(   
	Id bigint PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(100),	
	LastName nvarchar(100),
	Patronymic nvarchar(100),
	Birthday date,
	ContractNumber bigint,
	DismissalNumber bigint, 
	PhotoPath nvarchar(1000)
)

INSERT INTO Persons(FirstName, LastName, Patronymic, Birthday, ContractNumber, DismissalNumber, PhotoPath) 
VALUES ('SomeName', 'SomeSurname', 'SomePatronymic', '1994-04-08', 1234567, 7654321, 'PersonalPhotosResource/kitten1.png')

INSERT INTO Persons(FirstName, LastName, Patronymic, Birthday, ContractNumber, DismissalNumber, PhotoPath) 
VALUES ('SomeBody', 'OnceToldMe', 'ThatWorldIsGonnaRowMe', '1994-04-08', 1234567, 7654321, NULL)

SELECT Persons.Id, Persons.FirstName, Persons.LastName, Persons.Patronymic,
Persons.Birthday, Persons.ContractNumber, Persons.DismissalNumber, Persons.PhotoPath
FROM Persons