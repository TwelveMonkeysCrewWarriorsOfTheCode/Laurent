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
/* For Authorizations */

INSERT INTO Authorisations ([AuthorisationType]) VALUES ('User')
INSERT INTO Authorisations ([AuthorisationType]) VALUES ('Admin')

/* For Belts */

INSERT INTO Belts([BeltColor]) VALUES ('Jaune')
INSERT INTO Belts([BeltColor]) VALUES ('Orange')
INSERT INTO Belts([BeltColor]) VALUES ('Vert')
INSERT INTO Belts([BeltColor]) VALUES ('Bleu')
INSERT INTO Belts([BeltColor]) VALUES ('Marron')
INSERT INTO Belts([BeltColor]) VALUES ('Noir')

/* For Roles */

INSERT INTO Roles ([Role]) VALUES ('Instructeur')
INSERT INTO Roles ([Role]) VALUES ('Assistant Instructeur')
INSERT INTO Roles ([Role]) VALUES ('Elèves')

/* For Members */
BEGIN
	DECLARE @Salt VARCHAR(100);
	SET @Salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @password_hash VARBINARY(64);
	SET @Password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, 'Admin1979', @Salt));
END	
INSERT INTO Members ([Email],[Password],[Salt],[LastName],[FirstName],[BirthDay],[Adress],[Phone],[AutorisationID]) VALUES ('jonxlaurent@gmail.com',@Password_hash,@Salt,'Jonxis','Laurent','1979-07-12','Rue de Bierset 74 4357 Jeneffe','0497/39.40.87',1)

BEGIN	
	SET @Salt = CONCAT(NEWID(), NEWID(), NEWID())

	SET @Password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, 'User1985', @Salt));
END	
INSERT INTO Members ([Email],[Password],[Salt],[LastName],[FirstName],[BirthDay],[Adress],[Phone],[AutorisationID]) VALUES ('coraliejuste@gmail.com',@Password_hash,@Salt,'Juste','Coralie','1985-07-04','Rue de Bierset 74 4357 Jeneffe','0489/28.80.37',2)