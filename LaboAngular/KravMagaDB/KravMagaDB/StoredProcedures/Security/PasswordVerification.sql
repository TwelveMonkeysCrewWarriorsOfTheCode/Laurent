CREATE PROCEDURE [dbo].[PasswordVerification]
	@Email VARCHAR(MAX),
	@Password VARCHAR(50)
AS	
	SELECT [Id],[Email],[LastName],[FirstName],[AutorisationID] 
	FROM V_GetForPasswordVerification 
	WHERE Email = @Email AND Password = HASHBYTES('SHA2_512', CONCAT(Salt, @Password, Salt))

	

