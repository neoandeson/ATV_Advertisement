USE [master]
GO
/****** Object:  Database [ATV]    Script Date: 15/12/2019 8:25:34 AM ******/
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
ALTER DATABASE [ATV] SET AUTO_CLOSE ON 
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
ALTER DATABASE [ATV] SET  ENABLE_BROKER 
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
/****** Object:  Table [dbo].[BusinessLog]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[Contract]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[ContractItem]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[CostRule]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[DiscountApply]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[Duration]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[MenuItem]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[ProductScheduleShow]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[RoleHasMenuItem]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[Session]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[ShowType]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[SystemLog]    Script Date: 15/12/2019 8:25:35 AM ******/
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
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 15/12/2019 8:25:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[User]    Script Date: 15/12/2019 8:25:35 AM ******/
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
SET IDENTITY_INSERT [dbo].[CostRule] ON 

INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (1, 1, 10, 1400000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2, 1, 15, 1800000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (3, 1, 20, 2300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (4, 1, 30, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (5, 2, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (6, 2, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (7, 2, 20, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (8, 2, 30, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (9, 3, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (10, 3, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (11, 3, 20, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (12, 3, 30, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (13, 4, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (14, 4, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (15, 4, 20, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (16, 4, 30, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (17, 5, 10, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (18, 5, 15, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (19, 5, 20, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (20, 5, 30, 5000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (21, 6, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (22, 6, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (23, 6, 20, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (24, 6, 30, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (25, 7, 10, 5200000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (26, 7, 15, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (27, 7, 20, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (28, 7, 30, 9500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (29, 8, 10, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (30, 8, 15, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (31, 8, 20, 8400000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (32, 8, 30, 12000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (33, 9, 10, 5200000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (34, 9, 15, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (35, 9, 20, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (36, 9, 30, 9500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (37, 10, 10, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (38, 10, 15, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (39, 10, 20, 5000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (40, 10, 30, 6000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (43, 11, 10, 4000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (44, 11, 15, 5000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (45, 12, 10, 2000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (46, 12, 15, 3000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (47, 13, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (48, 13, 15, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (49, 14, 10, 2000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (50, 14, 15, 3000000, 2)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (51, 9, 180, 8000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (52, 9, 600, 7000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (53, 15, 10, 5000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (54, 15, 15, 6000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (55, 15, 20, 7000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (56, 15, 30, 9000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (57, 16, 10, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (58, 16, 15, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (59, 16, 20, 5000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (60, 16, 30, 6000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (61, 17, 10, 4700000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (62, 17, 15, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (63, 17, 20, 7800000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (64, 17, 30, 10500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (65, 18, 10, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (66, 18, 15, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (67, 18, 20, 8400000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (68, 18, 30, 12000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (69, 19, 10, 8400000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (70, 19, 15, 12500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (71, 19, 20, 14500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (72, 19, 30, 18500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (73, 20, 10, 10500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (74, 20, 15, 14500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (75, 20, 20, 17800000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (76, 20, 30, 21000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (77, 21, 10, 10500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (78, 21, 15, 14500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (79, 21, 20, 17800000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (80, 21, 30, 21000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (81, 22, 10, 15500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (82, 22, 15, 17500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (83, 22, 20, 20000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (84, 22, 30, 23000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (85, 23, 10, 19000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (86, 23, 15, 23000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (87, 23, 20, 25000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (88, 23, 30, 27000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (89, 24, 10, 19000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (90, 24, 15, 23000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (91, 24, 20, 25000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (92, 24, 30, 27000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (93, 25, 10, 10500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (94, 25, 15, 14500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (95, 25, 20, 17500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (96, 25, 30, 21000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (97, 19, 180, 12000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (98, 19, 600, 9000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (99, 21, 180, 12000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (100, 21, 600, 9000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (101, 25, 180, 8000000, 3)
GO
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (102, 25, 600, 7000000, 3)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (104, 26, 10, 2000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (105, 27, 10, 1000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (106, 28, 10, 500000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (107, 29, 10, 300000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (108, 30, 10, 1000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (109, 1, 20, 1000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (110, 4, 20, 1000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (111, 7, 20, 1000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (112, 10, 20, 1000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (113, 17, 20, 1000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (114, 21, 20, 2000000, 4)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (115, 1, 20, 500000, 8)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (116, 7, 20, 500000, 8)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (117, 17, 20, 500000, 8)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (118, 1, 20, 300000, 9)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (119, 7, 20, 300000, 9)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (120, 17, 20, 300000, 9)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (121, 19, 20, 1000000, 10)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (122, 1, 30, 1000000, 5)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (123, 1, 60, 1500000, 5)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (124, 7, 30, 1000000, 5)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (125, 7, 60, 1500000, 5)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (126, 20, 30, 1000000, 5)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (127, 20, 60, 1500000, 5)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (128, 1, 10, 500000, 6)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (129, 7, 10, 500000, 6)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (130, 20, 10, 500000, 6)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (131, 31, 10, 10500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (132, 31, 15, 14500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (133, 31, 20, 17800000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (134, 31, 30, 21000000, 1)
SET IDENTITY_INSERT [dbo].[CostRule] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Email], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'VINAMILK', N'234132', N'qwerqwer', N'12341324', N'134213', N'vinamilk@gmail.com', N'12341324', N'12334124', 1, NULL, CAST(N'2019-12-14T10:16:09.077' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[DiscountApply] ON 

INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (2, 50000000, N'Từ 5 triệu đồng đến dưới 50 triệu đồng', 7)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (3, 100000000, N'Từ 50 triệu đồng đến dưới 100 triệu đồng', 10)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (4, 200000000, N'Từ 100 triệu đồng đến dưới 200 triệu đồng', 12)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (5, 500000000, N'Từ 200 triệu đồng đến dưới 500 triệu đồng', 15)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (6, 1000000000, N'Từ 500 triệu đồng đến dưới 1 tỷ đồng', 18)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (7, 5000000000, N'Từ 1 tỷ đồng đến dưới 5 tỷ đồng', 20)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (9, 8000000000, N'Từ 5 tỷ đồng đến dưới 8 tỷ đồng', 25)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (10, 10000000000, N'Từ 8 tỷ đồng đến dưới 10 tỷ đồng', 30)
INSERT [dbo].[DiscountApply] ([Id], [ApplyPrice], [Description], [Percentage]) VALUES (11, 10000000001, N'Từ 10 tỷ đồng trở lên', 35)
SET IDENTITY_INSERT [dbo].[DiscountApply] OFF
SET IDENTITY_INSERT [dbo].[Duration] ON 

INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, 10, 1, CAST(N'2019-12-12T21:18:10.063' AS DateTime), CAST(N'2019-12-12T21:18:10.063' AS DateTime), 4)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, 15, 1, CAST(N'2019-12-12T21:18:18.870' AS DateTime), CAST(N'2019-12-12T21:18:22.823' AS DateTime), 4)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, 20, 1, CAST(N'2019-12-12T21:18:30.253' AS DateTime), CAST(N'2019-12-12T21:18:30.253' AS DateTime), 4)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, 30, 1, CAST(N'2019-12-12T21:18:35.110' AS DateTime), CAST(N'2019-12-12T21:18:35.110' AS DateTime), 4)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, 60, 1, CAST(N'2019-12-12T21:18:56.530' AS DateTime), CAST(N'2019-12-12T21:18:56.533' AS DateTime), 4)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, 180, 1, CAST(N'2019-12-12T21:19:25.430' AS DateTime), CAST(N'2019-12-12T21:19:25.430' AS DateTime), 4)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (7, 600, 1, CAST(N'2019-12-12T21:19:34.550' AS DateTime), CAST(N'2019-12-12T21:19:34.550' AS DateTime), 4)
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
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (16, N'Bảng giá quảng cáo', 1, N'In ấn', 7)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (17, N'Đổi mật khẩu', 1, N'Trợ giúp', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (18, N'Thông tin ứng dụng', 1, N'Trợ giúp', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (19, N'Trợ giúp', 0, NULL, 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (20, N'Xếp lịch theo ngày', 1, N'Nhập liệu', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (21, N'Đặt lại mật khẩu', 1, N'Trợ giúp', 4)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (22, N'Xem lịch sử', 1, N'Trợ giúp', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (23, N'Tạo tài khoản', 1, N'Trợ giúp', 5)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'staff')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'sa')
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
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (17, 2, 16)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (18, 2, 17)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (19, 2, 18)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (20, 2, 19)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (21, 2, 20)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (22, 1, 21)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (23, 1, 22)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (24, 1, 17)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (25, 1, 18)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (26, 1, 19)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (27, 1, 23)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (28, 3, 1)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (29, 3, 2)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (30, 3, 3)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (31, 3, 4)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (32, 3, 5)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (33, 3, 6)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (34, 3, 7)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (35, 3, 8)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (36, 3, 9)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (37, 3, 10)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (38, 3, 11)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (39, 3, 12)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (40, 3, 13)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (41, 3, 14)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (42, 3, 15)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (43, 3, 16)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (44, 3, 17)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (45, 3, 18)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (46, 3, 19)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (47, 3, 20)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (48, 3, 21)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (49, 3, 22)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (50, 3, 23)
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] OFF
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'A', N'Sáng', 1, CAST(N'2019-12-12T21:16:19.400' AS DateTime), CAST(N'2019-12-12T21:16:19.400' AS DateTime), 4)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'B', N'Trưa', 1, CAST(N'2019-12-12T21:16:44.910' AS DateTime), CAST(N'2019-12-12T21:16:44.910' AS DateTime), 4)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'C', N'Xế Trưa', 1, CAST(N'2019-12-12T21:17:08.470' AS DateTime), CAST(N'2019-12-12T21:17:08.470' AS DateTime), 4)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'D', N'Chiều', 1, CAST(N'2019-12-12T21:17:16.013' AS DateTime), CAST(N'2019-12-12T21:17:16.013' AS DateTime), 4)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'E', N'Tối', 1, CAST(N'2019-12-12T21:17:28.260' AS DateTime), CAST(N'2019-12-12T21:17:28.260' AS DateTime), 4)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'P', N'Popup', 1, CAST(N'2019-12-12T22:35:55.500' AS DateTime), CAST(N'2019-12-12T22:35:55.500' AS DateTime), 4)
SET IDENTITY_INSERT [dbo].[Session] OFF
SET IDENTITY_INSERT [dbo].[ShowType] ON 

INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'Quảng cáo', N'Phát trên sóng truyền hình', 1, CAST(N'2019-12-12T21:11:30.053' AS DateTime), CAST(N'2019-12-12T21:11:30.053' AS DateTime), 4)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'Popup', N'Hiển thị thông báo nổi', 1, CAST(N'2019-12-12T21:12:18.740' AS DateTime), CAST(N'2019-12-12T21:12:18.740' AS DateTime), 4)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'Tự giới thiệu', N'Video dài', 1, CAST(N'2019-12-12T21:12:37.460' AS DateTime), CAST(N'2019-12-12T21:12:37.460' AS DateTime), 4)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'Thông báo rao vặt', N'Mặt định 20 giây', 1, CAST(N'2019-12-12T21:13:39.770' AS DateTime), CAST(N'2019-12-13T21:02:54.840' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'FM Quảng cáo', N'Trên sóng FM', 1, CAST(N'2019-12-12T21:14:13.850' AS DateTime), CAST(N'2019-12-12T21:14:34.997' AS DateTime), 4)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'FM Thông báo', N'Trên sóng FM', 1, CAST(N'2019-12-12T21:15:16.970' AS DateTime), CAST(N'2019-12-13T21:03:37.263' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (7, N'KEY LOGO', N'Hiển thị Logo', -2, CAST(N'2019-12-12T21:15:44.797' AS DateTime), CAST(N'2019-12-12T22:49:48.693' AS DateTime), 4)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (8, N'TB Chuyển nhượng sử dụng đất', N'Mặt định 20 giây', 1, CAST(N'2019-12-13T20:52:46.573' AS DateTime), CAST(N'2019-12-13T21:02:34.070' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (9, N'TB mất giấy tờ, tìm người thân', N'Mặt định 20 giây', 1, CAST(N'2019-12-13T20:53:17.693' AS DateTime), CAST(N'2019-12-13T21:02:39.780' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (10, N'Cáo phó, cảm tạ trước TSAG', N'Mặt định 20 giây', 1, CAST(N'2019-12-13T20:53:47.710' AS DateTime), CAST(N'2019-12-13T21:02:11.990' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ShowType] OFF
SET IDENTITY_INSERT [dbo].[SystemConfig] ON 

INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (1, N'ContractNumberInMonth', N'12', 2, N'Giá trị số để tạo ra mã của hợp đồng trong 1 tháng của 1 năm (VD: 0021219). Trở về 1 khi qua tháng mới. ValueString là tháng được ghi')
INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (2, N'DirectorName', N'Nguyễn Văn Lên', NULL, N'Tên Giám Đốc')
INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (3, N'ApplyPricingDate', N'', 6.3713467205E+17, N'Ngày áp dụng bảng giá quảng cáo')
INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (4, N'FromEmail', N'neoandesonn@gmail.com', NULL, N'Email dùng để gửi')
INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (5, N'ToEmail', N'gooddaytoeverybody@gmail.com', NULL, N'Email người nhận được dùng trong in lịch chiếu')
SET IDENTITY_INSERT [dbo].[SystemConfig] OFF
SET IDENTITY_INSERT [dbo].[TimeSlot] ON 

INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'A1', N'Trước phim sáng (đợt I)', 630, N'A', 1, CAST(N'2019-12-12T21:20:36.577' AS DateTime), CAST(N'2019-12-12T21:20:36.577' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'A2', N'Giữa phim sáng (đợt I)', 715, N'A', 1, CAST(N'2019-12-12T21:22:24.003' AS DateTime), CAST(N'2019-12-12T21:22:24.003' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'A3', N'Cuối phim sáng (đợt I)', 800, N'A', 1, CAST(N'2019-12-12T21:24:32.640' AS DateTime), CAST(N'2019-12-12T21:24:32.640' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'A4', N'Trước phim sáng (đợt II)', 905, N'A', 1, CAST(N'2019-12-12T22:03:15.787' AS DateTime), CAST(N'2019-12-12T22:03:15.787' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'A5', N'Giữa phim sáng (đợt II)', 925, N'A', 1, CAST(N'2019-12-12T22:04:09.193' AS DateTime), CAST(N'2019-12-12T22:04:09.193' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'A6', N'Cuối phim sáng (đợt II)', 945, N'A', 1, CAST(N'2019-12-12T22:05:18.073' AS DateTime), CAST(N'2019-12-12T22:05:18.073' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (7, N'B1', N'Trước phim trưa', 1200, N'B', 1, CAST(N'2019-12-12T22:06:22.993' AS DateTime), CAST(N'2019-12-12T22:06:22.993' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (8, N'B2', N'Giữa phim trưa', 1220, N'B', 1, CAST(N'2019-12-12T22:07:36.907' AS DateTime), CAST(N'2019-12-12T22:07:36.907' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (9, N'B3', N'Cuối phim trưa', 1245, N'B', 1, CAST(N'2019-12-12T22:08:36.520' AS DateTime), CAST(N'2019-12-12T22:08:36.520' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (10, N'C1', N'Trước phim xế trưa', 1405, N'C', 1, CAST(N'2019-12-12T22:09:39.497' AS DateTime), CAST(N'2019-12-12T22:09:39.497' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (11, N'P1', N'Giữa phim tối', 1800, N'P', 1, CAST(N'2019-12-12T22:36:28.970' AS DateTime), CAST(N'2019-12-12T22:36:28.970' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (12, N'P2', N'Các phim còn lại', 2100, N'P', 1, CAST(N'2019-12-12T22:38:14.863' AS DateTime), CAST(N'2019-12-12T22:38:14.867' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (14, N'P3', N'KEY LOGO', 2200, N'P', 1, CAST(N'2019-12-12T22:49:11.673' AS DateTime), CAST(N'2019-12-12T22:49:11.673' AS DateTime), 4)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (15, N'C2', N'Giữa phim xế trưa', 1425, N'C', 1, CAST(N'2019-12-13T16:17:08.190' AS DateTime), CAST(N'2019-12-13T16:17:08.193' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (16, N'C3', N'Cuối phim xế trưa', 1450, N'C', 1, CAST(N'2019-12-13T16:18:42.390' AS DateTime), CAST(N'2019-12-13T16:18:42.390' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (17, N'D1', N'Trước phim chiều', 1700, N'D', 1, CAST(N'2019-12-13T16:20:08.703' AS DateTime), CAST(N'2019-12-13T16:20:08.707' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (18, N'D2', N'Giữa phim chiều', 1745, N'D', 1, CAST(N'2019-12-13T16:21:25.630' AS DateTime), CAST(N'2019-12-13T16:21:25.630' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (19, N'D3', N'Trước thời sự An Giang', 1830, N'D', 1, CAST(N'2019-12-13T16:23:03.220' AS DateTime), CAST(N'2019-12-13T16:23:03.220' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (20, N'E1', N'Trước thời sự Đài THVN', 1900, N'E', 1, CAST(N'2019-12-13T16:27:43.940' AS DateTime), CAST(N'2019-12-13T16:27:43.940' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (21, N'E2', N'Sau dự báo thời tiết', 1950, N'E', 1, CAST(N'2019-12-13T16:30:09.423' AS DateTime), CAST(N'2019-12-13T16:30:09.423' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (22, N'E4', N'Sau giới thiệu tựa phim tối', 2010, N'E', 1, CAST(N'2019-12-13T16:31:44.987' AS DateTime), CAST(N'2019-12-13T16:31:44.990' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (23, N'E5', N'Giữa phim tối (đợt I)', 2030, N'E', 1, CAST(N'2019-12-13T16:33:39.990' AS DateTime), CAST(N'2019-12-13T16:33:39.990' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (24, N'E6', N'Giữa phim tối (đợt II)', 2115, N'E', 1, CAST(N'2019-12-13T16:35:05.653' AS DateTime), CAST(N'2019-12-15T07:51:12.220' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (25, N'E7', N'Trước khi kết thúc phim tối (đợt II)', 2140, N'E', 1, CAST(N'2019-12-13T16:39:33.013' AS DateTime), CAST(N'2019-12-13T16:39:33.017' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (26, N'TB2', N'Thông báo rao vặt sau dự báo thời tiết (19h50)', 1945, N'B', -1, CAST(N'2019-12-13T16:51:38.950' AS DateTime), CAST(N'2019-12-13T16:51:38.950' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (27, N'TB1', N'Thông báo rao vặt vào khung giờ phim 6h30, 9h05, 12h, 14h05, 17h', 630, N'A', -1, CAST(N'2019-12-13T16:55:00.957' AS DateTime), CAST(N'2019-12-13T16:55:00.957' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (28, N'TB3', N'Thông báo chuyển nhượng sự dụng đất (6h30,12h,17h)', 630, N'A', -1, CAST(N'2019-12-13T16:57:08.967' AS DateTime), CAST(N'2019-12-13T16:57:08.967' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (29, N'TB4', N'TB mất giấy tờ cá nhân, tìm người thân vào khung giờ phim 6h30, 11h45, 17h', 630, N'A', -1, CAST(N'2019-12-13T16:59:28.667' AS DateTime), CAST(N'2019-12-13T16:59:28.667' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (30, N'TB5', N'Cáo phó, cảm tạ vào khung giờ Thời sự AG(18h30)', 1830, N'D', -1, CAST(N'2019-12-13T17:00:35.547' AS DateTime), CAST(N'2019-12-13T17:00:35.547' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (31, N'E3', N'Sau An toàn Giao Thông', 1951, N'E', 1, CAST(N'2019-12-15T07:54:51.127' AS DateTime), CAST(N'2019-12-15T08:04:24.957' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'admin', N'AADIc5VPn+rt+OdyDp8dTzwTyeLMkewPUefcHo7UlPh2LUii3giKgCPybZacSky2Pg==', N'AD0001', N'Admin', 1, 1, NULL, NULL, CAST(N'2019-12-08T09:21:20.560' AS DateTime), 1)
INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'staff', N'AImM6sQe3PsyztL68a/ojRy5+RrvlbMrMd6b4h6c1RusmmS/0sTLfy8XIAtn23KT1g==', N'NV0002', N'Admin', 2, 1, NULL, NULL, CAST(N'2019-12-08T09:31:01.297' AS DateTime), 1)
INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'sa', N'AADIc5VPn+rt+OdyDp8dTzwTyeLMkewPUefcHo7UlPh2LUii3giKgCPybZacSky2Pg==', N'SA0001', N'SuperAdmin', 3, 1, NULL, CAST(N'2019-12-12T19:42:09.693' AS DateTime), CAST(N'2019-12-12T19:44:46.660' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNIQUE_CODE_SESSION]    Script Date: 15/12/2019 8:25:35 AM ******/
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
