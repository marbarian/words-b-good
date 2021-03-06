/****** Object:  Table [dbo].[Categories]    Script Date: 3/2/2014 10:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](max) NULL,
	[User_UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/2/2014 10:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Online] [bit] NOT NULL,
	[Permission] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Vocabs]    Script Date: 3/2/2014 10:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vocabs](
	[VocabId] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](max) NOT NULL,
	[Definition] [nvarchar](max) NOT NULL,
	[Category_CategoryId] [int] NOT NULL,
	[UsedDate] [datetime] NOT NULL,
	[EtyLink] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Vocabs] PRIMARY KEY CLUSTERED 
(
	[VocabId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Subject], [User_UserId]) VALUES (1, N'WordOfTheDay', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Name], [Password], [Email], [Online], [Permission]) VALUES (1, N'Marian', N'marian', N'marian@gmail.com', 0, N'Admin')
INSERT [dbo].[Users] ([UserId], [Name], [Password], [Email], [Online], [Permission]) VALUES (2, N'Bob', N'bob', N'bob@gmail.com', 1, N'Registered')
INSERT [dbo].[Users] ([UserId], [Name], [Password], [Email], [Online], [Permission]) VALUES (4, N'Felicia', N'felicia', N'felicia@gmail.com', 1, N'Registered')
INSERT [dbo].[Users] ([UserId], [Name], [Password], [Email], [Online], [Permission]) VALUES (5, N'Mandy', N'mandy', N'mandy@gmail.com', 0, N'Registered')
INSERT [dbo].[Users] ([UserId], [Name], [Password], [Email], [Online], [Permission]) VALUES (16, N'Marian', NULL, N'marian@gmail.com', 0, NULL)
INSERT [dbo].[Users] ([UserId], [Name], [Password], [Email], [Online], [Permission]) VALUES (17, N'Marian', N'marian', N'marian@gmail.com', 0, N'Admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Vocabs] ON 

INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (1, N'Oligarchy', N'form of government in which the supreme power is placed in the hands of a small, exclusive group', 1, CAST(0x0000A2E200000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (2, N'Shoal', N'a large group or crowd', 1, CAST(0x0000A2E300000000 AS DateTime), NULL, N'adj')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (3, N'Rhapsodize', N'to speak or write in a very enthusiastic manner', 1, CAST(0x0000A2E400000000 AS DateTime), NULL, N'v')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (4, N'Innocuous', N'harmless; dull; innocent', 1, CAST(0x0000A2E500000000 AS DateTime), NULL, N'adj')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (13, N'Incorrigible', N'not capable of correction or improvement', 1, CAST(0x0000A2E600000000 AS DateTime), NULL, N'adj')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (14, N'Debauchery', N'indulgence in one''s appetites', 1, CAST(0x0000A2E700000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (15, N'Fledgling', N'inexperienced person; beginner', 1, CAST(0x0000A2E800000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (16, N'Idiosyncrasy', N'any personal peculiarity, mannerism', 1, CAST(0x0000A2E900000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (17, N'Knavery', N'a dishonest act', 1, CAST(0x0000A2EA00000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (18, N'Acerbic', N'acid in temper, mood or tone; sour in taste', 1, CAST(0x0000A2EB00000000 AS DateTime), NULL, N'adj')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (19, N'Equivocation', N'a purposely misleading statement', 1, CAST(0x0000A2EC00000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (20, N'Iniquitous', N'wicked; unjust', 1, CAST(0x0000A2ED00000000 AS DateTime), NULL, N'adj')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (21, N'Abnegation', N'a denial', 1, CAST(0x0000A2EE00000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (22, N'Pedantic', N'emphasizing minutiae or form in scholarship or teaching', 1, CAST(0x0000A2EF00000000 AS DateTime), NULL, N'adj')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (23, N'Autocracy', N'an absolute monarchy; government where one person holds power', 1, CAST(0x0000A2F000000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (24, N'Egress', N'a way out; exit', 1, CAST(0x0000A2F100000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (25, N'Extemporize', N'to improvise; to make it up as you go along', 1, CAST(0x0000A2F200000000 AS DateTime), NULL, N'v')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (26, N'Edify', N'to build or establish; to instruct and improve the mind', 1, CAST(0x0000A2F300000000 AS DateTime), NULL, N'v')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (27, N'Xenophobia', N'fear of foreigners', 1, CAST(0x0000A2F400000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (28, N'Lambaste', N'to scold or beat harshly', 1, CAST(0x0000A2F500000000 AS DateTime), NULL, N'v')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (29, N'Doggerel', N'verse characterized by forced rhyme and meter', 1, CAST(0x0000A2F600000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (30, N'Malinger', N'to pretend to be ill in order to escape work', 1, CAST(0x0000A2F700000000 AS DateTime), NULL, N'v')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (31, N'Misanthrope', N'a person who distrusts everything; a hater of mankind', 1, CAST(0x0000A2F800000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (32, N'Indigence', N'the condition of being poor', 1, CAST(0x0000A2F900000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (33, N'Saturnine', N'gloomy, sluggish; to cause or undergo fermentation', 1, CAST(0x0000A2FA00000000 AS DateTime), NULL, N'adj')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (34, N'Exculpate', N'to free from guilt', 1, CAST(0x0000A2FB00000000 AS DateTime), NULL, N'v')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (35, N'Dauntless', N'fearless; not discouraged', 1, CAST(0x0000A2FC00000000 AS DateTime), NULL, N'adj')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (36, N'Deleterious', N'harmful; hurtful; noxious', 1, CAST(0x0000A2FD00000000 AS DateTime), NULL, N'adj')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (37, N'Sycophant', N'flatterer', 1, CAST(0x0000A2FE00000000 AS DateTime), NULL, N'n')
INSERT [dbo].[Vocabs] ([VocabId], [Word], [Definition], [Category_CategoryId], [UsedDate], [EtyLink], [Type]) VALUES (38, N'Depredation', N'a plundering or laying waste', 1, CAST(0x0000A2FF00000000 AS DateTime), NULL, N'n')
SET IDENTITY_INSERT [dbo].[Vocabs] OFF
/****** Object:  Index [IX_User_UserId]    Script Date: 3/2/2014 10:33:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_User_UserId] ON [dbo].[Categories]
(
	[User_UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Index [IX_Category_CategoryId]    Script Date: 3/2/2014 10:33:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Category_CategoryId] ON [dbo].[Vocabs]
(
	[Category_CategoryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.Users_User_UserId] FOREIGN KEY([User_UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.Users_User_UserId]
GO
ALTER TABLE [dbo].[Vocabs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vocabs_dbo.Categories_Category_CategoryId] FOREIGN KEY([Category_CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vocabs] CHECK CONSTRAINT [FK_dbo.Vocabs_dbo.Categories_Category_CategoryId]
GO
