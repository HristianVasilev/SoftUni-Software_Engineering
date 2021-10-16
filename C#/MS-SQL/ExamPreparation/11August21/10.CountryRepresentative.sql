USE Bakery
GO

SELECT 
	[CountryName],
	[DistributorName]
FROM
	(SELECT	
		RANK() OVER (PARTITION BY C.[Name] ORDER BY COUNT(I.Id) DESC) AS [Rank],
		C.[Name] AS [CountryName],
		D.[Name] AS [DistributorName],
		COUNT(I.Id) AS [CountOfIngredients]
	FROM Countries AS C
	LEFT JOIN Distributors AS D ON C.Id = D.CountryId
	LEFT JOIN Ingredients AS I ON I.DistributorId = D.Id
GROUP BY C.[Name], D.[Name]) AS SUB
WHERE [Rank] = 1
ORDER BY [CountryName], [DistributorName]
