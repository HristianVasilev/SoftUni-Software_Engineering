USE SoftUni
GO

SELECT TOP(3)
	E.EmployeeID,
	E.FirstName
FROM Employees E
WHERE E.EmployeeID NOT IN (SELECT EmployeeID FROM EmployeesProjects)
ORDER BY E.EmployeeID ASC