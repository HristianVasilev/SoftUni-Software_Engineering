USE [Service]
GO

CREATE TABLE Users
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] NVARCHAR(50),
	[Password] NVARCHAR(50),
	[Name] NVARCHAR(50),
	[Birthdate] DATETIME,
	[Age] INT,
	[Email] VARCHAR(100)
);

CREATE TABLE Departments
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50)
);

CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[Birthdate] DATETIME,
	[Age] INT,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id])
);

CREATE TABLE Categories
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50),
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id])
);

CREATE TABLE [Status]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Label] NVARCHAR(100),
);

CREATE TABLE Reports
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[StatusId] INT FOREIGN KEY REFERENCES [Status]([Id]),
	[OpenDate] DATETIME,
	[CloseDate] DATETIME,
	[Description] VARCHAR(100),
	[UserId] INT FOREIGN KEY REFERENCES [Users]([Id]),
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id])
);