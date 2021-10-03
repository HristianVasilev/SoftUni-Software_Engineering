USE Gringotts
GO

SELECT
	SUM(SUB.[DIFF]) AS [SumDifference]
FROM
	(SELECT F.DepositAmount - (SELECT S.DepositAmount 
								FROM WizzardDeposits S 
								WHERE S.Id = F.Id +	1) AS [DIFF]
	FROM WizzardDeposits F) AS SUB;