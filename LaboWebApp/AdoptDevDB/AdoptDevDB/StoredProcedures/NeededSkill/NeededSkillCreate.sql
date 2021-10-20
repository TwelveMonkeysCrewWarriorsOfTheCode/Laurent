CREATE PROCEDURE [dbo].[NeededSkillCreate]
	@ContractId int,
	@SkillId int
AS
	INSERT INTO [NeededSkills] (ContractId,SkillId)
	VALUES (@ContractId,@SkillId)
