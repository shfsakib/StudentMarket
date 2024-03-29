USE [StuMarketDb]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 7/15/2020 12:34:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[MobileNumber] [nvarchar](max) NOT NULL,
	[NidNo] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[DateofBirth] [nvarchar](50) NOT NULL,
	[ProfilePicture] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[ReferedBy] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[InTime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Buy]    Script Date: 7/15/2020 12:34:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buy](
	[BuyId] [int] NOT NULL,
	[Invoice] [nvarchar](50) NOT NULL,
	[PostId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[BuyerId] [int] NOT NULL,
	[SellerId] [int] NOT NULL,
	[DeadLine] [nvarchar](50) NULL,
	[Quantity] [int] NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[SellerNoti] [nvarchar](50) NULL,
	[BuyerNoti] [nvarchar](50) NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[Intime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Buy] PRIMARY KEY CLUSTERED 
(
	[BuyId] ASC,
	[Invoice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/15/2020 12:34:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[InTime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 7/15/2020 12:34:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[DISTRICTID] [int] NOT NULL,
	[DIVISIONID] [int] NULL,
	[DISTRICTNM] [nvarchar](50) NOT NULL,
	[BDNAME] [nvarchar](100) NULL CONSTRAINT [DF_District_BDNAME]  DEFAULT (N'N'),
	[LATITUDE] [float] NULL,
	[LONGITUDE] [float] NULL,
	[WEBADDRESS] [nvarchar](100) NULL,
	[CREATE_AT] [smalldatetime] NULL,
	[UPDATE_AT] [smalldatetime] NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[DISTRICTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Division]    Script Date: 7/15/2020 12:34:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Division](
	[ID] [int] NOT NULL,
	[DIVISION] [nvarchar](50) NULL,
	[BDNAME] [nvarchar](50) NULL,
	[CREATE_AT] [nvarchar](50) NULL,
	[UPDATE_AT] [nvarchar](50) NULL,
 CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PayPrice]    Script Date: 7/15/2020 12:34:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayPrice](
	[PayId] [int] NOT NULL,
	[BuyerId] [int] NOT NULL,
	[SellerId] [int] NOT NULL,
	[OrderInvoice] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[TrxId] [nvarchar](50) NOT NULL,
	[Intime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PayPrice] PRIMARY KEY CLUSTERED 
(
	[PayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostAd]    Script Date: 7/15/2020 12:34:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostAd](
	[PostId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Status] [nchar](1) NULL,
	[Intime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PostAd] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostPic]    Script Date: 7/15/2020 12:34:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostPic](
	[PicId] [int] NOT NULL,
	[PostId] [int] NOT NULL,
	[Picture] [nvarchar](max) NOT NULL,
	[Intime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PostPic] PRIMARY KEY CLUSTERED 
(
	[PicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserList]    Script Date: 7/15/2020 12:34:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserList](
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobileNo] [nvarchar](50) NOT NULL,
	[DOB] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Division] [int] NOT NULL,
	[District] [int] NOT NULL,
	[Address] [nvarchar](50) NULL,
	[GNidNo] [nvarchar](50) NOT NULL,
	[BCertNo] [nvarchar](50) NOT NULL,
	[NidNo] [nvarchar](50) NULL,
	[About] [nvarchar](max) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Status] [nchar](1) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Intime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserList] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Admin] ([AdminId], [Name], [Email], [MobileNumber], [NidNo], [Gender], [DateofBirth], [ProfilePicture], [Password], [Type], [ReferedBy], [Status], [InTime]) VALUES (1, N'Sakib Hossain', N'sakib@gmail.com', N'01685685506', N'7841248490', N'Male', N'02-08-1996', N'/Photos/Admin/1.png', N'S', N'Super Admin', N'none', N'Active', N'02-07-2020_11:58:00')
INSERT [dbo].[Admin] ([AdminId], [Name], [Email], [MobileNumber], [NidNo], [Gender], [DateofBirth], [ProfilePicture], [Password], [Type], [ReferedBy], [Status], [InTime]) VALUES (2, N'Mehedi', N'mehedi@gmail.com', N'01843911345', N'122343434', N'Male', N'02-07-2020', N'/Photos/Admin/2.png', N'S', N'Super Admin', N'sakib@gmail.com', N'Active', N'02/07/2020_01:46:03')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1001, N'2020070001', 1003, CAST(20000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), 1002, 1001, N'', 1, N'Buy', N'Confirmed', N'Readed', N'Readed', N'Cash on delivery', N'04/07/2020_08:27:14')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1002, N'2020070001', 1001, CAST(150.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), 1002, 1001, N'', 1, N'Buy', N'Rejected', N'Readed', N'Readed', N'Pay Online', N'04/07/2020_08:27:15')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1003, N'2020070002', 1002, CAST(170.00 AS Decimal(18, 2)), CAST(850.00 AS Decimal(18, 2)), 1002, 1001, N'20-07-2020', 5, N'Order', N'Confirmed', N'Readed', N'Readed', N'Pay Online', N'04/07/2020_08:27:31')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1004, N'2020070003', 1004, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1004, 1003, N'', 0, N'Hire', N'Confirmed', N'Readed', N'Readed', N'Pay Online', N'14/07/2020_08:25:48')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1007, N'2020070006', 1001, CAST(150.00 AS Decimal(18, 2)), CAST(900.00 AS Decimal(18, 2)), 1004, 1001, N'15-07-2020', 6, N'Order', N'Confirmed', N'Readed', N'Readed', N'Pay Online', N'14/07/2020_09:03:02')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1009, N'2020070007', 1001, CAST(150.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), 1004, 1001, N'', 1, N'Buy', N'Pending', N'Readed', N'Readed', N'', N'14/07/2020_09:06:34')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1010, N'2020070008', 1006, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1004, 1006, N'', 0, N'Hire', N'Confirmed', N'Readed', N'Readed', N'Pay Online', N'14/07/2020_10:52:00')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1011, N'2020070009', 1006, CAST(8000.00 AS Decimal(18, 2)), CAST(8000.00 AS Decimal(18, 2)), 1004, 1006, N'', 1, N'Buy', N'Rejected', N'Readed', N'Readed', N'Pay Online', N'14/07/2020_10:52:45')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1012, N'2020070010', 1002, CAST(170.00 AS Decimal(18, 2)), CAST(510.00 AS Decimal(18, 2)), 1007, 1001, N'21-07-2020', 3, N'Order', N'Pending', NULL, NULL, N'Pay Online', N'15/07/2020_12:25:07')
INSERT [dbo].[Buy] ([BuyId], [Invoice], [PostId], [Price], [TotalPrice], [BuyerId], [SellerId], [DeadLine], [Quantity], [Type], [Status], [SellerNoti], [BuyerNoti], [PaymentMethod], [Intime]) VALUES (1013, N'2020070011', 1006, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1007, 1006, N'', 0, N'Hire', N'Pending', NULL, NULL, N'Pay Online', N'15/07/2020_12:25:26')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [InTime]) VALUES (1, N'Handicraft', N'26/06/2020_11:45:18')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [InTime]) VALUES (2, N'Software', N'26/06/2020_11:58:22')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [InTime]) VALUES (3, N'IOT', N'27/06/2020_01:03:33')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [InTime]) VALUES (4, N'Developer', N'30/06/2020_12:53:24')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [InTime]) VALUES (5, N'Artist', N'30/06/2020_12:53:38')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [InTime]) VALUES (6, N'Designer', N'30/06/2020_12:54:02')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [InTime]) VALUES (7, N'Event', N'30/06/2020_12:54:08')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [InTime]) VALUES (8, N'Pet', N'14/07/2020_07:34:41')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [InTime]) VALUES (9, N'Others', N'14/07/2020_07:36:06')
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (1, 3, N'Dhaka', N'ঢাকা', 23.7115253, 90.4111451, N'www.dhaka.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (2, 3, N'Faridpur', N'ফরিদপুর', 23.6070822, 89.8429406, N'www.faridpur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (3, 3, N'Gazipur', N'গাজীপুর', 24.0022858, 90.4264283, N'www.gazipur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (4, 3, N'Gopalganj', N'গোপালগঞ্জ', 23.0050857, 89.8266059, N'www.gopalganj.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (5, 8, N'Jamalpur', N'জামালপুর', 24.937533, 89.937775, N'www.jamalpur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2016-04-06 10:49:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (6, 3, N'Kishoreganj', N'কিশোরগঞ্জ', 24.444937, 90.776575, N'www.kishoreganj.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (7, 3, N'Madaripur', N'মাদারীপুর', 23.164102, 90.1896805, N'www.madaripur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (8, 3, N'Manikganj', N'মানিকগঞ্জ', 0, 0, N'www.manikganj.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (9, 3, N'Munshiganj', N'মুন্সিগঞ্জ', 0, 0, N'www.munshiganj.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (10, 8, N'Mymensingh', N'ময়মনসিং', 0, 0, N'www.mymensingh.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2016-04-06 10:49:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (11, 3, N'Narayanganj', N'নারায়াণগঞ্জ', 23.63366, 90.496482, N'www.narayanganj.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (12, 3, N'Narsingdi', N'নরসিংদী', 23.932233, 90.71541, N'www.narsingdi.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (13, 8, N'Netrokona', N'নেত্রকোনা', 24.870955, 90.727887, N'www.netrokona.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2016-04-06 10:47:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (14, 3, N'Rajbari', N'রাজবাড়ি', 23.7574305, 89.6444665, N'www.rajbari.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (15, 3, N'Shariatpur', N'শরীয়তপুর', 0, 0, N'www.shariatpur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (16, 8, N'Sherpur', N'শেরপুর', 25.0204933, 90.0152966, N'www.sherpur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2016-04-06 10:48:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (17, 3, N'Tangail', N'টাঙ্গাইল', 0, 0, N'www.tangail.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (18, 5, N'Bogra', N'বগুড়া', 24.8465228, 89.377755, N'www.bogra.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (19, 5, N'Joypurhat', N'জয়পুরহাট', 0, 0, N'www.joypurhat.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (20, 5, N'Naogaon', N'নওগাঁ', 0, 0, N'www.naogaon.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (21, 5, N'Natore', N'নাটোর', 24.420556, 89.000282, N'www.natore.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (22, 5, N'Nawabganj', N'নবাবগঞ্জ', 24.5965034, 88.2775122, N'www.chapainawabganj.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (23, 5, N'Pabna', N'পাবনা', 23.998524, 89.233645, N'www.pabna.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (24, 5, N'Rajshahi', N'রাজশাহী', 0, 0, N'www.rajshahi.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (25, 5, N'Sirajgonj', N'সিরাজগঞ্জ', 24.4533978, 89.7006815, N'www.sirajganj.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (26, 6, N'Dinajpur', N'দিনাজপুর', 25.6217061, 88.6354504, N'www.dinajpur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (27, 6, N'Gaibandha', N'গাইবান্ধা', 25.328751, 89.528088, N'www.gaibandha.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (28, 6, N'Kurigram', N'কুড়িগ্রাম', 25.805445, 89.636174, N'www.kurigram.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (29, 6, N'Lalmonirhat', N'লালমনিরহাট', 0, 0, N'www.lalmonirhat.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (30, 6, N'Nilphamari', N'নীলফামারী', 25.931794, 88.856006, N'www.nilphamari.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (31, 6, N'Panchagarh', N'পঞ্চগড়', 26.3411, 88.5541606, N'www.panchagarh.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (32, 6, N'Rangpur', N'রংপুর', 25.7558096, 89.244462, N'www.rangpur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (33, 6, N'Thakurgaon', N'ঠাকুরগাঁও', 26.0336945, 88.4616834, N'www.thakurgaon.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (34, 1, N'Barguna', N'বরগুনা', 0, 0, N'www.barguna.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (35, 1, N'Barisal', N'বরিশাল', 0, 0, N'www.barisal.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (36, 1, N'Bhola', N'ভোলা', 22.685923, 90.648179, N'www.bhola.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (37, 1, N'Jhalokati', N'ঝালকাঠি', 0, 0, N'www.jhalakathi.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (38, 1, N'Patuakhali', N'পটুয়াখালী', 22.3596316, 90.3298712, N'www.patuakhali.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (39, 1, N'Pirojpur', N'পিরোজপুর', 0, 0, N'www.pirojpur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (40, 2, N'Bandarban', N'বান্দরবান', 22.1953275, 92.2183773, N'www.bandarban.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (41, 2, N'Brahmanbaria', N'ব্রাহ্মণবাড়িয়া', 23.9570904, 91.1119286, N'www.brahmanbaria.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (42, 2, N'Chandpur', N'চাঁদপুর', 23.2332585, 90.6712912, N'www.chandpur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (43, 2, N'Chittagong', N'চট্টগ্রাম', 22.335109, 91.834073, N'www.chittagong.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (44, 2, N'Comilla', N'কুমিল্লা', 23.4682747, 91.1788135, N'www.comilla.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (45, 2, N'Cox''s Bazar', N'কক্স বাজার', 0, 0, N'www.coxsbazar.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (46, 2, N'Feni', N'ফেনী', 23.023231, 91.3840844, N'www.feni.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (47, 2, N'Khagrachari', N'খাগড়াছড়ি', 23.119285, 91.984663, N'www.khagrachhari.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (48, 2, N'Lakshmipur', N'লক্ষ্মীপুর', 22.942477, 90.841184, N'www.lakshmipur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (49, 2, N'Noakhali', N'নোয়াখালী', 22.869563, 91.099398, N'www.noakhali.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (50, 2, N'Rangamati', N'রাঙ্গামাটি', 0, 0, N'www.rangamati.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (51, 7, N'Habiganj', N'হবিগঞ্জ', 24.374945, 91.41553, N'www.habiganj.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (52, 7, N'Maulvibazar', N'মৌলভীবাজার', 24.482934, 91.777417, N'www.moulvibazar.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (53, 7, N'Sunamganj', N'সুনামগঞ্জ', 25.0658042, 91.3950115, N'www.sunamganj.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (54, 7, N'Sylhet', N'সিলেট', 24.8897956, 91.8697894, N'www.sylhet.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (55, 4, N'Bagerhat', N'বাগেরহাট', 22.651568, 89.785938, N'www.bagerhat.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (56, 4, N'Chuadanga', N'চুয়াডাঙ্গা', 23.6401961, 88.841841, N'www.chuadanga.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (57, 4, N'Jessore', N'যশোর', 23.16643, 89.2081126, N'www.jessore.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (58, 4, N'Jhenaidah', N'ঝিনাইদহ', 23.5448176, 89.1539213, N'www.jhenaidah.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (59, 4, N'Khulna', N'খুলনা', 22.815774, 89.568679, N'www.khulna.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (60, 4, N'Kushtia', N'কুষ্টিয়া', 23.901258, 89.120482, N'www.kushtia.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (61, 4, N'Magura', N'মাগুরা', 23.487337, 89.419956, N'www.magura.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (62, 4, N'Meherpur', N'মেহেরপুর', 23.762213, 88.631821, N'www.meherpur.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (63, 4, N'Narail', N'নড়াইল', 23.172534, 89.512672, N'www.narail.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[District] ([DISTRICTID], [DIVISIONID], [DISTRICTNM], [BDNAME], [LATITUDE], [LONGITUDE], [WEBADDRESS], [CREATE_AT], [UPDATE_AT]) VALUES (64, 4, N'Satkhira', N'সাতক্ষীরা', 0, 0, N'www.satkhira.gov.bd', CAST(N'2015-09-13 04:33:00' AS SmallDateTime), CAST(N'2015-09-13 04:36:00' AS SmallDateTime))
INSERT [dbo].[Division] ([ID], [DIVISION], [BDNAME], [CREATE_AT], [UPDATE_AT]) VALUES (1, N'Barisal', N'বরিশাল', N'0000/00/00 00:00:00', N'0000/00/00 00:00:00')
INSERT [dbo].[Division] ([ID], [DIVISION], [BDNAME], [CREATE_AT], [UPDATE_AT]) VALUES (2, N'Chittagong', N'চট্টগ্রাম', N'0000-00-00 00:00:00', N'0000-00-00 00:00:00')
INSERT [dbo].[Division] ([ID], [DIVISION], [BDNAME], [CREATE_AT], [UPDATE_AT]) VALUES (3, N'Dhaka', N'ঢাকা', N'0000-00-00 00:00:00', N'0000-00-00 00:00:00')
INSERT [dbo].[Division] ([ID], [DIVISION], [BDNAME], [CREATE_AT], [UPDATE_AT]) VALUES (4, N'Khulna', N'খুলনা', N'0000-00-00 00:00:00', N'0000-00-00 00:00:00')
INSERT [dbo].[Division] ([ID], [DIVISION], [BDNAME], [CREATE_AT], [UPDATE_AT]) VALUES (5, N'Rajshahi', N'রাজশাহী', N'0000-00-00 00:00:00', N'0000-00-00 00:00:00')
INSERT [dbo].[Division] ([ID], [DIVISION], [BDNAME], [CREATE_AT], [UPDATE_AT]) VALUES (6, N'Rangpur', N'রংপুর', N'0000-00-00 00:00:00', N'0000-00-00 00:00:00')
INSERT [dbo].[Division] ([ID], [DIVISION], [BDNAME], [CREATE_AT], [UPDATE_AT]) VALUES (7, N'Sylhet', N'সিলেট', N'0000-00-00 00:00:00', N'0000-00-00 00:00:00')
INSERT [dbo].[Division] ([ID], [DIVISION], [BDNAME], [CREATE_AT], [UPDATE_AT]) VALUES (8, N'Mymensingh', N'ময়মনসিংহ', N'2016-04-06 10:46:00', N'0000-00-00 00:00:00')
INSERT [dbo].[PayPrice] ([PayId], [BuyerId], [SellerId], [OrderInvoice], [Price], [TrxId], [Intime]) VALUES (1001, 1002, 1001, N'2020070001', CAST(20150.00 AS Decimal(18, 2)), N'7GNCGSYEV4O987V', N'05/07/2020_11:16:13')
INSERT [dbo].[PayPrice] ([PayId], [BuyerId], [SellerId], [OrderInvoice], [Price], [TrxId], [Intime]) VALUES (1002, 1004, 1006, N'2020070008', CAST(5000.00 AS Decimal(18, 2)), N'7GE5NILQ61', N'15/07/2020_12:11:04')
INSERT [dbo].[PostAd] ([PostId], [UserId], [CategoryId], [ProductName], [Description], [Price], [Status], [Intime]) VALUES (1001, 1001, 1, N'Pencil Box', N'Demo', CAST(150.00 AS Decimal(18, 2)), N'A', N'01/07/2020_11:49:50')
INSERT [dbo].[PostAd] ([PostId], [UserId], [CategoryId], [ProductName], [Description], [Price], [Status], [Intime]) VALUES (1002, 1001, 1, N'Bamboo Pencil Box', N'I have 5 pieces', CAST(170.00 AS Decimal(18, 2)), N'A', N'04/07/2020_05:24:12')
INSERT [dbo].[PostAd] ([PostId], [UserId], [CategoryId], [ProductName], [Description], [Price], [Status], [Intime]) VALUES (1003, 1001, 7, N'Wedding Planner', N'Price will be increase or decrease based on plan.', CAST(20000.00 AS Decimal(18, 2)), N'A', N'04/07/2020_05:43:34')
INSERT [dbo].[PostAd] ([PostId], [UserId], [CategoryId], [ProductName], [Description], [Price], [Status], [Intime]) VALUES (1004, 1003, 4, N'website development with c#', N'choose your design and built your official or personal website.', CAST(20000.00 AS Decimal(18, 2)), N'A', N'14/07/2020_07:30:36')
INSERT [dbo].[PostAd] ([PostId], [UserId], [CategoryId], [ProductName], [Description], [Price], [Status], [Intime]) VALUES (1005, 1003, 8, N'pigeon', N'2 pair,each pair''s price is individual.', CAST(3000.00 AS Decimal(18, 2)), N'A', N'14/07/2020_07:51:40')
INSERT [dbo].[PostAd] ([PostId], [UserId], [CategoryId], [ProductName], [Description], [Price], [Status], [Intime]) VALUES (1006, 1006, 6, N'design your company name with a beautiful logo', N'we design your dreams.price negotiable.', CAST(8000.00 AS Decimal(18, 2)), N'A', N'14/07/2020_08:16:02')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1001, 1001, N'/Photos/Post/pencilbox.jpg', N'01/07/2020_11:49:50')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1002, 1002, N'/Photos/Post/pencilbox.jpg', N'04/07/2020_05:24:13')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1003, 1003, N'/Photos/Post/49262.jpg', N'04/07/2020_05:43:35')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1004, 1003, N'/Photos/Post/about.jpg', N'04/07/2020_05:43:35')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1005, 1003, N'/Photos/Post/contact.jpg', N'04/07/2020_05:43:35')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1006, 1003, N'/Photos/Post/dd.jpg', N'04/07/2020_05:43:35')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1007, 1004, N'/Photos/Post/website 2.jpg', N'14/07/2020_07:30:36')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1008, 1004, N'/Photos/Post/website-hd-png-download.jpg', N'14/07/2020_07:30:36')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1009, 1005, N'/Photos/Post/pet sell image 2.jpg', N'14/07/2020_07:51:41')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1010, 1005, N'/Photos/Post/pet sell post.jpg', N'14/07/2020_07:51:41')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1011, 1006, N'/Photos/Post/logo design 1.jpg', N'14/07/2020_08:16:02')
INSERT [dbo].[PostPic] ([PicId], [PostId], [Picture], [Intime]) VALUES (1012, 1006, N'/Photos/Post/logo design 2.png', N'14/07/2020_08:16:02')
INSERT [dbo].[UserList] ([UserId], [Name], [Email], [MobileNo], [DOB], [Gender], [Division], [District], [Address], [GNidNo], [BCertNo], [NidNo], [About], [Picture], [Type], [Status], [Password], [Intime]) VALUES (1001, N'Sakib Hossain', N'shfsakib@gmail.com', N'01685685506', N'02-08-1996', N'Male', 2, 43, N'Chandgaon', N'18268429018237', N'121781982328232', N'8780456328', N'Software developer', N'/Photos/1001.png', N'Seller', N'A', N'123', N'27/06/2020_01:12:05')
INSERT [dbo].[UserList] ([UserId], [Name], [Email], [MobileNo], [DOB], [Gender], [Division], [District], [Address], [GNidNo], [BCertNo], [NidNo], [About], [Picture], [Type], [Status], [Password], [Intime]) VALUES (1003, N'Md Mehadi Hasan', N'mehedi@gmail.com', N'01727709132', N'30-07-2020', N'Male', 2, 43, N'dewanbazar,chittagong.', N'455341', N'562471', N'143252', N'developer', N'/Photos/1003.png', N'Seller', N'A', N'4321', N'13/07/2020_11:18:10')
INSERT [dbo].[UserList] ([UserId], [Name], [Email], [MobileNo], [DOB], [Gender], [Division], [District], [Address], [GNidNo], [BCertNo], [NidNo], [About], [Picture], [Type], [Status], [Password], [Intime]) VALUES (1004, N'Ratul dey', N'ratul@gmail.com', N'01866354671', N'16-05-1995', N'Male', 3, 6, N'sholakia,kisorgonj', N'643345', N'543232', N'132342', N'Businessman', N'/Photos/1004.png', N'Buyer', N'A', N'1234', N'13/07/2020_11:27:58')
INSERT [dbo].[UserList] ([UserId], [Name], [Email], [MobileNo], [DOB], [Gender], [Division], [District], [Address], [GNidNo], [BCertNo], [NidNo], [About], [Picture], [Type], [Status], [Password], [Intime]) VALUES (1006, N'Sakib Asraf', N'sakib@gmail.com', N'01863628234', N'23-07-2020', N'Male', 4, 55, N'Bagerhat sadar', N'834354', N'293226', N'534523', N'designer', N'/Photos/1006.png', N'Seller', N'A', N'454543', N'13/07/2020_11:40:33')
INSERT [dbo].[UserList] ([UserId], [Name], [Email], [MobileNo], [DOB], [Gender], [Division], [District], [Address], [GNidNo], [BCertNo], [NidNo], [About], [Picture], [Type], [Status], [Password], [Intime]) VALUES (1007, N'Salekur  Rahman', N'salek@gmail.com', N'01856082361', N'22-11-2020', N'Male', 7, 53, N'sunamganj town center', N'5636837878', N'053682', N'345247', N'Entrepreneur', N'/Photos/1007.png', N'Buyer', N'A', N'3452', N'14/07/2020_12:22:05')
