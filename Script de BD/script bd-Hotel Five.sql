USE [master]
GO
/****** Object:  Database [HotelFive]    Script Date: 17/11/2023 07:50:36 ******/
CREATE DATABASE [HotelFive]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelFive', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotelFive.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelFive_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotelFive_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotelFive] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelFive].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelFive] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelFive] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelFive] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelFive] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelFive] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelFive] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HotelFive] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelFive] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelFive] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelFive] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelFive] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelFive] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelFive] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelFive] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelFive] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelFive] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelFive] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelFive] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelFive] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelFive] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelFive] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelFive] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelFive] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelFive] SET  MULTI_USER 
GO
ALTER DATABASE [HotelFive] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelFive] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelFive] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelFive] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelFive] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelFive] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HotelFive] SET QUERY_STORE = OFF
GO
USE [HotelFive]
GO
/****** Object:  Table [dbo].[ClienteReserva]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteReserva](
	[IdClienteReserva] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NULL,
	[HabitacionID] [int] NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
	[Estado] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdClienteReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [int] NULL,
	[Apellido] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[FechaNacimiento] [varchar](12) NULL,
	[Email] [varchar](50) NULL,
	[Telefono] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoReserva]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoReserva](
	[idEstado] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitaciones]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitaciones](
	[IdHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[IdPiso] [int] NULL,
	[Numero] [int] NULL,
	[IdTipo] [int] NULL,
	[Descripcion] [varchar](100) NULL,
	[Estado] [varchar](20) NULL,
	[Precio] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[IdReserva] [int] NULL,
	[FechaFactura] [datetime] NULL,
	[TipodePago] [varchar](20) NULL,
	[Estado] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Piso]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Piso](
	[idPiso] [int] IDENTITY(1,1) NOT NULL,
	[NumeroPiso] [int] NULL,
	[Estado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdEstado] [int] NULL,
	[IdHabitacion] [int] NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
	[Total] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Usuario]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Usuario](
	[id_tipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](15) NOT NULL,
 CONSTRAINT [PK_tipoUsuario] PRIMARY KEY CLUSTERED 
(
	[id_tipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoHabitacion]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoHabitacion](
	[idTipoHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 17/11/2023 07:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_tipoUsuario] [int] NOT NULL,
	[DNI] [int] NOT NULL,
	[apellido] [varchar](20) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[email] [varchar](30) NOT NULL,
	[telefono] [int] NOT NULL,
	[contraseña] [varchar](30) NOT NULL,
	[baja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ClienteReserva] ON 

INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (1, 1, 2, CAST(N'2023-11-15T00:00:00.000' AS DateTime), CAST(N'2023-11-16T00:00:00.000' AS DateTime), N'Activo')
INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (2, 2, 1, CAST(N'2023-11-22T00:00:00.000' AS DateTime), CAST(N'2023-11-25T00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (3, 3, 3, CAST(N'2023-11-20T00:00:00.000' AS DateTime), CAST(N'2023-11-22T00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (7, 4, 2, CAST(N'2023-11-24T00:00:00.000' AS DateTime), CAST(N'2023-11-29T00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (8, 5, 1, CAST(N'2023-11-14T00:00:00.000' AS DateTime), CAST(N'2023-11-14T00:00:00.000' AS DateTime), N'Activo')
INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (9, 5, 3, CAST(N'2023-11-15T06:52:37.557' AS DateTime), CAST(N'2023-11-16T06:52:37.510' AS DateTime), N'Activo')
INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (10, 7, 1, CAST(N'2023-11-23T00:00:00.000' AS DateTime), CAST(N'2023-11-30T00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (11, 4, 1, CAST(N'2023-11-15T10:55:07.743' AS DateTime), CAST(N'2023-11-16T10:55:07.000' AS DateTime), N'Activo')
INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (12, 4, 1, CAST(N'2023-11-15T11:03:25.840' AS DateTime), CAST(N'2023-11-16T11:03:25.803' AS DateTime), N'Activo')
INSERT [dbo].[ClienteReserva] ([IdClienteReserva], [ClienteID], [HabitacionID], [FechaInicio], [FechaFin], [Estado]) VALUES (13, 4, 1, CAST(N'2023-11-16T00:00:00.000' AS DateTime), CAST(N'2023-11-18T00:00:00.000' AS DateTime), N'Pendiente')
SET IDENTITY_INSERT [dbo].[ClienteReserva] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([IdCliente], [Dni], [Apellido], [Nombre], [FechaNacimiento], [Email], [Telefono]) VALUES (1, 123456789, N'Gómez', N'Ana', N'1990-05-15', N'ana@email.com', 555123456)
INSERT [dbo].[Clientes] ([IdCliente], [Dni], [Apellido], [Nombre], [FechaNacimiento], [Email], [Telefono]) VALUES (2, 987654321, N'López', N'Juan', N'1985-11-30', N'juan@email.com', 555789012)
INSERT [dbo].[Clientes] ([IdCliente], [Dni], [Apellido], [Nombre], [FechaNacimiento], [Email], [Telefono]) VALUES (3, 555555555, N'Pérez', N'María', N'22-08-1995', N'maria@email.com', 555555555)
INSERT [dbo].[Clientes] ([IdCliente], [Dni], [Apellido], [Nombre], [FechaNacimiento], [Email], [Telefono]) VALUES (4, 42004018, N'llopi', N'alvaro', N'13-06-1999', N'alvaro@gmail.com', 1111111)
INSERT [dbo].[Clientes] ([IdCliente], [Dni], [Apellido], [Nombre], [FechaNacimiento], [Email], [Telefono]) VALUES (5, 41498346, N'coronel', N'florencia', N'11-09-1998', N'florencia@gmail.com', 12365498)
INSERT [dbo].[Clientes] ([IdCliente], [Dni], [Apellido], [Nombre], [FechaNacimiento], [Email], [Telefono]) VALUES (7, 38311096, N'gimenez', N'sergio', N'20-12-2012', N'sergio@gmail.com', 1234568)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoReserva] ON 

INSERT [dbo].[EstadoReserva] ([idEstado], [Estado]) VALUES (1, N'Confirmada')
INSERT [dbo].[EstadoReserva] ([idEstado], [Estado]) VALUES (2, N'Cancelada')
INSERT [dbo].[EstadoReserva] ([idEstado], [Estado]) VALUES (3, N'Pendiente de Pago')
INSERT [dbo].[EstadoReserva] ([idEstado], [Estado]) VALUES (4, N'Completada')
SET IDENTITY_INSERT [dbo].[EstadoReserva] OFF
GO
SET IDENTITY_INSERT [dbo].[Habitaciones] ON 

INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (1, 1, 101, 1, N'tv + cable + aire', N'Disponible', 250)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (2, 1, 102, 1, N'wifi + baño + aire', N'Disponible', 250)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (3, 1, 103, 1, N'wifi + tv + cable', N'Disponible', 250)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (4, 1, 104, 1, N'baño + tv + cable + aire', N'Disponible', 300)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (5, 1, 105, 1, N'wifi + baño + tv + cable + aire', N'Disponible', 350)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (6, 2, 201, 2, N'wifi + tv + cable', N'Disponible', 250)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (7, 2, 202, 2, N'tv + cable + aire', N'Disponible', 250)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (8, 2, 203, 2, N'baño + tv + cable + aire', N'Disponible', 300)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (9, 2, 204, 2, N'wifi + tv + cable', N'Disponible', 250)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (10, 2, 205, 2, N'wifi + baño + tv + cable + aire', N'Disponible', 350)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (11, 3, 301, 3, N'tv + cable + aire', N'Disponible', 250)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (12, 3, 302, 3, N'baño + tv + cable + aire', N'Disponible', 300)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (13, 3, 303, 3, N'tv + cable + aire', N'Disponible', 250)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (14, 3, 304, 3, N'wifi + baño + aire', N'Disponible', 250)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (15, 3, 305, 3, N'wifi + baño + tv + cable + aire', N'Disponible', 350)
INSERT [dbo].[Habitaciones] ([IdHabitacion], [IdPiso], [Numero], [IdTipo], [Descripcion], [Estado], [Precio]) VALUES (16, 1, 106, 1, N'aire + cable + tv + baño + wifi', N'Disponible', 350)
SET IDENTITY_INSERT [dbo].[Habitaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Pago] ON 

INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (1, 2, CAST(N'2023-11-15T11:41:43.487' AS DateTime), N'Tarjeta', N'PAGADO')
INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (2, 1, CAST(N'2023-11-15T11:41:52.000' AS DateTime), N'Tarjeta', N'PAGADO')
INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (3, 1, CAST(N'2023-11-15T11:59:40.267' AS DateTime), N'Tarjeta', N'PAGADO')
INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (4, 4, CAST(N'2023-11-15T11:59:51.883' AS DateTime), N'Tarjeta', N'PAGADO')
INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (5, 5, CAST(N'2023-11-15T12:12:54.107' AS DateTime), N'Tarjeta', N'PAGADO')
INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (6, 6, CAST(N'2023-11-15T12:13:09.547' AS DateTime), N'Tarjeta', N'PAGADO')
INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (7, 7, CAST(N'2023-11-15T12:13:43.707' AS DateTime), N'Efectivo', N'PAGADO')
INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (8, 8, CAST(N'2023-11-15T12:51:31.460' AS DateTime), N'Efectivo', N'PAGADO')
INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (9, 9, CAST(N'2023-11-15T12:56:22.380' AS DateTime), N'Tarjeta', N'PAGADO')
INSERT [dbo].[Pago] ([IdPago], [IdReserva], [FechaFactura], [TipodePago], [Estado]) VALUES (10, 9, CAST(N'2023-11-15T12:58:39.753' AS DateTime), N'Tarjeta', N'PAGADO')
SET IDENTITY_INSERT [dbo].[Pago] OFF
GO
SET IDENTITY_INSERT [dbo].[Piso] ON 

INSERT [dbo].[Piso] ([idPiso], [NumeroPiso], [Estado]) VALUES (1, 1, N'Activo')
INSERT [dbo].[Piso] ([idPiso], [NumeroPiso], [Estado]) VALUES (2, 2, N'Activo')
INSERT [dbo].[Piso] ([idPiso], [NumeroPiso], [Estado]) VALUES (3, 3, N'Activo')
SET IDENTITY_INSERT [dbo].[Piso] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservas] ON 

INSERT [dbo].[Reservas] ([IdReserva], [IdCliente], [IdUsuario], [IdEstado], [IdHabitacion], [FechaInicio], [FechaFin], [Total]) VALUES (1, 7, 1, 3, 1, CAST(N'2023-11-15T11:40:06.657' AS DateTime), CAST(N'2023-11-18T11:40:06.000' AS DateTime), 750)
INSERT [dbo].[Reservas] ([IdReserva], [IdCliente], [IdUsuario], [IdEstado], [IdHabitacion], [FechaInicio], [FechaFin], [Total]) VALUES (2, 4, 1, 3, 2, CAST(N'2023-11-15T11:40:39.470' AS DateTime), CAST(N'2023-11-19T11:40:39.000' AS DateTime), 1000)
INSERT [dbo].[Reservas] ([IdReserva], [IdCliente], [IdUsuario], [IdEstado], [IdHabitacion], [FechaInicio], [FechaFin], [Total]) VALUES (3, 5, 1, 3, 1, CAST(N'2023-11-15T11:57:24.587' AS DateTime), CAST(N'2023-11-16T11:57:24.000' AS DateTime), 250)
INSERT [dbo].[Reservas] ([IdReserva], [IdCliente], [IdUsuario], [IdEstado], [IdHabitacion], [FechaInicio], [FechaFin], [Total]) VALUES (4, 5, 1, 3, 3, CAST(N'2023-11-15T11:57:42.133' AS DateTime), CAST(N'2023-11-16T11:57:42.000' AS DateTime), 250)
INSERT [dbo].[Reservas] ([IdReserva], [IdCliente], [IdUsuario], [IdEstado], [IdHabitacion], [FechaInicio], [FechaFin], [Total]) VALUES (5, 4, 1, 3, 1, CAST(N'2023-11-15T12:05:37.457' AS DateTime), CAST(N'2023-11-18T12:05:37.000' AS DateTime), 750)
INSERT [dbo].[Reservas] ([IdReserva], [IdCliente], [IdUsuario], [IdEstado], [IdHabitacion], [FechaInicio], [FechaFin], [Total]) VALUES (6, 7, 1, 3, 3, CAST(N'2023-11-15T12:05:56.217' AS DateTime), CAST(N'2023-11-23T12:05:56.000' AS DateTime), 2000)
INSERT [dbo].[Reservas] ([IdReserva], [IdCliente], [IdUsuario], [IdEstado], [IdHabitacion], [FechaInicio], [FechaFin], [Total]) VALUES (7, 7, 3, 3, 2, CAST(N'2023-11-15T12:13:19.983' AS DateTime), CAST(N'2023-11-16T12:13:19.000' AS DateTime), 250)
INSERT [dbo].[Reservas] ([IdReserva], [IdCliente], [IdUsuario], [IdEstado], [IdHabitacion], [FechaInicio], [FechaFin], [Total]) VALUES (8, 7, 11, 3, 1, CAST(N'2023-11-15T12:48:57.890' AS DateTime), CAST(N'2023-11-16T12:48:57.000' AS DateTime), 250)
INSERT [dbo].[Reservas] ([IdReserva], [IdCliente], [IdUsuario], [IdEstado], [IdHabitacion], [FechaInicio], [FechaFin], [Total]) VALUES (9, 4, 11, 3, 1, CAST(N'2023-11-15T12:56:10.147' AS DateTime), CAST(N'2023-11-16T12:56:10.000' AS DateTime), 250)
SET IDENTITY_INSERT [dbo].[Reservas] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Usuario] ON 

INSERT [dbo].[Tipo_Usuario] ([id_tipoUsuario], [nombre]) VALUES (1, N'Admin')
INSERT [dbo].[Tipo_Usuario] ([id_tipoUsuario], [nombre]) VALUES (2, N'Gerente')
INSERT [dbo].[Tipo_Usuario] ([id_tipoUsuario], [nombre]) VALUES (3, N'Recepcionista')
SET IDENTITY_INSERT [dbo].[Tipo_Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoHabitacion] ON 

INSERT [dbo].[TipoHabitacion] ([idTipoHabitacion], [Tipo]) VALUES (1, N'Individual')
INSERT [dbo].[TipoHabitacion] ([idTipoHabitacion], [Tipo]) VALUES (2, N'Doble')
INSERT [dbo].[TipoHabitacion] ([idTipoHabitacion], [Tipo]) VALUES (3, N'Familiar')
SET IDENTITY_INSERT [dbo].[TipoHabitacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (1, 1, 12345678, N'Apellido1', N'Nombre1', N'email1@example.com', 123456789, N'5a63e75a6e7a09f1f2bbded46dd2ac', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (2, 2, 23456789, N'Apellido2', N'Nombre2', N'email2@example.com', 234567890, N'3fb14b60d144c0c85deb4f01d8e8c9', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (3, 3, 34567890, N'Apellido3', N'Nombre3', N'email3@example.com', 345678901, N'7511d7e795929bc4f97ff62ef9779f', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (4, 1, 45678901, N'Apellido4', N'Nombre4', N'email4@example.com', 456789012, N'5aac963295ac54126f1ae87e98fba8', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (5, 2, 56789012, N'Apellido5', N'Nombre5', N'email5@example.com', 567890123, N'c9391add1c2695e903be0a61ae93b2', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (6, 3, 67890123, N'Apellido6', N'Nombre6', N'email6@example.com', 678901234, N'660d4912b7357981384ce6b5c64982', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (7, 1, 78901234, N'Apellido7', N'Nombre7', N'email7@example.com', 789012345, N'1faba17a2eb276d9c91f3f76ac8c08', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (8, 2, 89012345, N'Apellido8', N'Nombre8', N'email8@example.com', 890123456, N'c3832d9e9eed3f7813ded8baa1fd9c', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (9, 3, 90123456, N'Apellido9', N'Nombre9', N'email9@example.com', 901234567, N'1eab7f984a6eabd4505ecd513c2013', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (10, 1, 12341234, N'Apellido10', N'Nombre10', N'email10@example.com', 123412345, N'5f0affdc0a9fa85a9bf330ff39a220', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (11, 1, 42004018, N'alvaro', N'alvaro', N'alvaro@gmail.com', 123456, N'c5d755912b82d04df10814b2ed8860', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (12, 1, 123456789, N'prueba', N'prueba', N'prueba@example.com', 123456789, N'1230a70ed6218ca77460e2a255d305', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (15, 1, 42004017, N'llopi', N'alvaro', N'llopi@example.com', 123456789, N'e24b475384d7dff2b41d385cb2a5b3', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_tipoUsuario], [DNI], [apellido], [nombre], [email], [telefono], [contraseña], [baja]) VALUES (16, 1, 11335544, N'Gimenez', N'Sergio', N'prueba1@example.com', 12356432, N'ef994e7262a78b97c039adf58214ee', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [UQ__Clientes__C0308575E4D04286]    Script Date: 17/11/2023 07:50:37 ******/
ALTER TABLE [dbo].[Clientes] ADD UNIQUE NONCLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Usuarios__C035B8DDF5311FFB]    Script Date: 17/11/2023 07:50:37 ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClienteReserva] ADD  DEFAULT ('Pendiente') FOR [Estado]
GO
ALTER TABLE [dbo].[Piso] ADD  DEFAULT ('Activo') FOR [Estado]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [baja]
GO
ALTER TABLE [dbo].[ClienteReserva]  WITH CHECK ADD  CONSTRAINT [FK_ClienteID] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ClienteReserva] CHECK CONSTRAINT [FK_ClienteID]
GO
ALTER TABLE [dbo].[ClienteReserva]  WITH CHECK ADD  CONSTRAINT [FK_HabitacionID] FOREIGN KEY([HabitacionID])
REFERENCES [dbo].[Habitaciones] ([IdHabitacion])
GO
ALTER TABLE [dbo].[ClienteReserva] CHECK CONSTRAINT [FK_HabitacionID]
GO
ALTER TABLE [dbo].[Habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_IdPiso] FOREIGN KEY([IdPiso])
REFERENCES [dbo].[Piso] ([idPiso])
GO
ALTER TABLE [dbo].[Habitaciones] CHECK CONSTRAINT [FK_IdPiso]
GO
ALTER TABLE [dbo].[Habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_IdTipo] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[TipoHabitacion] ([idTipoHabitacion])
GO
ALTER TABLE [dbo].[Habitaciones] CHECK CONSTRAINT [FK_IdTipo]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_IdReserva] FOREIGN KEY([IdReserva])
REFERENCES [dbo].[Reservas] ([IdReserva])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_IdReserva]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_IdCliente]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_IdEstado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[EstadoReserva] ([idEstado])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_IdEstado]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_IdHabitacion] FOREIGN KEY([IdHabitacion])
REFERENCES [dbo].[Habitaciones] ([IdHabitacion])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_IdHabitacion]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_IdUsuario]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_tipoUsuario] FOREIGN KEY([id_tipoUsuario])
REFERENCES [dbo].[Tipo_Usuario] ([id_tipoUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_tipoUsuario]
GO
USE [master]
GO
ALTER DATABASE [HotelFive] SET  READ_WRITE 
GO
