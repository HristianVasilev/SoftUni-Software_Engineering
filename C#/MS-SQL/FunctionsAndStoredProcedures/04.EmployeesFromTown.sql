USE SoftUni
GO

--DECLARE @Town NVARCHAR(50)
--SET @Town = 'Sofia'

--SELECT
--	FirstName AS [First Name],
--	LastName AS [Last Name]
--FROM Employees E
--JOIN Addresses A ON E.AddressID = A.AddressID
--WHERE A.TownID  = (SELECT TownID FROM Towns WHERE [Name] = @Town)

CREATE PROCEDURE usp_GetEmployeesFromTown @Town NVARCHAR(50)
AS
BEGIN
	SELECT
		FirstName AS [First Name],
		LastName AS [Last Name]
	FROM Employees E
	JOIN Addresses A ON E.AddressID = A.AddressID
	WHERE A.TownID  = (SELECT TownID FROM Towns WHERE [Name] = @Town)
END
GO

EXEC usp_GetEmployeesFromTown @Town = 'Sofia'