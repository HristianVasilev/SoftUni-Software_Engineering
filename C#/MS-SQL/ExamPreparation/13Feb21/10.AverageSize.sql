USE [Bitbucket]
GO

SELECT
	U.Username,
	AVG(F.Size) AS [Size]
FROM Users AS U
JOIN Commits AS C ON U.Id = C.ContributorId
JOIN Files AS F ON C.Id = F.CommitId
GROUP BY U.Username
ORDER BY [Size] DESC, U.Username ASC