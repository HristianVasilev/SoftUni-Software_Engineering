USE SoftUni
GO

SELECT TOP(50)
	E.FirstName,
	E.LastName,
	T.[Name],
	A.AddressText
FROM Employees E
JOIN Addresses A ON E.AddressID = A.AddressID
JOIN Towns T ON A.TownID = T.TownID
ORDER BY E.FirstName ASC, E.LastName ASC