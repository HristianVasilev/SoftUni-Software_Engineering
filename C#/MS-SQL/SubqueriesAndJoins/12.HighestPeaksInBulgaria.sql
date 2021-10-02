USE [Geography]
GO

SELECT
	C.CountryCode,
	M.MountainRange,
	P.PeakName,
	P.Elevation
FROM Peaks P
JOIN Mountains M ON M.Id = P.MountainId
JOIN MountainsCountries MC ON M.Id = MC.MountainId
JOIN Countries C ON MC.CountryCode = C.CountryCode
WHERE P.Elevation > 2835 AND C.CountryCode = 'BG'
ORDER BY P.Elevation DESC