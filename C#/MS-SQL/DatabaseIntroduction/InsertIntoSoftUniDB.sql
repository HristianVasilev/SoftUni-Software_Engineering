USE SoftUni;

GO

--•	Towns: Sofia, Plovdiv, Varna, Burgas
INSERT INTO Towns
VALUES 
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas');

--•	Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance
INSERT INTO Departments
VALUES 
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance');

--•	Employees:
--Name						Job Title			Department				Hire Date		Salary
--Ivan Ivanov Ivanov		.NET Developer		Software Development	01/02/2013		3500.00
--Petar Petrov Petrov		Senior Engineer		Engineering				02/03/2004		4000.00
--Maria Petrova Ivanova		Intern				Quality Assurance		28/08/2016		525.25
--Georgi Teziev Ivanov		CEO					Sales					09/12/2007		3000.00
--Peter Pan Pan				Intern				Marketing				28/08/2016		599.88
INSERT INTO Employees
VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, CONVERT(DATETIME,'02/03/2004', 103), 3500.00, NULL),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, CONVERT(DATETIME,'02/03/2004', 103), 4000.00, NULL),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, CONVERT(DATETIME,'28/08/2016', 103), 525.25, NULL),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, CONVERT(DATETIME,'09/12/2007', 103), 3000.00, NULL),
	('Peter', 'Pan', 'Pan', 'Intern', 3, CONVERT(DATETIME,'28/08/2016', 103), 599.88, NULL);
