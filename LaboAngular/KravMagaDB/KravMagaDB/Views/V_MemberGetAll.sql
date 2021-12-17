CREATE VIEW [dbo].[V_MemberGetAll]
	AS SELECT [Members].[Id],[Email],[LastName],[FirstName],[BirthDay],[Adress],[Phone],[Subscription],
			  [LastDateSubscription],[AuthorisationID],
			  [RoleID],[BeltID],[Authorisations].[AuthorisationType],[Roles].[Role],[Belts].[BeltColor]
	FROM [Members]
	JOIN [Authorisations] ON AuthorisationID = Authorisations.Id
	JOIN [Roles] ON RoleID = Roles.Id
	JOIN [Belts] ON BeltID = Belts.Id