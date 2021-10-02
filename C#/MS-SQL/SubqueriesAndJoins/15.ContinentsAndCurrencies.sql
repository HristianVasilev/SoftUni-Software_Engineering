USE [Geography]
GO

SELECT
	SUB.ContinentCode,
	SUB.CurrencyCode,
	SUB.CurrencyUsage
FROM
	(SELECT 
		[COUNT].ContinentCode,
		[COUNT].CurrencyCode,
		COUNT(CurrencyCode) AS [CurrencyUsage],
		DENSE_RANK() OVER (PARTITION BY [COUNT].ContinentCode ORDER BY COUNT	([COUNT].CurrencyCode) DESC) AS [RANK]
	FROM Countries AS [COUNT]
	JOIN Continents AS [CONT] ON [CONT].ContinentCode = [COUNT].ContinentCode
	GROUP BY [COUNT].ContinentCode, [COUNT].CurrencyCode) AS SUB
WHERE SUB.[RANK] = 1 AND SUB.CurrencyUsage != 1
ORDER BY SUB.ContinentCode;