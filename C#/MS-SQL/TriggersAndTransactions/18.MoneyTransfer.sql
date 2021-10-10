USE Bank
GO

CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(20,4))
AS
BEGIN TRANSACTION
	EXEC dbo.usp_DepositMoney @receiverId, @amount
	EXEC dbo.usp_WithdrawMoney @senderId, @amount
COMMIT