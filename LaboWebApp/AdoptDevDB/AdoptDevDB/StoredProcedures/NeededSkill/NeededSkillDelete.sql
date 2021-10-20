CREATE PROCEDURE [dbo].[NeededSkillDelete]
	@Id int
AS
	DELETE FROM [NeededSkills] WHERE Id = @Id

