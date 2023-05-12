USE [master]
GO
/****** Object:  Database [Login-RegistrationDb]    Script Date: 12.05.2023 14:10:34 ******/
CREATE DATABASE [Login-RegistrationDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Login-RegistrationDb', FILENAME = N'C:\Users\aamun\AppData\Roaming\Microsoft\Microsoft SQL Server\Login-RegistrationDb\Login-RegistrationDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Login-RegistrationDb_log', FILENAME = N'C:\Users\aamun\AppData\Roaming\Microsoft\Microsoft SQL Server\Login-RegistrationDb\Login-RegistrationDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Login-RegistrationDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Login-RegistrationDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Login-RegistrationDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Login-RegistrationDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Login-RegistrationDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Login-RegistrationDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Login-RegistrationDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Login-RegistrationDb] SET  MULTI_USER 
GO
ALTER DATABASE [Login-RegistrationDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Login-RegistrationDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Login-RegistrationDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Login-RegistrationDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Login-RegistrationDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Login-RegistrationDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Login-RegistrationDb] SET QUERY_STORE = OFF
GO
USE [Login-RegistrationDb]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12.05.2023 14:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (N'463f1a0b-9671-4ce5-8f1a-f4bdf1f256d4', N'user3', N'123')
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (N'30fc2a82-b30b-42dc-aa5a-cba652871bea', N'user4', N'345')
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (N'069eb670-52a1-4d0d-aa26-11b5ab2bb76d', N'user4', N'345')
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (N'745b3d5f-2757-4a13-9975-ede09f98e4dc', N'user4', N'345')
GO
USE [master]
GO
ALTER DATABASE [Login-RegistrationDb] SET  READ_WRITE 
GO
