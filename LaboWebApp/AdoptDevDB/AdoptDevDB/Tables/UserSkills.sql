CREATE TABLE [dbo].[UserSkills]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [SkillId] INT NOT NULL,
    CONSTRAINT [FK_USERS_USERSKILLS]FOREIGN KEY (UserId) REFERENCES [Users](Id),
    CONSTRAINT [FK_USERS_SKILLS]FOREIGN KEY (SkillId) REFERENCES [Skills](Id)
)
