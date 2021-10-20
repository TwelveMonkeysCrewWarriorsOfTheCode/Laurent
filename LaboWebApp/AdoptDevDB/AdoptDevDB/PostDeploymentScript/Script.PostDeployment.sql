/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* For Categories */

INSERT INTO Categories ([Name])
VALUES ('Backend')

INSERT INTO Categories ([Name])
VALUES ('Frontend')

INSERT INTO Categories ([Name])
VALUES ('Base de données')

/* For Skills */

INSERT INTO Skills ([Name],[Description],CategoryId)
VALUES ('C#','Langage de programmation orientée objet, commercialisé par Microsoft depuis 2002 et destiné à développer sur la plateforme Microsoft .NET',1)

INSERT INTO Skills ([Name],[Description],CategoryId)
VALUES ('C++','Langage de programmation compilé permettant la programmation sous de multiples paradigmes, dont la programmation procédurale, la programmation orientée objet et la programmation générique',1)

INSERT INTO Skills ([Name],[Description],CategoryId)
VALUES ('C','Langage de programmation impératif généraliste, de bas niveau. Inventé au début des années 1970 pour réécrire Unix',1)

INSERT INTO Skills ([Name],[Description],CategoryId)
VALUES ('Java','Langage de programmation orienté objet créé par James Gosling et Patrick Naughton, employés de Sun Microsystems',1)

INSERT INTO Skills ([Name],[Description],CategoryId)
VALUES ('SQL','Langage de requête structurée est un langage informatique normalisé servant à exploiter des bases de données relationnelles',3)

INSERT INTO Skills ([Name],[Description],CategoryId)
VALUES ('Angular','communément appelé Angular 2 ou Angular v2 et plus est un framework côté client, open source, basé sur TypeScript',2)

INSERT INTO Skills ([Name],[Description],CategoryId)
VALUES ('NodeJs','Plateforme logicielle libre en JavaScript, orientée vers les applications réseau évènementielles hautement concurrentes qui doivent pouvoir monter en charge',2)

INSERT INTO Skills ([Name],[Description],CategoryId)
VALUES ('Microsoft Visual Studio','logiciels de développement pour Windows et mac OS conçue par Microsoft',1)

/* For Users */
BEGIN
	DECLARE @Salt VARCHAR(100);
	SET @Salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @password_hash VARBINARY(64);
	SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, 'Lo8671jo!', @Salt));
END	
	INSERT INTO [Users] ([Email], [Password], [Salt], [Name], [Phone], [IsOwner])
	VALUES ('jonxlaurent@gmail.com', @password_hash, @Salt, 'Laurent', '0497/39.40.87', 'false')

BEGIN
	/*DECLARE @Salt VARCHAR(100);*/
	SET @Salt = CONCAT(NEWID(), NEWID(), NEWID())

	/*DECLARE @password_hash VARBINARY(64);*/
	SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, 'Alchemie1985!', @Salt));
END	
	INSERT INTO [Users] ([Email], [Password], [Salt], [Name], [Phone], [IsOwner])
	VALUES ('coraliejuste@gmail.com', @password_hash, @Salt, 'Coralie', '0471/70.17.48', 'true')

/* For UserSkills */
INSERT INTO [UserSkills] ([SkillId],[UserId])
VALUES (1,1)

INSERT INTO [UserSkills] ([SkillId],[UserId])
VALUES (5,1)

INSERT INTO [UserSkills] ([SkillId],[UserId])
VALUES (6,1)

INSERT INTO [UserSkills] ([SkillId],[UserId])
VALUES (3,1)

INSERT INTO [UserSkills] ([SkillId],[UserId])
VALUES (2,1)

/* For contract */
INSERT INTO Contracts ([Description],[Price],[DeadLine],[OwnerId],[DevId])
VALUES ('Faire un programme',200.50,'2022-12-31',2,1)

INSERT INTO Contracts ([Description],[Price],[DeadLine],[OwnerId])
VALUES ('Faire un autre programme',240.75,'2022-07-30',2)

/* For NeededSkills */

INSERT INTO NeededSkills ([ContractId],[SkillId])
VALUES (1,1)

INSERT INTO NeededSkills ([ContractId],[SkillId])
VALUES (1,5)

INSERT INTO NeededSkills ([ContractId],[SkillId])
VALUES (1,6)

INSERT INTO NeededSkills ([ContractId],[SkillId])
VALUES (2,4)

INSERT INTO NeededSkills ([ContractId],[SkillId])
VALUES (2,5)

INSERT INTO NeededSkills ([ContractId],[SkillId])
VALUES (2,6)