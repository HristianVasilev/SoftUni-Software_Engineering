USE Bitbucket
GO

SELECT F.Id, F.[Name], CONCAT(F.Size,'KB') AS Size FROM Files AS F
WHERE F.Id NOT IN (SELECT DISTINCT P.ParentId FROM Files AS P WHERE P.ParentId IS NOT NULL)   