USE SoftUni
GO

SELECT  
	 DepartmentID,
	 Salary
FROM (SELECT DISTINCT
			DepartmentID,
			Salary,
			DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
		FROM Employees) AS SUB
WHERE [Rank] = 3