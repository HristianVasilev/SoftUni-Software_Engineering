USE SoftUni
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS 
BEGIN
	DECLARE @result VARCHAR(7)

	IF @salary < 30000 SET @result = 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000 SET @result = 'Average'
	ELSE SET @result = 'High'

    RETURN @result
END
GO

SELECT dbo.ufn_GetSalaryLevel(5)