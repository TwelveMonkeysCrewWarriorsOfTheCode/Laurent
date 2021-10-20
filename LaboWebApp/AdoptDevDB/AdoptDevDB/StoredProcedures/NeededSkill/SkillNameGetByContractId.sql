CREATE PROCEDURE [dbo].[NeededSkillGetByContractId]
	@id int
AS
	SELECT * FROM V_NeededSkillGetAll
	WHERE ContractId = @Id
