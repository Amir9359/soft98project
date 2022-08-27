USE [master]
GO
/****** Object:  Database [Soft98Db]    Script Date: 26/08/2022 4:06:23 pm ******/
CREATE DATABASE [Soft98Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Soft98Db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Soft98Db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Soft98Db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Soft98Db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Soft98Db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Soft98Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Soft98Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Soft98Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Soft98Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Soft98Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Soft98Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Soft98Db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Soft98Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Soft98Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Soft98Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Soft98Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Soft98Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Soft98Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Soft98Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Soft98Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Soft98Db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Soft98Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Soft98Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Soft98Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Soft98Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Soft98Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Soft98Db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Soft98Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Soft98Db] SET RECOVERY FULL 
GO
ALTER DATABASE [Soft98Db] SET  MULTI_USER 
GO
ALTER DATABASE [Soft98Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Soft98Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Soft98Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Soft98Db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Soft98Db] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Soft98Db', N'ON'
GO
ALTER DATABASE [Soft98Db] SET QUERY_STORE = OFF
GO
USE [Soft98Db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/08/2022 4:06:23 pm ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 26/08/2022 4:06:23 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matlabs]    Script Date: 26/08/2022 4:06:23 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matlabs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Date] [nvarchar](23) NULL,
	[Show] [bit] NOT NULL,
	[NumberSeen] [int] NULL,
	[IsSoft] [bit] NOT NULL,
	[IsMobile] [bit] NOT NULL,
	[IsTech] [bit] NOT NULL,
 CONSTRAINT [PK_Matlabs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 26/08/2022 4:06:23 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26/08/2022 4:06:23 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](6) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220730052128_initial', N'5.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220730070810_create-roleUser', N'5.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220806080327_categoryMig', N'5.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220806080633_categoryMIgration', N'5.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220825062417_MatlabMigration', N'5.0.10')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1, N'سیستم عامل', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (2, N'نرم افزار ', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (3, N'گرافیک', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (4, N'موبایل', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (9, N'ویندوز', 1)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (10, N'ویندوز 8', 9)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1002, N'آموزشی', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1003, N'ویندوز 10', 9)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1004, N'ویندوز 11', 9)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1005, N'مک ', 1006)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1006, N'سایر سیستم عامل ها ', 1)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1007, N'نرم افزار', 2)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1008, N'اینترنت', 2)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1009, N'مالتی مدیا', 2)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1010, N'بازیابی اطلاعات', 1007)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1011, N'پشتیبان گیری', 1007)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1012, N'بهینه سازی ویندوز', 1007)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1013, N'مدیریت دانلود ', 1008)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1014, N'مرورگر اینترنت', 1008)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1016, N'پلیر موزیک ', 1009)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1017, N'پخش کننده فیلم ', 1009)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1018, N'پخش صوت', 1009)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1019, N'اندروید ', 4)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1020, N'سایر', 4)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1021, N'نرم افزار موبایل', 4)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1022, N'بهینه سازی', 1019)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1023, N'پخش کننده ', 1019)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1024, N'کاربردی', 1019)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Matlabs] ON 

INSERT [dbo].[Matlabs] ([Id], [Title], [Description], [Date], [Show], [NumberSeen], [IsSoft], [IsMobile], [IsTech]) VALUES (13, N'مطالب نرم افزار', N'شرح مطالب نرم افزار', N'25/08/2022 11:31:57 pm', 0, 0, 1, 0, 0)
INSERT [dbo].[Matlabs] ([Id], [Title], [Description], [Date], [Show], [NumberSeen], [IsSoft], [IsMobile], [IsTech]) VALUES (14, N'مطالب موبایل', N'مطالب موبایل شرح ', N'25/08/2022 11:32:21 pm', 0, 0, 0, 1, 0)
INSERT [dbo].[Matlabs] ([Id], [Title], [Description], [Date], [Show], [NumberSeen], [IsSoft], [IsMobile], [IsTech]) VALUES (15, N'مطالب تکنولوژی', N'شرح مطالب تکولوژِی', N'25/08/2022 11:32:51 pm', 0, 0, 0, 0, 1)
INSERT [dbo].[Matlabs] ([Id], [Title], [Description], [Date], [Show], [NumberSeen], [IsSoft], [IsMobile], [IsTech]) VALUES (16, N'تست', N'تست', N'26/08/2022 9:48:28 am', 0, 0, 1, 1, 0)
INSERT [dbo].[Matlabs] ([Id], [Title], [Description], [Date], [Show], [NumberSeen], [IsSoft], [IsMobile], [IsTech]) VALUES (17, N'تست 2', N'تست 2', N'26/08/2022 11:17:35 am', 0, 0, 1, 1, 0)
INSERT [dbo].[Matlabs] ([Id], [Title], [Description], [Date], [Show], [NumberSeen], [IsSoft], [IsMobile], [IsTech]) VALUES (18, N'تست تکنولوژی', N'ییی', N'26/08/2022 11:40:16 am', 0, 0, 0, 0, 1)
SET IDENTITY_INSERT [dbo].[Matlabs] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'user')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Phone], [RoleId], [Password], [Code], [IsActive]) VALUES (13, N'09033333333', 2, N'20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70', N'e15542', 1)
INSERT [dbo].[Users] ([Id], [Phone], [RoleId], [Password], [Code], [IsActive]) VALUES (1002, N'09330139182', 2, N'20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70', N'14b077', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Categories_ParentId]    Script Date: 26/08/2022 4:06:23 pm ******/
CREATE NONCLUSTERED INDEX [IX_Categories_ParentId] ON [dbo].[Categories]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 26/08/2022 4:06:23 pm ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_ParentId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [Soft98Db] SET  READ_WRITE 
GO
