USE SoftUni
GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel @SalaryLevel VARCHAR(7)
AS
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
END
GO

EXEC usp_EmployeesBySalaryLevel @SalaryLevel = 'High'