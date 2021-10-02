USE SoftUni
GO

SELECT 
	EmployeeID,
	FirstName,
	LastName,
	Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID ASC) AS Rank
FROM Employees 
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC
