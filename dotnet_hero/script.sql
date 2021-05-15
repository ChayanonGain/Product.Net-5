CREATE DATABASE [istock]
GO
USE [istock]
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
 [AccountID] [int] IDENTITY(1,1) NOT NULL,
 [Username] [nvarchar](max) NOT NULL,
 [Password] [nvarchar](max) NOT NULL,
 [Created] [datetime2](7) NOT NULL,
 [RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED
(
 [AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
 [CategoryID] [int] IDENTITY(1,1) NOT NULL,
 [Name] [nvarchar](max) NOT NULL,
 [Created] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED
(
 [CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
 [ProductID] [int] IDENTITY(1,1) NOT NULL,
 [Name] [nvarchar](max) NOT NULL,
 [Image] [nvarchar](50) NULL,
 [Stock] [int] NOT NULL,
 [Price] [decimal](18, 0) NOT NULL,
 [Created] [datetime2](7) NOT NULL,
 [CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED
(
 [ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
 [RoleID] [int] IDENTITY(1,1) NOT NULL,
 [Name] [nvarchar](max) NOT NULL,
 [Created] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED
(
 [RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON
INSERT [dbo].[Accounts] ([AccountID], [Username], [Password], [Created], [RoleID]) VALUES (1, N'iblurblur@gmail.com', N'OQx26DXYE1Z7k/+udngNnQ==.Fj06G8+ppHpRWz5XPQY5c8q5aFgSTfLZ5lHHTp+v9ac=', CAST(N'2021-02-16T18:18:37.3800000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT [dbo].[Categories] ([CategoryID], [Name], [Created]) VALUES (1, N'IT', CAST(N'2021-02-16T18:27:58.4066667' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryID], [Name], [Created]) VALUES (2, N'Food', CAST(N'2021-02-16T18:27:58.4066667' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryID], [Name], [Created]) VALUES (3, N'Sport', CAST(N'2021-02-16T18:27:58.4066667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (1, N'NodeMCU Development Kit V2 แถมสาย USB (Node MCU)', N'product_22.jpg', 0, CAST(280 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (2, N'Arduino Sensor Shield V5.0', N'product_11.jpg', 100, CAST(150 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (3, N'DHT 22 - Temp. Sensor', N'product_15.jpg', 1000, CAST(300 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (4, N'DotMatrix LED Display', N'product_14.jpg', 1000, CAST(300 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (5, N'IR Flame Detector Module (ตรวจจับเปลวไฟด้วย Infrared)', N'product_20.jpg', 100, CAST(290 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (6, N'IR Flame Detector Module (ตรวจจับเปลวไฟด้วย Infrared)', N'product_19.jpg', 60, CAST(100 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (7, N'NodeMCU32', N'product_17.jpg', 1000, CAST(300 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (8, N'Raining Sensor', N'product_16.jpg', 1000, CAST(300 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (9, N'Arduino UNO R3 แถมสาย USB Type A Male/B Male Cable', N'product_04.jpg', 1000, CAST(300 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (10, N'WeMos D1 R2 WiFi ESP8266 Development Board Compatible Arduino UNO', N'product_21.jpg', 100, CAST(370 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (11, N'Arduino ProtoShield Mini UNO Prototype Shield พร้อม Mini Breadboard', N'product_12.jpg', 100, CAST(60 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (12, N'Arduino Nano 3.0 Mini USB รุ่นใหม่ใช้ชิฟ CH340G แถมสาย Mini USB', N'product_23.jpg', 2, CAST(130 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (13, N'Arduino MEGA 2560 R3 ใช้ชิฟ USB CH340 รุ่นใหม่ แถมสาย USB', N'product_05.jpg', 100, CAST(200 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (14, N'4-Channel 5VDC Relay Module Relay Active High / LOW', N'product_07.jpg', 1, CAST(185 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (15, N'4-Channel 5VDC Relay Module Relay Active High / LOW', N'product_01.jpg', 1, CAST(185 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (16, N'4-Channel 5VDC Relay Module Relay Active High / LOW', N'product_02.jpg', 1, CAST(185 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Image], [Stock], [Price], [Created], [CategoryID]) VALUES (17, N'Arduino Sensor Kit V5.0', N'product_10.jpg', 13, CAST(150 AS Decimal(18, 0)), CAST(N'2019-06-15T03:10:54.6366667' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RoleID], [Name], [Created]) VALUES (1, N'Admin', CAST(N'2021-02-16T17:48:10.6933333' AS DateTime2))
INSERT [dbo].[Roles] ([RoleID], [Name], [Created]) VALUES (2, N'Cashier', CAST(N'2021-02-16T17:48:31.5233333' AS DateTime2))
INSERT [dbo].[Roles] ([RoleID], [Name], [Created]) VALUES (3, N'Member', CAST(N'2021-02-16T17:48:52.4066667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Roles]
GO