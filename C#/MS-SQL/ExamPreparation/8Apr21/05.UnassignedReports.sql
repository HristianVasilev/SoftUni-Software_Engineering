USE [Service]
GO

SELECT
	[Description], 
	FORMAT(OpenDate, 'dd-MM-yyyy') AS [Date]
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY [OpenDate] ASC, [Description] ASC