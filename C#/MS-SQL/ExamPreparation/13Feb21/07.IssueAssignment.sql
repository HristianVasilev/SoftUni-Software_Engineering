USE Bitbucket
GO

SELECT
	I.Id,
	CONCAT(U.Username, ' : ', I.Title) AS [IssueAssignee]
FROM Issues AS I
JOIN Users AS U ON I.AssigneeId = U.Id
ORDER BY I.Id DESC, [IssueAssignee] ASC