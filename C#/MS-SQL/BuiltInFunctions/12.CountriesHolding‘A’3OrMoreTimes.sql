USE [Geography]
GO

SELECT
	CountryName,
	IsoCode
FROM Countries
WHERE (LEN(CountryName) - LEN(REPLACE(LOWER(CountryName),'a',''))) >= 3
ORDER BY IsoCode;