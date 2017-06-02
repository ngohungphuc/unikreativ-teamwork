USE [master]
GO
/****** Object:  Database [Unikreativ]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE DATABASE [Unikreativ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Unikreativ', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Unikreativ.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Unikreativ_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Unikreativ_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Unikreativ] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Unikreativ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Unikreativ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Unikreativ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Unikreativ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Unikreativ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Unikreativ] SET ARITHABORT OFF 
GO
ALTER DATABASE [Unikreativ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Unikreativ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Unikreativ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Unikreativ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Unikreativ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Unikreativ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Unikreativ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Unikreativ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Unikreativ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Unikreativ] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Unikreativ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Unikreativ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Unikreativ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Unikreativ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Unikreativ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Unikreativ] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Unikreativ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Unikreativ] SET RECOVERY FULL 
GO
ALTER DATABASE [Unikreativ] SET  MULTI_USER 
GO
ALTER DATABASE [Unikreativ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Unikreativ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Unikreativ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Unikreativ] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Unikreativ] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Unikreativ', N'ON'
GO
USE [Unikreativ]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[ChargeRate] [float] NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Industries] [int] NOT NULL,
	[JobTitle] [nvarchar](max) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[Website] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Billings]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Billings](
	[Id] [uniqueidentifier] NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[ProjectId] [uniqueidentifier] NULL,
	[RateOfTask] [float] NOT NULL,
	[TasksRequestId] [uniqueidentifier] NOT NULL,
	[Total] [float] NOT NULL,
	[WorkingTime] [float] NOT NULL,
 CONSTRAINT [PK_Billings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [uniqueidentifier] NOT NULL,
	[AssignBy] [nvarchar](max) NULL,
	[AssignTo] [nvarchar](max) NULL,
	[DateAssigned] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsCompleted] [bit] NOT NULL,
	[ProjectId] [uniqueidentifier] NULL,
	[TaskName] [nvarchar](max) NULL,
	[TasksRequestId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaFiles]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaFiles](
	[Id] [uniqueidentifier] NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[TasksRequestId] [uniqueidentifier] NULL,
	[UploadDate] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_MediaFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [uniqueidentifier] NOT NULL,
	[AgreementDate] [datetime2](7) NOT NULL,
	[BillingId] [nvarchar](max) NULL,
	[ClientId] [nvarchar](max) NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[EventId] [nvarchar](max) NULL,
	[ProjectDescription] [nvarchar](max) NULL,
	[ProjectName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubTasks]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubTasks](
	[Id] [uniqueidentifier] NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[ProjectId] [uniqueidentifier] NULL,
	[SubTaskName] [nvarchar](max) NULL,
 CONSTRAINT [PK_SubTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TasksRequests]    Script Date: 30/05/2017 10:21:50 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TasksRequests](
	[Id] [uniqueidentifier] NOT NULL,
	[AssignBy] [nvarchar](max) NULL,
	[AssignTo] [nvarchar](max) NULL,
	[CompleteRate] [float] NOT NULL,
	[CostOfTask] [float] NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[Due] [datetime2](7) NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[ProjectId] [uniqueidentifier] NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[SubTaskId] [uniqueidentifier] NULL,
	[TaskName] [nvarchar](max) NULL,
	[WorkingTime] [float] NOT NULL,
 CONSTRAINT [PK_TasksRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170517132534_Init', N'1.1.2')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'2838d572-aac9-49b0-a0cc-ebe580ec42a6', N'4adc14ec-4061-44b6-a8c1-5f2b99d0a42f', N'Administrator', N'Administrator')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'836794ad-48ee-460f-aa70-ad17637dc72b', N'2cc15edc-eca1-4dfd-ac9f-f56b18bebb77', N'Watcher', N'Watcher')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'93021199-399e-4a3b-b8f6-54ebc87e585a', N'7eb64825-65d1-47f0-84b6-f230cf7e6a17', N'Manager', N'Manager')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'b67edf9f-ba36-40ae-88f0-9ff41f70b156', N'0fca6db2-fd22-431b-bf9d-7f6777b0e89d', N'Developer', N'Developer')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'bb7e5295-858a-4857-bbaa-a6d85af3c689', N'5669e8da-f775-47f7-8d53-ec34a3b1ca87', N'Client', N'Client')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'd361e957-71e9-4cbe-a68c-e10814dc4bb2', N'05eef599-8a56-4e77-8039-d04ee3c7bcc3', N'Accountant', N'Accountant')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'f8a1b247-3ee2-4b60-8a26-844bf7dfcdd9', N'5e239b3c-eb91-4259-a5a2-2751c7b5dd18', N'Designer', N'Designer')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0b7ac51c-0abe-4a88-8330-f286c5a7917b', N'2838d572-aac9-49b0-a0cc-ebe580ec42a6')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eb75199a-00af-42eb-b16d-5349823eb95a', N'2838d572-aac9-49b0-a0cc-ebe580ec42a6')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eb75199a-00af-42eb-b16d-5349823eb95a', N'b67edf9f-ba36-40ae-88f0-9ff41f70b156')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2944a8a4-d882-4bbe-92d6-dbad2e6c1227', N'bb7e5295-858a-4857-bbaa-a6d85af3c689')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [Address], [ChargeRate], [CompanyName], [ConcurrencyStamp], [Country], [Email], [EmailConfirmed], [FullName], [Industries], [JobTitle], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [Status], [TwoFactorEnabled], [UserName], [Website]) VALUES (N'0b7ac51c-0abe-4a88-8330-f286c5a7917b', 0, NULL, 14, N'Unikreativ', N'a96da9fd-8b82-47cc-a3df-7fbbe44935d1', NULL, N'helentran2609@gmail.com', 1, N'Trần Mai Phương', 1, N'Web Developer', 0, NULL, NULL, N'HelenTran', N'AQAAAAEAACcQAAAAEAd3Vc9/dbPBOCWCxpKiprEf3VNpsQSfTra3u/0PpGZFXrVgzbb1OildqvskZk+ITw==', N'0937005331', 1, N'6c29a4ab-dc10-4e72-8b57-d3651ac3fe40', NULL, 0, N'helentran', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [Address], [ChargeRate], [CompanyName], [ConcurrencyStamp], [Country], [Email], [EmailConfirmed], [FullName], [Industries], [JobTitle], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [Status], [TwoFactorEnabled], [UserName], [Website]) VALUES (N'2944a8a4-d882-4bbe-92d6-dbad2e6c1227', 0, N'123 Cộng Hòa Quận Tân Bình', 0, N'KMS', N'3f822cb5-8004-4042-ad81-242871f3c52f', N'Việt Nam', N'kmstechnology@com.vn', 1, NULL, 1, NULL, 0, NULL, NULL, NULL, N'AQAAAAEAACcQAAAAEIAcXE+aGlglZzvVslT2wqSP3+QeKzNHEnPon4CGmjsgrl/1LaocALOgFYcpxrCBKw==', N'(+84) 8 3811 9977', 1, N'3307e6ae-e1fa-4c2f-bd7f-c3905f35c332', NULL, 0, N'kms', N'http://www.kms-technology.com/')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [Address], [ChargeRate], [CompanyName], [ConcurrencyStamp], [Country], [Email], [EmailConfirmed], [FullName], [Industries], [JobTitle], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [Status], [TwoFactorEnabled], [UserName], [Website]) VALUES (N'eb75199a-00af-42eb-b16d-5349823eb95a', 0, NULL, 14, N'None', N'5a66e890-7b78-47b7-9c26-348a7f5a5f0d', NULL, N'ngohungphuc95@gmail.com', 1, N'Ngô Hùng Phúc', 1, N'Web Developer', 0, NULL, NULL, N'TonyHudson', N'AQAAAAEAACcQAAAAEJmXepLUo7AkVCEQRGlxdMuuEQCbIqArLPZBA3mZxzYnabFrO+P6Q/ADy2vlR3xxkQ==', N'01269976689', 1, N'b2a9708b-c0b8-4ab4-b3c5-5c553517f2f0', NULL, 0, N'tony', NULL)
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Billings_ProjectId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_Billings_ProjectId] ON [dbo].[Billings]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Billings_TasksRequestId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Billings_TasksRequestId] ON [dbo].[Billings]
(
	[TasksRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_ProjectId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_Events_ProjectId] ON [dbo].[Events]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_TasksRequestId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_Events_TasksRequestId] ON [dbo].[Events]
(
	[TasksRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MediaFiles_TasksRequestId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_MediaFiles_TasksRequestId] ON [dbo].[MediaFiles]
(
	[TasksRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MediaFiles_UserId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_MediaFiles_UserId] ON [dbo].[MediaFiles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubTasks_ProjectId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_SubTasks_ProjectId] ON [dbo].[SubTasks]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TasksRequests_ProjectId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_TasksRequests_ProjectId] ON [dbo].[TasksRequests]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TasksRequests_SubTaskId]    Script Date: 30/05/2017 10:21:50 CH ******/
CREATE NONCLUSTERED INDEX [IX_TasksRequests_SubTaskId] ON [dbo].[TasksRequests]
(
	[SubTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Billings]  WITH CHECK ADD  CONSTRAINT [FK_Billings_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Billings] CHECK CONSTRAINT [FK_Billings_Projects_ProjectId]
GO
ALTER TABLE [dbo].[Billings]  WITH CHECK ADD  CONSTRAINT [FK_Billings_TasksRequests_TasksRequestId] FOREIGN KEY([TasksRequestId])
REFERENCES [dbo].[TasksRequests] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Billings] CHECK CONSTRAINT [FK_Billings_TasksRequests_TasksRequestId]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Projects_ProjectId]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_TasksRequests_TasksRequestId] FOREIGN KEY([TasksRequestId])
REFERENCES [dbo].[TasksRequests] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_TasksRequests_TasksRequestId]
GO
ALTER TABLE [dbo].[MediaFiles]  WITH CHECK ADD  CONSTRAINT [FK_MediaFiles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[MediaFiles] CHECK CONSTRAINT [FK_MediaFiles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[MediaFiles]  WITH CHECK ADD  CONSTRAINT [FK_MediaFiles_TasksRequests_TasksRequestId] FOREIGN KEY([TasksRequestId])
REFERENCES [dbo].[TasksRequests] ([Id])
GO
ALTER TABLE [dbo].[MediaFiles] CHECK CONSTRAINT [FK_MediaFiles_TasksRequests_TasksRequestId]
GO
ALTER TABLE [dbo].[SubTasks]  WITH CHECK ADD  CONSTRAINT [FK_SubTasks_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[SubTasks] CHECK CONSTRAINT [FK_SubTasks_Projects_ProjectId]
GO
ALTER TABLE [dbo].[TasksRequests]  WITH CHECK ADD  CONSTRAINT [FK_TasksRequests_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[TasksRequests] CHECK CONSTRAINT [FK_TasksRequests_Projects_ProjectId]
GO
ALTER TABLE [dbo].[TasksRequests]  WITH CHECK ADD  CONSTRAINT [FK_TasksRequests_SubTasks_SubTaskId] FOREIGN KEY([SubTaskId])
REFERENCES [dbo].[SubTasks] ([Id])
GO
ALTER TABLE [dbo].[TasksRequests] CHECK CONSTRAINT [FK_TasksRequests_SubTasks_SubTaskId]
GO
USE [master]
GO
ALTER DATABASE [Unikreativ] SET  READ_WRITE 
GO
