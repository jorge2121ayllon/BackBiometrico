
drop database if exists biometrico
GO
CREATE DATABASE biometrico;
GO
use [biometrico];

/******Table [dbo].[User]******/
CREATE TABLE [User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](10) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[Gmail] [varchar](100) NOT NULL,
	[Rol] [varchar](100) NOT NULL,
	[Erased] [bit] NOT NULL,
	[Date] [datetime] NOT NULL,
	CONSTRAINT [PK_user] PRIMARY KEY(Id))
GO

/******Table [dbo].[Club]******/
CREATE TABLE [Club](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
	[Erased] [bit] NOT NULL,
	[Date] [datetime] NOT NULL,
	CONSTRAINT [PK_club] PRIMARY KEY(Id))
GO

/******Table [dbo].[Categoria]******/
CREATE TABLE [Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
	[Erased] [bit] NOT NULL,
	[Date] [datetime] NOT NULL,
	CONSTRAINT [PK_categoria] PRIMARY KEY(Id))
GO

/******Table [dbo].[Jugador]******/
CREATE TABLE [Jugador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ApellidoPaterno] [varchar](50) NOT NULL,
	[ApellidoMaterno] [varchar](50) NOT NULL,
	[Ci] [varchar](30) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Padre] [varchar](50) NULL,
	[Madre] [varchar](50) NULL,
	[Foto] [varchar](max) NULL,
	[Club] [int] NOT NULL,
	[Categoria] [int] NOT NULL,
	[Erased] [bit] NOT NULL,
	[Date] [datetime] NOT NULL,
	
	CONSTRAINT [PK_jugador] PRIMARY KEY(Id),
    CONSTRAINT [FK_jugador_categoria] FOREIGN KEY([Categoria]) REFERENCES [dbo].[Categoria] ([Id]),
	CONSTRAINT [FK_jugador_club] FOREIGN KEY([Club]) REFERENCES [dbo].[Club] ([Id]))
GO

/******agregando datos de prueba user******/
SET IDENTITY_INSERT [biometrico].[dbo].[User] ON 
INSERT [dbo].[User] ([Id], [NombreUsuario], [Clave], [Gmail], [Rol], [Erased], [Date]) VALUES (1, 'jorhe     ', 'jorhe212                                                                                            ', 'jorhe212                                                                                            ', 'Administrador                                                                                       ', 0, CAST(N'2024-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[User] ([Id], [NombreUsuario], [Clave], [Gmail], [Rol], [Erased], [Date]) VALUES (2, 'string    ', '1000.PSSf8/eLUggwDhd4MjeS9A==.KsMR0qiGvbAEs9UeHInFzBZwyCNgYzoc1QsajU2/6fE=                          ', 'string                                                                                              ', 'Administrador                                                                                       ', 0, CAST(N'2024-08-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [biometrico].[dbo].[User] OFF
GO

/******agregando datos de prueba club******/
SET IDENTITY_INSERT [biometrico].[dbo].[Club] ON 
INSERT INTO [biometrico].[dbo].[Club] ([Id],[Descripcion], [Erased], [Date]) VALUES (1,'All Hali',0, CAST(N'2024-08-15T00:00:00.000' AS DateTime))
INSERT INTO [biometrico].[dbo].[Club] ([Id],[Descripcion], [Erased], [Date]) VALUES (2,'Inter de Miami',0, CAST(N'2024-08-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [biometrico].[dbo].[Club] OFF
GO

/******agregando datos de prueba categoria******/
SET IDENTITY_INSERT [biometrico].[dbo].[Categoria] ON 
INSERT INTO [biometrico].[dbo].[Categoria] ([Id],[Descripcion], [Erased], [Date]) VALUES (1,'sub-20',0, CAST(N'2024-08-15T00:00:00.000' AS DateTime))
INSERT INTO [biometrico].[dbo].[Categoria] ([Id],[Descripcion], [Erased], [Date]) VALUES (2,'sub-17',0, CAST(N'2024-08-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [biometrico].[dbo].[Categoria] OFF
GO

/******agregando datos de prueba jugador******/
SET IDENTITY_INSERT [biometrico].[dbo].[Jugador] ON 
INSERT INTO [biometrico].[dbo].[Jugador] (Id,Nombre,ApellidoPaterno,ApellidoMaterno,Ci,FechaNacimiento,Padre,Madre,Foto,Club,Categoria,[Erased], [Date]) VALUES (1,'Neymar Jr','Do santos','Da silva','23987893','1993-04-23','padre do santos','madre da silva','https://assets-fr.imgfoot.com/media/cache/642x382/neymar-2324.jpg',1,2,0, CAST(N'2024-08-15T00:00:00.000' AS DateTime))
INSERT INTO [biometrico].[dbo].[Jugador] (Id,Nombre,ApellidoPaterno,ApellidoMaterno,Ci,FechaNacimiento,Padre,Madre,Foto,Club,Categoria,[Erased], [Date]) VALUES (2,'Luis','Suares','Gomes','56732486','1990-07-15','miguel suares','maria gomez','https://images.mlssoccer.com/image/private/t_editorial_landscape_8_desktop_mobile/mls/rkhfr9lywt2ut3deea8m.webp',2,1,0, CAST(N'2024-08-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [biometrico].[dbo].[Jugador] ON 

USE [master]
GO