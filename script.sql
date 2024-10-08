/****** Object:  Table [dbo].[User]    Script Date: 15/8/2024 12:43:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Database [biometrico]    Script Date: 15/8/2024 12:43:40 ******/
DROP DATABASE [biometrico]
GO
/****** Object:  Database [biometrico]    Script Date: 15/8/2024 12:43:40 ******/
CREATE DATABASE [biometrico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'biometrico', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\biometrico.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'biometrico_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\biometrico.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [biometrico] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [biometrico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [biometrico] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [biometrico] SET ANSI_NULLS ON 
GO
ALTER DATABASE [biometrico] SET ANSI_PADDING ON 
GO
ALTER DATABASE [biometrico] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [biometrico] SET ARITHABORT ON 
GO
ALTER DATABASE [biometrico] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [biometrico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [biometrico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [biometrico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [biometrico] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [biometrico] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [biometrico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [biometrico] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [biometrico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [biometrico] SET  DISABLE_BROKER 
GO
ALTER DATABASE [biometrico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [biometrico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [biometrico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [biometrico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [biometrico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [biometrico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [biometrico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [biometrico] SET RECOVERY FULL 
GO
ALTER DATABASE [biometrico] SET  MULTI_USER 
GO
ALTER DATABASE [biometrico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [biometrico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [biometrico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [biometrico] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [biometrico] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [biometrico] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [biometrico] SET QUERY_STORE = OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 15/8/2024 12:43:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nchar](10) NOT NULL,
	[Clave] [nchar](100) NOT NULL,
	[Gmail] [nchar](100) NOT NULL,
	[Rol] [nchar](100) NOT NULL,
	[Erased] [bit] NOT NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [NombreUsuario], [Clave], [Gmail], [Rol], [Erased], [Date]) VALUES (1, N'jorhe     ', N'jorhe212                                                                                            ', N'jorhe212                                                                                            ', N'Administrador                                                                                       ', 0, CAST(N'2024-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[User] ([Id], [NombreUsuario], [Clave], [Gmail], [Rol], [Erased], [Date]) VALUES (2, N'string    ', N'1000.PSSf8/eLUggwDhd4MjeS9A==.KsMR0qiGvbAEs9UeHInFzBZwyCNgYzoc1QsajU2/6fE=                          ', N'string                                                                                              ', N'Administrador                                                                                       ', 0, CAST(N'2024-08-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER DATABASE [biometrico] SET  READ_WRITE 
GO
