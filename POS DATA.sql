USE [master]
GO

/****** Object:  Database [POS_System]    Script Date: 1/23/2016 11:19:45 AM ******/
CREATE DATABASE [POS_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POS_System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\POS_System.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'POS_System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\POS_System_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [POS_System] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [POS_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [POS_System] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [POS_System] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [POS_System] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [POS_System] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [POS_System] SET ARITHABORT OFF 
GO

ALTER DATABASE [POS_System] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [POS_System] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [POS_System] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [POS_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [POS_System] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [POS_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [POS_System] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [POS_System] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [POS_System] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [POS_System] SET  DISABLE_BROKER 
GO

ALTER DATABASE [POS_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [POS_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [POS_System] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [POS_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [POS_System] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [POS_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [POS_System] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [POS_System] SET RECOVERY FULL 
GO

ALTER DATABASE [POS_System] SET  MULTI_USER 
GO

ALTER DATABASE [POS_System] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [POS_System] SET DB_CHAINING OFF 
GO

ALTER DATABASE [POS_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [POS_System] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [POS_System] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [POS_System] SET  READ_WRITE 
GO

