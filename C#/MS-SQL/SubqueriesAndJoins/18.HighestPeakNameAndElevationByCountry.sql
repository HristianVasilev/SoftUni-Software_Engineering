USE [Geography]
GO

SELECT TOP(5)
	SUB.CountryName AS [Country],
	CASE
		WHEN SUB.PeakName IS NULL THEN '(no highest peak)' 
		ELSE SUB.PeakName
	END AS [Highest Peak Name],
	CASE
		WHEN SUB.Elevation IS NULL THEN 0
		ELSE SUB.Elevation
	END AS [Highest Peak Elevation],
	CASE 
		WHEN SUB.MountainRange IS NULL THEN '(no mountain)'
		ELSE SUB.MountainRange
	END AS [Mountain]
FROM
	(SELECT
		C.CountryName,
		DENSE_RANK() OVER (PARTITION BY C.CountryName ORDER BY P.Elevation DESC) AS		[ElevationRank],
		P.PeakName,
		P.Elevation,
		M.MountainRange
	FROM Countries C
	LEFT JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
	LEFT JOIN Peaks P ON P.MountainId = MC.MountainId
	LEFT JOIN Mountains M ON MC.MountainId = M.Id) AS SUB
WHERE SUB.[ElevationRank] = 1
ORDER BY SUB.CountryName ASC, SUB.PeakName ASC