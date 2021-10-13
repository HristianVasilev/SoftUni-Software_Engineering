USE [Service]
GO

SELECT
	[Description],
	(SELECT [Name] FROM Categories WHERE Reports.CategoryId = Categories.Id) AS [CategoryName]
FROM Reports
WHERE CategoryId IS NOT NULL
ORDER BY [Description] ASC, [CategoryName] ASC