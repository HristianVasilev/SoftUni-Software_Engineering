CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@initialSum DECIMAL(15,2), @yearlyIntereseRate FLOAT(24), @years INT)
RETURNS DECIMAL(15,4)
AS
BEGIN
	RETURN CAST(@initialSum * (POWER((1 + @yearlyIntereseRate), @years)) AS decimal(15,4))
END
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)