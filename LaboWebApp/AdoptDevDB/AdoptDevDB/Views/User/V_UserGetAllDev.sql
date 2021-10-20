CREATE VIEW [dbo].[V_UserGetAllDev]
	AS SELECT [Users].Id, [Users].Email, [Users].Phone, [Users].IsOwner,
	[Skills].[Name],[Skills].[Description],
	[Categories].[Name] AS CategoryName, [Contracts].Description AS ContractDescription
	FROM [Users]
	JOIN [UserSkills] ON [Users].Id = [UserSkills].UserId
	JOIN [Skills] ON [UserSkills].SkillId = [Skills].Id
	JOIN [Categories] ON [Skills].CategoryId = [Categories].Id
	JOIN [Contracts] ON [Users].Id = [Contracts].DevId
