USE Gringotts
GO

SELECT TOP(2)
	DepositGroup 
FROM 
	(SELECT 
		DepositGroup,
		AVG(MagicWandSize) [AverageMagicWandSize]
	FROM WizzardDeposits
	GROUP BY DepositGroup
	) AS SUB
ORDER BY SUB.[AverageMagicWandSize];