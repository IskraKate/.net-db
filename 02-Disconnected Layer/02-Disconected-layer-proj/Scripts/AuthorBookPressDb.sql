IF DB_ID('BooksAuthorsPresses') IS NOT NULL
BEGIN
	USE master
	 ALTER DATABASE BooksAuthorsPresses SET single_user with rollback immediate
    DROP DATABASE BooksAuthorsPresses
END
GO 

CREATE DATABASE BooksAuthorsPresses
GO

USE BooksAuthorsPresses
GO

CREATE TABLE Authors
(	
	Id bigint PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(100)
)
GO

CREATE TABLE Presses
(
	Id bigint PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(100),
)
GO

CREATE TABLE Books
( 	
	Id bigint PRIMARY KEY IDENTITY(1,1),
	Title nvarchar(100),

	AuthorFk bigint,
	PressFk bigint

    FOREIGN KEY (AuthorFk) REFERENCES Authors(Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (PressFk) REFERENCES Presses(Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)
GO

INSERT INTO Authors VALUES('Mark Twain');
INSERT INTO Authors VALUES('George Orwell');

INSERT INTO Presses VALUES('Press1');
INSERT INTO Presses VALUES('Press2');

INSERT INTO Books VALUES('Tom Sawyer and Huckleberry Finn', 1, 1);
INSERT INTO Books VALUES('1984', 2, 2);
INSERT INTO Books VALUES('2084', 2, 1);
GO