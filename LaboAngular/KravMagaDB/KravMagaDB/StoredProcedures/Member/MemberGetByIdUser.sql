CREATE PROCEDURE [dbo].[MemberGetByIdUser]
	@Id int 
AS
	SELECT Id,Email,LastName,FirstName,BirthDay,Adress,Phone,Subscription,BeltColor 
	FROM V_MemberGetAll
	WHERE Id = @Id

