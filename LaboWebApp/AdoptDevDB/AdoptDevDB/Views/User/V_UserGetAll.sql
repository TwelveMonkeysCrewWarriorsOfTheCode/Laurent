CREATE VIEW [dbo].[V_UserGetAll]
	AS SELECT [Users].Id, [Users].Email, [Users].Phone, [Users].IsOwner,
	[Skills].[Name],[Skills].[Description],
	[Categories].[Name] AS CategoryName, cDev.Description AS ContractDescription
	FROM [Users]
	JOIN [UserSkills] ON [Users].Id = [UserSkills].UserId
	JOIN [Skills] ON [UserSkills].SkillId = [Skills].Id
	JOIN [Categories] ON [Skills].CategoryId = [Categories].Id
	JOIN [Contracts] AS cDev ON [Users].Id = cDev.DevId
	JOIN [Contracts] AS cOwner ON [Users].Id = cOwner.OwnerId
