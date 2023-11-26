USE [PastExamsHub]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [Uid]) VALUES (1, N'umarkovic864@gmail.com', N'Uros', N'Markovic', 2, 16690, 4, 1, N'uros')
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [Uid]) VALUES (3, N'valenejkovic@gmail.com', N'Valentina', N'Nejkovic', 1, null, null, 2, N'valentina')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
