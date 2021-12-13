CREATE PROCEDURE [dbo].[MemberLogin]
	@Email VARCHAR(MAX),
	@Password VARCHAR (50)
AS
	BEGIN
		DECLARE @Salt VARCHAR(100);
		SET @Salt = (SELECT Salt FROM Members Where Email = @Email)

		DECLARE @password_hash VARBINARY(64);
		SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Salt));

		SELECT Email, Id FROM Members WHERE Email Like @Email AND [Password] = @password_hash 
	END
