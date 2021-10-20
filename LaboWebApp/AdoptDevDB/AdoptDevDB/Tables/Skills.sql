﻿CREATE TABLE [dbo].[Skills]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_SKILL_CATEGORIES]FOREIGN KEY (CategoryId) REFERENCES [Categories](Id)
)
