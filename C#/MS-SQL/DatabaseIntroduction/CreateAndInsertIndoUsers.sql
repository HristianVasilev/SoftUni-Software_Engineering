CREATE TABLE Users
(
	Id INT IDENTITY PRIMARY KEY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture DECIMAL(5,2),
	LastLoginTime DATETIME,
	IsDeleted BIT
);

INSERT INTO Users
VALUES
	('mincho','mincho666',55.87,'2020-12-10',0),
	('pencho','pencho666',55.87,'2020-12-10',0),
	('penka','penka666',88.74,'2020-12-10',1),
	('hindo','hindeto',874.58,'2020-12-10',0),
	('gergi','jorkata',514.98,'2020-12-10',1);
