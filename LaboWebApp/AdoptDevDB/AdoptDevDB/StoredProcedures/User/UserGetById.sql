CREATE PROCEDURE [dbo].[UserGetById]
	@id int
AS
	SELECT * FROM V_UserGetAllSimple WHERE Id = @id

