USE SoftUni
GO

SELECT TOP(10)
	FirstName,
	LastName,
	DepartmentID
FROM Employees AS E
WHERE E.Salary > (SELECT
					AVG(Salary) AS [AverageSalary]
				FROM Employees EAVGS
				WHERE E.DepartmentID = EAVGS.DepartmentID
				GROUP BY DepartmentID) 
ORDER BY DepartmentID