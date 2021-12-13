CREATE PROCEDURE [dbo].[BeltUpdate]
	@Id int,
	@BeltColor VARCHAR(50)
AS
	UPDATE Belts SET [BeltColor] = @BeltColor WHERE Id = @Id
