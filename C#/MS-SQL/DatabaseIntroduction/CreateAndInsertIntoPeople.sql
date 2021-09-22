CREATE TABLE People
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture SMALLINT,
	Height DECIMAL(6,2),
	[Weight] DECIMAL(6,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
);

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES 
	('Gosho', 1, 1.75, 74.88, 'm', '1993-08-14', 'ne znam kvo da napisha'),
	('Minka', 1, 1.67, 51.74, 'f', '1997-03-27', 'se taq'),
	('Misho', 1, 1.78, 78.62, 'm', '1992-01-06', 'kvo da se zanimavam'),
	('Pencho', 2, 1.82, 86.41, 'm', '1995-10-20', 'mizeriya'),
	('Penka', 1, 1.71, 55.57, 'm', '1998-09-18', 'ne mi se zanimaava sq');