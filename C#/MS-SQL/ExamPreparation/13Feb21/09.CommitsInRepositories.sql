USE Bitbucket
GO


SELECT
	R.Id,
	R.[Name],
	COUNT(C.Id) AS [Commits]
FROM Repositories AS R
JOIN Commits AS C ON R.Id = C.RepositoryId
GROUP BY R.Id, R.[Name]
ORDER BY [Commits] DESC, R.Id ASC, R.[Name] ASC

