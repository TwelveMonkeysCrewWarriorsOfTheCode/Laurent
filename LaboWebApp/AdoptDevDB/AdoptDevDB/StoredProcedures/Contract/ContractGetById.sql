CREATE PROCEDURE [dbo].[ContractGetById]
	@Id int
AS
	SELECT * FROM V_ContractGetAll WHERE Id = @Id

