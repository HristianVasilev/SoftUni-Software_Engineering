USE SoftUni
GO

--DECLARE @FirstLetter NVARCHAR(50)
--SET @FirstLetter = 'M'

--SELECT
--	[Name],
--	LEFT([Name],LEN(@FirstLetter))
--FROM Towns
--WHERE LEFT([Name],LEN(@FirstLetter)) = @FirstLetter

CREATE PROCEDURE usp_GetTownsStartingWith @FirstLetter NVARCHAR(50)
AS
BEGIN
	SELECT
		[Name] AS [Town]
	FROM Towns
	WHERE LEFT([Name],LEN(@FirstLetter)) = @FirstLetter
END
GO

EXEC usp_GetTownsStartingWith @FirstLetter = 'b'