USE SoftUni
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Salary DECIMAL(18,4)
AS
BEGIN
	SELECT
		FirstName AS [First Name],
		LastName AS [Last Name]
	FROM Employees
	WHERE Salary >= @Salary
END
GO

EXEC usp_GetEmployeesSalaryAboveNumber @Salary = 48100;