USE Bank
GO

CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum DECIMAL(18,2),
	NewSum DECIMAL(18,2)
);

GO

CREATE OR ALTER TRIGGER tr_AccountChange ON Accounts
FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.AccountHolderId, d.Balance, i.Balance 
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance != d.Balance
END;

UPDATE Accounts
SET Balance += 1000
WHERE AccountHolderId = 1