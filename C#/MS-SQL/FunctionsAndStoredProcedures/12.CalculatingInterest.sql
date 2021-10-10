USE Bank
GO

CREATE OR ALTER PROC 
	usp_CalculateFutureValueForAccount (@accountID INT, @yearlyIntereseRate FLOAT(24))
AS
BEGIN
	SELECT
		A.Id AS [Account Id],
		AH.FirstName,
		AH.LastName,
		A.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(A.Balance, @yearlyIntereseRate, 5) AS [Balance in 5 years]
	FROM Accounts AS A
	JOIN AccountHolders AH ON A.Id = AH.Id
	WHERE A.Id = @accountID
END
GO

EXEC usp_CalculateFutureValueForAccount @accountID = 1, @yearlyIntereseRate = 0.1