CREATE PROCEDURE [dbo].[SkillGetById]
	@Id int
AS
	SELECT * FROM V_SkillGetAll
	WHERE Id = @Id

