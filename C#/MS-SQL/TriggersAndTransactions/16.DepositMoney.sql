USE Bank
GO

CREATE PROC usp_DepositMoney (@accountId INT , @moneyAmount DECIMAL(20,4)) 
AS
BEGIN TRANSACTION
	IF (@moneyAmount IS NULL OR @moneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money!', 16, 1)
		RETURN
	END

	IF @accountId IS NULL OR NOT EXISTS (SELECT * FROM Accounts WHERE AccountHolderId = @accountId) 
	BEGIN
		ROLLBACK
		RAISERROR('Invalid accountId!', 16, 1)
		RETURN
	END

	UPDATE Accounts
	SET Balance = Balance + @moneyAmount
	WHERE Id = @accountId
COMMIT