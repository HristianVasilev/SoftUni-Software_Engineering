USE [Geography]
GO

SELECT TOP(5)
	SUB.CountryName,
	SUB.Elevation AS [HighestPeakElevation],
	SUB.[Length] AS [LongestRiverLength]
FROM
	(SELECT
		C.CountryName,
		P.[PeakName],
		DENSE_RANK() OVER (PARTITION BY C.CountryName ORDER BY P.Elevation DESC) AS [PeakRank],
		P.Elevation,
		DENSE_RANK() OVER (PARTITION BY C.CountryName ORDER BY R.[Length] DESC) AS [RiverRank],
		R.[Length]
	FROM Countries C 
	JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
	JOIN Peaks P ON MC.MountainId = P.MountainId
	JOIN CountriesRivers CR ON C.CountryCode = CR.CountryCode
	JOIN Rivers R ON CR.RiverId = R.Id) AS SUB
WHERE SUB.[PeakRank] = 1 AND SUB.[RiverRank] = 1
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, SUB.CountryName ASC
