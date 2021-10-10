USE Bank
GO

CREATE PROC usp_GetHoldersFullName 
AS
BEGIN
	SELECT CONCAT(AH.FirstName, ' ', AH.LastName) AS [Full Name]
	FROM AccountHolders AS AH
END
GO

EXEC usp_GetHoldersFullName;