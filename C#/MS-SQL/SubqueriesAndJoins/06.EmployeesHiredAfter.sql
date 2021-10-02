USE SoftUni
GO

SELECT
	E.FirstName,
	E.LastName,
	E.HireDate,
	D.[Name]
FROM Employees E
JOIN Departments D ON E.DepartmentID = D.DepartmentID
WHERE D.[Name] IN ('Sales', 'Finance') AND E.HireDate > CONVERT(DATETIME, '1.1.1999')
ORDER BY E.HireDate ASC;