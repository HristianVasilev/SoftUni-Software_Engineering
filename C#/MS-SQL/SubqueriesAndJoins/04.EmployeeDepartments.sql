USE SoftUni
GO

SELECT TOP(5)
	E.EmployeeID,
	E.FirstName,
	E.Salary,
	D.[Name]
FROM Employees E
JOIN Departments D ON E.DepartmentID = D.DepartmentID
WHERE E.Salary > 15000
ORDER BY D.DepartmentID