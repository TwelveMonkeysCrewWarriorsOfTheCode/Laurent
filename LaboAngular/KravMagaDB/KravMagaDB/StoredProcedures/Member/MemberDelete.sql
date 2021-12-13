CREATE PROCEDURE [dbo].[MemberDelete]
	@Id int
AS
	UPDATE [Members] 
	SET [IsActif] = 0
	WHERE Id = @Id