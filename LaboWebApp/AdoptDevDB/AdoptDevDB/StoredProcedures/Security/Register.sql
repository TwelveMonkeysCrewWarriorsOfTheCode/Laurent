CREATE PROCEDURE [dbo].[Register]
	@Email VARCHAR(MAX),
	@Password VARCHAR (50),
	@Name VARCHAR(50),
	@Phone VARCHAR(50),
	@IsOwner BIT

AS
	BEGIN
		DECLARE @Salt VARCHAR(100);
		SET @Salt = CONCAT(NEWID(), NEWID(), NEWID())

		DECLARE @password_hash VARBINARY(64);
		SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Salt));
	END	
		INSERT INTO [Users] ([Email], [Password], [Salt], [Name], [Phone], [IsOwner])
		VALUES (@Email, @password_hash, @Salt, @Name, @Phone, @IsOwner)
