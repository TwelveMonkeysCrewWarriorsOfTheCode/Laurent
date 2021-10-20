CREATE PROCEDURE [dbo].[ContractUpdate]
	@Id int,
	@Description VARCHAR(MAX),	
	@Price float,
	@DeadLine DATE,
	@DevId int
AS
	UPDATE [Contracts]
	SET [Description] = @Description, [Price] = @Price, [DeadLine] = @DeadLine, [DevId] = @DevId	
	WHERE Id = @Id
