CREATE PROCEDURE [dbo].[MemberUpdate]
	@Id int,
	@Email VARCHAR(MAX),	
	@LastName VARCHAR(50),
	@FirstName VARCHAR(50),
	@BirthDay DATETIME,
	@Adress VARCHAR(MAX),
	@Phone VARCHAR(50),
	@BeltId int
AS
	UPDATE [Members] 
	SET [Email] = @Email, [LastName] = @LastName, [FirstName] = @FirstName, [Birthday] = @Birthday, [Adress] = @Adress, [Phone] = @Phone, [BeltID] = @BeltId
	WHERE Id = @Id
	
	

            
