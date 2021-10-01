USE Example
GO

--DROP TABLE [StudentsExams]
--DROP TABLE [Students]
--DROP TABLE [Exams]

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50)
);

CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(100,1),
	[Name] NVARCHAR(50)
);

CREATE TABLE [StudentsExams](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]) NOT NULL
	
	PRIMARY KEY ([StudentID], [ExamID]) 
);

INSERT INTO [Students]
VALUES	('Mila'),                                     
		('Toni'),
		('Ron');

SET IDENTITY_INSERT [Exams] ON

INSERT INTO [Exams] ([ExamID], [Name])
VALUES	(101,'SpringMVC'),
		(102,'Neo4j'),
		(103,'Oracle 11g');

INSERT INTO [StudentsExams]
VALUES	(1,	101),
		(1,	102),
		(2,	101),
		(3,	103),
		(2,	102),
		(2,	103);