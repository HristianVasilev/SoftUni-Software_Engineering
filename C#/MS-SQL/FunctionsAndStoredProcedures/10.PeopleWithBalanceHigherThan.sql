USE Bank
GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan @balance DECIMAL(15,2)
AS
BEGIN
	SELECT
		AH.FirstName,
		AH.LastName
	FROM AccountHolders AS AH
	JOIN Accounts AS A ON AH.Id = A.AccountHolderId
	GROUP BY AH.FirstName, AH.LastName
	HAVING SUM(A.Balance) > @balance	
	ORDER BY AH.FirstName, AH.LastName
END
GO

EXEC usp_GetHoldersWithBalanceHigherThan @balance = 5000000;