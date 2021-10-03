USE Gringotts
GO

SELECT * FROM
	(SELECT
		DepositGroup,
		SUM(DepositAmount) AS [TotalSum]
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup) AS SUB
WHERE SUB.[TotalSum] < 150000
ORDER BY SUB.[TotalSum] DESC