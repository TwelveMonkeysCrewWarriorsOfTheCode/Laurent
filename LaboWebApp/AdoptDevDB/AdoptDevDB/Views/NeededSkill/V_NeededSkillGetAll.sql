CREATE VIEW [dbo].[V_NeededSkillGetAll]
	AS 
		SELECT [Skills].[Name],[Skills].CategoryId,[NeededSkills].Id,[NeededSkills].SkillId, [NeededSkills].ContractId FROM NeededSkills
		JOIN [Skills] ON [Skills].Id = [NeededSkills].SkillId
