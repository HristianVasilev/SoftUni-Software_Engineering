USE SoftUni
GO

SELECT
	EMP.EmployeeID,
	EMP.FirstName,
	EMP.ManagerID,
	(SELECT FirstName FROM Employees E WHERE E.EmployeeID = EMP.ManagerID) AS [ManagerName]
FROM Employees EMP
WHERE ManagerID IN (3, 7)
ORDER BY EmployeeID ASC