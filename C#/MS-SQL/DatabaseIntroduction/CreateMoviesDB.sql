CREATE DATABASE Movies;

USE Movies;

GO

--•	Directors (Id, DirectorName, Notes)
CREATE TABLE Directors
(
	Id INT IDENTITY PRIMARY KEY,
	DirectorName NVARCHAR(50),
	Notes NVARCHAR(500)
);

--•	Genres (Id, GenreName, Notes)

CREATE TABLE Genres
(
	Id INT IDENTITY PRIMARY KEY,
	GenreName NVARCHAR(50),
	Notes NVARCHAR(500)
);

--•	Categories (Id, CategoryName, Notes)

CREATE TABLE Categories
(
	Id INT IDENTITY PRIMARY KEY,
	CategoryName NVARCHAR(50),
	Notes NVARCHAR(500)
);

--•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)

CREATE TABLE Movies
(
	Id INT IDENTITY PRIMARY KEY,
	Title NVARCHAR(50),
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear SMALLINT,
	[Length] DECIMAL(6, 2),
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	Rating INT,
	Notes NVARCHAR(500)
);


INSERT INTO Directors
VALUES 
	('Kircho Kirilov', null),
	('Mircho Mirchev', null),
	('Pencho Penchev', null),
	('Minka Mincheva', null),
	('Penka Penkova', null);

INSERT INTO Genres
VALUES
	('artistic', null),
	('musical', null),
	('comedy', null),
	('crime', null),
	('horror', null);

INSERT INTO Categories
VALUES
	('Action', null),
	('Drama', null),
	('Romance', null),
	('Thriller', null),
	('Horror', null);

INSERT INTO Movies
VALUES
	('Movie1',1,2010,120.28,5,88,null),
	('Movie2',2,2011,120.28,5,55,null),
	('Movie3',3,2012,120.28,5,22,null),
	('Movie4',4,2013,120.28,5,99,null),
	('Movie5',5,2014,120.28,5,77,null);
