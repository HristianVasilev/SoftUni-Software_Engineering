USE [University]
GO

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
);

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY, 
	[StudentNumber] CHAR(10) NOT NULL,
	[StudentName] NVARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
);

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATETIME2 NOT NULL,
	[PaymentAmount] DECIMAL(15,2),
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
);

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY,
	[SubjectName] NVARCHAR(50)
);

CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),

	PRIMARY KEY ([StudentID], [SubjectID])
);