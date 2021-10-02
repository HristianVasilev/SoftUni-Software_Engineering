USE [Geography]
GO

SELECT 
	COUNT(CountryCode) AS [Count]
FROM Countries
WHERE CountryCode NOT IN
	(SELECT DISTINCT CountryCode FROM MountainsCountries);