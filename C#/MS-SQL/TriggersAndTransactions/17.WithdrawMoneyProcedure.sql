USE Bank
GO

CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(20,4))
AS
BEGIN TRANSACTION
	IF(@accountId IS NULL OR NOT EXISTS(SELECT * FROM Accounts WHERE Id = @accountId))
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid account!', 16, 1 ) RETURN
	END

	IF(@moneyAmount IS NULL OR @moneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid amount of money!', 16, 1 ) RETURN
	END

	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @accountId
COMMIT