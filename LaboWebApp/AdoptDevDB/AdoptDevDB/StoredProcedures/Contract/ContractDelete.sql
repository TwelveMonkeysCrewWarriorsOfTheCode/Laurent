CREATE PROCEDURE [dbo].[ContractDelete]
	@Id int
AS
	DELETE FROM [Contracts] WHERE Id = @Id

