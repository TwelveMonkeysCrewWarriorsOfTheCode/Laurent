CREATE PROCEDURE [dbo].[CategoryGetById]
	@id int
AS
	SELECT * FROM V_CategoryGetAll WHERE Id = @id
