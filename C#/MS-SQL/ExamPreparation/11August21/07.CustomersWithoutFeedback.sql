USE Bakery
GO

SELECT 
	CONCAT(C.FirstName, ' ', C.LastName) AS [CustomerName],
	PhoneNumber,
	Gender
FROM Customers AS C
WHERE C.Id NOT IN (SELECT CustomerId FROM Feedbacks AS F)
ORDER BY C.Id ASC