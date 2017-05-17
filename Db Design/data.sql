USE [master]
GO
/****** Object:  Database [Unikreativ]    Script Date: 17/05/2017 11:26:23 CH ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/05/2017 11:26:23 CH ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[Billings]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[Events]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[MediaFiles]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[Projects]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[SubTasks]    Script Date: 17/05/2017 11:26:24 CH ******/
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
/****** Object:  Table [dbo].[TasksRequests]    Script Date: 17/05/2017 11:26:24 CH ******/
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
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'151de3fb-52a4-48e8-924a-da55d2af018f', N'c96c8373-1433-4a29-8f5c-16af9cf8743f', N'Developer', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'25152573-c761-462f-90c6-ffe27be85a74', N'9a2f7f27-3f7e-41a6-8bc6-68b30c929093', N'Administrator', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'26fdf3ac-ebfc-499f-8c6f-4caead004f15', N'c8d8cb8d-a87f-4387-a487-76a3535f13c5', N'Designer', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'6d640990-2927-4b9f-8f9f-56024e40b8df', N'6514eae2-cb1e-48a0-a281-713c1b6dd248', N'Watcher', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'7c594524-05e2-4a8b-bfcc-de1061f40784', N'5edde832-01ba-421f-81ae-0669039ca0fd', N'Client', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'dca11ea2-d637-4d3b-a9fa-9b688a28d4cd', N'be6f7bd0-275b-4671-b130-9018dca422ea', N'Manager', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'de873c59-c1ee-4322-a5e7-0123fc782e75', N'd7609095-3297-4833-89ff-93f5efd1e77e', N'Accountant', NULL)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c7f23af6-5973-4475-80a4-0e64abdd6657', N'25152573-c761-462f-90c6-ffe27be85a74')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [Address], [ChargeRate], [CompanyName], [ConcurrencyStamp], [Country], [Email], [EmailConfirmed], [FullName], [Industries], [JobTitle], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [Status], [TwoFactorEnabled], [UserName], [Website]) VALUES (N'c7f23af6-5973-4475-80a4-0e64abdd6657', 0, NULL, 14, N'Unikreativ', N'30900026-a73f-48e4-a4dd-f8c4f467b6b1', NULL, N'helentran2609@gmail.com', 1, N'Trần Mai Phương', 1, N'Web Developer', 0, NULL, NULL, N'HelenTran', N'AQAAAAEAACcQAAAAEMFuNoHzqygK8rtKKmXdvF6uRZX06nsWobfHoDrWD/niW7l6WCeL6AmfGQUGOrBnIw==', N'0937005331', 1, N'dff088d6-092f-4498-9b8f-4759b0a4a9ca', NULL, 0, N'helentran', NULL)
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Billings_ProjectId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_Billings_ProjectId] ON [dbo].[Billings]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Billings_TasksRequestId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Billings_TasksRequestId] ON [dbo].[Billings]
(
	[TasksRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_ProjectId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_Events_ProjectId] ON [dbo].[Events]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_TasksRequestId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_Events_TasksRequestId] ON [dbo].[Events]
(
	[TasksRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MediaFiles_TasksRequestId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_MediaFiles_TasksRequestId] ON [dbo].[MediaFiles]
(
	[TasksRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MediaFiles_UserId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_MediaFiles_UserId] ON [dbo].[MediaFiles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubTasks_ProjectId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_SubTasks_ProjectId] ON [dbo].[SubTasks]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TasksRequests_ProjectId]    Script Date: 17/05/2017 11:26:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_TasksRequests_ProjectId] ON [dbo].[TasksRequests]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TasksRequests_SubTaskId]    Script Date: 17/05/2017 11:26:24 CH ******/
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
