USE Bakery
GO

SELECT
	FirstName,
	Age,
	PhoneNumber
FROM Customers
WHERE Age >= 21 AND FirstName LIKE '%an%' 
	OR 
	RIGHT(PhoneNumber, 2) = '38' AND CountryId != (SELECT C.Id FROM Countries AS C 
													WHERE C.[Name] = 'Greece')
ORDER BY FirstName ASC, AGE DESC