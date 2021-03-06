USE [master]
GO
/****** Object:  Database [HotelPuraVida]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE DATABASE [HotelPuraVida]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelPuraVida', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HotelPuraVida.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HotelPuraVida_log', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HotelPuraVida_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HotelPuraVida] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelPuraVida].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelPuraVida] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelPuraVida] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelPuraVida] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelPuraVida] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelPuraVida] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelPuraVida] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HotelPuraVida] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelPuraVida] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelPuraVida] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelPuraVida] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelPuraVida] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelPuraVida] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelPuraVida] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelPuraVida] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelPuraVida] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HotelPuraVida] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelPuraVida] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelPuraVida] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelPuraVida] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelPuraVida] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelPuraVida] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HotelPuraVida] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelPuraVida] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelPuraVida] SET  MULTI_USER 
GO
ALTER DATABASE [HotelPuraVida] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelPuraVida] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelPuraVida] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelPuraVida] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HotelPuraVida] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HotelPuraVida]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelModels]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelModels](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Company] [nvarchar](30) NOT NULL,
	[Rating] [int] NOT NULL,
 CONSTRAINT [PK_dbo.HotelModels] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[OrdenID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
	[People] [real] NOT NULL,
	[RoomType] [nvarchar](max) NOT NULL,
	[CostPerNight] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderReservationModels]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderReservationModels](
	[OrdenID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[UserID] [nvarchar](128) NULL,
	[OrderStatus] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderReservationModels] PRIMARY KEY CLUSTERED 
(
	[OrdenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReservationModels]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationModels](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[People] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[HotelID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UserViewModels_UserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ReservationModels] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleViewModels]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleViewModels](
	[RoleID] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UserViewModels_UserID] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.RoleViewModels] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomModels]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomModels](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[AvailableDays] [datetime] NOT NULL,
	[MaxPeople] [int] NOT NULL,
	[HotelID] [int] NOT NULL,
	[RoomNumber] [int] NOT NULL DEFAULT ((0)),
	[CostPerNight] [decimal](18, 2) NOT NULL DEFAULT ((0)),
	[RoomType] [nvarchar](max) NOT NULL DEFAULT (''),
	[People] [real] NULL,
	[Discriminator] [nvarchar](128) NOT NULL DEFAULT (''),
	[OrderReservation_OrdenID] [int] NULL,
 CONSTRAINT [PK_dbo.RoomModels] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserViewModels]    Script Date: 15-Aug-16 19:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserViewModels](
	[UserID] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[EMail] [nvarchar](max) NULL,
	[Role_RoleID] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.UserViewModels] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrdenID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_OrdenID] ON [dbo].[OrderDetails]
(
	[OrdenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoomID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_RoomID] ON [dbo].[OrderDetails]
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_UserID] ON [dbo].[OrderReservationModels]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HotelID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_HotelID] ON [dbo].[ReservationModels]
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoomID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_RoomID] ON [dbo].[ReservationModels]
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserViewModels_UserID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_UserViewModels_UserID] ON [dbo].[ReservationModels]
(
	[UserViewModels_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserViewModels_UserID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_UserViewModels_UserID] ON [dbo].[RoleViewModels]
(
	[UserViewModels_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HotelID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_HotelID] ON [dbo].[RoomModels]
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderReservation_OrdenID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_OrderReservation_OrdenID] ON [dbo].[RoomModels]
(
	[OrderReservation_OrdenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Role_RoleID]    Script Date: 15-Aug-16 19:44:18 ******/
CREATE NONCLUSTERED INDEX [IX_Role_RoleID] ON [dbo].[UserViewModels]
(
	[Role_RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ReservationModels] ADD  DEFAULT ((0)) FOR [UserID]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.OrderReservationModels_OrdenID] FOREIGN KEY([OrdenID])
REFERENCES [dbo].[OrderReservationModels] ([OrdenID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.OrderReservationModels_OrdenID]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.RoomModels_RoomID] FOREIGN KEY([RoomID])
REFERENCES [dbo].[RoomModels] ([RoomID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.RoomModels_RoomID]
GO
ALTER TABLE [dbo].[OrderReservationModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderReservationModels_dbo.UserViewModels_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserViewModels] ([UserID])
GO
ALTER TABLE [dbo].[OrderReservationModels] CHECK CONSTRAINT [FK_dbo.OrderReservationModels_dbo.UserViewModels_UserID]
GO
ALTER TABLE [dbo].[ReservationModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ReservationModels_dbo.HotelModels_HotelID] FOREIGN KEY([HotelID])
REFERENCES [dbo].[HotelModels] ([HotelID])
GO
ALTER TABLE [dbo].[ReservationModels] CHECK CONSTRAINT [FK_dbo.ReservationModels_dbo.HotelModels_HotelID]
GO
ALTER TABLE [dbo].[ReservationModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ReservationModels_dbo.RoomModels_RoomID] FOREIGN KEY([RoomID])
REFERENCES [dbo].[RoomModels] ([RoomID])
GO
ALTER TABLE [dbo].[ReservationModels] CHECK CONSTRAINT [FK_dbo.ReservationModels_dbo.RoomModels_RoomID]
GO
ALTER TABLE [dbo].[ReservationModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ReservationModels_dbo.UserViewModels_UserViewModels_UserID] FOREIGN KEY([UserViewModels_UserID])
REFERENCES [dbo].[UserViewModels] ([UserID])
GO
ALTER TABLE [dbo].[ReservationModels] CHECK CONSTRAINT [FK_dbo.ReservationModels_dbo.UserViewModels_UserViewModels_UserID]
GO
ALTER TABLE [dbo].[RoleViewModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleViewModels_dbo.UserViewModels_UserViewModels_UserID] FOREIGN KEY([UserViewModels_UserID])
REFERENCES [dbo].[UserViewModels] ([UserID])
GO
ALTER TABLE [dbo].[RoleViewModels] CHECK CONSTRAINT [FK_dbo.RoleViewModels_dbo.UserViewModels_UserViewModels_UserID]
GO
ALTER TABLE [dbo].[RoomModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoomModels_dbo.HotelModels_HotelID] FOREIGN KEY([HotelID])
REFERENCES [dbo].[HotelModels] ([HotelID])
GO
ALTER TABLE [dbo].[RoomModels] CHECK CONSTRAINT [FK_dbo.RoomModels_dbo.HotelModels_HotelID]
GO
ALTER TABLE [dbo].[RoomModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoomModels_dbo.OrderReservationModels_OrderReservation_OrdenID] FOREIGN KEY([OrderReservation_OrdenID])
REFERENCES [dbo].[OrderReservationModels] ([OrdenID])
GO
ALTER TABLE [dbo].[RoomModels] CHECK CONSTRAINT [FK_dbo.RoomModels_dbo.OrderReservationModels_OrderReservation_OrdenID]
GO
ALTER TABLE [dbo].[UserViewModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserViewModels_dbo.RoleViewModels_Role_RoleID] FOREIGN KEY([Role_RoleID])
REFERENCES [dbo].[RoleViewModels] ([RoleID])
GO
ALTER TABLE [dbo].[UserViewModels] CHECK CONSTRAINT [FK_dbo.UserViewModels_dbo.RoleViewModels_Role_RoleID]
GO
USE [master]
GO
ALTER DATABASE [HotelPuraVida] SET  READ_WRITE 
GO
