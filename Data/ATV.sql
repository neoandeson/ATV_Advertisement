USE [master]
GO
/****** Object:  Database [ATV]    Script Date: 08/12/2019 9:34:21 AM ******/
CREATE DATABASE [ATV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ATV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.TIENTPSQL\MSSQL\DATA\ATV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ATV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.TIENTPSQL\MSSQL\DATA\ATV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ATV] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ATV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ATV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ATV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ATV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ATV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ATV] SET ARITHABORT OFF 
GO
ALTER DATABASE [ATV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ATV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ATV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ATV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ATV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ATV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ATV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ATV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ATV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ATV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ATV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ATV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ATV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ATV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ATV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ATV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ATV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ATV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ATV] SET  MULTI_USER 
GO
ALTER DATABASE [ATV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ATV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ATV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ATV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ATV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ATV] SET QUERY_STORE = OFF
GO
USE [ATV]
GO
/****** Object:  Table [dbo].[BusinessLog]    Script Date: 08/12/2019 9:34:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[ActorId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[DateAct] [datetime] NOT NULL,
 CONSTRAINT [PK_BusinessLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 08/12/2019 9:34:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nchar](10) NOT NULL,
	[CustomerCode] [nvarchar](20) NOT NULL,
	[CustomerName] [nvarchar](200) NULL,
	[SumCost] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[Cost] [float] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractItem]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractCode] [nvarchar](10) NOT NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[DurationSecond] [int] NOT NULL,
	[NumberOfShow] [int] NOT NULL,
	[TotalCost] [float] NOT NULL,
	[ShowTypeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_ContractDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostRule]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostRule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeSlotId] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[ShowTypeId] [int] NOT NULL,
 CONSTRAINT [PK_CostRule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Phone1] [nvarchar](14) NOT NULL,
	[Phone2] [nvarchar](14) NULL,
	[Email] [nvarchar](50) NULL,
	[Fax] [nvarchar](14) NULL,
	[TaxCode] [nvarchar](10) NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountApply]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountApply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplyPrice] [float] NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Percentage] [float] NOT NULL,
 CONSTRAINT [PK_DiscountApply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Duration]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Length] [int] NOT NULL,
	[StatusId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Duration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Level] [int] NOT NULL,
	[ParentName] [nvarchar](30) NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductScheduleShow]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductScheduleShow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractDetailId] [int] NOT NULL,
	[ProductName] [nvarchar](80) NOT NULL,
	[ShowTime] [varchar](5) NOT NULL,
	[ShowTimeInt] [int] NULL,
	[ShowDate] [datetime] NOT NULL,
	[ShowTypeId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TimeSlot] [nvarchar](50) NOT NULL,
	[TimeSlotCode] [varchar](10) NULL,
	[TimeSlotLength] [int] NOT NULL,
	[Cost] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[TotalCost] [float] NOT NULL,
	[OrderNumber] [int] NOT NULL,
 CONSTRAINT [PK_ProductScheduleShow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleHasMenuItem]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleHasMenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuItemId] [int] NOT NULL,
 CONSTRAINT [PK_RoleHasMenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [char](1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Session_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShowType]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShowType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_ContractType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ValueString] [nvarchar](50) NULL,
	[ValueNumber] [float] NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_SystemConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemLog]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_SystemLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FromHour] [int] NOT NULL,
	[SessionCode] [char](1) NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 08/12/2019 9:34:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BusinessLog] ON 

INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (1, N'staff Sửa hợp đồng mã HD0031219 ', 2, 5, CAST(N'2019-12-07T22:31:02.740' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (2, N'staff Sửa hợp đồng mã VINAMILK', 2, 5, CAST(N'2019-12-07T23:06:03.283' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (3, N'staff Sửa khách hàng mã DHGPHARMA', 2, 5, CAST(N'2019-12-07T23:08:02.730' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (4, N'staff Xuất file lịch phát sóng ngày 07/12/2019 11:08:56 PM', 2, 6, CAST(N'2019-12-07T23:09:00.183' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (5, N'staff Xuất file lịch phát sóng ngày 07/12/2019 11:11:10 PM', 2, 6, CAST(N'2019-12-07T23:11:27.520' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (6, N'staff Xuất file lịch phát sóng ngày 07/12/2019 11:11:10 PM và gửi mail cho gooddaytoeverybody@gmail.com', 2, 6, CAST(N'2019-12-07T23:11:35.697' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (7, N'staff Xuất file lịch phát sóng ngày 07/12/2019 11:13:24 PM', 2, 6, CAST(N'2019-12-07T23:13:38.940' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (8, N'staff Xuất file lịch phát sóng ngày 07/12/2019 11:13:24 PM và gửi mail cho gooddaytoeverybody@gmail.com', 2, 6, CAST(N'2019-12-07T23:13:46.973' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (9, N'admin Sửa mật khẩu', 1, 5, CAST(N'2019-12-08T09:20:49.297' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (10, N'admin Sửa mật khẩu', 1, 5, CAST(N'2019-12-08T09:21:21.663' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (11, N'admin Sửa mật khẩu thành mặc định cho username 2', 1, 5, CAST(N'2019-12-08T09:25:50.197' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (12, N'staff Sửa mật khẩu', 2, 5, CAST(N'2019-12-08T09:26:29.090' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (13, N'admin Sửa mật khẩu thành mặc định cho username ', 1, 5, CAST(N'2019-12-08T09:27:04.833' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (14, N'admin Sửa mật khẩu thành mặc định cho username ', 1, 5, CAST(N'2019-12-08T09:28:35.690' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (15, N'admin Sửa mật khẩu thành mặc định cho username staff', 1, 5, CAST(N'2019-12-08T09:30:19.267' AS DateTime))
INSERT [dbo].[BusinessLog] ([Id], [Content], [ActorId], [TypeId], [DateAct]) VALUES (16, N'admin Sửa mật khẩu thành mặc định cho username staff', 1, 5, CAST(N'2019-12-08T09:31:05.633' AS DateTime))
SET IDENTITY_INSERT [dbo].[BusinessLog] OFF
SET IDENTITY_INSERT [dbo].[Contract] ON 

INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [CustomerName], [SumCost], [Discount], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'HD0011219 ', N'VINAMILK', N'Công ty Cổ phần Sữa Việt Nam Vinamilk', 7000000, 0, 7000000, CAST(N'2019-12-06T06:27:44.400' AS DateTime), CAST(N'2019-12-31T06:27:44.000' AS DateTime), 1, CAST(N'2019-12-06T06:28:12.080' AS DateTime), CAST(N'2019-12-06T09:06:05.573' AS DateTime), 2)
INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [CustomerName], [SumCost], [Discount], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'HD0021219 ', N'TKL', N'Công ty CP Truyền thông TK-L', 15000000, 0, 15000000, CAST(N'2019-12-06T06:30:11.297' AS DateTime), CAST(N'2019-12-31T06:30:11.000' AS DateTime), 1, CAST(N'2019-12-06T06:30:22.567' AS DateTime), CAST(N'2019-12-06T06:32:01.867' AS DateTime), 2)
INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [CustomerName], [SumCost], [Discount], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'HD0031219 ', N'SAOTHUY', N'Cty Truyền thông & giải trí Sao Thủy', 48000000, 5, 45600000, CAST(N'2019-12-06T09:07:59.833' AS DateTime), CAST(N'2019-12-31T09:07:59.000' AS DateTime), 1, CAST(N'2019-12-06T09:08:14.100' AS DateTime), CAST(N'2019-12-07T22:31:01.757' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Contract] OFF
SET IDENTITY_INSERT [dbo].[ContractItem] ON 

INSERT [dbo].[ContractItem] ([Id], [ContractCode], [FileName], [ProductName], [DurationSecond], [NumberOfShow], [TotalCost], [ShowTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'HD0011219', N'SocolaMilk V419', N'Sữa socola', 10, 5, 7000000, 1, 1, CAST(N'2019-12-06T06:28:49.187' AS DateTime), CAST(N'2019-12-06T09:06:03.343' AS DateTime), 2)
INSERT [dbo].[ContractItem] ([Id], [ContractCode], [FileName], [ProductName], [DurationSecond], [NumberOfShow], [TotalCost], [ShowTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'HD0021219', N'trailer dmat 02', N'Trailer Đôi mắt ân tình', 30, 5, 15000000, 1, 1, CAST(N'2019-12-06T06:31:22.640' AS DateTime), CAST(N'2019-12-06T06:32:00.087' AS DateTime), 2)
INSERT [dbo].[ContractItem] ([Id], [ContractCode], [FileName], [ProductName], [DurationSecond], [NumberOfShow], [TotalCost], [ShowTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'HD0031219', N'QC Ca Nhac', N'CaNhac', 20, 10, 48000000, 1, 1, CAST(N'2019-12-06T09:08:36.550' AS DateTime), CAST(N'2019-12-06T09:09:51.190' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ContractItem] OFF
SET IDENTITY_INSERT [dbo].[CostRule] ON 

INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (1, 1, 10, 1400000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2, 1, 15, 1800000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (3, 1, 20, 2300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (4, 1, 30, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (5, 2, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (6, 2, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (7, 3, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (8, 3, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (9, 4, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (10, 4, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (11, 4, 20, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (12, 4, 30, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (13, 5, 10, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (14, 5, 15, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (15, 5, 20, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (16, 5, 30, 5000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (17, 6, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (18, 6, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (19, 6, 20, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (20, 6, 30, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (21, 7, 10, 5200000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (22, 7, 15, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (23, 7, 20, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (24, 7, 30, 9500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (25, 8, 10, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (26, 8, 15, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (27, 8, 20, 8400000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (28, 8, 30, 12000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (29, 9, 10, 5200000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (30, 9, 15, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (31, 9, 20, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (32, 9, 30, 9500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (33, 10, 10, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (34, 10, 15, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (35, 11, 10, 4500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (1036, 8, 30, 10000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (1037, 1, 180, 12000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (1038, 5, 180, 15000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (1039, 1, 600, 5000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2037, 2, 10, 4000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2038, 2, 15, 5000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2039, 1011, 10, 4700000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2040, 1011, 15, 5300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2041, 1011, 20, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2042, 1011, 30, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2043, 1012, 10, 15000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2044, 1012, 15, 16000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2045, 1012, 15, 10000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2046, 1012, 10, 10000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2047, 1012, 10, 20000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2048, 1013, 180, 12000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2049, 1013, 600, 9000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2050, 9, 180, 8000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2051, 9, 600, 7000000, 2)
SET IDENTITY_INSERT [dbo].[CostRule] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'VINAMILK', N'Công ty Cổ phần Sữa Việt Nam Vinamilk', N'Số 10, Đường Tân Trào, phường Tân Phú, quận 7, Tp. HCM', N'84028541', N'', N'vinamilk@gmail.com', N'840285416', N'5489098098', 1, NULL, CAST(N'2019-12-07T23:06:02.237' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'DHGPHARMA', N'Công Ty Cp Dược Hậu Giang', N'200 Cô Bắc, Phường Cô Giang, 1, Hồ Chí Minh', N'028 3836 9353', N'', N'dhg@gmail.com', N'', N'', 1, NULL, CAST(N'2019-12-07T23:08:01.843' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'TANHIEPPHAT', N'Tập đoàn Nước giải khát Tân Hiệp Phát', N'219 Đại lộ Bình Dương, Vĩnh Phú, Thuận An, Bình Dương', N'0898 760 066', N'', NULL, N'', N'7236472347', 1, NULL, CAST(N'2019-09-04T23:29:40.380' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1002, N'TKL', N'Công ty CP Truyền thông TK-L', N'222 Pasteur - Phường 06 - Quận 3 - TP. Hồ Chí Minh', N'028-38232246', N'', NULL, N'028-38290507', N'0300993574', 1, NULL, CAST(N'2019-09-20T13:14:46.643' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1003, N'UNILEVER', N'Công ty TNHH Quốc tế Unilever Việt Nam', N'156 Nguyễn Lương Bằng, Phường Tân Phú, Quận 7, Tp Hồ Chí Minh', N'0283892024', N'02854135686', NULL, N'', N'', 1, NULL, CAST(N'2019-09-20T13:18:18.550' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1004, N'TUOITREVIET', N'CTY TNHH SX Phim Tuổi Trẻ Việt', N'123 Hoàng Hoa Thám P.3 Q.Tân Bình', N'92193402938', N'8093813923', NULL, N'23942890', N'1094021394', 1, NULL, CAST(N'2019-10-19T16:23:34.687' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1005, N'LKC', N'Cty LKC media', N'5A Nguyễn Xí, P12 Quận Phú Nhuận', N'293409923409', N'98012837412980', NULL, N'8701298417891', N'1132487029', 1, NULL, CAST(N'2019-10-19T16:24:54.830' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1006, N'THONGBAO', N'Thông báo rao vặt', N'Không có', N'98723847901827', N'0982713408172', N'', N'1238974018', N'', 1, NULL, CAST(N'2019-10-19T17:13:17.177' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1007, N'SAOTHUY', N'Cty Truyền thông & giải trí Sao Thủy', N'12 Nguyễn Thái Học, P12. Quận 4', N'098123098120', N'', N'saothuy@gmail.com', N'', N'9870213984', 1, NULL, CAST(N'2019-10-19T17:22:19.330' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[DiscountApply] ON 

INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (1, 50, N'Từ 5 triệu đồng đến 50 triệu đồng', 7)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (2, 100, N'Từ 50 triệu đồng đến 100 triệu đồng', 10)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (3, 200, N'Từ 100 triệu đồng đến 200 triệu đồng', 12)
SET IDENTITY_INSERT [dbo].[DiscountApply] OFF
SET IDENTITY_INSERT [dbo].[Duration] ON 

INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, 10, 1, CAST(N'2019-09-15T11:22:34.643' AS DateTime), CAST(N'2019-09-15T11:22:48.263' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, 15, 1, CAST(N'2019-09-15T11:22:52.600' AS DateTime), CAST(N'2019-09-15T11:22:52.600' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, 20, 1, CAST(N'2019-09-15T11:22:57.657' AS DateTime), CAST(N'2019-09-15T11:22:57.657' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, 30, 1, CAST(N'2019-09-15T11:23:02.320' AS DateTime), CAST(N'2019-09-15T11:23:02.320' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, 120, 1, CAST(N'2019-11-10T14:24:16.680' AS DateTime), CAST(N'2019-11-10T14:24:16.680' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, 60, 1, CAST(N'2019-11-10T14:54:37.127' AS DateTime), CAST(N'2019-11-10T14:54:37.130' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1005, 180, 1, CAST(N'2019-12-04T09:30:17.850' AS DateTime), CAST(N'2019-12-04T09:30:17.850' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1006, 600, 1, CAST(N'2019-12-04T09:30:23.377' AS DateTime), CAST(N'2019-12-04T09:30:23.377' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Duration] OFF
SET IDENTITY_INSERT [dbo].[MenuItem] ON 

INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1, N'Danh mục', 0, NULL, 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (2, N'Danh mục khách hàng', 1, N'Danh mục', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (3, N'Danh mục loại quảng cáo', 1, N'Danh mục', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (4, N'Báo cáo doanh thu', 1, N'In ấn', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (5, N'Danh mục thời lượng', 1, N'Danh mục', 6)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (6, N'Danh mục buổi phát', 1, N'Danh mục', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (7, N'Danh mục thời điểm', 1, N'Danh mục', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (8, N'Nhập liệu', 0, NULL, 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (9, N'Hợp đồng quảng cáo', 1, N'Nhập liệu', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (10, N'In ấn', 0, NULL, 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (11, N'In lịch phát sóng', 1, N'In ấn', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (12, N'Đối chiếu công nợ', 1, N'In ấn', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (13, N'Chứng nhận phát sóng', 1, N'In ấn', 4)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (14, N'Dự trù thời lượng', 1, N'In ấn', 5)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (15, N'Đăng ký quảng cáo', 1, N'In ấn', 6)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1013, N'Bảng giá quảng cáo', 1, N'In ấn', 7)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1014, N'Đổi mật khẩu', 1, N'Trợ giúp', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1015, N'Thông tin ứng dụng', 1, N'Trợ giúp', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1016, N'Trợ giúp', 0, NULL, 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1017, N'Xếp lịch theo ngày', 1, N'Nhập liệu', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1018, N'Đặt lại mật khẩu', 1, N'Trợ giúp', 4)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1019, N'Xem lịch sử', 1, N'Trợ giúp', 3)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[ProductScheduleShow] ON 

INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (1, 1, N'SocolaMilk V419', N'06:30', 630, CAST(N'2019-12-06T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 10, 1400000, 0, 7000000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (2, 1, N'SocolaMilk V419', N'06:30', 630, CAST(N'2019-12-07T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 10, 1400000, 0, 7000000, 2)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (3, 1, N'SocolaMilk V419', N'06:30', 630, CAST(N'2019-12-08T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 10, 1400000, 0, 7000000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (4, 1, N'SocolaMilk V419', N'06:30', 630, CAST(N'2019-12-09T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 10, 1400000, 0, 7000000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (5, 1, N'SocolaMilk V419', N'06:30', 630, CAST(N'2019-12-10T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 10, 1400000, 0, 7000000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (6, 2, N'trailer dmat 02', N'06:30', 630, CAST(N'2019-12-06T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 30, 3000000, 0, 15000000, 1)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (7, 2, N'trailer dmat 02', N'06:30', 630, CAST(N'2019-12-07T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 30, 3000000, 0, 15000000, 3)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (8, 2, N'trailer dmat 02', N'06:30', 630, CAST(N'2019-12-08T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 30, 3000000, 0, 15000000, 1)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (9, 2, N'trailer dmat 02', N'06:30', 630, CAST(N'2019-12-09T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 30, 3000000, 0, 15000000, 1)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (10, 2, N'trailer dmat 02', N'06:30', 630, CAST(N'2019-12-10T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 30, 3000000, 0, 15000000, 1)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (11, 3, N'QC Ca Nhac', N'06:30', 630, CAST(N'2019-12-06T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 20, 2300000, 0, 11500000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (12, 3, N'QC Ca Nhac', N'06:30', 630, CAST(N'2019-12-07T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 20, 2300000, 0, 11500000, 1)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (13, 3, N'QC Ca Nhac', N'06:30', 630, CAST(N'2019-12-08T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 20, 2300000, 0, 11500000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (14, 3, N'QC Ca Nhac', N'06:30', 630, CAST(N'2019-12-09T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 20, 2300000, 0, 11500000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (15, 3, N'QC Ca Nhac', N'06:30', 630, CAST(N'2019-12-10T00:00:00.000' AS DateTime), 1, 1, N'Trước phim sáng (đợt I)', N'A1', 20, 2300000, 0, 11500000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (16, 3, N'QC Ca Nhac', N'12:00', 1200, CAST(N'2019-12-06T00:00:00.000' AS DateTime), 1, 1, N'Trước phim trưa', N'B1', 20, 7300000, 0, 36500000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (17, 3, N'QC Ca Nhac', N'12:00', 1200, CAST(N'2019-12-07T00:00:00.000' AS DateTime), 1, 1, N'Trước phim trưa', N'B1', 20, 7300000, 0, 36500000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (18, 3, N'QC Ca Nhac', N'12:00', 1200, CAST(N'2019-12-08T00:00:00.000' AS DateTime), 1, 1, N'Trước phim trưa', N'B1', 20, 7300000, 0, 36500000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (19, 3, N'QC Ca Nhac', N'12:00', 1200, CAST(N'2019-12-09T00:00:00.000' AS DateTime), 1, 1, N'Trước phim trưa', N'B1', 20, 7300000, 0, 36500000, 4)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowTimeInt], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotCode], [TimeSlotLength], [Cost], [Discount], [TotalCost], [OrderNumber]) VALUES (20, 3, N'QC Ca Nhac', N'12:00', 1200, CAST(N'2019-12-10T00:00:00.000' AS DateTime), 1, 1, N'Trước phim trưa', N'B1', 20, 7300000, 0, 36500000, 4)
SET IDENTITY_INSERT [dbo].[ProductScheduleShow] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'staff')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] ON 

INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1, 2, 1)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (2, 2, 2)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (3, 2, 3)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (5, 2, 4)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (6, 2, 5)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (7, 2, 6)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (8, 2, 7)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (9, 2, 8)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (10, 2, 9)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (11, 2, 10)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (12, 2, 11)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (13, 2, 12)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (14, 2, 13)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (15, 2, 14)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (16, 2, 15)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1014, 2, 1013)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1015, 2, 1014)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1016, 2, 1015)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1017, 2, 1016)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1018, 2, 1017)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1019, 1, 1018)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1020, 1, 1019)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1021, 1, 1014)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1022, 1, 1015)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1023, 1, 1016)
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] OFF
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'A', N'Sáng', 1, CAST(N'2019-09-04T23:30:21.223' AS DateTime), CAST(N'2019-09-04T23:31:46.770' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'B', N'Trưa', 1, CAST(N'2019-09-04T23:30:51.090' AS DateTime), CAST(N'2019-09-04T23:31:54.340' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'C', N'Xế', 1, CAST(N'2019-09-04T23:31:02.340' AS DateTime), CAST(N'2019-09-04T23:31:57.170' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'D', N'Chiều', 1, CAST(N'2019-09-04T23:31:11.707' AS DateTime), CAST(N'2019-09-04T23:31:59.780' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'E', N'Tối', 1, CAST(N'2019-09-04T23:33:14.517' AS DateTime), CAST(N'2019-09-04T23:33:14.517' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'F', N'Khuya', 1, CAST(N'2019-09-04T23:33:31.090' AS DateTime), CAST(N'2019-09-04T23:50:34.867' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Session] OFF
SET IDENTITY_INSERT [dbo].[ShowType] ON 

INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'Quảng cáo', N'Video thông tin ngắn', 1, CAST(N'2019-09-04T23:31:46.770' AS DateTime), CAST(N'2019-09-04T23:31:46.770' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'Tự giới thiệu', N'Video thông tin dài', 1, CAST(N'2019-09-04T23:31:46.770' AS DateTime), CAST(N'2019-09-04T23:31:46.770' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'Popup', N'Hiện cửa sổ nhỏ', 1, CAST(N'2019-09-08T13:42:44.933' AS DateTime), CAST(N'2019-09-08T13:42:44.933' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'Rao vặt', N'Thông báo rao vặt', 1, CAST(N'2019-12-04T00:17:38.070' AS DateTime), CAST(N'2019-12-04T00:17:38.070' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'FM QC sản phẩrm', N'trên đài FM', 1, CAST(N'2019-12-04T00:18:11.167' AS DateTime), CAST(N'2019-12-04T00:18:11.167' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'FM Thông báo', N'Trên đài FM', 1, CAST(N'2019-12-04T00:18:26.280' AS DateTime), CAST(N'2019-12-04T00:18:26.280' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ShowType] OFF
SET IDENTITY_INSERT [dbo].[SystemConfig] ON 

INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (1, N'ContractNumberInMonth', N'12', 4, N'Giá trị số để tạo ra mã của hợp đồng trong 1 tháng của 1 năm (VD: 0021219). Trở về 1 khi qua tháng mới. ValueString là tháng được ghi')
INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (2, N'DirectorName', N'Nguyễn Văn Lên', NULL, N'Tên Giám Đốc')
INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (3, N'ApplyPricingDate', N'', 6.3713467205E+17, N'Ngày áp dụng bảng giá quảng cáo')
INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (4, N'FromEmail', N'neoandesonn@gmail.com', NULL, N'Email dùng để gửi')
INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (5, N'ToEmail', N'gooddaytoeverybody@gmail.com', NULL, N'Email người nhận được dùng trong in lịch chiếu')
SET IDENTITY_INSERT [dbo].[SystemConfig] OFF
SET IDENTITY_INSERT [dbo].[SystemLog] ON 

INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (1, N'   at System.Data.Entity.Internal.InternalContext.SaveChanges()
   at System.Data.Entity.Internal.LazyInternalContext.SaveChanges()
   at System.Data.Entity.DbContext.SaveChanges()
   at DataService.Infrastructure.Repository`1.Add(TEntity entity) in H:\Project\ATV2\ATV_Advertisment\DataService\Infrastructure\IRepository.cs:line 49
   at ATV_Advertisment.Services.ProductScheduleShowService.AddProductScheduleShow(ProductScheduleShow input) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Services\ProductScheduleShowService.cs:line 42
   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 127', CAST(N'2019-09-05T00:19:50.903' AS DateTime), 1)
INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (2, N'   at System.Data.Entity.Internal.InternalContext.SaveChanges()
   at System.Data.Entity.Internal.LazyInternalContext.SaveChanges()
   at System.Data.Entity.DbContext.SaveChanges()
   at DataService.Infrastructure.Repository`1.Add(TEntity entity) in H:\Project\ATV2\ATV_Advertisment\DataService\Infrastructure\IRepository.cs:line 49
   at ATV_Advertisment.Services.ProductScheduleShowService.AddProductScheduleShow(ProductScheduleShow input) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Services\ProductScheduleShowService.cs:line 42
   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 130', CAST(N'2019-09-05T00:27:23.460' AS DateTime), 1)
INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (1002, N'   at System.Data.Entity.Internal.InternalContext.SaveChanges()
   at System.Data.Entity.Internal.LazyInternalContext.SaveChanges()
   at System.Data.Entity.DbContext.SaveChanges()
   at DataService.Infrastructure.Repository`1.Update(TEntity entityToUpdate) in H:\Project\ATV2\ATV_Advertisment\DataService\Infrastructure\IRepository.cs:line 56
   at ATV_Advertisment.Services.ProductScheduleShowService.EditProductScheduleShow(ProductScheduleShow input) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Services\ProductScheduleShowService.cs:line 96
   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 154', CAST(N'2019-09-05T23:21:58.680' AS DateTime), 1)
INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (1003, N'   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 152', CAST(N'2019-09-05T23:55:59.197' AS DateTime), 1)
INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (1004, N'   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 188', CAST(N'2019-11-07T13:58:09.227' AS DateTime), 1)
INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (1005, N'   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 188', CAST(N'2019-11-07T13:59:05.460' AS DateTime), 1)
INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (1006, N'   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 183', CAST(N'2019-11-10T14:55:55.237' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[SystemLog] OFF
SET IDENTITY_INSERT [dbo].[TimeSlot] ON 

INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'A1', N'Trước phim sáng (đợt I)', 630, N'A', 1, CAST(N'2019-09-15T11:26:29.630' AS DateTime), CAST(N'2019-11-07T13:44:58.580' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'A2', N'Giữa phim sáng (đợt I)', 715, N'A', 1, CAST(N'2019-09-15T11:38:27.303' AS DateTime), CAST(N'2019-09-15T11:38:27.307' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'A3', N'Cuối phim sáng (đợt I)', 800, N'A', 1, CAST(N'2019-09-15T11:39:44.617' AS DateTime), CAST(N'2019-09-15T11:40:12.950' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'A4', N'Trước phim sáng (đợt II)', 905, N'A', 1, CAST(N'2019-09-20T12:44:26.430' AS DateTime), CAST(N'2019-09-20T12:44:26.430' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'A5', N'Giữa phim sáng (đợt II)', 925, N'A', 1, CAST(N'2019-09-20T12:47:21.527' AS DateTime), CAST(N'2019-09-20T12:47:21.527' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'A6', N'Cuối phim sáng', 945, N'A', 1, CAST(N'2019-09-20T12:48:45.707' AS DateTime), CAST(N'2019-09-20T12:48:45.707' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (7, N'B1', N'Trước phim trưa', 1200, N'B', 1, CAST(N'2019-09-20T12:50:30.937' AS DateTime), CAST(N'2019-09-20T12:50:30.937' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (8, N'B2', N'Giữa phim trưa', 1220, N'B', 1, CAST(N'2019-09-20T12:52:13.713' AS DateTime), CAST(N'2019-09-20T12:52:13.713' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (9, N'B3', N'Cuối phim trưa', 1245, N'B', 1, CAST(N'2019-09-20T13:07:19.687' AS DateTime), CAST(N'2019-09-20T13:07:30.483' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (10, N'C1', N'Trước phim xế trưa (I)', 1405, N'C', 1, CAST(N'2019-09-20T13:09:20.580' AS DateTime), CAST(N'2019-09-20T14:33:06.083' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (11, N'C2', N'Phim xe trua (II)', 1425, N'C', 1, CAST(N'2019-09-20T14:29:34.040' AS DateTime), CAST(N'2019-09-20T14:33:22.140' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1011, N'D1', N'Trước Phim Chiều', 1700, N'D', 1, CAST(N'2019-12-04T09:25:28.710' AS DateTime), CAST(N'2019-12-04T09:25:28.710' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1012, N'E1', N'Trước thời sự Đài THVN', 1900, N'E', 1, CAST(N'2019-12-04T09:28:00.007' AS DateTime), CAST(N'2019-12-04T09:28:00.007' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1013, N'E2', N'Sau dự báo thời tiết', 1950, N'E', 1, CAST(N'2019-12-04T09:29:40.410' AS DateTime), CAST(N'2019-12-04T09:29:40.410' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'admin', N'AADIc5VPn+rt+OdyDp8dTzwTyeLMkewPUefcHo7UlPh2LUii3giKgCPybZacSky2Pg==', N'AD0001', N'Admin', 1, 1, NULL, NULL, CAST(N'2019-12-08T09:21:20.560' AS DateTime), 1)
INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'staff', N'AImM6sQe3PsyztL68a/ojRy5+RrvlbMrMd6b4h6c1RusmmS/0sTLfy8XIAtn23KT1g==', N'NV0002', N'Admin', 2, 1, NULL, NULL, CAST(N'2019-12-08T09:31:01.297' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNIQUE_CODE_SESSION]    Script Date: 08/12/2019 9:34:22 AM ******/
ALTER TABLE [dbo].[Session] ADD  CONSTRAINT [UNIQUE_CODE_SESSION] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Discount]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[ContractItem] ADD  CONSTRAINT [DF_ContractDetail_ContractCode]  DEFAULT ((0)) FOR [ContractCode]
GO
ALTER TABLE [dbo].[CostRule] ADD  CONSTRAINT [DF_CostRule_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[ProductScheduleShow] ADD  CONSTRAINT [DF_ProductScheduleShow_OrderNumber]  DEFAULT ((0)) FOR [OrderNumber]
GO
ALTER TABLE [dbo].[RoleHasMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_RoleHasMenuItem_MenuItem] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItem] ([Id])
GO
ALTER TABLE [dbo].[RoleHasMenuItem] CHECK CONSTRAINT [FK_RoleHasMenuItem_MenuItem]
GO
ALTER TABLE [dbo].[RoleHasMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_RoleHasMenuItem_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RoleHasMenuItem] CHECK CONSTRAINT [FK_RoleHasMenuItem_Role]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [ATV] SET  READ_WRITE 
GO
