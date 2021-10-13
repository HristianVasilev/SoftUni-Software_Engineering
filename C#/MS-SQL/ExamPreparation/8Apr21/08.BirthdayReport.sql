USE [Service]
GO

SELECT
	U.[Username],
	C.[Name]
FROM Reports AS R
JOIN Users AS U ON R.UserId = U.Id
JOIN Categories C ON R.CategoryId = C.Id
WHERE DAY(R.OpenDate) = DAY(U.Birthdate) AND MONTH(R.OpenDate) = MONTH(U.Birthdate)
ORDER BY U.Username ASC , C.[Name] ASC