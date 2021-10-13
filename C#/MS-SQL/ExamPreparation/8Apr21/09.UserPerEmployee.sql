USE [Service]
GO

SELECT
	[FullName],
	COUNT(X.UserId) AS [UsersCount]
FROM
	(SELECT
		CONCAT(E.FirstName, ' ', E.LastName) AS [FullName],
		R.UserId 
	FROM Employees E
	LEFT JOIN Reports R ON E.Id = R.EmployeeId) AS X
GROUP BY [FullName]
ORDER BY [UsersCount] DESC, [FullName] ASC