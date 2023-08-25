--------------------------------------------
-- Author: Jorge Pérez
-- Description: Script to create database for Academic Load in DETRI Department
-- Database Name: dbCargaHorariaTIC_DETRI_2023
--------------------------------------------
--------------------------------------------
-- PRESS F5 to Execute entire script
--------------------------------------------
USE [master]
GO
/****** Object:  Database [dbCargaHorariaTIC_DETRI_2023]    Script Date: 25/8/2023 14:34:06 ******/
CREATE DATABASE [dbCargaHorariaTIC_DETRI_2023]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbCargaHorariaTIC_DETRI_2023', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbCargaHorariaTIC_DETRI_2023.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbCargaHorariaTIC_DETRI_2023_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbCargaHorariaTIC_DETRI_2023_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbCargaHorariaTIC_DETRI_2023].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET  MULTI_USER 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET QUERY_STORE = OFF
GO
USE [dbCargaHorariaTIC_DETRI_2023]
GO
/****** Object:  Table [dbo].[tblActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblActividad](
	[idActividad] [int] IDENTITY(1,1) NOT NULL,
	[idTpAct_f] [int] NOT NULL,
	[idProyecto_f] [int] NULL,
	[nombreActividad] [varchar](255) NOT NULL,
	[cantHoraSemana] [int] NULL,
	[cantHoraTotal] [int] NULL,
	[estadoActividad] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblActividadCargas]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblActividadCargas](
	[idActivCrgs] [int] IDENTITY(1,1) NOT NULL,
	[idCrgHoraria] [int] NOT NULL,
	[idActividad] [int] NOT NULL,
	[horasSemana] [int] NULL,
	[horaTotal] [int] NULL,
	[estadoActivCrgDocencia] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idActivCrgs] ASC,
	[idCrgHoraria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAsigCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAsigCrgHoraria](
	[idAsigCrgHoraria] [int] IDENTITY(1,1) NOT NULL,
	[idCrgHoraria] [int] NOT NULL,
	[idGrAsig] [int] NOT NULL,
	[estadoAsigCrgDocencia] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idAsigCrgHoraria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uq_GrAsignatura] UNIQUE NONCLUSTERED 
(
	[idCrgHoraria] ASC,
	[idGrAsig] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAsignatura](
	[idAsignatura] [int] IDENTITY(1,1) NOT NULL,
	[idCarrera] [int] NOT NULL,
	[nombreAsignatura] [varchar](150) NOT NULL,
	[tipoAsignatura] [varchar](50) NOT NULL,
	[codigoAsignatura] [varchar](30) NOT NULL,
	[horasAsignaturaTotales] [int] NOT NULL,
	[horasAsignaturaSemanales] [int] NOT NULL,
	[nivelAsignatura] [varchar](50) NOT NULL,
	[estadoAsignatura] [bit] NOT NULL,
 CONSTRAINT [PK_Asignatura] PRIMARY KEY CLUSTERED 
(
	[idAsignatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCargaHoraria](
	[idCargaHoraria] [int] IDENTITY(1,1) NOT NULL,
	[idDocente] [int] NOT NULL,
	[idSemestre] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCargaHoraria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uq_Cargas] UNIQUE NONCLUSTERED 
(
	[idDocente] ASC,
	[idSemestre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCarrera]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCarrera](
	[idCarrera] [int] IDENTITY(1,1) NOT NULL,
	[idDep] [int] NOT NULL,
	[nombreCarrera] [varchar](100) NOT NULL,
	[codigoCarrera] [varchar](50) NULL,
	[pensum] [varchar](50) NOT NULL,
	[estadoCarrera] [bit] NOT NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[idCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDepartamento]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartamento](
	[idDepartamento] [int] IDENTITY(1,1) NOT NULL,
	[nombreDepartamento] [varchar](50) NOT NULL,
	[emailDepartamento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[idDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDiaSemana]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDiaSemana](
	[idDiaSemana] [int] IDENTITY(1,1) NOT NULL,
	[dia] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDiaSemana] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDocente](
	[idDocente] [int] IDENTITY(1,1) NOT NULL,
	[idDepa] [int] NOT NULL,
	[nombre1Docente] [varchar](50) NOT NULL,
	[nombre2Docente] [varchar](50) NOT NULL,
	[apellido1Docente] [varchar](50) NOT NULL,
	[apellido2Docente] [varchar](50) NOT NULL,
	[tituloDocente] [varchar](50) NOT NULL,
	[emailDocente] [varchar](50) NOT NULL,
	[estadoDocente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGrAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGrAsignatura](
	[idGrAsig] [int] IDENTITY(1,1) NOT NULL,
	[idAsignatura] [int] NOT NULL,
	[grupoAsignatura] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idGrAsig] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uq_tblGrAsignatura] UNIQUE NONCLUSTERED 
(
	[idAsignatura] ASC,
	[grupoAsignatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHorarioGrAsig]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHorarioGrAsig](
	[idHorario] [int] IDENTITY(1,1) NOT NULL,
	[idSemestreGrAsignatura] [int] NOT NULL,
	[horaInicio] [time](7) NOT NULL,
	[horaFin] [time](7) NOT NULL,
	[idDiaSemana] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProyecto]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProyecto](
	[idProyecto] [int] IDENTITY(1,1) NOT NULL,
	[codigoProyecto] [varchar](50) NOT NULL,
	[nombreProyecto] [varchar](255) NOT NULL,
	[fechaInicio] [date] NOT NULL,
	[fechaFin] [date] NOT NULL,
	[presupuesto] [decimal](18, 2) NOT NULL,
	[tipoProyecto] [varchar](255) NOT NULL,
	[urlAval] [nvarchar](max) NULL,
	[estadoProyecto] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSemestre](
	[idSemestre] [int] IDENTITY(1,1) NOT NULL,
	[codigoSemestre] [varchar](50) NOT NULL,
	[añoSemestre] [int] NOT NULL,
	[diaInicio] [date] NOT NULL,
	[diaFin] [date] NOT NULL,
	[numSemanasClase] [int] NOT NULL,
	[numSemanasSemestre] [int] NOT NULL,
	[estadoSemestre] [bit] NULL,
 CONSTRAINT [PK_Semestre] PRIMARY KEY CLUSTERED 
(
	[idSemestre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSemestreAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSemestreAsignatura](
	[idSemestreAsignatura] [int] IDENTITY(1,1) NOT NULL,
	[idSemestre] [int] NOT NULL,
	[idAsignatura] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSemestreAsignatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSemestreGrAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSemestreGrAsignatura](
	[idSemestreGrAsignatura] [int] IDENTITY(1,1) NOT NULL,
	[idSemestre] [int] NOT NULL,
	[idGrAsig] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSemestreGrAsignatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSemestreTpDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSemestreTpDocente](
	[idSemestreTpDoc] [int] IDENTITY(1,1) NOT NULL,
	[idTipoDoc] [int] NOT NULL,
	[idSemestre] [int] NOT NULL,
	[idDocente] [int] NOT NULL,
	[numHorasSemestrales] [int] NOT NULL,
	[estadoSemestreDoc] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSemestreTpDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uq_tblSemestreTpDocente] UNIQUE NONCLUSTERED 
(
	[idSemestre] ASC,
	[idDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTipoActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTipoActividad](
	[idTpAct] [int] IDENTITY(1,1) NOT NULL,
	[nombreTpAct] [varchar](255) NOT NULL,
	[descripcionTpAct] [varchar](255) NOT NULL,
 CONSTRAINT [PK_TpActividad] PRIMARY KEY CLUSTERED 
(
	[idTpAct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTipoDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTipoDocente](
	[idTipoDocente] [int] IDENTITY(1,1) NOT NULL,
	[nombreTipoDocente] [varchar](100) NOT NULL,
	[numHorasSemestrales] [int] NOT NULL,
	[estadoTipoDocente] [bit] NOT NULL,
 CONSTRAINT [PK_TipoDocente] PRIMARY KEY CLUSTERED 
(
	[idTipoDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTipoDocenteSemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTipoDocenteSemestre](
	[idTipoDocenteSemestre] [int] IDENTITY(1,1) NOT NULL,
	[idTipoDocente] [int] NOT NULL,
	[idSemestre] [int] NOT NULL,
	[numHorasSemestrales] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoDocenteSemestre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblActividad]  WITH CHECK ADD FOREIGN KEY([idProyecto_f])
REFERENCES [dbo].[tblProyecto] ([idProyecto])
GO
ALTER TABLE [dbo].[tblActividad]  WITH CHECK ADD FOREIGN KEY([idTpAct_f])
REFERENCES [dbo].[tblTipoActividad] ([idTpAct])
GO
ALTER TABLE [dbo].[tblActividadCargas]  WITH CHECK ADD FOREIGN KEY([idActividad])
REFERENCES [dbo].[tblActividad] ([idActividad])
GO
ALTER TABLE [dbo].[tblActividadCargas]  WITH CHECK ADD FOREIGN KEY([idCrgHoraria])
REFERENCES [dbo].[tblCargaHoraria] ([idCargaHoraria])
GO
ALTER TABLE [dbo].[tblAsigCrgHoraria]  WITH CHECK ADD FOREIGN KEY([idCrgHoraria])
REFERENCES [dbo].[tblCargaHoraria] ([idCargaHoraria])
GO
ALTER TABLE [dbo].[tblAsigCrgHoraria]  WITH CHECK ADD FOREIGN KEY([idGrAsig])
REFERENCES [dbo].[tblGrAsignatura] ([idGrAsig])
GO
ALTER TABLE [dbo].[tblAsignatura]  WITH CHECK ADD FOREIGN KEY([idCarrera])
REFERENCES [dbo].[tblCarrera] ([idCarrera])
GO
ALTER TABLE [dbo].[tblCargaHoraria]  WITH CHECK ADD FOREIGN KEY([idDocente])
REFERENCES [dbo].[tblDocente] ([idDocente])
GO
ALTER TABLE [dbo].[tblCargaHoraria]  WITH CHECK ADD FOREIGN KEY([idSemestre])
REFERENCES [dbo].[tblSemestre] ([idSemestre])
GO
ALTER TABLE [dbo].[tblCarrera]  WITH CHECK ADD FOREIGN KEY([idDep])
REFERENCES [dbo].[tblDepartamento] ([idDepartamento])
GO
ALTER TABLE [dbo].[tblDocente]  WITH CHECK ADD FOREIGN KEY([idDepa])
REFERENCES [dbo].[tblDepartamento] ([idDepartamento])
GO
ALTER TABLE [dbo].[tblGrAsignatura]  WITH CHECK ADD FOREIGN KEY([idAsignatura])
REFERENCES [dbo].[tblAsignatura] ([idAsignatura])
GO
ALTER TABLE [dbo].[tblHorarioGrAsig]  WITH CHECK ADD FOREIGN KEY([idDiaSemana])
REFERENCES [dbo].[tblDiaSemana] ([idDiaSemana])
GO
ALTER TABLE [dbo].[tblHorarioGrAsig]  WITH CHECK ADD FOREIGN KEY([idSemestreGrAsignatura])
REFERENCES [dbo].[tblSemestreGrAsignatura] ([idSemestreGrAsignatura])
GO
ALTER TABLE [dbo].[tblSemestreAsignatura]  WITH CHECK ADD  CONSTRAINT [FK_SemestreAsignatura_Asignatura] FOREIGN KEY([idAsignatura])
REFERENCES [dbo].[tblAsignatura] ([idAsignatura])
GO
ALTER TABLE [dbo].[tblSemestreAsignatura] CHECK CONSTRAINT [FK_SemestreAsignatura_Asignatura]
GO
ALTER TABLE [dbo].[tblSemestreAsignatura]  WITH CHECK ADD  CONSTRAINT [FK_SemestreAsignatura_Semestre] FOREIGN KEY([idSemestre])
REFERENCES [dbo].[tblSemestre] ([idSemestre])
GO
ALTER TABLE [dbo].[tblSemestreAsignatura] CHECK CONSTRAINT [FK_SemestreAsignatura_Semestre]
GO
ALTER TABLE [dbo].[tblSemestreGrAsignatura]  WITH CHECK ADD  CONSTRAINT [FK_SemestreGrAsignatura_GrAsignatura] FOREIGN KEY([idGrAsig])
REFERENCES [dbo].[tblGrAsignatura] ([idGrAsig])
GO
ALTER TABLE [dbo].[tblSemestreGrAsignatura] CHECK CONSTRAINT [FK_SemestreGrAsignatura_GrAsignatura]
GO
ALTER TABLE [dbo].[tblSemestreGrAsignatura]  WITH CHECK ADD  CONSTRAINT [FK_SemestreGrAsignatura_Semestre] FOREIGN KEY([idSemestre])
REFERENCES [dbo].[tblSemestre] ([idSemestre])
GO
ALTER TABLE [dbo].[tblSemestreGrAsignatura] CHECK CONSTRAINT [FK_SemestreGrAsignatura_Semestre]
GO
ALTER TABLE [dbo].[tblSemestreTpDocente]  WITH CHECK ADD FOREIGN KEY([idDocente])
REFERENCES [dbo].[tblDocente] ([idDocente])
GO
ALTER TABLE [dbo].[tblSemestreTpDocente]  WITH CHECK ADD FOREIGN KEY([idSemestre])
REFERENCES [dbo].[tblSemestre] ([idSemestre])
GO
ALTER TABLE [dbo].[tblSemestreTpDocente]  WITH CHECK ADD FOREIGN KEY([idTipoDoc])
REFERENCES [dbo].[tblTipoDocente] ([idTipoDocente])
GO
ALTER TABLE [dbo].[tblTipoDocenteSemestre]  WITH CHECK ADD  CONSTRAINT [FK_TipoDocenteSemestre_Semestre] FOREIGN KEY([idSemestre])
REFERENCES [dbo].[tblSemestre] ([idSemestre])
GO
ALTER TABLE [dbo].[tblTipoDocenteSemestre] CHECK CONSTRAINT [FK_TipoDocenteSemestre_Semestre]
GO
ALTER TABLE [dbo].[tblTipoDocenteSemestre]  WITH CHECK ADD  CONSTRAINT [FK_TipoDocenteSemestre_TipoDocente] FOREIGN KEY([idTipoDocente])
REFERENCES [dbo].[tblTipoDocente] ([idTipoDocente])
GO
ALTER TABLE [dbo].[tblTipoDocenteSemestre] CHECK CONSTRAINT [FK_TipoDocenteSemestre_TipoDocente]
GO
/****** Object:  StoredProcedure [dbo].[CopiarAllCargasAcademicasConNuevoSemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--test--
--exec CopiarAllCargasAcademicasConNuevoSemestre 2, 4
---
-- Stored Procedure to copy ALL data from other semester to another semester
CREATE   PROCEDURE [dbo].[CopiarAllCargasAcademicasConNuevoSemestre]
    @idSemestreExistente int,
    @idSemestreNuevo int
AS
BEGIN
    -- Insertar las nuevas cargas académicas con el semestre especificado
    INSERT INTO tblCargaHoraria (idDocente, idSemestre)
    SELECT idDocente, @idSemestreNuevo
    FROM tblCargaHoraria
    WHERE idSemestre = @idSemestreExistente;

    -- Obtener los ID de las nuevas cargas académicas insertadas
    DECLARE @idCargaAcademicaExistente int;
    DECLARE @idCargaAcademicaNueva int;
    SET @idCargaAcademicaExistente = (SELECT MIN(idCargaHoraria) FROM tblCargaHoraria WHERE idSemestre = @idSemestreExistente);
    SET @idCargaAcademicaNueva = (SELECT MAX(idCargaHoraria) FROM tblCargaHoraria WHERE idSemestre = @idSemestreNuevo);

    -- Copiar las asignaturas de las cargas académicas existentes a las nuevas cargas académicas
    INSERT INTO tblAsigCrgHoraria (idCrgHoraria, idGrAsig, estadoAsigCrgDocencia)
    SELECT @idCargaAcademicaNueva, idGrAsig, estadoAsigCrgDocencia
    FROM tblAsigCrgHoraria
    WHERE idCrgHoraria = @idCargaAcademicaExistente;

    -- Copiar las actividades de las cargas académicas existentes a las nuevas cargas académicas
    INSERT INTO tblActividadCargas (idCrgHoraria, idActividad, horasSemana, horaTotal, estadoActivCrgDocencia)
    SELECT @idCargaAcademicaNueva, idActividad, horasSemana, horaTotal, estadoActivCrgDocencia
    FROM tblActividadCargas
    WHERE idCrgHoraria = @idCargaAcademicaExistente;

    -- Copiar las horas exigibles de los docentes al nuevo semestre
    INSERT INTO tblSemestreTpDocente (idTipoDoc, idSemestre, idDocente, numHorasSemestrales, estadoSemestreDoc)
    SELECT idTipoDoc, @idSemestreNuevo, idDocente, numHorasSemestrales, estadoSemestreDoc
    FROM tblSemestreTpDocente
    WHERE idSemestre = @idSemestreExistente;
END
GO
/****** Object:  StoredProcedure [dbo].[spActivityValidation]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--TEST
--select * from tblTipoDocente
--select * from tblSemestre
--select * from tblSemestreTpDocente

--exec spAddDocentesToTypeDocente 1,1,144
-----------------------------------------
-- Validation Stored Procedures
-----------------------------------------
-- SP to validate if activity exists in an specific academic Load
CREATE   PROCEDURE [dbo].[spActivityValidation]
@idCrgHoraria int,
@actividadName varchar(255)
AS
BEGIN 
	SELECT COUNT(*) FROM tblActividadCargas ac
	INNER JOIN tblActividad a ON ac.idActividad = a.idActividad
	WHERE (a.nombreActividad = @actividadName AND ac.idCrgHoraria = @idCrgHoraria)
END
GO
/****** Object:  StoredProcedure [dbo].[spAddActCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblActividadCargas"
CREATE PROCEDURE [dbo].[spAddActCrgHoraria]
	@idCrgH int,
	@idAct int,
	@hSemana int,
	@hTotal int
AS
	BEGIN 
		INSERT INTO tblActividadCargas(idCrgHoraria,idActividad,horasSemana, horaTotal,estadoActivCrgDocencia)
		VALUES(@idCrgH, @idAct,@hSemana, @hTotal,1)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblActividad"
CREATE   PROCEDURE [dbo].[spAddActividad]
	@idTpAct int,
	@idProyecto int,
	@nameAct varchar(255),
	@horasAct int,
	@horasTAct int
AS
	BEGIN 
		IF @idProyecto = 0
        SET @idProyecto = NULL;
		INSERT INTO tblActividad(idTpAct_f,idProyecto_f,nombreActividad,cantHoraSemana,cantHoraTotal, estadoActividad)
		VALUES(@idTpAct,@idProyecto, @nameAct, @horasAct,@horasTAct,1)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddAsigCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblAsigCrgHoraria"
CREATE PROCEDURE [dbo].[spAddAsigCrgHoraria]
	@idCrgH int,
	@idGrAsig int
AS
	BEGIN 
		INSERT INTO tblAsigCrgHoraria(idCrgHoraria,idGrAsig,estadoAsigCrgDocencia)
		VALUES(@idCrgH, @idGrAsig,1)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblAsignatura"
CREATE   PROCEDURE [dbo].[spAddAsignatura]
	@idCarrera int,
	@nameAsig varchar(255),
	@tpAsig varchar(255),
	@codAsig varchar(255),
	@hAsigTot int,
	@hAsigSem int,
	@lvlAsig varchar(255)
AS
	BEGIN 
		INSERT INTO tblAsignatura(idCarrera,nombreAsignatura,tipoAsignatura,codigoAsignatura, horasAsignaturaTotales,
		horasAsignaturaSemanales,nivelAsignatura,estadoAsignatura)
		VALUES(@idCarrera, @nameAsig, @tpAsig, @codAsig, @hAsigTot,@hAsigSem,@lvlAsig,1)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblCargaHoraria"
CREATE PROCEDURE [dbo].[spAddCargaHoraria]
	@idDocent int,
	@idSemestr int
AS
	BEGIN 
		INSERT INTO tblCargaHoraria(idDocente,idSemestre)
		VALUES(@idDocent, @idSemestr)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddCarrera]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblCarrera"
CREATE   PROCEDURE [dbo].[spAddCarrera]
	@idDepa int,
	@nameCarreer varchar(255),
	@codCarrer varchar(50),
	@pensum varchar(255)
AS
	BEGIN 
		INSERT INTO tblCarrera(idDep,nombreCarrera,codigoCarrera, pensum,estadoCarrera)
		VALUES( @idDepa, @nameCarreer, @codCarrer,@pensum,1)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddDepartamento]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----------------------------------------
-- CREATION STORED PROCEDURES  SECTION
----------------------------------------
-- Stored Procedure to create one row from  "tblDepartamento"
CREATE PROCEDURE [dbo].[spAddDepartamento]
-- EXEC spAddDepartamento 'DETRI', 'detri@epn.edu.ec';
	@nameDepa varchar(50),
	@emailDepa varchar(50)
AS
	BEGIN 
		INSERT INTO tblDepartamento(nombreDepartamento,emailDepartamento)
		VALUES( @nameDepa, @emailDepa)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblDocente"
CREATE PROCEDURE [dbo].[spAddDocente]
	@idDepa	int,
	@name1 varchar(255),
	@name2 varchar(255),
	@apellido1 varchar(255),
	@apellido2 varchar(255),
	@tituloDoc varchar(255),
	@email varchar(50)
AS
	BEGIN 
		INSERT INTO tblDocente(idDepa,nombre1Docente,nombre2Docente,
		apellido1Docente,apellido2Docente,tituloDocente,emailDocente, estadoDocente)
		VALUES(@idDepa,@name1,@name2,@apellido1,@apellido2,@tituloDoc,@email,1)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddDocentesToTypeDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Add multiple   "tblSemestreTpDocente"
CREATE   PROCEDURE [dbo].[spAddDocentesToTypeDocente]
	@idTpDocente int,
	@idSmstr int,
	@numHSemstre int
AS
BEGIN
    DECLARE @total_registros INT
    DECLARE @indice INT
    SET @indice = 1
    
    SELECT @total_registros = COUNT(*) FROM tblDocente
    
    WHILE @indice <= @total_registros
    BEGIN
        INSERT INTO tblSemestreTpDocente (idTipoDoc,idSemestre,idDocente,numHorasSemestrales, estadoSemestreDoc) 
		VALUES (@idTpDocente, @idSmstr,@indice, @numHSemstre,1)
        SET @indice = @indice + 1
    END
END
GO
/****** Object:  StoredProcedure [dbo].[spAddGrAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblGrAsignatura"
CREATE PROCEDURE [dbo].[spAddGrAsignatura]
	@idAsig int,
	@Gr varchar(20)
AS
	BEGIN 
		INSERT INTO tblGrAsignatura(idAsignatura,grupoAsignatura)
		VALUES(@idAsig,@Gr)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddGrAsignaturaOut]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP to create one row from tblGrAsignatura and get those id row
CREATE   PROCEDURE [dbo].[spAddGrAsignaturaOut]
	@idAsig int,
	@Gr varchar(20),
	@InsertedID int OUTPUT
AS
BEGIN 
	-- Verificar si ya existe un registro con el mismo grupoAsignatura
    IF EXISTS (SELECT 1 FROM tblGrAsignatura WHERE grupoAsignatura = @Gr AND idAsignatura = @idAsig)
    BEGIN
        SELECT @InsertedID = idGrAsig FROM tblGrAsignatura WHERE grupoAsignatura = @Gr AND idAsignatura = @idAsig; -- Indicar que ya existe un registro con el mismo grupoAsignatura
        RETURN; -- Salir del procedimiento sin realizar la inserción
    END

	INSERT INTO tblGrAsignatura(idAsignatura, grupoAsignatura)
	VALUES (@idAsig, @Gr);

	SET @InsertedID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spAddHorarioAsig]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from "tblHorarioGrAsig"
CREATE   PROCEDURE [dbo].[spAddHorarioAsig]
    @idSemestre int,
    @idGrAsig	int,
    @horaInicio time,
    @horaFin	time,
    @dia		int	,
    @resultado	bit OUTPUT
AS
BEGIN
    DECLARE @idSemestreGrAsignatura int
	DECLARE @idHorario int
    SET @resultado = 0 -- Inicializar con valor "False" (Error)
	
	---------------------------------------------------------
	-- Verificar si hay conflicto de horario
	IF NOT EXISTS (
		SELECT 1
		FROM tblHorarioGrAsig HGA
		INNER JOIN tblSemestreGrAsignatura SGA ON HGA.idSemestreGrAsignatura = SGA.idSemestreGrAsignatura
		WHERE SGA.idGrAsig = @idGrAsig AND HGA.isActive = 1
			AND idDiaSemana = @dia
			AND (
				(@horaInicio >= horaInicio AND @horaInicio < horaFin) OR
				(@horaFin > horaInicio AND @horaFin <= horaFin) OR
				(@horaInicio <= horaInicio AND @horaFin >= horaFin)
			)
	)
	BEGIN
		-- Verificar si ya existe un registro con el mismo idSemestre e idGrAsig
		SELECT @idSemestreGrAsignatura = idSemestreGrAsignatura
		FROM tblSemestreGrAsignatura
		WHERE idSemestre = @idSemestre AND idGrAsig = @idGrAsig

		IF @idSemestreGrAsignatura IS NULL
		BEGIN
			-- Insertar en tblSemestreGrAsignatura solo si no existe
			INSERT INTO tblSemestreGrAsignatura (idSemestre, idGrAsig, isActive)
			VALUES (@idSemestre, @idGrAsig, 1)
        
			SET @idSemestreGrAsignatura = SCOPE_IDENTITY() -- Obtener el ID recién insertado

			-- Insertar en tblHorarioGrAsig usando el ID de tblSemestreGrAsignatura
			INSERT INTO tblHorarioGrAsig (idSemestreGrAsignatura, horaInicio, horaFin, idDiaSemana, isActive)
			VALUES (@idSemestreGrAsignatura, @horaInicio, @horaFin, @dia, 1)
		END
		ELSE
        BEGIN
			SELECT @idHorario = idHorario
			FROM tblHorarioGrAsig
			WHERE idSemestreGrAsignatura = @idSemestreGrAsignatura AND idDiaSemana = @dia

			IF @idHorario IS NULL
			BEGIN
				INSERT INTO tblHorarioGrAsig (idSemestreGrAsignatura, horaInicio, horaFin, idDiaSemana, isActive)
				VALUES (@idSemestreGrAsignatura, @horaInicio, @horaFin, @dia, 1)
			END
			ELSE
			BEGIN
				-- Actualizar en tblHorarioGrAsig usando el ID de tblSemestreGrAsignatura
				UPDATE tblHorarioGrAsig
				SET horaInicio = @horaInicio,
					horaFin = @horaFin
					--,idDiaSemana = @dia
				WHERE idSemestreGrAsignatura = @idSemestreGrAsignatura
					AND isActive = 1 AND idHorario = @idHorario
			END
        END

		SET @resultado = 1 -- Cambiar a valor "True" (Éxito)
	END
	ELSE
	BEGIN
		SET @resultado = 0 -- Mantener valor "False" (Error)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAddHorarioAsigNoOut]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from "tblHorarioGrAsig"
CREATE   PROCEDURE [dbo].[spAddHorarioAsigNoOut]
    @idSemestre int,
    @idGrAsig	int,
    @horaInicio time,
    @horaFin	time,
    @dia		int	
AS
BEGIN
    DECLARE @idSemestreGrAsignatura int
	DECLARE @idHorario int
	
	---------------------------------------------------------
	-- Verificar si hay conflicto de horario
	IF NOT EXISTS (
		SELECT 1
		FROM tblHorarioGrAsig HGA
		INNER JOIN tblSemestreGrAsignatura SGA ON HGA.idSemestreGrAsignatura = SGA.idSemestreGrAsignatura
		WHERE SGA.idGrAsig = @idGrAsig AND HGA.isActive = 1
			AND idDiaSemana = @dia
			AND (
				(@horaInicio >= horaInicio AND @horaInicio < horaFin) OR
				(@horaFin > horaInicio AND @horaFin <= horaFin) OR
				(@horaInicio <= horaInicio AND @horaFin >= horaFin)
			)
	)
	BEGIN
		-- Verificar si ya existe un registro con el mismo idSemestre e idGrAsig
		SELECT @idSemestreGrAsignatura = idSemestreGrAsignatura
		FROM tblSemestreGrAsignatura
		WHERE idSemestre = @idSemestre AND idGrAsig = @idGrAsig

		IF @idSemestreGrAsignatura IS NULL
		BEGIN
			-- Insertar en tblSemestreGrAsignatura solo si no existe
			INSERT INTO tblSemestreGrAsignatura (idSemestre, idGrAsig, isActive)
			VALUES (@idSemestre, @idGrAsig, 1)
        
			SET @idSemestreGrAsignatura = SCOPE_IDENTITY() -- Obtener el ID recién insertado

			-- Insertar en tblHorarioGrAsig usando el ID de tblSemestreGrAsignatura
			INSERT INTO tblHorarioGrAsig (idSemestreGrAsignatura, horaInicio, horaFin, idDiaSemana, isActive)
			VALUES (@idSemestreGrAsignatura, @horaInicio, @horaFin, @dia, 1)
		END
		ELSE
        BEGIN
			SELECT @idHorario = idHorario
			FROM tblHorarioGrAsig
			WHERE idSemestreGrAsignatura = @idSemestreGrAsignatura AND idDiaSemana = @dia

			IF @idHorario IS NULL
			BEGIN
				INSERT INTO tblHorarioGrAsig (idSemestreGrAsignatura, horaInicio, horaFin, idDiaSemana, isActive)
				VALUES (@idSemestreGrAsignatura, @horaInicio, @horaFin, @dia, 1)
			END
			ELSE
			BEGIN
				-- Actualizar en tblHorarioGrAsig usando el ID de tblSemestreGrAsignatura
				UPDATE tblHorarioGrAsig
				SET horaInicio = @horaInicio,
					horaFin = @horaFin
					--,idDiaSemana = @dia
				WHERE idSemestreGrAsignatura = @idSemestreGrAsignatura
					AND isActive = 1 AND idHorario = @idHorario
			END
        END

		--SET @resultado = 1 -- Cambiar a valor "True" (Éxito)
	END
	--ELSE
	--BEGIN
	--	SET @resultado = 0 -- Mantener valor "False" (Error)
	--END
END
---------------------------------------------------------
GO
/****** Object:  StoredProcedure [dbo].[spAddOrUpdateSemestreAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- Stored Procedure to create or update one row into  "tblSemestreAsignatura"
CREATE   PROCEDURE [dbo].[spAddOrUpdateSemestreAsignatura]
	@idSemestre int,
	@idAsignatura int,
	@state bit
AS
	BEGIN 
		IF EXISTS(SELECT idSemestreAsignatura FROM tblSemestreAsignatura WHERE idSemestre = @idSemestre AND idAsignatura = @idAsignatura)
		BEGIN
			UPDATE tblSemestreAsignatura
			SET isActive = @state
			WHERE idSemestre = @idSemestre AND idAsignatura = @idAsignatura
		END
		ELSE
		BEGIN
			INSERT INTO tblSemestreAsignatura (idSemestre, idAsignatura,isActive)
			VALUES (@idSemestre, @idAsignatura, @state)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddOrUpdateSemestreTpDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblAsigCarrera"
--CREATE PROCEDURE [dbo].[spAddAsigCarrera]
--	@idCarrera int,
--	@idAsig int,
--	@state bit
--AS
--	BEGIN 
--		INSERT INTO tblAsigCarrera(idCarrera,idAsignatura,estadoAsigCarrera)
--		VALUES(@idCarrera,@idAsig,@state)
--	END
--GO
---- Stored Procedure to create one row into  "tblSemestreDocente"
CREATE   PROCEDURE [dbo].[spAddOrUpdateSemestreTpDocente]
	@idSemestre int,
	@idDocente int,
	@idTpDocente int,
	@numHoras int,
	@state bit
AS
	BEGIN 
		IF EXISTS(SELECT idSemestreTpDoc FROM tblSemestreTpDocente WHERE idSemestre = @idSemestre AND idDocente = @idDocente)
		BEGIN
			UPDATE tblSemestreTpDocente
			SET estadoSemestreDoc = @state,
				idTipoDoc = @idTpDocente, numHorasSemestrales = @numHoras
			WHERE idSemestre = @idSemestre AND idDocente = @idDocente
		END
		ELSE
		BEGIN
			INSERT INTO tblSemestreTpDocente (idTipoDoc,idSemestre, idDocente, numHorasSemestrales,estadoSemestreDoc)
			VALUES (@idTpDocente,@idSemestre, @idDocente, @numHoras, @state)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddProyecto]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--STored Procedute to create Proyectos
CREATE PROCEDURE [dbo].[spAddProyecto]
    @codigoProyecto varchar(50),
    @nombreProyecto varchar(255),
    @fechaInicio date,
    @fechaFin date,
    @presupuesto decimal(18, 2),
    @tipoProyecto varchar(255),
    @urlAval nvarchar(max)
AS
BEGIN
    INSERT INTO tblProyecto (codigoProyecto, nombreProyecto, fechaInicio, fechaFin, presupuesto, tipoProyecto, urlAval, estadoProyecto)
    VALUES (@codigoProyecto, @nombreProyecto, @fechaInicio, @fechaFin, @presupuesto, @tipoProyecto, @urlAval,1);
END;
GO
/****** Object:  StoredProcedure [dbo].[spAddSemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec spAddSemestre '2023A',2023,'lunes,30 de enero 2023','2023-05-02',16,20,1
--exec spReadAllSemestres
-- Stored Procedure to create one row from  "tblSemestre"
CREATE   PROCEDURE [dbo].[spAddSemestre]
	@codSmstr	varchar(50),
	@yrSmstr int,
	@dIni date,
	@dFin date,
	@nSemanaClase int,
	@nSemanaSemestre int
AS
	BEGIN 
		INSERT INTO tblSemestre(codigoSemestre,añoSemestre,diaInicio, diaFin,
		numSemanasClase,numSemanasSemestre,estadoSemestre)
		VALUES(@codSmstr, @yrSmstr, @dIni, @dFin, @nSemanaClase, @nSemanaSemestre, 1)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddSemestreTpDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblSemestreTpDocente"
CREATE PROCEDURE [dbo].[spAddSemestreTpDocente]
	@idTpDocente int,
	@idSmstr int,
	@idDocente int,
	@numHSemstre int
AS
	BEGIN 
		INSERT INTO tblSemestreTpDocente(idTipoDoc,idSemestre,idDocente,numHorasSemestrales, estadoSemestreDoc)
		VALUES(@idTpDocente, @idSmstr,@idDocente, @numHSemstre,1)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddTipoActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblTipoActividad"
CREATE PROCEDURE [dbo].[spAddTipoActividad]
	@nameTpActiv varchar(255),
	@descripActividad	varchar(255)
AS
	BEGIN 
		INSERT INTO tblTipoActividad(nombreTpAct,descripcionTpAct)
		VALUES(@nameTpActiv, @descripActividad)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddTipoDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from  "tblTipoDocente"
CREATE PROCEDURE [dbo].[spAddTipoDocente]
	@nameTP varchar(255),
	@numHorasSem int
AS
	BEGIN 
		INSERT INTO tblTipoDocente(nombreTipoDocente,numHorasSemestrales, estadoTipoDocente)
		VALUES(@nameTP,@numHorasSem, 1)
	END
GO
/****** Object:  StoredProcedure [dbo].[spAddTipoDocenteSemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row in "tblTipoDocenteSemestre"
-- Stored Procedure to insert or update a row in "tblTipoDocenteSemestre"
CREATE PROCEDURE [dbo].[spAddTipoDocenteSemestre]
--test
--EXEC spAddTipoDocenteSemestre 1, 1, 440; -- Ejemplo: Tipo de docente 1, Semestre 1, 40 horas
	@idTipoDocente int,
	@idSemestre int,
	@numHorasSemestrales int
AS
BEGIN 
	MERGE tblTipoDocenteSemestre AS target
	USING (SELECT @idTipoDocente AS idTipoDocente, @idSemestre AS idSemestre) AS source
	ON (target.idTipoDocente = source.idTipoDocente AND target.idSemestre = source.idSemestre)
	WHEN MATCHED THEN
		UPDATE SET numHorasSemestrales = @numHorasSemestrales
	WHEN NOT MATCHED THEN
		INSERT (idTipoDocente, idSemestre, numHorasSemestrales)
		VALUES (@idTipoDocente, @idSemestre, @numHorasSemestrales);
END
GO
/****** Object:  StoredProcedure [dbo].[spAsignatureValidation]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SP to validate if asignature exists in an specific academic Load
CREATE   PROCEDURE [dbo].[spAsignatureValidation]
@idCrgHoraria int,
@asignatureName varchar(255),
@Gr varchar(30)
AS
BEGIN 
	SELECT COUNT(*) 
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig  on gr.idAsignatura = asig.idAsignatura
	WHERE (asig.nombreAsignatura = @asignatureName AND interAsig.idCrgHoraria = @idCrgHoraria AND gr.grupoAsignatura = @Gr)
END
GO
/****** Object:  StoredProcedure [dbo].[spCheckExCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [spGetIdCargaHoraria] 1,2
-- Stored Procedure to check an existing CargaHoraria register
CREATE PROCEDURE [dbo].[spCheckExCargaHoraria]
@idDocente int,
@idSemestre int
AS
BEGIN 
	SELECT count(idCargaHoraria) AS ID
	FROM tblCargaHoraria
	WHERE (idSemestre = @idSemestre AND idDocente= @idDocente)
END
GO
/****** Object:  StoredProcedure [dbo].[spCheckHorasExDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to check if Docente has  horas exigibles
CREATE PROCEDURE [dbo].[spCheckHorasExDocente]
@idDocente int,
@idSemestre int
AS
BEGIN 
	SELECT COALESCE((SELECT numHorasSemestrales FROM tblSemestreTpDocente WHERE idSemestre = @idSemestre AND idDocente = @idDocente), -1)
	AS HorasSemestrales;
END
GO
/****** Object:  StoredProcedure [dbo].[spCheckHorasExDocenteByIdCrgH]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to check if Docente has  horas exigibles
CREATE PROCEDURE [dbo].[spCheckHorasExDocenteByIdCrgH]
@idCarga int
AS
BEGIN 
	SELECT stp.numHorasSemestrales
	FROM tblSemestreTpDocente stp
	INNER JOIN tblSemestre s ON stp.idSemestre = s.idSemestre
	INNER JOIN tblCargaHoraria cg ON s.idSemestre = cg.idSemestre
	WHERE cg.idCargaHoraria = @idCarga
END
GO
/****** Object:  StoredProcedure [dbo].[spCopiarRegistrosHorasExigibles]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to copy data from other semester to another semester into "tblSemestreTpDocente"
CREATE   PROCEDURE [dbo].[spCopiarRegistrosHorasExigibles]
    @idSemestreActual int,
    @idNuevoSemestre int
AS
BEGIN
    INSERT INTO tblSemestreTpDocente (idTipoDoc, idSemestre, idDocente, numHorasSemestrales, estadoSemestreDoc)
    SELECT idTipoDoc, @idNuevoSemestre, idDocente, numHorasSemestrales, estadoSemestreDoc
    FROM tblSemestreTpDocente
    WHERE idSemestre = @idSemestreActual
END
GO
/****** Object:  StoredProcedure [dbo].[spCopySemestreCargas]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[spCopySemestreCargas]
    @idSemestreExistente INT,
    @idSemestreNuevo INT,
    @CopiaExitosa BIT OUTPUT
AS
BEGIN
    --SET NOCOUNT ON;
    DECLARE @TransactionName NVARCHAR(20) = 'CopySemestreCargasData';

    BEGIN TRY
        BEGIN TRANSACTION @TransactionName;

		INSERT INTO tblCargaHoraria(idDocente, idSemestre)
		SELECT idDocente,@idSemestreNuevo
		FROM tblCargaHoraria
		WHERE idSemestre = @idSemestreExistente;

		-- Eliminar registros existentes en tblSemestreTpDocente creados por defecto por el trigger para el nuevo semestre
		DELETE FROM tblSemestreTpDocente
		WHERE idSemestre = @idSemestreNuevo

		INSERT INTO tblSemestreTpDocente(idTipoDoc, idSemestre, idDocente, numHorasSemestrales, estadoSemestreDoc)
		SELECT idTipoDoc,@idSemestreNuevo, idDocente, numHorasSemestrales, estadoSemestreDoc
		FROM tblSemestreTpDocente
		WHERE idSemestre = @idSemestreExistente;

		DELETE FROM tblSemestreAsignatura
		WHERE idSemestre = @idSemestreNuevo

		INSERT INTO tblSemestreAsignatura(idSemestre, idAsignatura, isActive)
		SELECT @idSemestreNuevo, idAsignatura, isActive
		FROM tblSemestreAsignatura
		WHERE idSemestre = @idSemestreExistente;

		INSERT INTO tblAsigCrgHoraria(idCrgHoraria, idGrAsig, estadoAsigCrgDocencia)
		SELECT new_t1.idCargaHoraria, t2.idGrAsig, t2.estadoAsigCrgDocencia
		FROM tblCargaHoraria AS t1
		JOIN tblCargaHoraria AS new_t1 ON t1.idSemestre = @idSemestreExistente AND new_t1.idSemestre = @idSemestreNuevo AND t1.idDocente = new_t1.idDocente -- Aquí se igualan los idDocnete también
		JOIN tblAsigCrgHoraria AS t2 ON t1.idCargaHoraria = t2.idCrgHoraria
		WHERE t1.idSemestre = @idSemestreExistente;

		-- Eliminar registros existentes en tblActividadCargas para el nuevo semestre
		DELETE FROM tblActividadCargas
		WHERE idCrgHoraria IN (
			SELECT new_t1.idCargaHoraria
			FROM tblCargaHoraria AS t1
			JOIN tblCargaHoraria AS new_t1 ON t1.idSemestre = @idSemestreExistente AND new_t1.idSemestre = @idSemestreNuevo AND t1.idDocente = new_t1.idDocente
			WHERE t1.idSemestre = @idSemestreExistente
		);

		INSERT INTO tblActividadCargas(idCrgHoraria, idActividad, horasSemana, horaTotal, estadoActivCrgDocencia)
		SELECT new_t1.idCargaHoraria, t2.idActividad, t2.horasSemana, t2.horaTotal, t2.estadoActivCrgDocencia
		FROM tblCargaHoraria AS t1
		JOIN tblCargaHoraria AS new_t1 ON t1.idSemestre = @idSemestreExistente AND new_t1.idSemestre = @idSemestreNuevo AND t1.idDocente = new_t1.idDocente -- Aquí se igualan los idDocnete también
		JOIN tblActividadCargas AS t2 ON t1.idCargaHoraria = t2.idCrgHoraria
		WHERE t1.idSemestre = @idSemestreExistente;


        -- Commit la transacción si todo se realizó exitosamente
        SET @CopiaExitosa = 1;
        COMMIT TRANSACTION @TransactionName;
    END TRY
    BEGIN CATCH
        -- Rollback en caso de error
        SET @CopiaExitosa = 0;
        ROLLBACK TRANSACTION @TransactionName;
		PRINT 'Error in transaction ' + @TransactionName + ': ' + ERROR_MESSAGE();
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spCopySemestreHorarios]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[spCopySemestreHorarios]
    @idSemestreExistente INT,
    @idSemestreNuevo INT,
    @CopiaExitosa BIT OUTPUT
AS
BEGIN
    --SET NOCOUNT ON;
    DECLARE @TransactionName NVARCHAR(20) = 'CopySemestreData';

    BEGIN TRY
        BEGIN TRANSACTION @TransactionName;

		INSERT INTO tblSemestreGrAsignatura (idSemestre, idGrAsig, isActive)
		SELECT @idSemestreNuevo, idGrAsig, isActive
		FROM tblSemestreGrAsignatura
		WHERE idSemestre = @idSemestreExistente;

		INSERT INTO tblHorarioGrAsig(idSemestreGrAsignatura, horaInicio, horaFin, idDiaSemana, isActive)
		SELECT new_t1.idSemestreGrAsignatura, t2.horaInicio, t2.horaFin, t2.idDiaSemana, t2.isActive
		FROM tblSemestreGrAsignatura AS t1
		JOIN tblSemestreGrAsignatura AS new_t1 ON t1.idSemestre = @idSemestreExistente AND new_t1.idSemestre = @idSemestreNuevo AND t1.idGrAsig = new_t1.idGrAsig -- Aquí se igualan los idGrAsig también
		JOIN tblHorarioGrAsig AS t2 ON t1.idSemestreGrAsignatura = t2.idSemestreGrAsignatura
		WHERE t1.idSemestre = @idSemestreExistente;

        -- Commit la transacción si todo se realizó exitosamente
        SET @CopiaExitosa = 1;
        COMMIT TRANSACTION @TransactionName;
    END TRY
    BEGIN CATCH
        -- Rollback en caso de error
        SET @CopiaExitosa = 0;
        ROLLBACK TRANSACTION @TransactionName;
		PRINT 'Error in transaction ' + @TransactionName + ': ' + ERROR_MESSAGE();
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spDeleteActivCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblActividadCargas"
CREATE PROCEDURE [dbo].[spDeleteActivCrgHoraria]
	@id int
AS
	BEGIN 
		DELETE FROM tblActividadCargas 
		WHERE idActivCrgs = @id
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblActividad"
CREATE PROCEDURE [dbo].[spDeleteActividad]
	@id int
AS
	BEGIN
		DELETE FROM tblActividad 
		WHERE idActividad = @id
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAsigCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblAsigCrgHoraria"
CREATE PROCEDURE [dbo].[spDeleteAsigCrgHoraria]
	@id int
AS
	BEGIN 
		DELETE FROM tblAsigCrgHoraria WHERE idAsigCrgHoraria = @id
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblAsignatura"
CREATE   PROCEDURE [dbo].[spDeleteAsignatura]
	@id int
AS
	BEGIN 
		UPDATE tblAsignatura
		SET estadoAsignatura = 0
		WHERE idAsignatura = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblCargaHoraria"
CREATE   PROCEDURE [dbo].[spDeleteCargaHoraria]
	@id int
AS
	BEGIN
		BEGIN TRANSACTION;

		-- Eliminar registros relacionados en tblActividadCargas
		DELETE FROM tblActividadCargas WHERE idCrgHoraria = @id;
		-- Eliminar registros relacionados en tblAsigCarga
		DELETE FROM tblAsigCrgHoraria WHERE idCrgHoraria = @id;

		-- Eliminar el registro de tblCargaHoraria
		DELETE FROM tblCargaHoraria WHERE idCargaHoraria = @id;

		COMMIT;
		END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCarrera]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblCarrera"
CREATE PROCEDURE [dbo].[spDeleteCarrera]
	@id	int
AS
	BEGIN
		DELETE FROM tblCarrera 
		WHERE idCarrera = @id 
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteDepartamento]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------
-- DELETING PROCEDURES 
---------------------------------
-- Stored Procedure to delete one row from  "tblDepartamento"
CREATE   PROCEDURE [dbo].[spDeleteDepartamento]
	@id int,
	@nameDepa varchar(50),
	@emailDepa varchar(50)
AS
	BEGIN 
		DELETE tblDepartamento 
		WHERE (idDepartamento = @id)
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblDocente"
CREATE PROCEDURE [dbo].[spDeleteDocente]
	@id	int
AS
	BEGIN
		UPDATE tblDocente
		SET estadoDocente = 0
		WHERE idDocente = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteGrAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblAsigCarrera"
--CREATE PROCEDURE [dbo].[spDeleteAsigCarrera]
--	@idCarrera int,
--	@idAsig int,
--	@state bit
--AS
--	BEGIN 
--		INSERT INTO tblAsigCarrera(idCarrera,idAsignatura,estadoAsigCarrera)
--		VALUES(@idCarrera,@idAsig,@state)
--		DELETE FROM tblAsigCarrera 
--		WHERE (idCarrera = @idCarrera AND idAsignatura = @idAsig AND estadoAsigCarrera = @state)
--	END
--GO
-- Stored Procedure to delete one row from  "tblGrAsignatura" using idAsingnatura
CREATE PROCEDURE [dbo].[spDeleteGrAsignatura]
	@id int
AS
	BEGIN
		DELETE FROM tblGrAsignatura 
		WHERE (idGrAsig = @id)
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteGrAsignaturaName]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblGrAsignatura" using Asignatura name
CREATE PROCEDURE [dbo].[spDeleteGrAsignaturaName]
	@nameAsignatura varchar(150),
	@Gr varchar(20)
AS
	BEGIN
		DELETE GR
		FROM tblGrAsignatura GR
		LEFT JOIN tblAsignatura ASG ON GR.idAsignatura = GR.idAsignatura
		WHERE (ASG.nombreAsignatura = @nameAsignatura AND 
				GR.grupoAsignatura = @Gr)
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteHorarioAsig]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblHorarioGrAsig"
CREATE PROCEDURE [dbo].[spDeleteHorarioAsig]
	@id int
AS
	BEGIN
		UPDATE tblHorarioGrAsig
		SET isActive = 0
		WHERE idHorario = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteProyecto]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SP to disable proyecto from tblProyectos
CREATE PROCEDURE [dbo].[spDeleteProyecto]
    @idProyecto int
AS
BEGIN
    UPDATE tblProyecto
    SET estadoProyecto = 0
    WHERE idProyecto = @idProyecto;
END;
GO
/****** Object:  StoredProcedure [dbo].[spDeleteSemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblSemestre"
CREATE PROCEDURE [dbo].[spDeleteSemestre]
	@id int
AS
	BEGIN
		--DELETE FROM tblSemestre 
		--WHERE idSemestre = @id
		UPDATE tblSemestre
		SET 
			estadoSemestre = 0
		WHERE idSemestre = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteSemestreTpDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblSemestreTpDocente"
CREATE PROCEDURE [dbo].[spDeleteSemestreTpDocente]
	@id int
AS
	BEGIN
		DELETE FROM tblSemestreTpDocente 
		WHERE idSemestreTpDoc = @id
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteTipoActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblTipoActividad"
CREATE PROCEDURE [dbo].[spDeleteTipoActividad]
	@id int,
	@nameTpActiv varchar(255),
	@descripActividad	varchar(255)
AS
	BEGIN 
		DELETE FROM tblTipoActividad 
		WHERE (idTpAct = @id)
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteTipoDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to delete one row from  "tblTipoDocente"
CREATE PROCEDURE [dbo].[spDeleteTipoDocente]
	@id int
AS
	BEGIN 
		DELETE FROM tblTipoDocente 
		WHERE idTipoDocente = @id
	END
GO
/****** Object:  StoredProcedure [dbo].[spDocentesById]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tree View 
CREATE PROCEDURE [dbo].[spDocentesById]
	@id int
AS
	BEGIN 
		SELECT idDepa AS ID, CONCAT(apellido1Docente,' ',apellido2Docente,' ',nombre1Docente,' ',nombre2Docente) AS Departamento
		FROM tblDocente WHERE idDepa = @id and estadoDocente = 1
		ORDER BY Departamento ASC
	END
GO
/****** Object:  StoredProcedure [dbo].[spDocentesByIdDepaWHorasExigiblesTV]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tree View Buscar docentes por Id Departamento y que contengan horas exigibles de un determinado semestre
CREATE   PROCEDURE [dbo].[spDocentesByIdDepaWHorasExigiblesTV]
	@idDepa int,
	@idSemestre int
AS
	BEGIN 
		SELECT ID, Docente, codigoSemestre
		FROM (
			SELECT doc.idDocente AS ID, CONCAT(apellido1Docente, ' ', apellido2Docente, ' ', nombre1Docente, ' ', nombre2Docente) AS Docente, sm.codigoSemestre
			FROM tblSemestreTpDocente std
			INNER JOIN tblDocente doc ON std.idDocente = doc.idDocente
			INNER JOIN tblTipoDocente tp ON std.idTipoDoc = tp.idTipoDocente
			INNER JOIN tblSemestre sm ON std.idSemestre = sm.idSemestre
			INNER JOIN tblCargaHoraria ch ON std.idDocente = ch.idDocente
			WHERE ch.idSemestre = @idSemestre AND doc.idDepa = @idDepa and std.idSemestre = @idSemestre and doc.estadoDocente = 1
		) AS subquery
		GROUP BY ID, Docente, codigoSemestre
		ORDER BY Docente ASC
	END
GO
/****** Object:  StoredProcedure [dbo].[spDocentesByIdTV]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tree View 
CREATE PROCEDURE [dbo].[spDocentesByIdTV]
	@id int
AS
	BEGIN 
		SELECT idDocente AS ID, CONCAT(apellido1Docente,' ',apellido2Docente,' ',nombre1Docente,' ',nombre2Docente) AS Docente
		FROM tblDocente WHERE idDepa = @id and estadoDocente = 1
		ORDER BY Docente ASC
	END
GO
/****** Object:  StoredProcedure [dbo].[spGetActividadesComisiones_BySemestre_Reporte]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP TO GET ACTIVIDADES DE COMISIONES G y I DE CARGA HORARIA By SEMESTRE TO REPORT
CREATE   PROCEDURE [dbo].[spGetActividadesComisiones_BySemestre_Reporte]
@idSemestre int
AS
BEGIN 
	SELECT ac.idActivCrgs AS ID, ta.nombreTpAct AS TIPO,a.nombreActividad AS 'ACTIVIDAD'
	, CONCAT(d.apellido1Docente, ' ', d.apellido2Docente, ' ', d.nombre1Docente, ' ', d.nombre2Docente) AS 'DOCENTE ASIGNADO', 
	CAST(
    CASE
        WHEN ac.horasSemana = 0 THEN ac.horaTotal / s.numSemanasClase
        ELSE ac.horasSemana
    END AS INT
) AS 'HORAS SEMANALES',
	(CASE WHEN ac.horaTotal = 0 THEN ac.horasSemana * s.numSemanasClase * 2 WHEN ac.horasSemana = 0 THEN ac.horaTotal  ELSE 0 END) AS 'HORAS TOTALES'
	FROM tblActividadCargas ac
	LEFT JOIN tblCargaHoraria ch ON ac.idCrgHoraria = ch.idCargaHoraria
	INNER JOIN tblActividad a ON ac.idActividad = a.idActividad
	INNER JOIN tblTipoActividad ta ON a.idTpAct_f = ta.idTpAct
	INNER JOIN tblDocente d ON ch.idDocente = d.idDocente
	INNER JOIN tblSemestre s ON ch.idSemestre = s.idSemestre
	WHERE ch.idSemestre = 1--@idSemestre
	AND (a.idTpAct_f = 3 OR a.idTpAct_f = 4)
	ORDER BY TIPO
END
GO
/****** Object:  StoredProcedure [dbo].[spGetActividadesD11D_BySemestre_Reporte]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP TO GET ACTIVIDADES D11 y F11 DE CARGA HORARIA By SEMESTRE TO REPORT
CREATE   PROCEDURE [dbo].[spGetActividadesD11D_BySemestre_Reporte]
@idSemestre int
AS
BEGIN 
	SELECT ac.idActivCrgs AS ID, ta.nombreTpAct AS TIPO,a.nombreActividad AS 'ACTIVIDAD'
	, CONCAT(d.apellido1Docente, ' ', d.apellido2Docente, ' ', d.nombre1Docente, ' ', d.nombre2Docente) AS 'DOCENTE ASIGNADO', 
	(CASE WHEN a.idTpAct_f = 1 THEN ac.horasSemana * s.numSemanasClase * 2 WHEN a.idTpAct_f = 2 THEN ac.horaTotal  ELSE 0 END) AS 'HORAS TOTALES'
	FROM tblActividadCargas ac
	LEFT JOIN tblCargaHoraria ch ON ac.idCrgHoraria = ch.idCargaHoraria
	INNER JOIN tblActividad a ON ac.idActividad = a.idActividad
	INNER JOIN tblTipoActividad ta ON a.idTpAct_f = ta.idTpAct
	INNER JOIN tblDocente d ON ch.idDocente = d.idDocente
	INNER JOIN tblSemestre s ON ch.idSemestre = s.idSemestre
	WHERE ch.idSemestre = @idSemestre
	AND (a.idTpAct_f = 1 OR a.idTpAct_f = 2)
	ORDER BY TIPO
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllHorariosByGRAsig]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to GET all HORARIOS from  "tblHorarioGrAsig" based on idGrAsig and idSemestre
CREATE   PROC [dbo].[spGetAllHorariosByGRAsig]
@idSemestre int,
@idGrAsig   int
AS 
BEGIN 
	DECLARE @idSemestreGrAsignatura int

    SELECT @idSemestreGrAsignatura = SGA.idSemestreGrAsignatura 
    FROM   tblSemestreGrAsignatura   SGA
	WHERE SGA.idGrAsig = @idGrAsig
	AND SGA.idSemestre = @idSemestre
	PRINT(@idSemestreGrAsignatura)
	IF @idSemestreGrAsignatura IS NOT NULL
        BEGIN
            SELECT idDiaSemana, horaInicio, horaFin
			FROM tblHorarioGrAsig HGA
			WHERE idSemestreGrAsignatura = @idSemestreGrAsignatura
        END
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllHorariosByGRAsigViewer]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP TO GET HORARIO TO VIEW
CREATE   PROC [dbo].[spGetAllHorariosByGRAsigViewer]
@idSemestre int,
@idGrAsig   int
AS 
BEGIN 
	DECLARE @idSemestreGrAsignatura int

    SELECT @idSemestreGrAsignatura = SGA.idSemestreGrAsignatura 
    FROM   tblSemestreGrAsignatura   SGA
	WHERE SGA.idGrAsig = @idGrAsig
	AND SGA.idSemestre = @idSemestre
	PRINT(@idSemestreGrAsignatura)
	IF @idSemestreGrAsignatura IS NOT NULL
        BEGIN
            SELECT DD.dia AS 'DÍA DE LA SEMANA',
			ISNULL(CONVERT(VARCHAR(5), horaInicio, 108), 'N/A') AS 'HORA INICIO', 
            ISNULL(CONVERT(VARCHAR(5), horaFin, 108), 'N/A') AS 'HORA FIN', horaInicio, horaFin,DD.dia
			FROM tblHorarioGrAsig HGA
			INNER JOIN tblDiaSemana DD ON HGA.idDiaSemana = DD.idDiaSemana
			WHERE idSemestreGrAsignatura = @idSemestreGrAsignatura AND horaInicio <> horaFin
        END
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAsignaturaGrBySemestreWithDocente_Reporte]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Get Asignaturas with Docente Name from  "tblAsigCrgHoraria"
CREATE   PROCEDURE [dbo].[spGetAsignaturaGrBySemestreWithDocente_Reporte]
	@idSemestre int
AS 
BEGIN 
    SELECT ach.idAsigCrgHoraria AS ID,a.codigoAsignatura AS CÓDIGO,ga.grupoAsignatura AS GRUPO ,a.nombreAsignatura AS ASIGNATURA,a.tipoAsignatura AS TIPO, 
	CONCAT(d.apellido1Docente, ' ', d.apellido2Docente, ' ', d.nombre1Docente, ' ', d.nombre2Docente) AS 'DOCENTE ASIGNADO'
	FROM tblAsigCrgHoraria ach
	LEFT JOIN tblCargaHoraria ch ON ach.idCrgHoraria = ch.idCargaHoraria
	INNER JOIN tblDocente d ON ch.idDocente = d.idDocente
	INNER JOIN tblGrAsignatura ga ON ach.idGrAsig = ga.idGrAsig
	INNER JOIN tblAsignatura a ON ga.idAsignatura = a.idAsignatura
	INNER JOIN tblSemestreAsignatura sa ON a.idAsignatura = sa.idAsignatura
	WHERE sa.isActive = 1 AND sa.idSemestre = @idSemestre
	AND ch.idSemestre = @idSemestre
	ORDER BY ASIGNATURA ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAsignaturaGrBySemestreWithOutDocente_Reporte]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Get Asignaturas without Docente from  "tblAsigCrgHoraria"
CREATE   PROCEDURE [dbo].[spGetAsignaturaGrBySemestreWithOutDocente_Reporte]
	@idSemestre int
AS 
BEGIN 
    SELECT a.idAsignatura AS ID, a.codigoAsignatura AS CÓDIGO, ga.grupoAsignatura AS GRUPO, a.nombreAsignatura AS ASGINATURA, a.tipoAsignatura AS TIPO
	FROM tblAsignatura a
	INNER JOIN tblGrAsignatura ga ON a.idAsignatura = ga.idAsignatura
	WHERE a.idAsignatura IN (
		SELECT sa.idAsignatura
		FROM tblSemestreAsignatura sa
		WHERE sa.isActive = 1 AND sa.idSemestre = @idSemestre
	) AND ga.idGrAsig NOT IN (
		SELECT ach.idGrAsig
		FROM tblAsigCrgHoraria ach
	) AND ga.idGrAsig IN (
		SELECT SGA.idGrAsig
		FROM tblSemestreGrAsignatura SGA
		WHERE SGA.idSemestre = @idSemestre and SGA.isActive = 1)
	ORDER BY ASGINATURA ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCodeAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get Asignature Code from tblAsignatura based on Asignature Name
CREATE   PROCEDURE [dbo].[spGetCodeAsignatura]
@idAsignatura int
AS
BEGIN 
	SELECT codigoAsignatura FROM tblAsignatura
	WHERE idAsignatura = @idAsignatura
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDataHorasExigiblesDocentesBySemestreAndName]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get type Docente Name based on idTipoDocente and idSemestre
CREATE   PROCEDURE [dbo].[spGetDataHorasExigiblesDocentesBySemestreAndName]
    @idSemestre INT,
	@nombreTipoDocente varchar(100)
AS
BEGIN
    DECLARE @RowCount INT;
	DECLARE @RowCountDefault INT;

    SELECT @RowCount = COUNT(*)
    FROM tblTipoDocenteSemestre
    WHERE idSemestre = @idSemestre;

	SELECT @RowCountDefault = COUNT(*)
    FROM tblTipoDocente


    IF @RowCount > 0 AND @RowCountDefault = @RowCount
    BEGIN
        SELECT TDS.idTipoDocenteSemestre as ID,TDS.numHorasSemestrales as HORAS
        FROM tblTipoDocenteSemestre TDS
		INNER JOIN tblTipoDocente TD ON TDS.idTipoDocente = TD.idTipoDocente
        WHERE idSemestre = @idSemestre and TD.nombreTipoDocente = @nombreTipoDocente
    END
    ELSE
    BEGIN
        SELECT idTipoDocente as ID,numHorasSemestrales as '# HORAS'
		FROM tblTipoDocente
		WHERE nombreTipoDocente = @nombreTipoDocente
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetDocenteIfGrExisteInCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[spGetDocenteIfGrExisteInCargaHoraria]
    @idSemestre INT,
	@idGr INT,
	@docenteName varchar(100) OUT
AS
BEGIN
	DECLARE @nameDoc varchar(100);
    SELECT @nameDoc =  CONCAT(apellido1Docente,' ',apellido2Docente,' ',nombre1Docente,' ',nombre2Docente)
    FROM tblAsigCrgHoraria ACH
	INNER JOIN tblCargaHoraria CH ON ACH.idCrgHoraria = CH.idCargaHoraria
	INNER JOIN tblDocente D ON CH.idDocente = D.idDocente
    WHERE CH.idSemestre = @idSemestre AND ACH.idGrAsig = @idGr;

	IF @nameDoc IS NULL
	BEGIN
		SET @docenteName = 'NONE'
		PRINT @docenteName
	END
	ELSE
	BEGIN
		SET @docenteName = @nameDoc
		PRINT @docenteName
	END
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetDocenteMailByCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Get Docente Name from  "tblCargaHoraria" based on idCargaHoraria
CREATE   PROCEDURE [dbo].[spGetDocenteMailByCrgHoraria]
@idCrgHoraria int
AS 
BEGIN 
    SELECT doc.emailDocente
	FROM tblCargaHoraria ch
	INNER JOIN tblDocente doc ON ch.idDocente = doc.idDocente
	WHERE ch.idCargaHoraria = @idCrgHoraria AND doc.estadoDocente = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDocenteNameByCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Get Docente Name from  "tblCargaHoraria" based on idCargaHoraria
CREATE   PROCEDURE [dbo].[spGetDocenteNameByCrgHoraria]
@idCrgHoraria int
AS 
BEGIN 
    SELECT CONCAT(apellido1Docente, ' ', apellido2Docente, ' ',nombre1Docente, ' ', nombre2Docente) NameDocente
	FROM tblCargaHoraria ch
	INNER JOIN tblDocente doc ON ch.idDocente = doc.idDocente
	WHERE ch.idCargaHoraria = @idCrgHoraria AND doc.estadoDocente = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDocenteNameTypeByCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Get Docente Type Name from  "tblCargaHoraria" based on idCargaHoraria
CREATE   PROCEDURE [dbo].[spGetDocenteNameTypeByCrgHoraria]
@idCrgHoraria int,
@idSemestre int
AS 
BEGIN 
    SELECT td.nombreTipoDocente
	FROM tblCargaHoraria ch
	INNER JOIN tblDocente doc ON ch.idDocente = doc.idDocente
	INNER JOIN tblSemestreTpDocente std ON doc.idDocente = std.idDocente
	INNER JOIN tblTipoDocente td ON std.idTipoDoc = td.idTipoDocente
	WHERE ch.idCargaHoraria = @idCrgHoraria and  std.idSemestre =@idSemestre and doc.estadoDocente = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDocentesLst_CargaAcademica_BySemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------
-- REPORTS Stored Procedures
-----------------------------------------
-- SP to get a list of Docentes with Activity Hours
CREATE   PROCEDURE [dbo].[spGetDocentesLst_CargaAcademica_BySemestre]
@idSemestre int
AS
BEGIN 
	SELECT 
    CONCAT(d.apellido1Docente, ' ', d.apellido2Docente, ' ', d.nombre1Docente, ' ', d.nombre2Docente) AS 'Docente',
    td.nombreTipoDocente AS 'Tipo de Docente',
    std.numHorasSemestrales AS 'Horas Exigibles',
	std.idSemestre,
    COALESCE(dh.horasActividadDocencia, 0) + COALESCE(sh.horasActividadSemestre, 0) AS 'Horas Docencia',
    COALESCE(dh.horasActividadGestion, 0) + COALESCE(sh.horasActividadGestionSemestre, 0) AS 'Horas Gestion',
    COALESCE(dh.horasActividadInvestigacion, 0) + COALESCE(sh.horasActividadInvestigacionSemestre, 0) AS 'Horas Investigacion',
    CASE
        WHEN (std.numHorasSemestrales - (COALESCE(dh.horasActividadDocencia, 0) + COALESCE(sh.horasActividadSemestre, 0) + COALESCE(dh.horasActividadGestion, 0) + COALESCE(sh.horasActividadGestionSemestre, 0) + COALESCE(dh.horasActividadInvestigacion, 0) + COALESCE(sh.horasActividadInvestigacionSemestre, 0))) = 0 THEN 'SI CUMPLE'
        WHEN (std.numHorasSemestrales - (COALESCE(dh.horasActividadDocencia, 0) + COALESCE(sh.horasActividadSemestre, 0) + COALESCE(dh.horasActividadGestion, 0) + COALESCE(sh.horasActividadGestionSemestre, 0) + COALESCE(dh.horasActividadInvestigacion, 0) + COALESCE(sh.horasActividadInvestigacionSemestre, 0))) < 0 THEN 'HORAS SOBRANTES'
		WHEN crg.idCargaHoraria IS NULL THEN 'CARGA ACADÉMICA INEXISTENTE'
		ELSE 'NO CUMPLE'
    END AS 'Cumple Horas Exigibles?'
	FROM 
		tblDocente d
		LEFT JOIN tblSemestreTpDocente std ON d.idDocente = std.idDocente
		LEFT JOIN tblTipoDocente td ON std.idTipoDoc = td.idTipoDocente
		LEFT JOIN tblCargaHoraria crg ON d.idDocente = crg.idDocente
		LEFT JOIN (
			SELECT ac.idCrgHoraria,
				   SUM(CASE WHEN a.idTpAct_f = 2 THEN ac.horaTotal ELSE 0 END) AS 'horasActividadDocencia',
				   SUM(CASE WHEN a.idTpAct_f = 4 THEN ac.horaTotal ELSE 0 END) AS 'horasActividadGestion',
				   SUM(CASE WHEN a.idTpAct_f = 3 THEN ac.horaTotal ELSE 0 END) AS 'horasActividadInvestigacion'
			FROM tblActividadCargas ac
			INNER JOIN tblActividad a ON ac.idActividad = a.idActividad
			GROUP BY ac.idCrgHoraria
		) dh ON crg.idCargaHoraria = dh.idCrgHoraria
		LEFT JOIN (
			SELECT ac.idCrgHoraria,
				   SUM(CASE WHEN a.idTpAct_f = 1 THEN ac.horasSemana * s.numSemanasClase * 2 ELSE 0 END) AS 'horasActividadSemestre',
				   SUM(CASE WHEN a.idTpAct_f = 4 THEN ac.horasSemana * s.numSemanasSemestre ELSE 0 END) AS 'horasActividadGestionSemestre',
				   SUM(CASE WHEN a.idTpAct_f = 3 THEN ac.horasSemana * s.numSemanasSemestre ELSE 0 END) AS 'horasActividadInvestigacionSemestre'
			FROM tblActividadCargas ac
			INNER JOIN tblActividad a ON ac.idActividad = a.idActividad
			INNER JOIN tblCargaHoraria ch ON ac.idCrgHoraria = ch.idCargaHoraria
			INNER JOIN tblSemestre s ON ch.idSemestre = s.idSemestre
			GROUP BY ac.idCrgHoraria
		) sh ON crg.idCargaHoraria = sh.idCrgHoraria
		WHERE crg.idSemestre = @idSemestre AND std.estadoSemestreDoc = 1 and std.idSemestre = @idSemestre
		ORDER BY Docente
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDocentesLst_CargaAcademica_BySemestre_To_Pdf]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP TO GET DATA TO EXPORT PDFs
CREATE   PROCEDURE [dbo].[spGetDocentesLst_CargaAcademica_BySemestre_To_Pdf]
@idSemestre int
AS
BEGIN 
	SELECT ch.idCargaHoraria,  CONCAT(d.apellido1Docente, ' ', d.apellido2Docente, ' ', d.nombre1Docente, ' ', d.nombre2Docente) AS Docente
	,std.numHorasSemestrales AS horasExigibles
	FROM tblCargaHoraria ch
	INNER JOIN tblDocente d ON ch.idDocente = d.idDocente
	INNER JOIN tblSemestreTpDocente std ON d.idDocente = std.idDocente
	WHERE ch.idSemestre = @idSemestre AND std.idSemestre = @idSemestre
	ORDER BY Docente
END
GO
/****** Object:  StoredProcedure [dbo].[spGetHoraActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Get Activity Hours from  "tblActividad" based on idActividad
CREATE   PROCEDURE [dbo].[spGetHoraActividad]
@idActividad int
AS 
BEGIN 
    SELECT cantHoraSemana AS 'Horas'
    FROM   tblActividad
	WHERE idActividad = @idActividad
END
GO
/****** Object:  StoredProcedure [dbo].[spGetHoraAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP TO GET HORAS SEMANALES FOR ASIGNATURA
CREATE   PROCEDURE [dbo].[spGetHoraAsignatura]
@idAsignatura int
AS 
BEGIN 
    SELECT horasAsignaturaSemanales
    FROM   tblAsignatura
	WHERE idAsignatura = @idAsignatura
END
GO
/****** Object:  StoredProcedure [dbo].[spGetHorarioForCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP TO GET DOCENTE HORARIO exec spGetHorarioForCargaHoraria 1
CREATE   PROCEDURE [dbo].[spGetHorarioForCargaHoraria]
    @idCargaHoraria int
AS
BEGIN
    DECLARE @idSemestre AS int;
    CREATE TABLE #LstidGRAsig (idGrAsig int);

    SELECT @idSemestre = CH.idSemestre
    FROM tblCargaHoraria CH
    WHERE CH.idCargaHoraria = @idCargaHoraria;

    INSERT INTO #LstidGRAsig (idGrAsig)
    SELECT ACH.idGrAsig
    FROM tblAsigCrgHoraria ACH
    WHERE ACH.idCrgHoraria = @idCargaHoraria;

    SELECT CONCAT(CONVERT(NVARCHAR(5), h.horaInicio, 108), ' - ', CONVERT(NVARCHAR(5), h.horaFin, 108)) AS HORA, ds.dia AS DÍA, 
           CONCAT(g.grupoAsignatura,'-',A.nombreAsignatura) AS ASIGNATURA, h.horaInicio, h.horaFin, ds.dia, ds.idDiaSemana
    FROM tblHorarioGrAsig h
    INNER JOIN tblDiaSemana ds ON h.idDiaSemana = ds.idDiaSemana
    INNER JOIN tblSemestreGrAsignatura sg ON h.idSemestreGrAsignatura = sg.idSemestreGrAsignatura
    INNER JOIN tblGrAsignatura g ON sg.idGrAsig = g.idGrAsig
    INNER JOIN tblAsignatura A ON g.idAsignatura = A.idAsignatura
    WHERE h.isActive = 1 and sg.idSemestre = @idSemestre and sg.idGrAsig IN (SELECT idGrAsig FROM #LstidGRAsig) AND h.horaInicio <> h.horaFin
    ORDER BY idDiaSemana ASC;

    DROP TABLE #LstidGRAsig;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetHorasExByTpDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get number of exigible hours by Docente Type
CREATE PROCEDURE [dbo].[spGetHorasExByTpDocente]
@idTpDocente int
AS
BEGIN 
	SELECT numHorasSemestrales
	FROM tblTipoDocente
	WHERE idTipoDocente = @idTpDocente
END
GO
/****** Object:  StoredProcedure [dbo].[spGetHorasExigiblesDocentesBySemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get the number of semester hours based on idTipoDocente and idSemestre
CREATE   PROCEDURE [dbo].[spGetHorasExigiblesDocentesBySemestre]
    @idSemestre INT
AS
BEGIN
    DECLARE @RowCount INT;
	DECLARE @RowCountDefault INT;

    SELECT @RowCount = COUNT(*)
    FROM tblTipoDocenteSemestre
    WHERE idSemestre = @idSemestre;

	SELECT @RowCountDefault = COUNT(*)
    FROM tblTipoDocente

    IF @RowCount > 0 AND @RowCountDefault = @RowCount
    BEGIN
        SELECT TDS.idTipoDocenteSemestre as ID, TD.nombreTipoDocente as 'TIPO DE DOCENTE' ,TDS.numHorasSemestrales as '# HORAS'
        FROM tblTipoDocenteSemestre TDS
		INNER JOIN tblTipoDocente TD ON TDS.idTipoDocente = TD.idTipoDocente
        WHERE idSemestre = @idSemestre ORDER by ID;
    END
    ELSE
    BEGIN
        SELECT idTipoDocente as ID,nombreTipoDocente as 'TIPO DE DOCENTE',numHorasSemestrales as '# HORAS'
		FROM tblTipoDocente ORDER by ID;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetHorasSemestrales]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get the number of semester hours based on idTipoDocente and idSemestre
CREATE PROCEDURE [dbo].[spGetHorasSemestrales]
--EXEC spGetHorasSemestrales 1, 1; -- Ejemplo: Tipo de docente 1, Semestre 1
	@idTipoDocente int,
	@idSemestre int
AS
BEGIN 
	DECLARE @numHorasSemestrales int

	SELECT @numHorasSemestrales = numHorasSemestrales
	FROM tblTipoDocenteSemestre
	WHERE idTipoDocente = @idTipoDocente AND idSemestre = @idSemestre

	IF @numHorasSemestrales IS NULL
	BEGIN
		SELECT @numHorasSemestrales = numHorasSemestrales
		FROM tblTipoDocente
		WHERE idTipoDocente = @idTipoDocente
	END

	SELECT @numHorasSemestrales AS numHorasSemestrales
END
GO
/****** Object:  StoredProcedure [dbo].[spGetHorasTotalesActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Get Activity Total Hours from  "tblActividad" based on idActividad
CREATE   PROCEDURE [dbo].[spGetHorasTotalesActividad]
@idActividad int
AS 
BEGIN 
    SELECT cantHoraTotal AS 'HorasTotales'
    FROM   tblActividad
	WHERE idActividad = @idActividad
END
GO
/****** Object:  StoredProcedure [dbo].[spGetIdActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get IdActividad from tblActividad based on Activity Name
CREATE PROCEDURE [dbo].[spGetIdActividad]
@ActividadName varchar(250)
AS
BEGIN 
	SELECT idActividad AS ID
	FROM tblActividad
	WHERE nombreActividad = @ActividadName
END
GO
/****** Object:  StoredProcedure [dbo].[spGetIdCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get IdCargaHoraria
CREATE PROCEDURE [dbo].[spGetIdCargaHoraria]
@idDocente int,
@idSemestre int
AS
BEGIN 
	SELECT idCargaHoraria AS ID
	FROM tblCargaHoraria
	WHERE (idSemestre = @idSemestre AND idDocente= @idDocente)
END
GO
/****** Object:  StoredProcedure [dbo].[spGetIdCargaHorariaLst_BySemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP TO GET IDs CARGA HORARIA By SEMESTRE TO EXPORT PDFs
CREATE   PROCEDURE [dbo].[spGetIdCargaHorariaLst_BySemestre]
@idSemestre int
AS
BEGIN 
	SELECT DISTINCT idCargaHoraria AS id
	FROM tblCargaHoraria
	WHERE idSemestre = @idSemestre
	ORDER BY id
END
GO
/****** Object:  StoredProcedure [dbo].[spGetIdGrAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get IdGrAsignatura from tblGrAsignatura based on idAsignatura and Grupo
CREATE PROCEDURE [dbo].[spGetIdGrAsignatura]
@idAsignatura int,
@Grupo varchar(100)
AS
BEGIN 
	SELECT idGrAsig AS ID
	FROM tblGrAsignatura
	WHERE (idAsignatura = @idAsignatura AND grupoAsignatura= @Grupo)
END
GO
/****** Object:  StoredProcedure [dbo].[spGetLevelAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get Asignature Level from tblAsignatura based on Asignature Name
CREATE   PROCEDURE [dbo].[spGetLevelAsignatura]
@idAsignatura int
AS
BEGIN 
	SELECT nivelAsignatura FROM tblAsignatura
	WHERE idAsignatura = @idAsignatura
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProjectInfoFromActivity]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get activities with project from  "tblActividad"
CREATE   PROCEDURE [dbo].[spGetProjectInfoFromActivity]
@idActividad INT
AS 
BEGIN 
    SELECT  P.codigoProyecto ,P.nombreProyecto,P.tipoProyecto, P.fechaInicio, P.fechaFin,P.urlAval,P.presupuesto,
	ISNULL(P.idProyecto, 0) AS IDP
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	LEFT JOIN tblProyecto P ON act.idProyecto_f = P.idProyecto
	WHERE act.idActividad = @idActividad
END
--exec [spGetProjectInfoFromActivity] 27
GO
/****** Object:  StoredProcedure [dbo].[spGetSemanasClaseBySemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get number of weeks of class
CREATE PROCEDURE [dbo].[spGetSemanasClaseBySemestre]
@idSemestre int
AS
BEGIN 
	select numSemanasClase
	from tblSemestre
	where idSemestre = @idSemestre
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSemanasSemestreBySemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get number of weeks of semestre
CREATE PROCEDURE [dbo].[spGetSemanasSemestreBySemestre]
@idSemestre int
AS
BEGIN 
	select numSemanasSemestre
	from tblSemestre
	where idSemestre = @idSemestre
END
GO
/****** Object:  StoredProcedure [dbo].[spGetTypeAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to get Asignature type from tblAsignatura based on Asignature Name
CREATE   PROCEDURE [dbo].[spGetTypeAsignatura]
@idAsignatura int
AS
BEGIN 
	SELECT tipoAsignatura FROM tblAsignatura
	WHERE idAsignatura = @idAsignatura
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllActividades]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblActividad"
CREATE   PROCEDURE [dbo].[spReadAllActividades]
AS 
BEGIN 
    SELECT idActividad AS ID,tp.nombreTpAct AS 'Tipo', ISNULL(P.codigoProyecto, 'SIN PROYECTO') AS 'Código proyecto' ,nombreActividad AS 'Actividad', cantHoraSemana AS 'Horas Semanales', cantHoraTotal AS 'Horas Totales',
	ISNULL(P.idProyecto, 0) AS IDP
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	LEFT JOIN tblProyecto P ON act.idProyecto_f = P.idProyecto
END
--exec [spReadAllActividades]
GO
/****** Object:  StoredProcedure [dbo].[spReadAllActividadesNotInCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All Investigation Activities not in tblActividadCargas for a specific carga horaria
CREATE   PROCEDURE [dbo].[spReadAllActividadesNotInCargaHoraria]
    @idCargaHoraria int,
	@tipo varchar(10)
AS 
BEGIN 
    SELECT act.idActividad AS ID, act.nombreActividad AS 'Actividad'
    FROM tblActividad act
    INNER JOIN tblTipoActividad tp ON act.idTpAct_f = tp.idTpAct
    WHERE (tp.nombreTpAct = @tipo AND act.estadoActividad = 1)
        AND NOT EXISTS (
            SELECT 1
            FROM tblActividadCargas ac
            WHERE ac.idActividad = act.idActividad AND ac.idCrgHoraria = @idCargaHoraria
        )
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllAsignaturas]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spReadAllAsignaturas]
AS 
BEGIN 
    SELECT idAsignatura AS ID,c.idCarrera, c.nombreCarrera AS Carrera,nombreAsignatura AS 'Nombre de la Asignatura', tipoAsignatura AS 'Tipo de Asignatura',
	codigoAsignatura AS 'Código',horasAsignaturaTotales AS 'Horas Totales', horasAsignaturaSemanales AS 'Horas Semanales',
	nivelAsignatura as Nivel
    FROM   tblAsignatura a
	INNER JOIN tblCarrera c ON a.idCarrera = c.idCarrera
	WHERE estadoAsignatura = 1
	ORDER BY 'Nombre de la Asignatura'
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllAsignaturasCmb]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spReadAllAsignaturasCmb]
AS 
BEGIN 
    SELECT DISTINCT a.idAsignatura AS ID, CONCAT(a.nombreAsignatura,' - ',a.codigoAsignatura) AS Asignatura
    FROM tblAsignatura a
	ORDER BY Asignatura ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllAsignaturasWGroups]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spReadAllAsignaturasWGroups]
@idSemestre int
AS 
BEGIN 
	SELECT DISTINCT a.idAsignatura AS ID,CONCAT(a.nombreAsignatura,' - ',a.codigoAsignatura) AS Asignatura
    FROM tblAsignatura a
    INNER JOIN tblGrAsignatura g ON a.idAsignatura = g.idAsignatura
    LEFT JOIN tblAsigCrgHoraria c ON g.idGrAsig = c.idGrAsig
	LEFT JOIN tblSemestreAsignatura sa ON a.idAsignatura = sa.idAsignatura
    --WHERE c.idAsigCrgHoraria IS NULL AND g.grupoAsignatura IS NOT NULL AND sa.isActive = 1 AND sa.idSemestre = @idSemestre
	WHERE sa.isActive = 1 AND sa.idSemestre = @idSemestre AND a.estadoAsignatura = 1
	ORDER BY Asignatura ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllAsignaturasWGroups_ByCarrera]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spReadAllAsignaturasWGroups_ByCarrera]
@idSemestre int,
@idCarrera int
AS 
BEGIN 
	--SELECT DISTINCT a.idAsignatura AS ID, a.nombreAsignatura AS Asignatura
 --   FROM tblAsignatura a
 --   INNER JOIN tblGrAsignatura g ON a.idAsignatura = g.idAsignatura
 --   LEFT JOIN tblAsigCrgHoraria c ON g.idGrAsig = c.idGrAsig
	--LEFT JOIN tblSemestreAsignatura sa ON a.idAsignatura = sa.idAsignatura
 --   WHERE c.idAsigCrgHoraria IS NULL AND g.grupoAsignatura IS NOT NULL AND sa.isActive = 1 AND sa.idSemestre = @idSemestre
	--AND a.idCarrera = @idCarrera
	--ORDER BY Asignatura ASC
	SELECT DISTINCT a.idAsignatura AS ID,   CONCAT(a.nombreAsignatura,' - ',a.codigoAsignatura) AS Asignatura
    FROM tblAsignatura a
    INNER JOIN tblGrAsignatura g ON a.idAsignatura = g.idAsignatura
    LEFT JOIN tblAsigCrgHoraria c ON g.idGrAsig = c.idGrAsig
	LEFT JOIN tblSemestreAsignatura sa ON a.idAsignatura = sa.idAsignatura
    WHERE c.idAsigCrgHoraria IS NULL AND g.grupoAsignatura IS NOT NULL AND sa.isActive = 1 AND sa.idSemestre = @idSemestre
	AND a.idCarrera = @idCarrera
	ORDER BY Asignatura ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllAsignaturasWGroupsWHorario]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spReadAllAsignaturasWGroupsWHorario]
@idSemestre int
AS 
BEGIN 
	SELECT DISTINCT a.idAsignatura AS ID,CONCAT(a.nombreAsignatura,' - ',a.codigoAsignatura) AS Asignatura
    FROM tblAsignatura a
    INNER JOIN tblGrAsignatura g ON a.idAsignatura = g.idAsignatura
	INNER JOIN tblSemestreGrAsignatura SGA ON g.idGrAsig = SGA.idGrAsig
    LEFT JOIN tblAsigCrgHoraria c ON g.idGrAsig = c.idGrAsig
	LEFT JOIN tblSemestreAsignatura sa ON a.idAsignatura = sa.idAsignatura
	LEFT JOIN tblHorarioGrAsig HGA ON SGA.idSemestreGrAsignatura = HGA.idSemestreGrAsignatura
    WHERE c.idAsigCrgHoraria IS NULL AND g.grupoAsignatura IS NOT NULL AND sa.isActive = 1 AND sa.idSemestre = @idSemestre
	AND SGA.isActive = 1 AND HGA.isActive = 1 AND SGA.idSemestre = @idSemestre
	ORDER BY Asignatura ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllCargaActividades]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [spReadAllCargaActividadesI] 1
-- Stored Procedure to Read all Actividades from a Specifica Academic Load from tblActividadCargas
CREATE   PROCEDURE [dbo].[spReadAllCargaActividades]
@idCrgHoraria int
AS
BEGIN 
	SELECT 
    interActiv.idActivCrgs AS ID, tpActiv.nombreTpAct AS Tipo,
    activ.nombreActividad AS 'ACTIVIDAD',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA'
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'HORAS SEMANALES',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA'
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'HORAS TOTALES'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	INNER JOIN tblTipoActividad tpActiv on activ.idTpAct_f = tpActiv.idTpAct
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria)
	ORDER BY Tipo;
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllCargaActividadesD11]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read all Actividades D11 from a Specifica Academic Load from tblActividadCargas
CREATE    PROCEDURE [dbo].[spReadAllCargaActividadesD11]
@idCrgHoraria int
AS
BEGIN 
	SELECT 
    interActiv.idActivCrgs AS ID, 
    activ.nombreActividad AS 'ACTIVIDAD',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'HORAS SEMANALES',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'HORAS TOTALES'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f = 1);
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllCargaActividadesF11]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read all Actividades F11 from a Specifica Academic Load from tblActividadCargas
CREATE    PROCEDURE [dbo].[spReadAllCargaActividadesF11]
@idCrgHoraria int
AS
BEGIN 
	SELECT 
    interActiv.idActivCrgs AS ID, 
    activ.nombreActividad AS 'ACTIVIDAD',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'HORAS SEMANALES',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'HORAS TOTALES'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f = 2);
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllCargaActividadesG]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read all Actividades de Gestion from a Specifica Academic Load from tblActividadCargas
CREATE   PROCEDURE [dbo].[spReadAllCargaActividadesG]
@idCrgHoraria int
AS
BEGIN 
	--SELECT interActiv.idActivCrgs AS ID,activ.nombreActividad AS 'Actividad',
	--	interActiv.horasSemana AS 'Horas Semanales', interActiv.horaTotal AS 'Horas Totales'
	--FROM   tblActividadCargas interActiv
	--INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	--WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=4)
	SELECT 
    interActiv.idActivCrgs AS ID, 
    activ.nombreActividad AS 'ACTIVIDAD',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'HORAS SEMANALES',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'HORAS TOTALES'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f = 4);
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllCargaActividadesI]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Stored Procedure to Read all Actividades de Investigacion from a Specifica Academic Load from tblActividadCargas
CREATE   PROCEDURE [dbo].[spReadAllCargaActividadesI]
@idCrgHoraria int
AS
BEGIN 
	SELECT 
    interActiv.idActivCrgs AS ID, 
    activ.nombreActividad AS 'ACTIVIDAD',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'HORAS SEMANALES',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'HORAS TOTALES',
	ISNULL(P.nombreProyecto, 'SIN PROYECTO') AS 'PROYECTO'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	LEFT JOIN tblProyecto P ON activ.idProyecto_f = P.idProyecto
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f = 3);
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllCargaAsignaturas]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read all Asignaturas from a Specifica Academic Load from tblAsigCrgHoraria
CREATE   PROCEDURE [dbo].[spReadAllCargaAsignaturas]
@idCrgHoraria int
AS
BEGIN 
	SELECT interAsig.idAsigCrgHoraria AS ID,asig.tipoAsignatura AS TIPO,ASIG.codigoAsignatura as CÓDIGO,gr.grupoAsignatura as GR,asig.nombreAsignatura AS 'ASIGNATURA',
		asig.horasAsignaturaSemanales AS 'HORAS SEMANALES', asig.horasAsignaturaTotales AS 'HORAS TOTALES', asig.idAsignatura as IDA
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig  on gr.idAsignatura = asig.idAsignatura
	WHERE idCrgHoraria = @idCrgHoraria
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllCargaAsignaturas_Review]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read all Asignaturas from a Specifica Academic Load from tblAsigCrgHoraria
CREATE PROCEDURE [dbo].[spReadAllCargaAsignaturas_Review]
@idCrgHoraria int
AS
BEGIN 
	SELECT interAsig.idAsigCrgHoraria AS ID,asig.codigoAsignatura AS 'Código',asig.nombreAsignatura AS 'Asignatura',gr.grupoAsignatura as GR,
		asig.horasAsignaturaSemanales AS 'Horas / Semana'
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig  on gr.idAsignatura = asig.idAsignatura
	WHERE idCrgHoraria = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllCargas]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------
-- SPs TO MANAGE ACADEMIC LOADS
------------------------------------------------
-- Stored Procedure to Read all Carga Academica from a Specifica Semester from tblAsigCrgHoraria
CREATE   PROCEDURE [dbo].[spReadAllCargas]
@idSemestre int
AS
BEGIN 
	SET NOCOUNT ON;

	SELECT ch.idCargaHoraria AS ID,CONCAT(d.apellido1Docente, ' ', d.apellido2Docente, ' ', d.nombre1Docente, ' ', d.nombre2Docente) AS DOCENTE
	FROM tblCargaHoraria ch
	INNER JOIN tblDocente d ON ch.idDocente = d.idDocente
	INNER JOIN tblSemestreTpDocente std ON std.idDocente = d.idDocente
	WHERE ch.idSemestre = @idSemestre
		AND std.estadoSemestreDoc = 1 AND std.numHorasSemestrales > 0 AND std.idSemestre = @idSemestre
		AND std.estadoSemestreDoc = 1
	ORDER BY Docente;
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllCarreras]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblCarrera"
CREATE   PROCEDURE [dbo].[spReadAllCarreras]
AS 
BEGIN 
    SELECT idCarrera AS ID,dep.nombreDepartamento AS 'Departamento', nombreCarrera AS 'Carrera', codigoCarrera AS 'Código',
			pensum AS 'Pensum'
    FROM   tblCarrera car
	INNER JOIN tblDepartamento dep  on car.idDep = dep.idDepartamento
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllDepartamentos]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spReadAllDepartamentos]
AS 
BEGIN 
    SELECT idDepartamento AS ID, nombreDepartamento AS 'Nombre del Departamento', emailDepartamento AS 'Correo electrónico del Departamento'
    FROM   tblDepartamento  
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllDepartamentos2Carrera]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read all departments from  "tblDepartamento"
CREATE PROC [dbo].[spReadAllDepartamentos2Carrera]
AS 
BEGIN 
    SELECT idDepartamento AS ID ,nombreDepartamento as Name
    FROM   tblDepartamento  
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllDocenciaD11Actividades]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All Docencia D1:1 Activities from  "tblActividad"
CREATE   PROCEDURE [dbo].[spReadAllDocenciaD11Actividades]
AS
BEGIN 
    SELECT idActividad AS ID, nombreActividad AS 'Actividad'
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	WHERE (tp.nombreTpAct = 'D11' AND estadoActividad = 1)
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllDocenciaF11Actividades]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All Docencia Fuera de 1:1 Activities from  "tblActividad"
CREATE   PROCEDURE [dbo].[spReadAllDocenciaF11Actividades]
AS
BEGIN 
    SELECT idActividad AS ID, nombreActividad AS 'Actividad'
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	WHERE (tp.nombreTpAct = 'D' AND estadoActividad = 1)
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllDocentes]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblDocente"
CREATE   PROCEDURE [dbo].[spReadAllDocentes]
AS 
BEGIN 
    SELECT idDocente AS ID,dep.nombreDepartamento AS 'Departamento', CONCAT(nombre1Docente, ' ', nombre2Docente) Nombres,
			CONCAT(apellido1Docente, ' ', apellido2Docente) Apellidos,tituloDocente AS 'Título', emailDocente AS Correo
    FROM   tblDocente car
	INNER JOIN tblDepartamento dep  on car.idDepa = dep.idDepartamento
	WHERE estadoDocente = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllDocentesAllNames]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblDocente"
CREATE   PROCEDURE [dbo].[spReadAllDocentesAllNames]
AS 
BEGIN 
    SELECT idDocente AS ID, CONCAT(apellido1Docente, ' ', apellido2Docente,' ', nombre1Docente, ' ', nombre2Docente) NombreDocente
    FROM   tblDocente WHERE estadoDocente = 1
	ORDER BY NombreDocente ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllDocentesWithHorasExigiblesBySemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblSemestreTpDocente" by Semestre ID
CREATE   PROCEDURE [dbo].[spReadAllDocentesWithHorasExigiblesBySemestre]
	@idSemestre int
AS 
BEGIN 
    SELECT std.idSemestreTpDoc AS ID, CONCAT(apellido1Docente, ' ', apellido2Docente,' ', nombre1Docente, ' ', nombre2Docente) NombreDocente,
	tp.nombreTipoDocente as 'Tipo de Docente',std.numHorasSemestrales as 'Horas Exigibles', sm.codigoSemestre as Semestre
    FROM   tblSemestreTpDocente std
	INNER JOIN tblDocente doc ON std.idDocente = doc.idDocente
	INNER JOIN tblTipoDocente tp ON std.idTipoDoc = tp.idTipoDocente
	INNER JOIN tblSemestre sm ON std.idSemestre = sm.idSemestre
	WHERE std.idSemestre = @idSemestre AND doc.estadoDocente = 1
	ORDER BY NombreDocente ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllGestionActividades]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All Gestion Activities from  "tblActividad"
CREATE   PROCEDURE [dbo].[spReadAllGestionActividades]
AS 
BEGIN 
    SELECT idActividad AS ID, nombreActividad AS 'Actividad'
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	WHERE (tp.nombreTpAct = 'G' AND estadoActividad = 1)
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllGrAsignaturas]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spReadAllGrAsignaturas]
AS 
BEGIN 
    SELECT gr.idGrAsig AS ID, asg.nombreAsignatura as ASIGNATURA, gr.grupoAsignatura as GRUPO, asg.codigoAsignatura AS 'CÓDIGO', asg.tipoAsignatura AS TIPO
    FROM   tblGrAsignatura gr
	INNER JOIN tblAsignatura asg ON gr.idAsignatura = asg.idAsignatura
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllGroupsByAsig]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spReadAllGroupsByAsig]
	@idAsignatura varchar(150)
AS 
BEGIN 
    SELECT gr.idGrAsig AS ID, gr.grupoAsignatura AS Grupos
    FROM tblGrAsignatura gr
    INNER JOIN tblAsignatura asg ON gr.idAsignatura = asg.idAsignatura
    WHERE asg.idAsignatura = @idAsignatura
    AND NOT EXISTS (
        SELECT 1
        FROM tblAsigCrgHoraria ash
        WHERE ash.idGrAsig = gr.idGrAsig
    )
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllGroupsByAsigBySemestreCmb]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spReadAllGroupsByAsigBySemestreCmb]
	@idAsignatura	int,
	@idSemestre		int
AS 
BEGIN 
    SELECT gr.idGrAsig AS ID, gr.grupoAsignatura AS Grupos
    FROM tblGrAsignatura gr
    INNER JOIN tblAsignatura asg ON gr.idAsignatura = asg.idAsignatura
    WHERE asg.idAsignatura = @idAsignatura
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllGroupsByAsigCmb]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spReadAllGroupsByAsigCmb]
	@idAsignatura int
AS 
BEGIN 
    SELECT gr.idGrAsig AS ID, gr.grupoAsignatura AS Grupos
    FROM tblGrAsignatura gr
    INNER JOIN tblAsignatura asg ON gr.idAsignatura = asg.idAsignatura
    WHERE asg.idAsignatura = @idAsignatura
	ORDER BY Grupos ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllGroupsByAsigWithHorario]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spReadAllGroupsByAsigWithHorario]
	@idAsignatura varchar(150),
	@idSemestre int
AS 
BEGIN 
    SELECT gr.idGrAsig AS ID, gr.grupoAsignatura AS Grupos
    FROM tblGrAsignatura gr
    INNER JOIN tblAsignatura asg ON gr.idAsignatura = asg.idAsignatura
	INNER JOIN tblSemestreGrAsignatura SGA ON gr.idGrAsig = SGA.idGrAsig
    WHERE asg.idAsignatura = @idAsignatura AND SGA.idSemestre = @idSemestre
    AND NOT EXISTS (
        SELECT 1
        FROM tblAsigCrgHoraria ash
		INNER JOIN tblCargaHoraria CH ON ash.idCrgHoraria = CH.idCargaHoraria
        WHERE ash.idGrAsig = gr.idGrAsig AND CH.idSemestre = @idSemestre
    )
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllHorariosAsignaturas]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[spReadAllHorariosAsignaturas]
AS 
BEGIN 
    DECLARE @DaysOfWeek TABLE (
        DayIndex INT,
        DayName VARCHAR(10)
    )

    INSERT INTO @DaysOfWeek (DayIndex, DayName)
    VALUES
        (1, 'LUNES'),
        (2, 'MARTES'),
        (3, 'MIÉRCOLES'),
        (4, 'JUEVES'),
        (5, 'VIERNES'),
        (6, 'SÁBADO'),
        (7, 'DOMINGO')

    DECLARE @DynamicSQL NVARCHAR(MAX)
    SET @DynamicSQL = ''

    SELECT @DynamicSQL = @DynamicSQL + 
        ', MAX(CASE WHEN HGR.idDiaSemana = ''' + DayIndex + ''' THEN ISNULL(CONVERT(VARCHAR(5), HGR.horaInicio, 108) + '' - '' + CONVERT(VARCHAR(5), HGR.horaFin, 108), '''') ELSE '''' END) AS [' + DayName + ']'
    FROM @DaysOfWeek
    SET @DynamicSQL = 'SELECT HGR.idHorario AS ID, S.codigoSemestre AS SEMESTRE,A.nombreAsignatura as ASIGNATURA, GR.grupoAsignatura as GRUPO ' + @DynamicSQL +
		', CONVERT(VARCHAR(5), HGR.horaInicio, 108) AS horaInicio, CONVERT(VARCHAR(5), HGR.horaFin, 108) AS horaFin, HGR.dia  ' +
        ' FROM tblHorarioGrAsig HGR ' +
        ' INNER JOIN tblSemestreGrAsignatura SGA ON HGR.idSemestreGrAsignatura = SGA.idSemestreGrAsignatura ' +
        ' INNER JOIN tblGrAsignatura GR ON SGA.idGrAsig = GR.idGrAsig ' +
        ' INNER JOIN tblAsignatura A ON GR.idAsignatura = A.idAsignatura ' +
		' INNER JOIN tblSemestre S ON SGA.idSemestre = S.idSemestre ' +
        ' WHERE HGR.isActive = 1 ' +
        ' GROUP BY HGR.idHorario, A.nombreAsignatura, GR.grupoAsignatura, S.codigoSemestre, horaInicio, horaFin, HGR.dia'

    EXEC sp_executesql @DynamicSQL
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllInvestigationActividades]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All Investigation Activities from  "tblActividad"
CREATE   PROCEDURE [dbo].[spReadAllInvestigationActividades]
AS 
BEGIN 
    SELECT idActividad AS ID, nombreActividad AS 'Actividad'
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	WHERE (tp.nombreTpAct = 'I' AND estadoActividad = 1)
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllInvestigationActividadesNotInCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All Investigation Activities not in tblActividadCargas for a specific carga horaria
CREATE   PROCEDURE [dbo].[spReadAllInvestigationActividadesNotInCargaHoraria]
    @idCargaHoraria int
AS 
BEGIN 
    SELECT act.idActividad AS ID, act.nombreActividad AS 'Actividad'
    FROM tblActividad act
    INNER JOIN tblTipoActividad tp ON act.idTpAct_f = tp.idTpAct
    WHERE (tp.nombreTpAct = 'D' AND act.estadoActividad = 1)
        AND NOT EXISTS (
            SELECT 1
            FROM tblActividadCargas ac
            WHERE ac.idActividad = act.idActividad AND ac.idCrgHoraria = @idCargaHoraria
        )
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllProyectos]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------
-- READ ALL PROCEDURES
---------------------------------------------------
-- SP to get all proyectos from tblProyecto
CREATE PROCEDURE [dbo].[spReadAllProyectos]
AS
BEGIN
    SELECT idProyecto, codigoProyecto AS 'CÓDIGO', nombreProyecto AS PROYECTO, fechaInicio AS 'FECHA INICIO', fechaFin as 'FECHA FIN', 
	presupuesto AS PRESUPUESTO, tipoProyecto AS TIPO, urlAval AS AVAL
    FROM tblProyecto
	WHERE estadoProyecto = 1
END;
GO
/****** Object:  StoredProcedure [dbo].[spReadAllSemestres]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblSemestre"
CREATE   PROCEDURE [dbo].[spReadAllSemestres]
AS 
BEGIN 
    SELECT idSemestre AS ID,codigoSemestre AS 'Código',añoSemestre AS 'Año',
		diaInicio AS 'Fecha Inicio', diaFin AS 'Fecha Fin', numSemanasClase AS 'Semanas de Clase',
		numSemanasSemestre AS 'Semanas Totales del Semestre'
    FROM   tblSemestre
	WHERE estadoSemestre = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllSmstreAsignaturaBySemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblSemestreTpDocente"
CREATE   PROCEDURE [dbo].[spReadAllSmstreAsignaturaBySemestre]
	@idSemestre int
AS 
BEGIN 
    SELECT sa.idSemestreAsignatura AS ID, a.idAsignatura ,a.codigoAsignatura ,a.nombreAsignatura AS Asignatura, a.nivelAsignatura AS NIVEL , a.tipoAsignatura AS TIPO,sa.isActive
	FROM tblSemestreAsignatura sa
	INNER JOIN tblAsignatura a ON sa.idAsignatura = a.idAsignatura
	WHERE sa.idSemestre = @idSemestre
	ORDER BY Asignatura ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllSmstreTpDocenteBySemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblSemestreTpDocente"
CREATE   PROCEDURE [dbo].[spReadAllSmstreTpDocenteBySemestre]
	@idSemestre int
AS 
BEGIN 
    SELECT STP.idDocente AS ID, CONCAT(D.apellido1Docente, ' ', D.apellido2Docente,' ', D.nombre1Docente, ' ', D.nombre2Docente) NombreDocente,
		STP.estadoSemestreDoc, STP.idTipoDoc
    FROM   tblSemestreTpDocente STP
	INNER JOIN tblDocente D ON STP.idDocente = D.idDocente
	INNER JOIN tblTipoDocente TD ON STP.idTipoDoc = TD.idTipoDocente
	WHERE STP.idSemestre = @idSemestre AND D.estadoDocente = 1
	ORDER BY NombreDocente ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllTipoActividades]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblTipoActividad"
CREATE   PROCEDURE [dbo].[spReadAllTipoActividades]
AS 
BEGIN 
    SELECT idTpAct AS ID,nombreTpAct AS 'Tipo de Actividad', descripcionTpAct AS 'Descripción'
    FROM   tblTipoActividad
END
GO
/****** Object:  StoredProcedure [dbo].[spReadAllTipoDocentes]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblTipoDocente"
CREATE   PROCEDURE [dbo].[spReadAllTipoDocentes]
AS 
BEGIN 
    SELECT idTipoDocente AS ID,nombreTipoDocente AS 'Tipo de Docente', numHorasSemestrales AS 'Horas Semestrales'
    FROM   tblTipoDocente
END
GO
/****** Object:  StoredProcedure [dbo].[spReadDepartamento]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spReadDepartamento]
    @DepaID int
AS 
BEGIN 
 
    SELECT idDepartamento, nombreDepartamento, emailDepartamento
    FROM   tblDepartamento  
    WHERE  ( idDepartamento = @DepaID) 
END
GO
/****** Object:  StoredProcedure [dbo].[spReadDepartamentosById]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spReadDepartamentosById]
AS 
BEGIN 
    SELECT idDepartamento AS ID, nombreDepartamento AS 'Departamento'
    FROM   tblDepartamento  
END
GO
/****** Object:  StoredProcedure [dbo].[spReadDocentesNamesWHorasExigibles]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblDocente"
CREATE   PROCEDURE [dbo].[spReadDocentesNamesWHorasExigibles]
@idSemestre int
AS 
BEGIN 
    SELECT D.idDocente AS ID, CONCAT(D.apellido1Docente, ' ', D.apellido2Docente,' ', D.nombre1Docente, ' ', D.nombre2Docente) NombreDocente
    FROM   tblSemestreTpDocente STP
	INNER JOIN tblDocente D ON STP.idDocente = D.idDocente
	WHERE STP.estadoSemestreDoc = 1 AND STP.idSemestre = @idSemestre AND STP.numHorasSemestrales > 0 AND D.estadoDocente = 1
	ORDER BY NombreDocente ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spReadTipoActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spReadTipoActividad]
    @idTpActiv int
AS 
BEGIN 
 
    SELECT idTpAct, nombreTpAct, descripcionTpAct
    FROM   tblTipoActividad  
    WHERE  ( idTpAct = @idTpActiv) 
END
GO
/****** Object:  StoredProcedure [dbo].[spReadTipoDocentesCmb]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Read All rows from  "tblTipoDocente"
CREATE   PROCEDURE [dbo].[spReadTipoDocentesCmb]
AS 
BEGIN 
    SELECT idTipoDocente AS ID,nombreTipoDocente AS 'TipoDocente'
    FROM   tblTipoDocente
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaActividadesD11_ByTotalHoursAct]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Actividades Total hours de Docencia (D11) from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spSumCargaActividadesD11_ByTotalHoursAct]
@idCrgHoraria int
AS
BEGIN 
	SELECT COALESCE(SUM(interActiv.horaTotal),0) AS 'HorasTotalesDocencia'
	FROM   tblActividadCargas interActiv
	INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=1)
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaActividadesD11_Semanal]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Actividades Semanal hours de Docencia (D11) from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spSumCargaActividadesD11_Semanal]
@idCrgHoraria int
AS
BEGIN 
	SELECT COALESCE(SUM(interActiv.horasSemana),0) AS 'HorasSemanalesDocencia'
	FROM   tblActividadCargas interActiv
	INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=1)
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaActividadesF11_ByTotalHoursAct]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Actividades Total hours de Docencia ( D) from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spSumCargaActividadesF11_ByTotalHoursAct]
@idCrgHoraria int
AS
BEGIN 
	SELECT  COALESCE(SUM(interActiv.horaTotal),0) AS 'HorasTotalesDocencia'
	FROM   tblActividadCargas interActiv
	INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=2 )
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaActividadesF11_Semanal]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Actividades Semanal hours de Docencia ( D) from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spSumCargaActividadesF11_Semanal]
@idCrgHoraria int
AS
BEGIN 
	SELECT COALESCE(SUM(interActiv.horasSemana),0) AS 'HorasTotalesDocencia'
	FROM   tblActividadCargas interActiv
	INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=2 )
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaActividadesG_ByTotalHoursAct]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Actividades Total hours de Gestion from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spSumCargaActividadesG_ByTotalHoursAct]
@idCrgHoraria int
AS
BEGIN 
	SELECT  COALESCE(SUM(interActiv.horaTotal),0) AS 'HorasTotalesGestion'
	FROM   tblActividadCargas interActiv
	INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=4)
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaActividadesG_Semanal]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Actividades Semanal hours de Gestion from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spSumCargaActividadesG_Semanal]
@idCrgHoraria int
AS
BEGIN 
	SELECT COALESCE(SUM(interActiv.horasSemana),0) AS 'HorasTotalesGestion'
	FROM   tblActividadCargas interActiv
	INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=4)
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaActividadesI_ByTotalHoursAct]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Actividades Total hours de Investigacion from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spSumCargaActividadesI_ByTotalHoursAct]
@idCrgHoraria int
AS
BEGIN 
	SELECT  COALESCE(SUM(interActiv.horaTotal),0) AS 'HorasTotalesInvestigacion'
	FROM   tblActividadCargas interActiv
	INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=3)
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaActividadesI_Semanal]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Actividades Semanal hours de Investigacion from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spSumCargaActividadesI_Semanal]
@idCrgHoraria int
AS
BEGIN 
	SELECT COALESCE(SUM(interActiv.horasSemana),0) AS 'HorasTotalesInvestigacion'
	FROM   tblActividadCargas interActiv
	INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=3)
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaClasesModular]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Modular Asignatures hours from a Specifica Academic Load from tblAsigCrgHoraria
CREATE PROCEDURE [dbo].[spSumCargaClasesModular]
@idCrgHoraria int
AS
BEGIN 
	SELECT COALESCE(SUM(asig.horasAsignaturaTotales),0) AS 'HorasTotalesAsignaturasMod'
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr  on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig on gr.idAsignatura = asig.idAsignatura
	WHERE (interAsig.idCrgHoraria = @idCrgHoraria AND (asig.tipoAsignatura='Modular')) --@idCrgHoraria
END
GO
/****** Object:  StoredProcedure [dbo].[spSumCargaClasesSemestral]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to SUM all Semestral Asignatures hours from a Specifica Academic Load from tblAsigCrgHoraria
CREATE PROCEDURE [dbo].[spSumCargaClasesSemestral]
@idCrgHoraria int
AS
BEGIN 
	SELECT COALESCE(SUM(asig.horasAsignaturaSemanales),0) AS 'HorasTotalesAsignaturas'
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr  on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig on gr.idAsignatura = asig.idAsignatura
	WHERE (interAsig.idCrgHoraria = @idCrgHoraria AND (asig.tipoAsignatura='Semestral')) --@idCrgHoraria
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateActivCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to update sepecific row from  "tblActividadCargas"
CREATE PROCEDURE [dbo].[spUpdateActivCrgHoraria]
	@id int,
	@idCrgH int,
	@idAct int,
	@hSemana int,
	@hTotal int
AS
	BEGIN
		UPDATE tblActividadCargas
		SET idCrgHoraria = @idCrgH, idActividad = @idAct,horasSemana = @hSemana,horaTotal = @hTotal, estadoActivCrgDocencia = 1
		WHERE idActivCrgs = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific one row from  "tblActividad"
CREATE   PROCEDURE [dbo].[spUpdateActividad]
	@id int,
	@idTpAct int,
	@idProyecto INT,
	@nameAct varchar(255),
	@horasAct int,
	@horasTAct int

AS
	BEGIN
		IF @idProyecto = 0
        SET @idProyecto = NULL;

		UPDATE tblActividad
		SET idTpAct_f = @idTpAct, idProyecto_f = @idProyecto,nombreActividad = @nameAct, cantHoraSemana = @horasAct,
			cantHoraTotal = @horasTAct ,estadoActividad = 1
		WHERE idActividad = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAsigCrgHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to update sepecific row from  "tblAsigCrgHoraria"
CREATE   PROCEDURE [dbo].[spUpdateAsigCrgHoraria]
	@id int,
	@idCrgH int,
	@idGrAsig int
AS
	BEGIN 
		UPDATE tblAsigCrgHoraria
		SET idCrgHoraria = @idCrgH, idGrAsig = @idGrAsig, estadoAsigCrgDocencia = 1
		WHERE idAsigCrgHoraria = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblAsignatura"
CREATE   PROCEDURE [dbo].[spUpdateAsignatura]
	@id int,
	@idCarrera int,
	@nameAsig varchar(255),
	@tpAsig varchar(255),
	@codAsig varchar(255),
	@hAsigTot int,
	@hAsigSem int,
	@lvlAsig varchar(255)
AS
	BEGIN
		UPDATE tblAsignatura
		SET idCarrera = @idCarrera, nombreAsignatura = @nameAsig, tipoAsignatura= @tpAsig, codigoAsignatura =@codAsig,
			horasAsignaturaTotales = @hAsigTot, horasAsignaturaSemanales = @hAsigSem, nivelAsignatura = @lvlAsig,
			estadoAsignatura = 1
		WHERE idAsignatura = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCargaHoraria]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to update specific row from  "tblCargaHoraria"
CREATE PROCEDURE [dbo].[spUpdateCargaHoraria]
	@id int,
	@idDocent int,
	@idSemestr int
AS
	BEGIN
		UPDATE tblCargaHoraria
		SET idDocente = @idDocent, idSemestre = @idSemestr
		WHERE idCargaHoraria = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCarrera]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblCarrera"
CREATE   PROCEDURE [dbo].[spUpdateCarrera]
	@id int,
	@idDepa	int,
	@nameCarreer varchar(255),
	@codCarrer varchar(50),
	@pensum varchar(255)
AS
	BEGIN
		UPDATE tblCarrera
		SET idDep = @idDepa, nombreCarrera= @nameCarreer, codigoCarrera =@codCarrer,
			pensum = @pensum, estadoCarrera = 1
		WHERE idCarrera = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateDepartamento]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblDepartamento"
CREATE PROCEDURE [dbo].[spUpdateDepartamento]
-- How to use:
-- EXEC spUpdateDepartamento 'DETRI', 'detri@epn.edu.ec';
	@id int,
	@nameDepa varchar(50),
	@emailDepa varchar(50)
AS
	BEGIN
		UPDATE tblDepartamento
		SET nombreDepartamento = @nameDepa, emailDepartamento= @emailDepa
		WHERE idDepartamento = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblDocente"
CREATE PROCEDURE [dbo].[spUpdateDocente]
	@id int,
	@idDepa	int,
	@name1 varchar(255),
	@name2 varchar(255),
	@apellido1 varchar(255),
	@apellido2 varchar(255),
	@tituloDoc varchar(255),
	@email varchar(50)
AS
	BEGIN
		UPDATE tblDocente
		SET idDepa = @idDepa, nombre1Docente= @name1, nombre2Docente =@name2,
			apellido1Docente = @apellido1, apellido2Docente = @apellido2, tituloDocente = @tituloDoc, emailDocente =@email
		WHERE idDocente = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateGrAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblAsigCarrera"
--CREATE PROCEDURE [dbo].[spUpdateAsigCarrera]
--	@id int,
--	@idCarrera int,
--	@idAsig int,
--	@state bit
--AS
--	BEGIN 
--		UPDATE tblAsigCarrera
--		SET idCarrera = @idCarrera, idAsignatura= @idAsig, estadoAsigCarrera = @state
--		WHERE  (idAsigCarrera = @id)
--	END
--GO
-- Stored Procedure to Update specific row from  "tblGrAsignatura"
CREATE PROCEDURE [dbo].[spUpdateGrAsignatura]
	@id int,
	@idAsig int,
	@Gr varchar(20)
AS
	BEGIN
		UPDATE tblGrAsignatura
		SET idAsignatura = @idAsig, grupoAsignatura= @Gr
		WHERE  (idGrAsig = @id)
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateHorarioAsig]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblHorarioGrAsig"
CREATE PROCEDURE [dbo].[spUpdateHorarioAsig]
	@id int,
	@idGr int,
	@hIni time,
	@hFin time,
	@day varchar(50)
AS
	BEGIN
		UPDATE tblHorarioGrAsig
		SET idSemestreGrAsignatura = @idGr, horaInicio =@hIni,
			horaFin = @hFin, idDiaSemana = @day, isActive = 1
		WHERE idHorario = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateHorasExigiblesSemestreTpDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- Stored Procedure to UPDATE one row into  "tblSemestreDocente"
CREATE   PROCEDURE [dbo].[spUpdateHorasExigiblesSemestreTpDocente]
	@idSemestre int,
	@idDocente int,
	@numHoras int,
	@result bit OUTPUT
AS
	BEGIN 
		IF EXISTS(SELECT idSemestreTpDoc FROM tblSemestreTpDocente WHERE idSemestre = @idSemestre AND idDocente = @idDocente)
		BEGIN
			UPDATE tblSemestreTpDocente
			SET numHorasSemestrales = @numHoras
			WHERE idSemestre = @idSemestre AND idDocente = @idDocente

			SET @result = 1
		END
		ELSE
		BEGIN
			SET @result = 0
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateProyecto]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP TO UPDATE PROYECTO FROM TBLPROYECTO
CREATE PROCEDURE [dbo].[spUpdateProyecto]
    @idProyecto int,
    @codigoProyecto varchar(50),
    @nombreProyecto varchar(255),
    @fechaInicio date,
    @fechaFin date,
    @presupuesto decimal(18, 2),
    @tipoProyecto varchar(255),
    @urlAval nvarchar(max)
AS
BEGIN
    UPDATE tblProyecto
    SET codigoProyecto = @codigoProyecto,
        nombreProyecto = @nombreProyecto,
        fechaInicio = @fechaInicio,
        fechaFin = @fechaFin,
        presupuesto = @presupuesto,
        tipoProyecto = @tipoProyecto,
        urlAval = @urlAval,
        estadoProyecto = 1
    WHERE idProyecto = @idProyecto;
END;
GO
/****** Object:  StoredProcedure [dbo].[spUpdateSemestre]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblSemestre"
CREATE   PROCEDURE [dbo].[spUpdateSemestre]
	@id int,
	@codSmstr	varchar(50),
	@yrSmstr int,
	@dIni date,
	@dFin date,
	@nSemanaClase int,
	@nSemanaSemestre int
AS
	BEGIN
		UPDATE tblSemestre
		SET codigoSemestre = @codSmstr, añoSemestre= @yrSmstr, diaInicio =@dIni,
			diaFin = @dFin, numSemanasClase = @nSemanaClase, numSemanasSemestre = @nSemanaSemestre,
			estadoSemestre = 1
		WHERE idSemestre = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateSemestreTpDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblSemestreTpDocente"
CREATE PROCEDURE [dbo].[spUpdateSemestreTpDocente]
	@id int,
	@idTpDocente int,
	@idSmstr int,
	@idDocente int,
	@numHSemstre int
AS
	BEGIN
		UPDATE tblSemestreTpDocente
		SET idTipoDoc = @idTpDocente, idSemestre= @idSmstr,idDocente = @idDocente, numHorasSemestrales =@numHSemstre,
			estadoSemestreDoc = 1
		WHERE idSemestreTpDoc = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateTipoActividad]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblTipoActividad"
CREATE PROCEDURE [dbo].[spUpdateTipoActividad]
	@id int,
	@nameTpActiv varchar(255),
	@descripActividad	varchar(255)
AS
	BEGIN
		UPDATE tblTipoActividad
		SET nombreTpAct = @nameTpActiv, descripcionTpAct= @descripActividad
		WHERE idTpAct = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateTipoDocente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to Update specific row from  "tblTipoDocente"
CREATE PROCEDURE [dbo].[spUpdateTipoDocente]
	@id int,
	@nameTP varchar(255),
	@numHorasSem int
AS
	BEGIN
		UPDATE tblTipoDocente
		SET nombreTipoDocente = @nameTP,numHorasSemestrales = @numHorasSem, estadoTipoDocente= 1
		WHERE idTipoDocente = @id;
	END
GO
/****** Object:  StoredProcedure [dbo].[spVerificarConflictoHorario]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP PARA VERIFICAR CRUCE DE HORARIO
CREATE   PROCEDURE [dbo].[spVerificarConflictoHorario]
    @idCargaHoraria int,
	@idGrAsig		int,
	@ConflictoHorario bit OUTPUT
AS
BEGIN
    DECLARE @idSemestre AS int;
	DECLARE @idSemestreGrAsig AS int;
    CREATE TABLE #LstidGRAsigC (idGrAsig int);

    SELECT @idSemestre = CH.idSemestre
    FROM tblCargaHoraria CH
    WHERE CH.idCargaHoraria = @idCargaHoraria;

	SELECT @idSemestreGrAsig = idSemestreGrAsignatura
	FROM tblSemestreGrAsignatura
	WHERE idSemestre = @idSemestre AND idGrAsig = @idGrAsig

    INSERT INTO #LstidGRAsigC (idGrAsig)
    SELECT ACH.idGrAsig
    FROM tblAsigCrgHoraria ACH
    WHERE ACH.idCrgHoraria = @idCargaHoraria;

    -- Obtener la horaInicio y horaFin del @idSemestreGrAsig actual
    DECLARE @horaInicio time, @horaFin time, @diaWeek int;
    SELECT @horaInicio = horaInicio, @horaFin = horaFin, @diaWeek = idDiaSemana
    FROM tblHorarioGrAsig
    WHERE idSemestreGrAsignatura = @idSemestreGrAsig;

	SET @ConflictoHorario = 0; -- Suponemos que no hay conflicto inicialmente

	IF EXISTS (
		SELECT 1
		FROM tblHorarioGrAsig h
		INNER JOIN tblDiaSemana ds ON h.idDiaSemana = ds.idDiaSemana
		INNER JOIN tblSemestreGrAsignatura sg ON h.idSemestreGrAsignatura = sg.idSemestreGrAsignatura
		INNER JOIN tblGrAsignatura g ON sg.idGrAsig = g.idGrAsig
		INNER JOIN tblAsignatura A ON g.idAsignatura = A.idAsignatura
		WHERE h.isActive = 1
		  AND sg.idGrAsig IN (SELECT idGrAsig FROM #LstidGRAsigC)
		  AND h.idDiaSemana = @diaWeek
		  AND ((@horaInicio <= h.horaFin AND @horaFin >= h.horaInicio) OR
			   (@horaFin >= h.horaInicio AND @horaInicio <= h.horaFin))
	)
	BEGIN
		SET @ConflictoHorario = 1;
	END;
	DROP TABLE #LstidGRAsigC;
END;
GO
/****** Object:  StoredProcedure [dbo].[spVerificarGRexistente]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP to verificar si existe GR en tblGrAsignatura
CREATE   PROCEDURE [dbo].[spVerificarGRexistente]
--exec [spVerificarGRexistente] 98, GRD4
	@idAsig int,
	@Gr varchar(20),
	@existeGR bit OUTPUT
AS
BEGIN
	-- Verificar si ya existe un registro con el mismo grupoAsignatura
    IF EXISTS (SELECT 1 FROM tblGrAsignatura WHERE grupoAsignatura = @Gr AND idAsignatura = @idAsig)
    BEGIN
        SET @existeGR = 1; -- Indicar que ya existe un registro con el mismo grupoAsignatura
        RETURN; -- Salir del procedimiento sin realizar la inserción
    END
	ELSE
	BEGIN
		SET @existeGR = 0; 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spVerificarHorarioWithNumHorasAsignatura]    Script Date: 25/8/2023 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure to create one row from "tblHorarioGrAsig"
CREATE   PROCEDURE [dbo].[spVerificarHorarioWithNumHorasAsignatura]
    @idGrAsig			int,
    @horasIngresadas	int,
    @resultado			bit OUTPUT
AS
BEGIN
	DECLARE @horasSemanalesAsignatura int
    SET @resultado = 0 -- Inicializar con valor "False" (Error)

	SELECT @horasSemanalesAsignatura = horasAsignaturaSemanales
	FROM tblAsignatura A
	INNER JOIN tblGrAsignatura GA ON A.idAsignatura = GA.idAsignatura
	WHERE GA.idGrAsig = @idGrAsig

	--Verificar si numero de horas del horario ingresado cumple con el numero de horas registradas
	IF @horasIngresadas = @horasSemanalesAsignatura
	BEGIN
		SET @resultado = 1 -- Cambiar a valor "True" (Éxito)
	END
	ELSE
	BEGIN
		RETURN;
	END
END
GO
USE [master]
GO
ALTER DATABASE [dbCargaHorariaTIC_DETRI_2023] SET  READ_WRITE 
GO
