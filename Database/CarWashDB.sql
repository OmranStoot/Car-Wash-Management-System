USE [DBCarWash]
GO
/****** Object:  Table [dbo].[CashInvoice]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashInvoice](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[TransNo] [nvarchar](50) NULL,
	[Cid] [int] NULL,
	[Vid] [int] NULL,
	[InvoiceDate] [date] NULL,
	[Status] [nvarchar](50) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[CreatedByEmployerID] [int] NOT NULL,
 CONSTRAINT [PK_CashInvoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashInvoiceService]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashInvoiceService](
	[InvoiceServiceID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NULL,
	[Sid] [int] NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_CashInvoiceService] PRIMARY KEY CLUSTERED 
(
	[InvoiceServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicaleType]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicaleType](
	[VehicaleTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Class] [nvarchar](50) NULL,
 CONSTRAINT [PK_VehicaleType] PRIMARY KEY CLUSTERED 
(
	[VehicaleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Vid] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[CarNo] [nvarchar](50) NULL,
	[CarModel] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Points] [int] NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_InvoicesList]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_InvoicesList]
AS
SELECT CI.InvoiceID, CI.TransNo, C.Name AS CustomerName, C.CarModel, V.Class, V.Name AS VehicaleType, CI.InvoiceDate, ISNULL(Srv.ServicesCount, 0) AS ServicesCount, CI.TotalAmount, CI.Status
FROM     dbo.CashInvoice AS CI INNER JOIN
                  dbo.Customer AS C ON CI.Cid = C.CustomerID INNER JOIN
                  dbo.VehicaleType AS V ON CI.Vid = V.VehicaleTypeID LEFT OUTER JOIN
                      (SELECT InvoiceID, COUNT(*) AS ServicesCount
                       FROM      dbo.CashInvoiceService AS CIS
                       GROUP BY InvoiceID) AS Srv ON CI.InvoiceID = Srv.InvoiceID
GO
/****** Object:  Table [dbo].[Company]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostGood]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostGood](
	[CostID] [int] IDENTITY(1,1) NOT NULL,
	[CostName] [nvarchar](50) NULL,
	[Cost] [decimal](18, 2) NULL,
	[CostDate] [date] NULL,
 CONSTRAINT [PK_CostGood] PRIMARY KEY CLUSTERED 
(
	[CostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employer]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employer](
	[EmployerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Dob] [date] NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Salary] [decimal](18, 2) NULL,
	[Password] [nvarchar](50) NULL,
	[Gender] [tinyint] NULL,
	[Permissions] [int] NOT NULL,
 CONSTRAINT [PK_Employer] PRIMARY KEY CLUSTERED 
(
	[EmployerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NULL,
	[PaymentDate] [date] NULL,
	[Amount] [decimal](18, 2) NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[Notes] [nvarchar](200) NULL,
	[PaidByEmployerID] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CashInvoice] ON 

INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (3, N'202601080001', 2, 5, CAST(N'2026-01-08' AS Date), N'Canceled', CAST(0.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (4, N'202601080002', 2, 5, CAST(N'2026-01-08' AS Date), N'Paid', CAST(40.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (5, N'202601080003', 2, 5, CAST(N'2026-01-08' AS Date), N'Canceled', CAST(32.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (6, N'202601080004', 5, 3, CAST(N'2026-01-08' AS Date), N'Paid', CAST(41.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (23, N'202601080005', 3, 12, CAST(N'2026-01-08' AS Date), N'PartiallyPaid', CAST(316.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (27, N'202601080006', 9, 8, CAST(N'2026-01-08' AS Date), N'Canceled', CAST(200.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (29, N'202601080007', 12, 8, CAST(N'2026-01-08' AS Date), N'Canceled', CAST(36.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (31, N'202601090001', 2, 5, CAST(N'2026-01-09' AS Date), N'Paid', CAST(404.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (33, N'202601090002', 11, 14, CAST(N'2026-01-09' AS Date), N'Canceled', CAST(120.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (34, N'202601090003', 10, 15, CAST(N'2026-01-09' AS Date), N'Paid', CAST(594.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (35, N'202601090004', 7, 17, CAST(N'2026-01-09' AS Date), N'Paid', CAST(1616.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (36, N'202601090005', 11, 14, CAST(N'2026-01-09' AS Date), N'Canceled', CAST(1212.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (37, N'202601090006', 9, 8, CAST(N'2026-01-09' AS Date), N'Paid', CAST(18.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (38, N'202601090007', 12, 8, CAST(N'2026-01-09' AS Date), N'Open', CAST(198.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (39, N'202601090008', 11, 14, CAST(N'2026-01-09' AS Date), N'Paid', CAST(150.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (40, N'202601090009', 11, 14, CAST(N'2026-01-09' AS Date), N'Open', CAST(150.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (41, N'202601090010', 3, 12, CAST(N'2026-01-09' AS Date), N'Open', CAST(120.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (42, N'202601090011', 9, 8, CAST(N'2026-01-09' AS Date), N'Paid', CAST(100.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (43, N'202601090012', 10, 15, CAST(N'2026-01-09' AS Date), N'Open', CAST(63.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (44, N'202601140001', 12, 8, CAST(N'2026-01-14' AS Date), N'Open', CAST(20.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (45, N'202601140002', 2, 5, CAST(N'2026-01-14' AS Date), N'Open', CAST(70.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (46, N'202601170001', 5, 3, CAST(N'2026-01-17' AS Date), N'Paid', CAST(72.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[CashInvoice] ([InvoiceID], [TransNo], [Cid], [Vid], [InvoiceDate], [Status], [TotalAmount], [CreatedByEmployerID]) VALUES (47, N'202601170002', 2, 5, CAST(N'2026-01-17' AS Date), N'Paid', CAST(161.00 AS Decimal(18, 2)), 5)
SET IDENTITY_INSERT [dbo].[CashInvoice] OFF
GO
SET IDENTITY_INSERT [dbo].[CashInvoiceService] ON 

INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (1, 3, 2, CAST(29.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (2, 3, 3, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (3, 3, 4, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (4, 3, 5, CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (5, 4, 11, CAST(8.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (6, 4, 12, CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (7, 4, 13, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (8, 5, 12, CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (9, 5, 13, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (10, 6, 10, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (11, 6, 11, CAST(8.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (12, 6, 12, CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (13, 6, 13, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (14, 23, 2, CAST(58.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (15, 23, 3, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (16, 27, 4, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (17, 27, 5, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (18, 29, 10, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (19, 29, 11, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (20, 31, 2, CAST(29.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (21, 31, 3, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (22, 31, 4, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (23, 31, 5, CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (24, 31, 6, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (25, 31, 7, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (26, 31, 8, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (27, 31, 9, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (28, 31, 10, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (29, 31, 11, CAST(8.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (30, 31, 12, CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (31, 31, 13, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (32, 33, 5, CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (33, 34, 2, CAST(87.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (34, 34, 3, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (35, 34, 4, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (36, 35, 2, CAST(116.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (37, 35, 3, CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (38, 35, 4, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (39, 35, 5, CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (40, 35, 6, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (41, 35, 7, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (42, 35, 8, CAST(8.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (43, 35, 9, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (44, 35, 10, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (45, 35, 11, CAST(32.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (46, 35, 12, CAST(48.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (47, 35, 13, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (48, 36, 2, CAST(87.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (49, 36, 3, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (50, 36, 4, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (51, 36, 5, CAST(90.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (52, 36, 6, CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (53, 36, 7, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (54, 36, 8, CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (55, 36, 9, CAST(45.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (56, 36, 10, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (57, 36, 11, CAST(24.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (58, 36, 12, CAST(36.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (59, 36, 13, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (60, 37, 10, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (61, 37, 11, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (62, 38, 2, CAST(58.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (63, 38, 3, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (64, 38, 4, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (65, 39, 3, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (66, 40, 4, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (67, 40, 5, CAST(90.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (68, 41, 4, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (69, 41, 5, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (70, 41, 6, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (71, 42, 4, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (72, 42, 5, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (73, 43, 10, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (74, 43, 11, CAST(24.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (75, 43, 12, CAST(36.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (76, 44, 6, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (77, 45, 3, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (78, 45, 4, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (79, 46, 4, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (80, 46, 5, CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (81, 46, 6, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (82, 46, 12, CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (83, 47, 2, CAST(29.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (84, 47, 3, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (85, 47, 4, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (86, 47, 5, CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (87, 47, 6, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (88, 47, 7, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (89, 47, 8, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[CashInvoiceService] ([InvoiceServiceID], [InvoiceID], [Sid], [Price]) VALUES (90, 47, 9, CAST(15.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CashInvoiceService] OFF
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyID], [CompanyName], [Address]) VALUES (1, N'Imrannoof', N'Damascus')
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[CostGood] ON 

INSERT [dbo].[CostGood] ([CostID], [CostName], [Cost], [CostDate]) VALUES (2, N'Business License', CAST(100.00 AS Decimal(18, 2)), CAST(N'2026-01-04' AS Date))
INSERT [dbo].[CostGood] ([CostID], [CostName], [Cost], [CostDate]) VALUES (3, N'ASE Cerrtifications', CAST(78.00 AS Decimal(18, 2)), CAST(N'2026-01-04' AS Date))
INSERT [dbo].[CostGood] ([CostID], [CostName], [Cost], [CostDate]) VALUES (4, N'Insurance', CAST(4000.00 AS Decimal(18, 2)), CAST(N'2026-01-04' AS Date))
INSERT [dbo].[CostGood] ([CostID], [CostName], [Cost], [CostDate]) VALUES (5, N'Mechanic''s Tooset with Specialty Tools', CAST(15000.00 AS Decimal(18, 2)), CAST(N'2026-01-04' AS Date))
SET IDENTITY_INSERT [dbo].[CostGood] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (2, 5, N'customer two', N'541', N'BMW X5 314', N'Aleppo', 10, N'0777777')
INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (3, 12, N'Customer one', N'112', N'Marsedce', N'Aleppo', 0, N'0876543')
INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (4, 9, N'Customer Three', N'11', N'Hunda', N'Daraa', 0, N'04444444')
INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (5, 3, N'Customer Four', N'24', N'KIA', N'Homs', 0, N'03333333')
INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (7, 17, N'Customer Five', N'34', N'BMW X5', N'Lebanon', 0, N'099999')
INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (8, 16, N'Customer Six', N'44', N'Ford', N'damascus', 0, N'934141322')
INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (9, 8, N'Customer Seven', N'55', N'Kia morning', N'Damascus', 0, N'0333333')
INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (10, 15, N'Customer Eight', N'12', N'Kia Rio', N'Latakia', 0, N'033333')
INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (11, 14, N'Customer Nine', N'90', N'Swzoky', N'syria', 0, N'044444')
INSERT [dbo].[Customer] ([CustomerID], [Vid], [Name], [CarNo], [CarModel], [Address], [Points], [Phone]) VALUES (12, 8, N'Customer Ten', N'43', N'Land Rover', N'syria', 0, N'022222')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employer] ON 

INSERT [dbo].[Employer] ([EmployerID], [Name], [Phone], [Address], [Dob], [Role], [Salary], [Password], [Gender], [Permissions]) VALUES (1, N'Imraan', N'0934660628', N'Syria, Damascus', CAST(N'2003-05-10' AS Date), N'Manager', CAST(10300.30 AS Decimal(18, 2)), N'123', 0, -1)
INSERT [dbo].[Employer] ([EmployerID], [Name], [Phone], [Address], [Dob], [Role], [Salary], [Password], [Gender], [Permissions]) VALUES (4, N'Hohny Deep', N'3452776566', N'California', CAST(N'2008-01-02' AS Date), N'Cashier', CAST(5000.00 AS Decimal(18, 2)), N'0000', 0, 61)
INSERT [dbo].[Employer] ([EmployerID], [Name], [Phone], [Address], [Dob], [Role], [Salary], [Password], [Gender], [Permissions]) VALUES (5, N'Sedra', N'0931410832', N'Syria Damascus', CAST(N'2004-07-02' AS Date), N'Manager', CAST(5700.00 AS Decimal(18, 2)), N'777', 1, -1)
INSERT [dbo].[Employer] ([EmployerID], [Name], [Phone], [Address], [Dob], [Role], [Salary], [Password], [Gender], [Permissions]) VALUES (6, N'Malik Saffour', N'0934511145', N'Syria Damascus', CAST(N'2008-01-02' AS Date), N'Worker', CAST(3000.00 AS Decimal(18, 2)), N'999', 0, 33)
INSERT [dbo].[Employer] ([EmployerID], [Name], [Phone], [Address], [Dob], [Role], [Salary], [Password], [Gender], [Permissions]) VALUES (7, N'mhd', N'09999999', N'italy', CAST(N'2000-02-15' AS Date), N'Worker', CAST(230.00 AS Decimal(18, 2)), N'333', 0, 33)
INSERT [dbo].[Employer] ([EmployerID], [Name], [Phone], [Address], [Dob], [Role], [Salary], [Password], [Gender], [Permissions]) VALUES (9, N'Employer', N'2222222', N'lebanon', CAST(N'2008-01-22' AS Date), N'Supervisor', CAST(222.00 AS Decimal(18, 2)), N'333', 1, 57)
SET IDENTITY_INSERT [dbo].[Employer] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (1, 38, CAST(N'2026-01-09' AS Date), CAST(200.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (2, 40, CAST(N'2026-01-09' AS Date), CAST(100.00 AS Decimal(18, 2)), N'Card', N'right now', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (3, 41, CAST(N'2026-01-09' AS Date), CAST(120.00 AS Decimal(18, 2)), N'Cash', N'qw', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (4, 41, CAST(N'2026-01-09' AS Date), CAST(120.00 AS Decimal(18, 2)), N'Cash', N'ee', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (5, 42, CAST(N'2026-01-09' AS Date), CAST(10.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (6, 42, CAST(N'2026-01-09' AS Date), CAST(100.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (7, 4, CAST(N'2026-01-14' AS Date), CAST(40.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (8, 6, CAST(N'2026-01-14' AS Date), CAST(10.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (9, 6, CAST(N'2026-01-14' AS Date), CAST(12.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (10, 6, CAST(N'2026-01-14' AS Date), CAST(9.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (11, 23, CAST(N'2026-01-14' AS Date), CAST(122.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (12, 37, CAST(N'2026-01-14' AS Date), CAST(18.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (13, 39, CAST(N'2026-01-14' AS Date), CAST(150.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (14, 6, CAST(N'2026-01-14' AS Date), CAST(10.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (15, 46, CAST(N'2026-01-17' AS Date), CAST(72.00 AS Decimal(18, 2)), N'Cash', N'', 1)
INSERT [dbo].[Payment] ([PaymentID], [InvoiceID], [PaymentDate], [Amount], [PaymentMethod], [Notes], [PaidByEmployerID]) VALUES (16, 47, CAST(N'2026-01-17' AS Date), CAST(161.00 AS Decimal(18, 2)), N'Cash', N'', 5)
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (2, N'Body Washing', CAST(29.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (3, N'Mashine Polish', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (4, N'Body Waxing', CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (5, N'Seat Dry Washing', CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (6, N'Floor & Ceiling Dry Washing', CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (7, N'Carpet Dry Washing', CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (8, N'Door Panel Cleaning', CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (9, N'Engine Bay Cleaning', CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (10, N'Headlight Cleaning', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (11, N'Water Mark Removing', CAST(8.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (12, N'Pitch Removing', CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[Service] ([ServiceID], [Name], [Price]) VALUES (13, N'Bactakleen', CAST(20.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicaleType] ON 

INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (2, N'COUPLE', N'1')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (3, N'SEDAN', N'1')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (5, N'SPOART CAR', N'1')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (6, N'HATCHBACK', N'1')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (7, N'STATION WAGON', N'2')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (8, N'SPORT-UTILITY VEHICALE (SUV)', N'2')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (9, N'MINIVAN', N'2')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (10, N'PICKUP TRUCK', N'2')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (11, N'MINI TRUCK', N'2')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (12, N'LIGHT TRUECK', N'2')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (13, N'MINIBUS', N'3')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (14, N'CITYBUS', N'3')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (15, N'MEDIUM TRUCK', N'3')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (16, N'EXPRESS BUS', N'4')
INSERT [dbo].[VehicaleType] ([VehicaleTypeID], [Name], [Class]) VALUES (17, N'HEABY TRUCK', N'4')
SET IDENTITY_INSERT [dbo].[VehicaleType] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_TransNo_Cashinvoice]    Script Date: 2/22/2026 12:16:30 AM ******/
ALTER TABLE [dbo].[CashInvoice] ADD  CONSTRAINT [UQ_TransNo_Cashinvoice] UNIQUE NONCLUSTERED 
(
	[TransNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employer] ADD  CONSTRAINT [DF_Employer_Permissions]  DEFAULT ((1)) FOR [Permissions]
GO
ALTER TABLE [dbo].[CashInvoice]  WITH CHECK ADD  CONSTRAINT [FK_CashInvoice_Customer] FOREIGN KEY([Cid])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CashInvoice] CHECK CONSTRAINT [FK_CashInvoice_Customer]
GO
ALTER TABLE [dbo].[CashInvoice]  WITH CHECK ADD  CONSTRAINT [FK_CashInvoice_Employer] FOREIGN KEY([CreatedByEmployerID])
REFERENCES [dbo].[Employer] ([EmployerID])
GO
ALTER TABLE [dbo].[CashInvoice] CHECK CONSTRAINT [FK_CashInvoice_Employer]
GO
ALTER TABLE [dbo].[CashInvoice]  WITH CHECK ADD  CONSTRAINT [FK_CashInvoice_VehicaleType] FOREIGN KEY([Vid])
REFERENCES [dbo].[VehicaleType] ([VehicaleTypeID])
GO
ALTER TABLE [dbo].[CashInvoice] CHECK CONSTRAINT [FK_CashInvoice_VehicaleType]
GO
ALTER TABLE [dbo].[CashInvoiceService]  WITH CHECK ADD  CONSTRAINT [FK_CashInvoiceService_CashInvoice] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[CashInvoice] ([InvoiceID])
GO
ALTER TABLE [dbo].[CashInvoiceService] CHECK CONSTRAINT [FK_CashInvoiceService_CashInvoice]
GO
ALTER TABLE [dbo].[CashInvoiceService]  WITH CHECK ADD  CONSTRAINT [FK_CashInvoiceService_Service] FOREIGN KEY([Sid])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[CashInvoiceService] CHECK CONSTRAINT [FK_CashInvoiceService_Service]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_VehicaleType] FOREIGN KEY([Vid])
REFERENCES [dbo].[VehicaleType] ([VehicaleTypeID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_VehicaleType]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_CashInvoice] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[CashInvoice] ([InvoiceID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_CashInvoice]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Employer] FOREIGN KEY([PaidByEmployerID])
REFERENCES [dbo].[Employer] ([EmployerID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Employer]
GO
ALTER TABLE [dbo].[CashInvoice]  WITH CHECK ADD  CONSTRAINT [CK_Cash_Status] CHECK  (([Status]='Canceled' OR [Status]='Paid' OR [Status]='Open' OR [Status]='PartiallyPaid'))
GO
ALTER TABLE [dbo].[CashInvoice] CHECK CONSTRAINT [CK_Cash_Status]
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewCashInvoice]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewCashInvoice]
    @TransNo NVARCHAR(50),
    @Cid INT,
    @Vid INT,
    @InvoiceDate DATETIME,
    @Status NVARCHAR(50),
    @TotalAmount DECIMAL(18,2),
	@CreatedByEmployerID INT
AS
BEGIN
    INSERT INTO CashInvoice(TransNo, Cid, Vid, InvoiceDate, Status, TotalAmount, CreatedByEmployerID)
    VALUES (@TransNo, @Cid, @Vid, @InvoiceDate, @Status, @TotalAmount, @CreatedByEmployerID);

    SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewCashInvoiceService]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewCashInvoiceService]
    @InvoiceID INT,
    @Sid INT,
    @Price DECIMAL(18,2)
AS
BEGIN
    INSERT INTO CashInvoiceService(InvoiceID, Sid, Price)
    VALUES (@InvoiceID, @Sid, @Price);

    SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewCompany]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewCompany]
@CompanyName NVARCHAR(50),
@Address NVARCHAR(50)
AS 
BEGIN 
	INSERT INTO Company(CompanyName, Address)
	VALUES (@CompanyName, @Address);
	SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewCostOfGood]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewCostOfGood]
@CostName NVARCHAR(50),
@Cost DECIMAL(18, 2),
@CostDate DATE
AS
BEGIN 
	INSERT INTO CostGood(CostName, Cost, CostDate)
	VALUES (@CostName, @Cost, @CostDate)
	SELECT SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewCustomer]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewCustomer]
    @Vid INT,
    @Name NVARCHAR(50),
    @Phone NVARCHAR(50),
    @CarNo NVARCHAR(50),
    @CarModel NVARCHAR(50),
    @Address NVARCHAR(200),
    @Points INT
AS
BEGIN
    INSERT INTO Customer
        (Vid, Name, Phone, CarNo, CarModel, Address, Points)
    VALUES
        (@Vid, @Name, @Phone, @CarNo, @CarModel, @Address, @Points);

    SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewEmployer]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewEmployer]
@Name NVARCHAR(100),
@Phone NVARCHAR(50),
@Address NVARCHAR(200),
@Dob DATE,
@Role NVARCHAR(50),
@Salary DECIMAL(18, 2),
@Password NVARCHAR(50),
@Gender TINYINT,
@Permissions INT
AS 
BEGIN
	INSERT INTO Employer
    (Name, Phone, Address, Dob, Role, Salary, Password, Gender, Permissions)
	VALUES
    (@Name, @Phone, @Address, @Dob, @Role, @Salary, @Password, @Gender, @Permissions);

	SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewPayment]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewPayment] 
    @InvoiceID INT,
    @Amount DECIMAL(18,2),
    @PaymentMethod NVARCHAR(50),
    @Notes NVARCHAR(200),
	@PaidByEmployerID INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY

        DECLARE @Total DECIMAL(18,2);
        DECLARE @Paid DECIMAL(18,2);
        DECLARE @Remaining DECIMAL(18,2);
        DECLARE @ActualAmount DECIMAL(18,2);

        SELECT @Total = TotalAmount
        FROM CashInvoice
        WHERE InvoiceID = @InvoiceID;

        SELECT @Paid = ISNULL(SUM(Amount), 0)
        FROM Payment
        WHERE InvoiceID = @InvoiceID;

        SET @Remaining = @Total - @Paid;

        IF @Remaining <= 0
            THROW 50001, 'Invoice is already fully paid.', 1;

        SET @ActualAmount =
            CASE
                WHEN @Amount > @Remaining THEN @Remaining
                ELSE @Amount
            END;

        INSERT INTO Payment
        (InvoiceID, PaymentDate, Amount, PaymentMethod, Notes, PaidByEmployerID)
        VALUES
        (@InvoiceID, GETDATE(), @ActualAmount, @PaymentMethod, @Notes, @PaidByEmployerID);

        EXEC SP_UpdateInvoiceStatusAfterPayment @InvoiceID;

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewService]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewService]
    @Name NVARCHAR(50),
    @Price DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Service (Name, Price)
    VALUES (@Name, @Price);

    SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewVehicaleType]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewVehicaleType]
@Name NVARCHAR(50),
@Class NVARCHAR(50)
AS 
BEGIN
	INSERT INTO VehicaleType(Name, Class)
	VALUES (@Name, @Class)
	SELECT SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCashInvoice]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteCashInvoice]
    @InvoiceID INT
AS
BEGIN
    DELETE FROM CashInvoice
    WHERE InvoiceID = @InvoiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCashInvoiceService]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteCashInvoiceService]
    @InvoiceServiceID INT
AS
BEGIN
    DELETE FROM CashInvoiceService
    WHERE InvoiceServiceID = @InvoiceServiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCompany]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteCompany]
@CompanyID INT
AS
BEGIN
	DELETE FROM Company
	WHERE CompanyID = @CompanyID;
END



GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCostOfGood]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteCostOfGood]
@CostID INT
AS
BEGIN
	DELETE FROM CostGood 
	WHERE CostID = @CostID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCustomer]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteCustomer]
    @CustomerID INT
AS
BEGIN
    DELETE FROM Customer
    WHERE CustomerID = @CustomerID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteEmployer]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteEmployer]
@EmployerID INT
AS 
BEGIN
	DELETE FROM Employer
	WHERE EmployerID = @EmployerID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteService]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteService]
    @ServiceID INT
AS
BEGIN
    DELETE FROM Service
    WHERE ServiceID = @ServiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteVehicaleType]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteVehicaleType]
@VehicaleTypeID INT
AS
BEGIN
	DELETE FROM VehicaleType
	WHERE VehicaleTypeID = @VehicaleTypeID;
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCashInvoices]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllCashInvoices]
AS
BEGIN
    SELECT * FROM CashInvoice;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCashInvoiceServices]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllCashInvoiceServices]
AS
BEGIN
    SELECT * FROM CashInvoiceService;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCompanies]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetAllCompanies]
AS 
BEGIN
	SELECT * FROM Company;
END




GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCostOfGoods]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetAllCostOfGoods]
AS
BEGIN
	SELECT * FROM CostGood;
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCustomers]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllCustomers]
AS
BEGIN
SELECT
    C.CustomerID,
	VT.VehicaleTypeID,
    C.Name,
    C.Phone,
    C.CarNo,
    C.CarModel,
    VT.Name AS CarType,
    C.Address,
    C.Points
FROM Customer C
INNER JOIN VehicaleType VT ON C.Vid = VT.VehicaleTypeID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllEmployer]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllEmployer]
AS 
BEGIN
	SELECT * FROM Employer;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllServices]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllServices]
AS
BEGIN
    SELECT * FROM Service;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllVehicaleTypes]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllVehicaleTypes]
AS
BEGIN
	SELECT * FROM VehicaleType;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCashInvoiceByID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCashInvoiceByID]
    @InvoiceID INT
AS
BEGIN
    SELECT * FROM CashInvoice
    WHERE InvoiceID = @InvoiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCashInvoiceReport]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCashInvoiceReport]
AS
BEGIN
    SELECT 
        CI.InvoiceID,
        CI.TransNo,
        C.Name AS CustomerName,
        C.CarModel,
        V.Name AS VehicleType,
        CI.InvoiceDate,
        ISNULL(Srv.Services, '') AS Services,
        CI.TotalAmount,
        CI.Status
    FROM CashInvoice CI 
    INNER JOIN Customer C 
        ON CI.Cid = C.CustomerID
    INNER JOIN VehicaleType V 
        ON CI.Vid = V.VehicaleTypeID
    LEFT JOIN
    (
        SELECT
            CIS.InvoiceID,
            STRING_AGG(S.Name, ', ') AS Services
        FROM CashInvoiceService CIS
        INNER JOIN Service S 
            ON CIS.Sid = S.ServiceID
        GROUP BY CIS.InvoiceID
    ) Srv
        ON CI.InvoiceID = Srv.InvoiceID
    ORDER BY CI.InvoiceDate DESC
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCashInvoiceReportByID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCashInvoiceReportByID]
    @InvoiceID INT
AS
BEGIN
    SELECT 
        CI.InvoiceID,
        CI.TransNo,
        C.Name AS CustomerName,
        C.CarModel,
        V.Name AS VehicleType,
        CI.InvoiceDate,
        ISNULL(Srv.Services, '') AS Services,
        CI.TotalAmount,
        CI.Status
    FROM CashInvoice CI 
    INNER JOIN Customer C 
        ON CI.Cid = C.CustomerID
    INNER JOIN VehicaleType V 
        ON CI.Vid = V.VehicaleTypeID
    LEFT JOIN
    (
        SELECT
            CIS.InvoiceID,
            STRING_AGG(S.Name, ', ') AS Services
        FROM CashInvoiceService CIS
        INNER JOIN Service S 
            ON CIS.Sid = S.ServiceID
        GROUP BY CIS.InvoiceID
    ) Srv
        ON CI.InvoiceID = Srv.InvoiceID
    WHERE CI.InvoiceID = @InvoiceID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCashInvoiceServiceByID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCashInvoiceServiceByID]
    @InvoiceServiceID INT
AS
BEGIN
    SELECT * FROM CashInvoiceService
    WHERE InvoiceServiceID = @InvoiceServiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCompanyInfoByID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCompanyInfoByID]
@CompanyID INT
AS 
BEGIN 
	SELECT * FROM Company 
	WHERE CompanyID = @CompanyID
END



GO
/****** Object:  StoredProcedure [dbo].[SP_GetCostOfGoodInfoByID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCostOfGoodInfoByID]
@CostID INT
AS 
BEGIN 
	SELECT * FROM CostGood WHERE CostID = @CostID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCostOfGoodsByDate]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCostOfGoodsByDate]
	@StartDate DATE,
    @EndDate DATE
AS
BEGIN
	SELECT 
        CostName, 
        Cost,
		CostDate
    FROM CostGood
    WHERE CostDate BETWEEN  @StartDate AND @EndDate
    ORDER BY CostDate ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCustomerInfoByID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCustomerInfoByID]
    @CustomerID INT
AS
BEGIN
    SELECT *
    FROM Customer
    WHERE CustomerID = @CustomerID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetEmployerByUserNameAndPassword]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetEmployerByUserNameAndPassword]
	@UserName NVARCHAR(50),
	@Password NVARCHAR(50)
AS
BEGIN
	SELECT * FROM Employer
	WHERE Name = @UserName AND Password = @Password;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetEmployerInfoByID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetEmployerInfoByID]
@EmployerID INT
AS 
BEGIN
	SELECT * FROM Employer WHERE EmployerID = @EmployerID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetInvoiceDetails_Header]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetInvoiceDetails_Header]
    @InvoiceID INT
AS
BEGIN
    SELECT
        CI.InvoiceID,
        CI.TransNo,
        CI.InvoiceDate,
        CI.Status,
        CI.TotalAmount,

        C.Name        AS CustomerName,
        C.CarModel,

        V.Name        AS VehicleType,
        V.Class
    FROM CashInvoice CI
    INNER JOIN Customer C ON CI.Cid = C.CustomerID
    INNER JOIN VehicaleType V ON CI.Vid = V.VehicaleTypeID
    WHERE CI.InvoiceID = @InvoiceID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetInvoicePayments]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetInvoicePayments]
    @InvoiceID INT
AS
BEGIN
    SELECT
        PaymentDate,
        Amount,
        PaymentMethod
    FROM Payment
    WHERE InvoiceID = @InvoiceID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetInvoiceServices]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetInvoiceServices]
    @InvoiceID INT
AS
BEGIN
    SELECT
        S.Name AS ServiceName,
        CIS.Price
    FROM CashInvoiceService CIS
    INNER JOIN Service S ON CIS.Sid = S.ServiceID
    WHERE CIS.InvoiceID = @InvoiceID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetInvoicesList]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetInvoicesList]
AS
BEGIN
    SELECT *
    FROM vw_InvoicesList;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetLastTransNoByDate]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetLastTransNoByDate]
    @InvoiceDate DATE
AS
BEGIN
    SELECT TOP 1 TransNo
    FROM CashInvoice
    WHERE CAST(InvoiceDate AS DATE) = @InvoiceDate
    ORDER BY InvoiceID DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetPaymentsByInvoice]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetPaymentsByInvoice]
@InvoiceID INT
AS
BEGIN
	SELECT * 
	FROM Payment
	WHERE InvoiceID = @InvoiceID;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GetRevenuePerDay]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetRevenuePerDay]
	@StartDate DATE,
    @EndDate DATE
AS
BEGIN
	SELECT 
        InvoiceDate, 
        SUM(TotalAmount) AS TotalPrice
    FROM CashInvoice
    WHERE InvoiceDate BETWEEN @StartDate AND @EndDate 
      AND Status = 'Paid'
    GROUP BY InvoiceDate
    ORDER BY InvoiceDate ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetServiceByID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetServiceByID]
    @ServiceID INT
AS
BEGIN
    SELECT * FROM Service
    WHERE ServiceID = @ServiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetServicesByInvoiceID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetServicesByInvoiceID]
    @InvoiceID INT
AS
BEGIN
    SELECT cis.*, s.Name AS ServiceName
    FROM CashInvoiceService cis
    INNER JOIN Service s ON cis.Sid = s.ServiceID
    WHERE cis.InvoiceID = @InvoiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTopSellingServices]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetTopSellingServices]
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT TOP 10 
        SA.Name AS ServiceName,
        COUNT(CIS.Sid) AS Qty, 
        ISNULL(SUM(SA.Price), 0) AS TotalIncome
    FROM CashInvoiceService CIS
    INNER JOIN Service SA ON CIS.Sid = SA.ServiceID
    INNER JOIN CashInvoice CI ON CIS.InvoiceID = CI.InvoiceID
    WHERE CI.InvoiceDate BETWEEN @StartDate AND @EndDate
      AND CI.Status = 'Paid' 
    GROUP BY SA.Name
    ORDER BY Qty DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTotalPriceByInvoiceID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetTotalPriceByInvoiceID]
@InvoiceID INT
AS 
BEGIN
	SELECT SUM(Price) FROM CashInvoiceService
	WHERE InvoiceID =@InvoiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetVehicaleTypeByID]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetVehicaleTypeByID]
    @VehicaleTypeID Int
AS
BEGIN
    SELECT * FROM VehicaleType WHERE VehicaleTypeID = @VehicaleTypeID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IsCashInvoiceExists]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IsCashInvoiceExists]
    @InvoiceID INT
AS
BEGIN
    SELECT Found = 1
    FROM CashInvoice
    WHERE InvoiceID = @InvoiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IsCashInvoiceServiceExists]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IsCashInvoiceServiceExists]
    @InvoiceServiceID INT
AS
BEGIN
    SELECT Found = 1
    FROM CashInvoiceService
    WHERE InvoiceServiceID = @InvoiceServiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IsCompanyExists]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IsCompanyExists]
@CompanyID INT
AS
BEGIN
	SELECT Found = 1 FROM Company WHERE CompanyID = @CompanyID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IsCustomerExists]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IsCustomerExists]
    @CustomerID INT
AS
BEGIN
    SELECT 1
    FROM Customer
    WHERE CustomerID = @CustomerID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IsEmployerExist]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IsEmployerExist]
@EmployerID INT
AS 
BEGIN
	SELECT 1 FROM Employer
	WHERE EmployerID = @EmployerID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IsServiceExists]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IsServiceExists]
    @ServiceID INT
AS
BEGIN
    SELECT 1
    FROM Service
    WHERE ServiceID = @ServiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IsVehicaleTypeExists]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_IsVehicaleTypeExists]
@VehicaleTypeID INT
AS 
BEGIN 
	SELECT Found = 1 FROM VehicaleType
	WHERE VehicaleTypeID = @VehicaleTypeID;
END


GO
/****** Object:  StoredProcedure [dbo].[SP_PrintInvoiceDetails]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PrintInvoiceDetails]
    @InvoiceID INT
AS
BEGIN
    SELECT 
        CI.InvoiceID,
        CI.TransNo,
        CI.InvoiceDate,
        CI.TotalAmount,
        CI.Status,

        C.Name AS CustomerName,
        C.CarNo,
        C.CarModel,
        V.Name AS VehicleType,

        S.Name AS ServiceName,
        CIS.Price AS ServicePrice,

        ISNULL((SELECT SUM(Amount) FROM Payment WHERE InvoiceID = CI.InvoiceID), 0) AS PaidAmount,
        (CI.TotalAmount - ISNULL((SELECT SUM(Amount) FROM Payment WHERE InvoiceID = CI.InvoiceID), 0)) AS RemainingAmount
    FROM CashInvoice CI 
    INNER JOIN Customer C ON CI.Cid = C.CustomerID
    INNER JOIN VehicaleType V ON CI.Vid = V.VehicaleTypeID
    INNER JOIN CashInvoiceService CIS ON CI.InvoiceID = CIS.InvoiceID
    INNER JOIN Service S ON CIS.Sid = S.ServiceID
    WHERE CI.InvoiceID = @InvoiceID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCashInvoice]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateCashInvoice]
    @InvoiceID INT,
    @TransNo NVARCHAR(50),
    @Cid INT,
    @Vid INT,
    @InvoiceDate DATETIME,
    @Status NVARCHAR(50),
    @TotalAmount DECIMAL(18,2)
AS
BEGIN
    UPDATE CashInvoice
    SET TransNo = @TransNo,
        Cid = @Cid,
        Vid = @Vid,
        InvoiceDate = @InvoiceDate,
        Status = @Status,
        TotalAmount = @TotalAmount
    WHERE InvoiceID = @InvoiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCashInvoiceService]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateCashInvoiceService]
    @InvoiceServiceID INT,
    @InvoiceID INT,
    @Sid INT,
    @Price DECIMAL(18,2)
AS
BEGIN
    UPDATE CashInvoiceService
    SET InvoiceID = @InvoiceID,
        Sid = @Sid,
        Price = @Price
    WHERE InvoiceServiceID = @InvoiceServiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCompany]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateCompany]
@CompanyID INT,
@CompanyName NVARCHAR(50),
@Address NVARCHAR(50)
AS
BEGIN
	UPDATE Company
	SET CompanyName = @CompanyName,
		Address = @Address
	WHERE CompanyID = @CompanyID;
END

GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCostOfGood]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateCostOfGood]
@CostID INT,
@CostName NVARCHAR(50),
@Cost DECIMAL(18, 2),
@CostDate DATE
AS
BEGIN
	UPDATE CostGood 
	SET CostName = @CostName,
		Cost = @Cost,
		CostDate = @CostDate
	WHERE CostID = @CostID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCustomer]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateCustomer]
    @CustomerID INT,
    @Vid INT,
    @Name NVARCHAR(50),
    @Phone NVARCHAR(50),
    @CarNo NVARCHAR(50),
    @CarModel NVARCHAR(50),
    @Address NVARCHAR(200),
    @Points INT
AS
BEGIN
    UPDATE Customer
    SET Vid = @Vid,
        Name = @Name,
        Phone = @Phone,
        CarNo = @CarNo,
        CarModel = @CarModel,
        Address = @Address,
        Points = @Points
    WHERE CustomerID = @CustomerID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCustomerPoints]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateCustomerPoints]
    @CustomerID INT,
    @Points INT
AS
BEGIN
    UPDATE Customer
    SET Points = @Points
    WHERE CustomerID = @CustomerID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateEmployer]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateEmployer]
@EmployerID INT,
@Name NVARCHAR(100),
@Phone NVARCHAR(50),
@Address NVARCHAR(200),
@Dob DATE,
@Role NVARCHAR(50),
@Salary DECIMAL(18, 2),
@Password NVARCHAR(50),
@Gender TINYINT,
@Permissions INT
AS 
BEGIN
	UPDATE Employer
	SET Name = @Name,
		Phone = @Phone,
		Address = @Address,
		Dob = @Dob,
		Role = @Role,
		Salary = @Salary,
		Password = @Password,
		Gender = @Gender,
        Permissions = @Permissions
	WHERE EmployerID = @EmployerID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateInvoiceStatusAfterPayment]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateInvoiceStatusAfterPayment]
@InvoiceID INT
AS
BEGIN
	DECLARE @Total DECIMAL(18,2)
	DECLARE @Paid DECIMAL(18,2)

	SELECT @Total = TotalAmount 
	FROM CashInvoice
	WHERE InvoiceID = @InvoiceID

	SELECT @Paid = ISNULL(SUM(Amount),0)
	FROM Payment
	WHERE InvoiceID = @InvoiceID

	UPDATE CashInvoice
		SET Status =
			CASE
				WHEN @Paid = 0 THEN 'Open'
				WHEN @Paid < @Total THEN 'PartiallyPaid'
				ELSE 'Paid'
			END
		WHERE InvoiceID = @InvoiceID;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateInvoiceTotal]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateInvoiceTotal]
    @InvoiceID INT
AS
BEGIN
    UPDATE CashInvoice
    SET TotalAmount = (
        SELECT SUM(Price)
        FROM CashInvoiceService
        WHERE InvoiceID = @InvoiceID
    )
    WHERE InvoiceID = @InvoiceID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateService]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateService]
    @ServiceID INT,
    @Name NVARCHAR(50),
    @Price DECIMAL(18,2)
AS
BEGIN
    UPDATE Service
    SET Name = @Name,
        Price = @Price
    WHERE ServiceID = @ServiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateVehicaleType]    Script Date: 2/22/2026 12:16:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateVehicaleType]
@VehicaleTypeID INT,
@Name NVARCHAR(50),
@Class NVARCHAR(50)
AS 
BEGIN
	UPDATE VehicaleType
	SET Name = @Name,
		Class = @Class
		WHERE VehicaleTypeID = @VehicaleTypeID;
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -120
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CI"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 338
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "V"
            Begin Extent = 
               Top = 343
               Left = 48
               Bottom = 484
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Srv"
            Begin Extent = 
               Top = 127
               Left = 290
               Bottom = 246
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_InvoicesList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_InvoicesList'
GO
