CREATE PROCEDURE [dbo].[MemberUpdateAdmin]
	@Id int,
	@Subscription BIT,
	@LastDateSubscription DATETIME,
	@AuthorisationID INT, 
    @RoleID INT, 
    @BeltID INT
AS
	UPDATE [Members]
	SET Subscription = @Subscription, LastDateSubscription = @LastDateSubscription, AuthorisationID = @AuthorisationID, RoleID = @RoleID, BeltID = @BeltID
	WHERE Id = @Id

