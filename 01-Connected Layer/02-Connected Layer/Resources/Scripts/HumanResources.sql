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
VALUES ('SomeName', 'SomeSurname', 'SomePatronymic', '1994-04-08', 1234567, 7654321, 'kitten1.JPG')

INSERT INTO Persons(FirstName, LastName, Patronymic, Birthday, ContractNumber, DismissalNumber, PhotoPath) 
VALUES ('SomeBody', 'OnceToldMe', 'ThatWorldIsGonnaRowMe', '1994-04-08', 1234567, 7654321, NULL)
GO

CREATE PROCEDURE ShowPersons AS
SELECT Persons.Id, Persons.FirstName, Persons.LastName, Persons.Patronymic, Persons.Birthday, Persons.ContractNumber, Persons.DismissalNumber, Persons.PhotoPath
FROM Persons
GO

CREATE PROCEDURE AddPerson
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Patronymic NVARCHAR(100),
	@Birthday Date,
	@ContractNumber bigint,
	@DismissalNumber bigint,
	@PhotoPath NVARCHAR(1000)
AS
INSERT INTO Persons(FirstName, LastName, Patronymic, Birthday, ContractNumber, DismissalNumber, PhotoPath) 
VALUES (@FirstName, @LastName, @Patronymic, @Birthday, @ContractNumber, @DismissalNumber, @PhotoPath)
GO


CREATE PROCEDURE EditPerson
	@Id bigint,
	@FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Patronymic NVARCHAR(100),
	@Birthday Date,
	@ContractNumber bigint,
	@DismissalNumber bigint,
	@PhotoPath NVARCHAR(1000)
AS
UPDATE Persons 
SET FirstName = @FirstName, LastName = @LastName, Patronymic = @Patronymic, Birthday = @Birthday,
ContractNumber = @ContractNumber, DismissalNumber = @DismissalNumber, PhotoPath = @PhotoPath
WHERE Id = @Id
GO


CREATE PROCEDURE DeletePerson 
    @Id bigint
AS
DELETE FROM Persons WHERE Id = @Id
GO
