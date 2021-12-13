CREATE PROCEDURE [dbo].[MemberUpdateAdmin]
	@Id int,
	@Subscription BIT,
	@LastDateSubscription DATETIME,
	@AutorisationID INT, 
    @RoleID INT, 
    @BeltID INT
AS
	UPDATE [Members]
	SET Subscription = @Subscription, LastDateSubscription = @LastDateSubscription, AutorisationID = @AutorisationID, RoleID = @RoleID, BeltID = @BeltID
	WHERE Id = @Id

