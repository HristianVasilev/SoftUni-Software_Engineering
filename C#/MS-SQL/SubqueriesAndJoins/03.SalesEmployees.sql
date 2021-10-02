USE SoftUni
GO

SELECT
	E.EmployeeID,
	E.FirstName,
	E.LastName,
	D.[Name]
FROM Employees E
JOIN Departments D ON E.DepartmentID = D.DepartmentID
WHERE D.Name = 'Sales'
ORDER BY E.EmployeeID ASC;