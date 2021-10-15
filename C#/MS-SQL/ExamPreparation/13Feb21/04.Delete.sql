USE Bitbucket
GO


DELETE FROM RepositoriesContributors
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Files 
WHERE CommitId IN (SELECT C.Id FROM Commits AS C 
					JOIN Repositories AS R ON C.RepositoryId = R.Id
					WHERE R.[Name] = 'Softuni-Teamwork')

DELETE FROM Commits 
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')


DELETE FROM Repositories WHERE [Name] = 'Softuni-Teamwork'