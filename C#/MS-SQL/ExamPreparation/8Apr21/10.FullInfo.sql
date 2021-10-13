USE [Service]
GO

SELECT
	CASE
		WHEN E.FirstName IS NULL AND E.LastName IS NULL THEN 'None'
		ELSE CONCAT(E.FirstName, ' ', E.LastName)
	END AS [Employee],
	CASE
		WHEN (SELECT [Name] FROM Departments D WHERE D.Id = E.DepartmentId) IS NULL THEN 'None'
		ELSE (SELECT [Name] FROM Departments D WHERE D.Id = E.DepartmentId)
	END AS [Department],
	(SELECT [Name] FROM Categories C WHERE R.CategoryId = C.Id) AS [Category],
	R.[Description],
	FORMAT(R.OpenDate, 'dd.MM.yyyy') AS [OpenDate],
	(SELECT Label FROM [Status] S WHERE R.StatusId = S.Id) AS [Status],
	(SELECT U.[Name] FROM Users U WHERE R.UserId = U.Id) AS [User]
FROM Reports R
LEFT JOIN Employees E ON R.EmployeeId = E.Id
ORDER BY E.FirstName DESC, E.LastName DESC, Department ASC, Category ASC, [Description] ASC, OpenDate ASC, [Status] ASC, [User] ASC
