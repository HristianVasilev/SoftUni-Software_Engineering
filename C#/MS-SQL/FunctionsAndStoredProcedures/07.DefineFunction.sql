USE SoftUni
GO

CREATE FUNCTION ufn_IsWordComprised
	(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT 
AS
BEGIN
	DECLARE @I INT = 1;
	DECLARE @letter CHAR(1);

	WHILE @I <= LEN(@word)
	BEGIN
		SET @letter = LOWER(SUBSTRING(@word, @I, 1))
		IF (CHARINDEX(@letter, @setOfLetters) = 0) RETURN 0;

		SET @I += 1;
	END

	RETURN 1
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')
