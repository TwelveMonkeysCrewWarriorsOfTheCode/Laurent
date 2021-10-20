CREATE PROCEDURE [dbo].[UserUpdate]
	@Id int,
	@Email VARCHAR(MAX),	
	@Name VARCHAR(50),
	@Phone VARCHAR(50),
	@IsOwner bit
AS
	UPDATE [Users] 
	SET [Email] = @Email, [Name] = @Name, [Phone] = @Phone, [IsOwner] = @IsOwner
	WHERE Id = @Id
