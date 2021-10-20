CREATE PROCEDURE [dbo].[ContractCreate]
	@Description VARCHAR(MAX),
	@Price FLOAT,
	@DeadLine DATE,
	@OwnerId INT,
	@DevId INT
AS
	INSERT INTO [Contracts] ([Description],[Price],[DeadLine],[OwnerId],[DevId])
	VALUES(@Description,@Price,@DeadLine,@OwnerId,@DevId)
	SELECT * FROM [Contracts] WHERE Id =  SCOPE_IDENTITY()