USE [Geography]
GO



SELECT TOP(5)
	C.CountryName,
	R.RiverName
FROM Countries C
LEFT JOIN CountriesRivers CR ON C.CountryCode = CR.CountryCode
LEFT JOIN Rivers R ON CR.RiverId = R.Id
WHERE ContinentCode IN (SELECT ContinentCode 
						FROM Continents 
						WHERE ContinentName = 'Africa')
ORDER BY C.CountryName