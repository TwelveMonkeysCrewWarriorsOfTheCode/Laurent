CREATE PROCEDURE [dbo].[UserDelete]
	@Id int
AS
	DELETE FROM [Users] WHERE Id = @Id
