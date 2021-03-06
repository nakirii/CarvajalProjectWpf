USE [master]
GO
/****** Object:  Database [Aeropuerto]    Script Date: 29/05/2022 4:21:17 p. m. ******/
CREATE DATABASE [Aeropuerto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Aeropuerto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Aeropuerto.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Aeropuerto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Aeropuerto_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Aeropuerto] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Aeropuerto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Aeropuerto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Aeropuerto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Aeropuerto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Aeropuerto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Aeropuerto] SET ARITHABORT OFF 
GO
ALTER DATABASE [Aeropuerto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Aeropuerto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Aeropuerto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Aeropuerto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Aeropuerto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Aeropuerto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Aeropuerto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Aeropuerto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Aeropuerto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Aeropuerto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Aeropuerto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Aeropuerto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Aeropuerto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Aeropuerto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Aeropuerto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Aeropuerto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Aeropuerto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Aeropuerto] SET RECOVERY FULL 
GO
ALTER DATABASE [Aeropuerto] SET  MULTI_USER 
GO
ALTER DATABASE [Aeropuerto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Aeropuerto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Aeropuerto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Aeropuerto] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Aeropuerto] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Aeropuerto] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Aeropuerto', N'ON'
GO
ALTER DATABASE [Aeropuerto] SET QUERY_STORE = OFF
GO
USE [Aeropuerto]
GO
/****** Object:  Table [dbo].[Aerolinea]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aerolinea](
	[IdAerolinea] [int] NOT NULL,
	[Aerolinea] [varchar](50) NULL,
 CONSTRAINT [PK_Aerolinea] PRIMARY KEY CLUSTERED 
(
	[IdAerolinea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[IdCiudad] [int] NOT NULL,
	[Ciudad] [varchar](50) NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[IdCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoVuelo]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoVuelo](
	[IdEstado] [int] NOT NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_EstadoVuelo] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[TipoUsuario] [varchar](15) NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[NoDoc] [varchar](15) NOT NULL,
	[PrimerNombre] [varchar](15) NOT NULL,
	[SegundoNombre] [varchar](15) NULL,
	[PrimerApellido] [varchar](15) NOT NULL,
	[SegundoApellido] [varchar](15) NULL,
	[Telefono] [varchar](15) NULL,
	[Correo] [varchar](50) NULL,
	[Password] [varbinary](8000) NULL,
	[TipoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[NoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo](
	[NoVuelo] [varchar](50) NOT NULL,
	[FechaSalida] [date] NOT NULL,
	[FechaLlegada] [date] NOT NULL,
	[HoraLlegada] [time](7) NOT NULL,
	[HoraSalida] [time](7) NOT NULL,
	[CiudadOrigen] [int] NOT NULL,
	[CiudadDestino] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdAerolinea] [int] NOT NULL,
 CONSTRAINT [PK_Vuelo] PRIMARY KEY CLUSTERED 
(
	[NoVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Aerolinea] ([IdAerolinea], [Aerolinea]) VALUES (17, N'LATAM')
INSERT [dbo].[Aerolinea] ([IdAerolinea], [Aerolinea]) VALUES (20, N'Avianca')
INSERT [dbo].[Aerolinea] ([IdAerolinea], [Aerolinea]) VALUES (32, N'Wingo')
INSERT [dbo].[Aerolinea] ([IdAerolinea], [Aerolinea]) VALUES (46, N'SATENA')
INSERT [dbo].[Aerolinea] ([IdAerolinea], [Aerolinea]) VALUES (55, N'EasyFly')
INSERT [dbo].[Aerolinea] ([IdAerolinea], [Aerolinea]) VALUES (69, N'AerCaribe')
GO
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (11, N'Bogota D.C')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (65, N'Armenia')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (73, N'Ivague')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (88, N'Barranquilla')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (118, N'Bucaramanga')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (150, N'Cali')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (171, N'Cartagena')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (275, N'Cucuta')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (532, N'Manizales')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (547, N'Medellin')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (657, N'Pereira')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (877, N'Santa Marta')
INSERT [dbo].[Ciudad] ([IdCiudad], [Ciudad]) VALUES (1070, N'Villavicencio')
GO
INSERT [dbo].[EstadoVuelo] ([IdEstado], [Estado]) VALUES (1, N'Programado')
INSERT [dbo].[EstadoVuelo] ([IdEstado], [Estado]) VALUES (2, N'Retrasado')
INSERT [dbo].[EstadoVuelo] ([IdEstado], [Estado]) VALUES (3, N'Cancelado')
INSERT [dbo].[EstadoVuelo] ([IdEstado], [Estado]) VALUES (4, N'Aterrizado')
INSERT [dbo].[EstadoVuelo] ([IdEstado], [Estado]) VALUES (5, N'En Curso')
GO
SET IDENTITY_INSERT [dbo].[TipoUsuario] ON 

INSERT [dbo].[TipoUsuario] ([IdTipo], [TipoUsuario]) VALUES (1, N'Administrador')
INSERT [dbo].[TipoUsuario] ([IdTipo], [TipoUsuario]) VALUES (2, N'Normal')
SET IDENTITY_INSERT [dbo].[TipoUsuario] OFF
GO
INSERT [dbo].[Usuario] ([NoDoc], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [Telefono], [Correo], [Password], [TipoUsuario]) VALUES (N'1234', N'User', N'', N'Test', N'', N'1005689', N'user@gmail.com', 0x020000000EF2E13977ECB35B37E074AD95B59F06EAA2F6E61C8C5999693A5B72AF6DC79C7ECEA4165AE93C02B310FFCA3D569C39, 1)
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY([TipoUsuario])
REFERENCES [dbo].[TipoUsuario] ([IdTipo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Aerolinea] FOREIGN KEY([IdAerolinea])
REFERENCES [dbo].[Aerolinea] ([IdAerolinea])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Aerolinea]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Ciudad] FOREIGN KEY([CiudadOrigen])
REFERENCES [dbo].[Ciudad] ([IdCiudad])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Ciudad]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Ciudad1] FOREIGN KEY([CiudadDestino])
REFERENCES [dbo].[Ciudad] ([IdCiudad])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Ciudad1]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_EstadoVuelo] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[EstadoVuelo] ([IdEstado])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_EstadoVuelo]
GO
/****** Object:  StoredProcedure [dbo].[CargarAerolinea]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CargarAerolinea]
as
select * from Aerolinea 
GO
/****** Object:  StoredProcedure [dbo].[CargarCiudad]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[CargarCiudad]
as
select * from Ciudad 
GO
/****** Object:  StoredProcedure [dbo].[CargarEstadoVuelo]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[CargarEstadoVuelo]
as
select * from EstadoVuelo 
GO
/****** Object:  StoredProcedure [dbo].[CargarTipoUsuario]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CargarTipoUsuario]
as
select * from TipoUsuario 
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuarios]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ConsultarUsuarios]
@NoDoc varchar (50)
as
select * from Usuario u join TipoUsuario t on u.TipoUsuario = t.IdTipo where NoDoc = @NoDoc
GO
/****** Object:  StoredProcedure [dbo].[ConsultarVuelo]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ConsultarVuelo]
@NoVuelo varchar(20)
as
select * from Vuelo where NoVuelo = @NoVuelo
GO
/****** Object:  StoredProcedure [dbo].[EditarUsuario]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EditarUsuario]
@NoDoc varchar (100),
@PrimerNombre varchar (100),
@SegundoNombre varchar (100),
@PrimerApellido varchar (100),
@SegundoApellido varchar (100),
@Telefono varchar (100),
@Correo varchar (100),
@Password nvarchar (50),
@TipoUsuario int
as
update  Usuario set PrimerNombre=@PrimerNombre, SegundoNombre=@SegundoNombre, 
		PrimerApellido=@PrimerApellido,SegundoApellido=@SegundoApellido,Telefono=@Telefono,Correo=@Correo,Password=EncryptByPassPhrase('password',@Password),TipoUsuario=@TipoUsuario
where NoDoc=@NoDoc
GO
/****** Object:  StoredProcedure [dbo].[EditarVuelo]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EditarVuelo]
@NoVuelo varchar (50),
@FechaSalida date,
@FechaLlegada date,
@HoraLlegada time(7),
@HoraSalida time(7),
@CiudadOrigen int,
@CiudadDestino int,
@IdEstado int,
@IdAerolinea int
as
update  Vuelo set FechaSalida=@FechaSalida, FechaLlegada=@FechaLlegada, 
		HoraLlegada=@HoraLlegada,HoraSalida=@HoraSalida,CiudadOrigen=@CiudadOrigen,CiudadDestino=@CiudadDestino,IdEstado=@IdEstado,IdAerolinea=@IdAerolinea
where NoVuelo=@NoVuelo
GO
/****** Object:  StoredProcedure [dbo].[ListarDetallesVuelo]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[ListarDetallesVuelo]
as
select V.NoVuelo,v.FechaSalida,V.FechaLlegada,V.HoraSalida,V.HoraLlegada,C.Ciudad as CiudadDestino,C2.Ciudad as CiudadOrigen,EV.Estado,A.Aerolinea
from Vuelo V join Ciudad C on V.CiudadDestino = C.IdCiudad join
Ciudad C2 on V.CiudadOrigen = C2.IdCiudad join 
EstadoVuelo EV on V.IdEstado = EV.IdEstado join
Aerolinea A on V.IdAerolinea = A.IdAerolinea
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarios]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[ListarUsuarios]
 as
 select NoDoc,PrimerNombre,PrimerApellido,Telefono,Correo,t.TipoUsuario
 from  Usuario u join TipoUsuario t on u.TipoUsuario=t.IdTipo
GO
/****** Object:  StoredProcedure [dbo].[NombreTipoUsuario]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NombreTipoUsuario]
@IdTipo int
as
select TipoUsuario from TipoUsuario where IdTipo = @IdTipo
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarUsuario]
@NoDoc varchar (100),
@PrimerNombre varchar (100),
@SegundoNombre varchar (100),
@PrimerApellido varchar (100),
@SegundoApellido varchar (100),
@Telefono varchar (100),
@Correo varchar (100),
@Password nvarchar (50), 
@TipoUsuario int
as
insert into Usuario values (@NoDoc,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Telefono,@Correo,EncryptByPassPhrase('password',@Password),@TipoUsuario)
GO
/****** Object:  StoredProcedure [dbo].[RegistrarVuelo]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarVuelo]
@NoVuelo varchar (50),
@FechaSalida date,
@FechaLlegada date,
@HoraLlegada time(7),
@HoraSalida time(7),
@CiudadOrigen int,
@CiudadDestino int,
@IdEstado int,
@IdAerolinea int
as
insert into Vuelo values (@NoVuelo,@FechaSalida,@FechaLlegada,@HoraLlegada,@HoraSalida,@CiudadOrigen,@CiudadDestino,@IdEstado,@IdAerolinea)
GO
/****** Object:  StoredProcedure [dbo].[ValidarLogin]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ValidarLogin]
@Usuario varchar(15),
@Password varchar(50),
@Patron varchar(50)
as 
select NoDoc,TipoUsuario from Usuario where NoDoc = @Usuario and
(DECRYPTBYPASSPHRASE(@Patron, Password)= @Password)
GO
/****** Object:  StoredProcedure [dbo].[Vercontrasena]    Script Date: 29/05/2022 4:21:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Vercontrasena]
@NoDoc varchar(15)
as
select Cast(DECRYPTBYPASSPHRASE('password',u.Password)
 as Nvarchar(20)) as Password, * from Usuario u where u.NoDoc = @NoDoc
GO
USE [master]
GO
ALTER DATABASE [Aeropuerto] SET  READ_WRITE 
GO
