USE [master]
GO
/****** Object:  Database [KaZaPy_DB]    Script Date: 04/30/2013 11:22:35 ******/
CREATE DATABASE [KaZaPy_DB] ON  PRIMARY 
( NAME = N'KaZaPy_DB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\KaZaPy_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KaZaPy_DB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\KaZaPy_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KaZaPy_DB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KaZaPy_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KaZaPy_DB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [KaZaPy_DB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [KaZaPy_DB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [KaZaPy_DB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [KaZaPy_DB] SET ARITHABORT OFF
GO
ALTER DATABASE [KaZaPy_DB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [KaZaPy_DB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [KaZaPy_DB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [KaZaPy_DB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [KaZaPy_DB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [KaZaPy_DB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [KaZaPy_DB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [KaZaPy_DB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [KaZaPy_DB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [KaZaPy_DB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [KaZaPy_DB] SET  DISABLE_BROKER
GO
ALTER DATABASE [KaZaPy_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [KaZaPy_DB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [KaZaPy_DB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [KaZaPy_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [KaZaPy_DB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [KaZaPy_DB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [KaZaPy_DB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [KaZaPy_DB] SET  READ_WRITE
GO
ALTER DATABASE [KaZaPy_DB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [KaZaPy_DB] SET  MULTI_USER
GO
ALTER DATABASE [KaZaPy_DB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [KaZaPy_DB] SET DB_CHAINING OFF
GO
USE [KaZaPy_DB]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04/30/2013 11:22:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](32) NOT NULL,
	[lastName] [nvarchar](32) NOT NULL,
	[email] [nvarchar](32) NOT NULL,
	[password] [nvarchar](16) NOT NULL,
	[privilege] [bit] NULL,
	[logged] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 04/30/2013 11:22:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](32) NOT NULL,
	[owner] [int] NOT NULL,
	[creationDate] [date] NULL,
	[modificationDate] [date] NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 04/30/2013 11:22:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[size] [int] NOT NULL,
	[blob] [image] NOT NULL,
	[album] [int] NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF_User_privilege]    Script Date: 04/30/2013 11:22:37 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_privilege]  DEFAULT ((0)) FOR [privilege]
GO
/****** Object:  Default [DF_User_logged]    Script Date: 04/30/2013 11:22:37 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_logged]  DEFAULT ((1)) FOR [logged]
GO
/****** Object:  Default [DF_Album_creationDate]    Script Date: 04/30/2013 11:22:37 ******/
ALTER TABLE [dbo].[Album] ADD  CONSTRAINT [DF_Album_creationDate]  DEFAULT (getdate()) FOR [creationDate]
GO
/****** Object:  Default [DF_Album_modificationDate]    Script Date: 04/30/2013 11:22:37 ******/
ALTER TABLE [dbo].[Album] ADD  CONSTRAINT [DF_Album_modificationDate]  DEFAULT (getdate()) FOR [modificationDate]
GO
/****** Object:  ForeignKey [FK_User_Album]    Script Date: 04/30/2013 11:22:37 ******/
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_User_Album] FOREIGN KEY([owner])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_User_Album]
GO
/****** Object:  ForeignKey [FK_Album_Image]    Script Date: 04/30/2013 11:22:37 ******/
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Album_Image] FOREIGN KEY([album])
REFERENCES [dbo].[Album] ([id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Album_Image]
GO
