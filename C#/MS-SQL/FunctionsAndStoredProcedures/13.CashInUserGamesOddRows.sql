USE Diablo
GO


CREATE OR ALTER FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN 
	SELECT SUM(F.Cash) AS [Cash sum] FROM
		(SELECT 
			ROW_NUMBER() OVER (ORDER BY Cash DESC) AS [RowNumber],
			Games.[Name] AS [GameName],
			UsersGames.Cash
		FROM UsersGames
		JOIN Games ON UsersGames.GameId = Games.Id
		WHERE Games.[Name] = @gameName) AS F
	WHERE F.RowNumber % 2 != 0
GO

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')