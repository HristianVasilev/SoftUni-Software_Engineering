USE Diablo
GO

SELECT
	U.Id,
	U.FirstName,
	G.[Name],
	UG.Cash
FROM UsersGames AS UG
JOIN Games AS G ON UG.GameId = G.Id
JOIN Users AS U ON UG.UserId = U.Id
WHERE U.FirstName = 'Stamat' AND G.[Name] = 'Safflower'

BEGIN TRANSACTION
GO

CREATE PROC usp_ForeachAll
AS
BEGIN

	DECLARE @itemsLength INT = 
	(SELECT COUNT(*) FROM Items WHERE MinLevel BETWEEN 11 AND 12 OR MinLevel BETWEEN 19 AND 21)

	DECLARE @counter INT = 1;

	WHILE @counter < @itemsLength
	BEGIN
		DECLARE @itemId INT = (SELECT t.Id FROM
									(SELECT ROW_NUMBER() OVER (ORDER BY Id) AS [RowNumber], Id 
									FROM Items 
									WHERE MinLevel BETWEEN 11 AND 12 
									OR MinLevel BETWEEN 19 AND 21) AS t
								WHERE t.[RowNumber] = @counter)
		


		SET @counter += 1					
	END
END