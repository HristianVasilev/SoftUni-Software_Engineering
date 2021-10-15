USE [Bitbucket]
GO

CREATE OR ALTER FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*) FROM Commits
			WHERE ContributorId = (SELECT Id FROM Users AS U WHERE U.Username = @username))
END;
GO
SELECT dbo.udf_AllUserCommits('UnderSinduxrein')