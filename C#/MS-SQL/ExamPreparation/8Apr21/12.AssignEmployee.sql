USE [Service]
GO

SELECT * FROM Reports
GO

CREATE OR ALTER PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
BEGIN
	DECLARE @D1 INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId);
	DECLARE @D2 INT = (SELECT C.DepartmentId FROM Reports R JOIN Categories C ON R.CategoryId = C.Id WHERE R.Id = @ReportId)
	
	IF (@D1 != @D2)
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 17, 1)
		RETURN
	END

	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
END;

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2