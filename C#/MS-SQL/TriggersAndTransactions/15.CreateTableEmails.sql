USE Bank
GO

CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT,
	[Subject] NVARCHAR(50),
	Body NVARCHAR(100)
);
GO

--ALTER TABLE NotificationEmails
--ALTER COLUMN [Subject] NVARCHAR(50)

--ALTER TABLE NotificationEmails
--ALTER COLUMN Body NVARCHAR(100)

--GO

--SELECT * FROM Logs

CREATE OR ALTER TRIGGER tr_NotificationsForLogs ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails
	SELECT 
		i.AccountId,
		CONCAT('Balance change for account: ', i.AccountId),
		CONCAT('On ', GETDATE(), ' your balance was changed from ', i.OldSum,' to ', i.NewSum, '.')  
	FROM inserted AS i
END

SELECT * FROM NotificationEmails