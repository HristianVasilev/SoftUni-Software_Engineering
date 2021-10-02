USE SoftUni
GO

SELECT TOP(5)
	E.EmployeeID,
	E.FirstName,
	P.[Name]
FROM Employees E
JOIN EmployeesProjects EP ON E.EmployeeID = EP.EmployeeID
JOIN Projects P ON EP.ProjectID = P.ProjectID
WHERE P.StartDate > CONVERT(DATETIME2, '13.08.2002', 103) AND P.EndDate IS NULL
ORDER BY E.EmployeeID ASC