USE SoftUni
GO

SELECT TOP(5)
	EmployeeID,
	JobTitle,
	E.AddressID,
	AddressText
FROM Employees E
JOIN Addresses A ON E.AddressID = A.AddressID
ORDER BY A.AddressID ASC