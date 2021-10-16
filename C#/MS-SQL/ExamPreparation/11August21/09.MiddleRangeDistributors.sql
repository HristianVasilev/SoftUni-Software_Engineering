USE Bakery
GO

SELECT * FROM
	(SELECT
		D.[Name] AS [DistributorName],
		I.[Name] AS [IngredientName],
		P.[Name] AS [ProductName],
		AVG(F.Rate) AS [AverageRate]
	FROM Distributors AS D
	JOIN Ingredients AS I ON I.DistributorId = D.Id
	JOIN ProductsIngredients AS P_I ON I.Id = P_I.IngredientId
	JOIN Products AS P ON P.Id = P_I.ProductId
	JOIN Feedbacks AS F ON F.ProductId = P.Id
	GROUP BY  D.[Name], I.[Name], P.[Name]) AS SUB
WHERE [AverageRate] BETWEEN 5 AND 8
ORDER BY [DistributorName] ASC, [IngredientName] ASC, [ProductName] ASC 
