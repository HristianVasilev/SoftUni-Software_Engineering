USE Bakery
GO



BEGIN TRANSACTION

CREATE TRIGGER tr_DeleteProduct ON Products
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @Id INT = (SELECT Id FROM deleted)

	DELETE FROM Feedbacks
	WHERE ProductId = @Id
	
	DELETE FROM ProductsIngredients
	WHERE ProductId = @Id

	DELETE FROM Products WHERE Id = @Id
END

GO

DELETE FROM Products WHERE Id = 7


ROLLBACK
