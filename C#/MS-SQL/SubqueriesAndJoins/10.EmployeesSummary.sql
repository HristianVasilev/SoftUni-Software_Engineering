USE SoftUni
GO

SELECT TOP(50)
	EMP.EmployeeID,
	CONCAT(EMP.FirstName, ' ', EMP.LastName) AS [EmployeeName],
	(SELECT 
			CONCAT(E.FirstName, ' ', E.LastName) 
		FROM Employees E
		WHERE E.EmployeeID = EMP.ManagerID) AS [ManagerName],
	(SELECT [Name] 
		FROM Departments D 
		WHERE EMP.DepartmentID = D.DepartmentID) AS [DepartmentName]
FROM Employees EMP
ORDER BY EMP.EmployeeID