CREATE PROCEDURE [dbo].[NeededSkillUpdate]
	@Id int,
	@ContractId int,
	@SkillId int
AS
	UPDATE [NeededSkills]
	SET [SkillId] = @SkillId
	WHERE Id = @Id AND ContractId = @ContractId
