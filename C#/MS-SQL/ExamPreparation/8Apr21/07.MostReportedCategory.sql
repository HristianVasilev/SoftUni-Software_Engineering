USE [Service]
GO

SELECT TOP(5)
	C.[Name] AS [CategoryName],
	COUNT(CategoryId) AS [ReportsNumber]
FROM Reports AS R
JOIN Categories AS C ON R.CategoryId = C.Id
GROUP BY C.[Name], CategoryId
ORDER BY [ReportsNumber] DESC, [CategoryName] ASC