CREATE PROCEDURE [dbo].[MemberRegister]
	@Email VARCHAR(MAX),
	@Password VARCHAR (50),
	@LastName VARCHAR(50),
	@FirstName VARCHAR(50),
	@BirthDay DATETIME,
	@Adress VARCHAR(MAX),
	@Phone VARCHAR(50)

AS
	BEGIN
		DECLARE @Salt VARCHAR(100);
		SET @Salt = CONCAT(NEWID(), NEWID(), NEWID())

		DECLARE @password_hash VARBINARY(64);
		SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Salt));
	END	
		INSERT INTO Members ([Email], [Password], [Salt], [LastName], [FirstName], [BirthDay], [Adress], [Phone])
		VALUES (@Email, @password_hash, @Salt, @LastName, @FirstName, @BirthDay, @Adress, @Phone)

		SELECT Id, Email, LastName, FirstName, AuthorisationID FROM [Members] WHERE Id =  SCOPE_IDENTITY()
	

