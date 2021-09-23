CREATE DATABASE SoftUni;
GO
USE SoftUni;
GO


--•	Towns (Id, Name)
CREATE TABLE Towns
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
);

--•	Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses
(
	Id INT IDENTITY PRIMARY KEY,
	AddressText NVARCHAR(80) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
);

--•	Departments (Id, Name)
CREATE TABLE Departments
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
);

--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(100) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATETIME NOT NULL,
	Salary MONEY NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id),

	CHECK (LEN(FirstName) >= 3),
	CHECK (LEN(MiddleName) >= 3),
	CHECK (LEN(LastName) >= 3),
	CHECK (LEN(JobTitle) >= 3),
	CHECK (Salary >= 0)
);