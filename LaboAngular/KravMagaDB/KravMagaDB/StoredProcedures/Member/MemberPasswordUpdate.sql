CREATE PROCEDURE [dbo].[MemberPasswordUpdate]
	@Email VARCHAR(MAX),
	@Password VARCHAR (50)
AS
	BEGIN
		DECLARE @Salt VARCHAR(100);
		SET @Salt = CONCAT(NEWID(), NEWID(), NEWID())

		DECLARE @password_hash VARBINARY(64);
		SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Salt));
		
		UPDATE Members SET [Password] = @password_hash, Salt = @Salt WHERE Email Like @Email
	END
