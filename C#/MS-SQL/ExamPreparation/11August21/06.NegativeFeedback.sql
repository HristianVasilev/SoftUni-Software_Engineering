USE Bakery
GO

SELECT
	F.ProductId,
	F.Rate,
	F.[Description],
	F.CustomerId,
	C.Age,
	C.Gender
FROM Feedbacks AS F
JOIN Customers AS C ON F.CustomerId = C.Id
WHERE Rate < 5
ORDER BY ProductId DESC, Rate ASC