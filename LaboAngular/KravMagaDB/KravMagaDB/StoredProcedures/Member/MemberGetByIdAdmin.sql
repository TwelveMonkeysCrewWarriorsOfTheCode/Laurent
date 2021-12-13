CREATE PROCEDURE [dbo].[MemberGetByIdAdmin]
	@Id int

AS
	SELECT * FROM V_MemberGetAll WHERE Id = @Id
