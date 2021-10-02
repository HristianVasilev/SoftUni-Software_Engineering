USE SoftUni
GO

SELECT
	EMP.EmployeeID,
	EMP.FirstName,
	CASE
		WHEN DATEPART(YEAR, StartDate) >= 2005 THEN NULL
		ELSE ProjectName
	END AS [ProjectName]
FROM
	(SELECT
		EP.EmployeeID,
		(SELECT FirstName FROM Employees E WHERE E.EmployeeID = EP.EmployeeID) AS [FirstName],
		(SELECT [Name] FROM Projects P WHERE P.ProjectID = EP.ProjectID) AS [ProjectName],
		(SELECT StartDate FROM Projects P WHERE P.ProjectID = EP.ProjectID) AS StartDate
	FROM EmployeesProjects EP
	WHERE EmployeeID = 24) AS EMP
