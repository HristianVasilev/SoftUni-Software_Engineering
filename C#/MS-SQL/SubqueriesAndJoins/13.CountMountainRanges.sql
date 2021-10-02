USE [Geography]
GO

SELECT
	CountryCode,
	COUNT(CountryCode) AS [MountainRanges]
FROM
	(SELECT
		CountryCode 
	FROM MountainsCountries
	WHERE CountryCode IN ('US', 'BG', 'RU')) AS MOUNTAINS
GROUP BY CountryCode