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
	Id bigint PRIMARY KEY,
	FirstName nvarchar(100),
	LastName nvarchar(100),
	Patronymic nvarchar(100),
	Birthday date,
	ContractNumber bigint,
	DismissalNumber bigint
)

INSERT INTO Persons(Id, FirstName, LastName, Patronymic, Birthday, ContractNumber, DismissalNumber) 
VALUES (1, 'SomeName', 'SomeSurname', 'SomePatronymic', '1994-04-08', 1234567, 7654321)

SELECT Persons.Id, Persons.FirstName, Persons.LastName, Persons.Patronymic, Persons.Birthday, Persons.ContractNumber, Persons.DismissalNumber
FROM Persons