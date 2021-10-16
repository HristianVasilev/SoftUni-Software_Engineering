USE Bakery
GO

BEGIN TRANSACTION

CREATE VIEW v_UserWithCountries AS
SELECT
	CONCAT(Customers.FirstName, ' ', Customers.LastName) AS [CustomerName],
	Customers.Age,
	Customers.Gender,
	Countries.[Name]
FROM Customers
JOIN Countries ON Customers.CountryId = Countries.Id

ROLLBACK