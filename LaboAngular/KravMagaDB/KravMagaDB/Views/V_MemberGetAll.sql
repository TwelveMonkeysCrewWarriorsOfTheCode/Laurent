CREATE VIEW [dbo].[V_MemberGetAll]
	AS SELECT [Members].[Id],[Email],[LastName],[FirstName],[BirthDay],[Adress],[Phone],[Subscription],
			  [LastDateSubscription],[AutorisationID],
			  [RoleID],[BeltID],[Autorisations].[AutorisationType],[Roles].[Role],[Belts].[BeltColor]
	FROM [Members]
	JOIN [Autorisations] ON AutorisationID = Autorisations.Id
	JOIN [Roles] ON RoleID = Roles.Id
	JOIN [Belts] ON BeltID = Belts.Id