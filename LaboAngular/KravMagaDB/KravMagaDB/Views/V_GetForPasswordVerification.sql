CREATE VIEW [dbo].[V_GetForPasswordVerification]
	AS 
	SELECT [Id],[Email],[Password],[Salt],[LastName],[FirstName],[BirthDay],[Adress],[Phone],
		   [AutorisationID],[BeltID],[RoleID]
	FROM [Members]
