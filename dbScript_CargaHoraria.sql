--------------------------------------------
-- Author: Jorge Pérez
-- Description: Script to create database for Academic Load in DETRI Department
-- Database Name: dbCargaHorariaData
--------------------------------------------
------------------------------
-- PRESS F5 to Execute entire script
------------------------------
USE master
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'dbCargaHorariaApril')
BEGIN
    DROP DATABASE dbCargaHorariaApril;
END
GO
PRINT 'Creating DB';
CREATE DATABASE dbCargaHorariaApril;
GO
USE dbCargaHorariaApril;

-----------------------------------------
-- Table Creation Section
-----------------------------------------
GO
-- Table: Departamento
CREATE TABLE tblDepartamento (
	idDepartamento int  NOT NULL IDENTITY(1, 1),
	nombreDepartamento varchar(50) NOT NULL,
	emailDepartamento varchar(50) NOT NULL,
    CONSTRAINT PK_Departamento PRIMARY KEY  (idDepartamento)
);
GO
-- Table: Tipo Actividad
CREATE TABLE tblTipoActividad (
	idTpAct int  NOT NULL IDENTITY(1, 1),
	nombreTpAct varchar(255) NOT NULL,
	descripcionTpAct varchar(255) NOT NULL,
    CONSTRAINT PK_TpActividad PRIMARY KEY  (idTpAct)
);
GO
-- Table: Carrera
CREATE TABLE tblCarrera (
	idCarrera int  NOT NULL IDENTITY(1, 1), --PK
	idDep int NOT NULL, -- FK
	nombreCarrera varchar(100) NOT NULL,
	codigoCarrera varchar(50),
	pensum varchar(50) NOT NULL,
	estadoCarrera bit NOT NULL,
    CONSTRAINT PK_Carrera PRIMARY KEY  (idCarrera),
	FOREIGN KEY (idDep) REFERENCES tblDepartamento(idDepartamento) ON UPDATE  NO ACTION  ON DELETE  NO ACTION
);
GO
-- Table: Tipo Docente
CREATE TABLE tblTipoDocente (
	idTipoDocente int  NOT NULL IDENTITY(1, 1),--PK
	nombreTipoDocente varchar(100) NOT NULL,
	numHorasSemestrales int NOT NULL,
	estadoTipoDocente bit NOT NULL,
    CONSTRAINT PK_TipoDocente PRIMARY KEY (idTipoDocente)
);
GO
-- Table: Docente
CREATE TABLE tblDocente(
	idDocente int  NOT NULL IDENTITY(1, 1),--PK
	idDepa int NOT NULL,--FK
	nombre1Docente varchar(50) NOT NULL,
	nombre2Docente varchar(50) NOT NULL,
	apellido1Docente varchar(50) NOT NULL,
	apellido2Docente varchar(50) NOT NULL,
	tituloDocente varchar(50) NOT NULL,
	PRIMARY KEY (idDocente),
	FOREIGN KEY (idDepa) REFERENCES tblDepartamento(idDepartamento) ON UPDATE  NO ACTION  ON DELETE  NO ACTION
);
GO
-- Table: Semestre  
CREATE TABLE tblSemestre(
	idSemestre int  NOT NULL IDENTITY(1, 1),--PK
	codigoSemestre varchar(50) NOT NULL,
	añoSemestre int NOT NULL,
	diaInicio date NOT NULL,
	diaFin date NOT NULL,
	numSemanasClase int NOT NULL,
	numSemanasSemestre int NOT NULL,
	estadoSemestre bit,
	CONSTRAINT PK_Semestre PRIMARY KEY (idSemestre)
);
GO
-- Table: SemestreTipoDocente intermedia
CREATE TABLE tblSemestreTpDocente(
	idSemestreTpDoc int  NOT NULL IDENTITY(1, 1),
	idTipoDoc int NOT NULL,
	idSemestre int NOT NULL,
	idDocente int NOT NULL,
	numHorasSemestrales int NOT NULL,
	estadoSemestreDoc bit NOT NULL,
	PRIMARY KEY (idSemestreTpDoc),
	FOREIGN KEY (idSemestre) REFERENCES tblSemestre(idSemestre) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	FOREIGN KEY (idDocente) REFERENCES tblDocente(idDocente) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	FOREIGN KEY (idTipoDoc) REFERENCES tblTipoDocente(idTipoDocente) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	CONSTRAINT uq_tblSemestreTpDocente UNIQUE(idSemestre, idDocente)
);
GO
----------------------------------------------------------
-- Table: Tipo Asignatura
CREATE TABLE tblTipoAsignatura (
	idTpAsig int  NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	nombreTpAct varchar(20) NOT NULL,
	descripcionTpAct varchar(255) NOT NULL
);
GO
-- Table: Asignatura
CREATE TABLE tblAsignatura (
	idAsignatura int  NOT NULL IDENTITY(1, 1),--PK
	nombreAsignatura varchar(150) NOT NULL,
	tipoAsignatura varchar(50) NOT NULL,
	codigoAsignatura varchar(30) NOT NULL,
	horasAsignaturaTotales int NOT NULL,
	horasAsignaturaSemanales int NOT NULL,
	nivelAsignatura varchar(50) NOT NULL,
	estadoAsignatura bit NOT NULL,
    CONSTRAINT PK_Asignatura PRIMARY KEY  (idAsignatura)
);
GO
-- Table: AsignaturaCarrera intermedia
CREATE TABLE tblAsigCarrera(
	idAsigCarrera int  NOT NULL IDENTITY(1, 1),
	idCarrera int NOT NULL,
	idAsignatura int NOT NULL,--FK 
	estadoSemestreDoc bit NOT NULL,
	PRIMARY KEY (idAsigCarrera),
	FOREIGN KEY (idCarrera) REFERENCES tblCarrera(idCarrera) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	FOREIGN KEY (idAsignatura) REFERENCES tblAsignatura(idAsignatura) ON UPDATE  NO ACTION  ON DELETE  NO ACTION
);
GO
-- Table: GrupoAsignatura
CREATE TABLE tblGrAsignatura(
	idGrAsig int  NOT NULL IDENTITY(1, 1),--PK
	idAsignatura int NOT NULL,--FK
	grupoAsignatura varchar(20) NOT NULL, 
	PRIMARY KEY (idGrAsig),
	FOREIGN KEY (idAsignatura) REFERENCES tblAsignatura(idAsignatura) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	CONSTRAINT uq_tblGrAsignatura UNIQUE(idAsignatura, grupoAsignatura)
);
GO
-- Table: HorarioAsig
CREATE TABLE tblHorarioGrAsig(
	idHorario int  NOT NULL IDENTITY(1, 1),--PK
	idGrAsig int NOT NULL,
	horaInicio time,
	horaFin time,
	dia varchar(50),
	PRIMARY KEY (idHorario),
	FOREIGN KEY (idGrAsig) REFERENCES tblGrAsignatura(idGrAsig) ON UPDATE  NO ACTION  ON DELETE  NO ACTION
);
GO
-- Table: Actividad
CREATE TABLE tblActividad(
	idActividad int  NOT NULL IDENTITY(1, 1) PRIMARY KEY,--PK
	idTpAct_f int NOT NULL,--FK
	nombreActividad varchar(255) NOT NULL,
	cantHoraSemana int,
	cantHoraTotal int,
	estadoActividad bit NOT NULL,
	FOREIGN KEY (idTpAct_f) REFERENCES tblTipoActividad(idTpAct) ON UPDATE  NO ACTION  ON DELETE  NO ACTION
);
GO
-- CARGA HORARIA TOTAL
CREATE TABLE tblCargaHoraria(
	idCargaHoraria int  NOT NULL IDENTITY(1, 1) PRIMARY KEY,--PK
	idDocente int NOT NULL,--FK
	idSemestre int NOT NULL,--FK
	FOREIGN KEY (idSemestre) REFERENCES tblSemestre(idSemestre) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	FOREIGN KEY (idDocente) REFERENCES tblDocente(idDocente) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	CONSTRAINT uq_Cargas UNIQUE(idDocente, idSemestre)
);
GO
-- Table: AsignaturaCargaHoraria intermedia  DELETE TABLE
CREATE TABLE tblAsigCrgHoraria(
	idAsigCrgHoraria int  NOT NULL IDENTITY(1, 1),--PK
	idCrgHoraria int NOT NULL, -- PK  & FK
	idGrAsig int NOT NULL,--FK
	estadoAsigCrgDocencia bit NOT NULL,
	PRIMARY KEY (idAsigCrgHoraria),
	FOREIGN KEY (idGrAsig) REFERENCES tblGrAsignatura(idGrAsig) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	FOREIGN KEY (idCrgHoraria) REFERENCES tblCargaHoraria(idCargaHoraria) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	CONSTRAINT uq_GrAsignatura UNIQUE(idCrgHoraria, idGrAsig)
);
GO
-- Table: ActividadCargas intermedia
CREATE TABLE tblActividadCargas(
	idActivCrgs int  NOT NULL IDENTITY(1, 1),
	idCrgHoraria int NOT NULL, -- PK & FK
	idActividad int NOT NULL,--FK |
	horasSemana int,
	horaTotal int,
	estadoActivCrgDocencia bit NOT NULL,
	PRIMARY KEY CLUSTERED (idActivCrgs, idCrgHoraria),
	FOREIGN KEY (idActividad) REFERENCES tblActividad(idActividad) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	FOREIGN KEY (idCrgHoraria) REFERENCES tblCargaHoraria(idCargaHoraria) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
	--CONSTRAINT uq_ActividadUnica UNIQUE(idCrgHoraria, idActividad)
);
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
-- Stored Procedure to create one row from  "tblCarrera"
CREATE PROCEDURE [dbo].[spAddCarrera]
	@idDepa int,
	@nameCarreer varchar(255),
	@codCarrer varchar(50),
	@pensum varchar(255),
	@est bit
AS
	BEGIN 
		INSERT INTO tblCarrera(idDep,nombreCarrera,codigoCarrera, pensum,estadoCarrera)
		VALUES( @idDepa, @nameCarreer, @codCarrer,@pensum,@est)
	END
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
-- Stored Procedure to create one row from  "tblDocente"
CREATE PROCEDURE [dbo].[spAddDocente]
	@idDepa	int,
	@name1 varchar(255),
	@name2 varchar(255),
	@apellido1 varchar(255),
	@apellido2 varchar(255),
	@tituloDoc varchar(255)
AS
	BEGIN 
		INSERT INTO tblDocente(idDepa,nombre1Docente,nombre2Docente,
		apellido1Docente,apellido2Docente,tituloDocente)
		VALUES(@idDepa,@name1,@name2,@apellido1,@apellido2,@tituloDoc)
	END
GO
--exec spAddSemestre '2023A',2023,'lunes,30 de enero 2023','2023-05-02',16,20,1
--exec spReadAllSemestres
-- Stored Procedure to create one row from  "tblSemestre"
CREATE PROCEDURE [dbo].[spAddSemestre]
	@codSmstr	varchar(50),
	@yrSmstr int,
	@dIni date,
	@dFin date,
	@nSemanaClase int,
	@nSemanaSemestre int,
	@state bit
AS
	BEGIN 
		INSERT INTO tblSemestre(codigoSemestre,añoSemestre,diaInicio, diaFin,
		numSemanasClase,numSemanasSemestre,estadoSemestre)
		VALUES(@codSmstr, @yrSmstr, @dIni, @dFin, @nSemanaClase, @nSemanaSemestre, @state)
	END
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
-- Stored Procedure to create one row from  "tblAsignatura"
CREATE PROCEDURE [dbo].[spAddAsignatura]
	@nameAsig varchar(255),
	@tpAsig varchar(255),
	@codAsig varchar(255),
	@hAsigTot int,
	@hAsigSem int,
	@lvlAsig varchar(255),
	@state bit
AS
	BEGIN 
		INSERT INTO tblAsignatura(nombreAsignatura,tipoAsignatura,codigoAsignatura, horasAsignaturaTotales,
		horasAsignaturaSemanales,nivelAsignatura,estadoAsignatura)
		VALUES(@nameAsig, @tpAsig, @codAsig, @hAsigTot,@hAsigSem,@lvlAsig,@state)
	END
GO
-- Stored Procedure to create one row from  "tblAsigCarrera"
CREATE PROCEDURE [dbo].[spAddAsigCarrera]
	@idCarrera int,
	@idAsig int,
	@state bit
AS
	BEGIN 
		INSERT INTO tblAsigCarrera(idCarrera,idAsignatura,estadoSemestreDoc)
		VALUES(@idCarrera,@idAsig,@state)
	END
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
-- Stored Procedure to create one row from "tblHorarioGrAsig"
CREATE PROCEDURE [dbo].[spAddHorarioAsig]
	@idGr int,
	@hIni time,
	@hFin time,
	@day varchar(50)
AS
	BEGIN 
		INSERT INTO tblHorarioGrAsig(idGrAsig,horaInicio,horaFin, dia)
		VALUES(@idGr, @hIni, @hFin,@day)
	END
GO
-- Stored Procedure to create one row from "tblHorarioGrAsig" Version2

--CREATE PROCEDURE [dbo].[spAddHorarioAsig2]
--	@nameAsig varchar(150),
--	@gr varchar(20),
--	@idGrAsig int,
--	@hIni time,
--	@hFin time,
--	@day varchar(50)
--	@idGrAsig = select(
--AS
--	BEGIN 
--		SELECT gr.idGrAsig AS ID
--		FROM   tblGrAsignatura gr
--		LEFT JOIN tblHorarioGrAsig gra ON gr.idGrAsig = gra.idGrAsig
--		WHERE (gr.idAsignatura=1 AND gr.grupoAsignatura ='GR2')
--	END
GO
-- Stored Procedure to create one row from  "tblActividad"
CREATE PROCEDURE [dbo].[spAddActividad]
	@idTpAct int,
	@nameAct varchar(255),
	@horasAct int,
	@horasTAct int,
	@state bit
AS
	BEGIN 
		INSERT INTO tblActividad(idTpAct_f,nombreActividad,cantHoraSemana,cantHoraTotal, estadoActividad)
		VALUES(@idTpAct, @nameAct, @horasAct,@horasTAct, @state)
	END
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

---------------------------------
-- READING PROCEDURES 
---------------------------------
-- Stored Procedure to Read All Rows from  "tblDepartamento"
IF OBJECT_ID('spReadAllDepartamentos') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllDepartamentos]
END 
GO
CREATE PROC [dbo].[spReadAllDepartamentos]
AS 
BEGIN 
    SELECT idDepartamento AS ID, nombreDepartamento AS 'Nombre del Departamento', emailDepartamento AS 'Correo electrónico del Departamento'
    FROM   tblDepartamento  
END
GO
-- Stored Procedure to Read All Rows from  "tblAsignaturas"
IF OBJECT_ID('spReadAllAsignaturas') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllAsignaturas]
END 
GO
CREATE PROC [dbo].[spReadAllAsignaturas]
AS 
BEGIN 
    SELECT idAsignatura AS ID, nombreAsignatura AS 'Nombre de la Asignatura', tipoAsignatura AS 'Tipo de Asignatura',
	codigoAsignatura AS 'Código',horasAsignaturaTotales AS 'Horas Totales', horasAsignaturaSemanales AS 'Horas Semanales',
	nivelAsignatura as Nivel ,estadoAsignatura AS Estado
    FROM   tblAsignatura
END
GO
-- Stored Procedure to Read All Rows from  "tblAsignaturas" where had Groups
IF OBJECT_ID('spReadAllAsignaturasWGroups') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllAsignaturasWGroups]
END 
GO
CREATE PROC [dbo].[spReadAllAsignaturasWGroups]
AS 
BEGIN 
    SELECT DISTINCT a.idAsignatura AS ID, a.nombreAsignatura AS Asignatura
    FROM tblAsignatura a
    INNER JOIN tblGrAsignatura g ON a.idAsignatura = g.idAsignatura
    LEFT JOIN tblAsigCrgHoraria c ON g.idGrAsig = c.idGrAsig
    WHERE c.idAsigCrgHoraria IS NULL AND g.grupoAsignatura IS NOT NULL
END
GO
-- Stored Procedure to Read All Rows from  "tblAsignaturas" where had Groups
IF OBJECT_ID('spReadAllAsignaturasCmb') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllAsignaturasCmb]
END 
GO
CREATE PROC [dbo].[spReadAllAsignaturasCmb]
AS 
BEGIN 
    SELECT DISTINCT a.idAsignatura AS ID, a.nombreAsignatura AS Asignatura
    FROM tblAsignatura a
END
GO
-- Stored Procedure to Read All Rows from  "tblGrAsignatura"
IF OBJECT_ID('spReadAllGrAsignaturas') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllGrAsignaturas]
END 
GO
CREATE PROC [dbo].[spReadAllGrAsignaturas]
AS 
BEGIN 
    SELECT gr.idGrAsig AS ID, asg.nombreAsignatura as Asignatura, gr.grupoAsignatura as GR
    FROM   tblGrAsignatura gr
	INNER JOIN tblAsignatura asg ON gr.idAsignatura = asg.idAsignatura
END
GO
-- Stored Procedure to Read All Rows from  "tblHorarioGrAsig"
IF OBJECT_ID('spReadAllHorariosAsignaturas') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllHorariosAsignaturas]
END 
GO
CREATE PROC [dbo].[spReadAllHorariosAsignaturas]
AS 
BEGIN 
	SELECT gr.idHorario AS ID, asg.nombreAsignatura as Asignatura, gra.grupoAsignatura as Grupo,
		gr.horaInicio AS 'Hora de Inicio', gr.horaFin AS 'Hora de Fin', gr.dia AS 'Día'
	FROM   tblHorarioGrAsig gr
		   INNER JOIN tblGrAsignatura gra ON gra.idGrAsig=gr.idGrAsig
		   INNER JOIN tblAsignatura asg ON gra.idAsignatura=asg.idAsignatura
END
GO
-- Stored Procedure to Read all departments from  "tblDepartamento"
CREATE PROC [dbo].[spReadAllDepartamentos2Carrera]
AS 
BEGIN 
    SELECT idDepartamento AS ID ,nombreDepartamento as Name
    FROM   tblDepartamento  
END
GO
-- Stored Procedure to Read specific row from  "tblDepartamento"
IF OBJECT_ID('spReadDepartamento') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadDepartamento]
END 
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
-- Stored Procedure to Read specific row from  "tblTipoActividad"
IF OBJECT_ID('spReadTipoActividad') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadTipoActividad]
END 
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
-- Stored Procedure to Read All rows from  "tblTipoActividad"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllTipoActividades]
AS 
BEGIN 
    SELECT idTpAct AS ID,nombreTpAct AS 'Tipo de Actividad', descripcionTpAct AS 'Descripción'
    FROM   tblTipoActividad
END
GO
-- Stored Procedure to Read All rows from  "tblActividad"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllActividades]
AS 
BEGIN 
    SELECT idActividad AS ID,tp.nombreTpAct AS 'Tipo', nombreActividad AS 'Actividad', cantHoraSemana AS 'Horas Semanales', cantHoraTotal AS 'Horas Totales'
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
END
GO
-- Stored Procedure to Get Activity Hours from  "tblActividad" based on idActividad
CREATE OR ALTER PROCEDURE [dbo].[spGetHoraActividad]
@idActividad int
AS 
BEGIN 
    SELECT cantHoraSemana AS 'Horas'
    FROM   tblActividad
	WHERE idActividad = @idActividad
END
GO
-- Stored Procedure to Get Activity Total Hours from  "tblActividad" based on idActividad
CREATE OR ALTER PROCEDURE [dbo].[spGetHorasTotalesActividad]
@idActividad int
AS 
BEGIN 
    SELECT cantHoraTotal AS 'HorasTotales'
    FROM   tblActividad
	WHERE idActividad = @idActividad
END
GO
-- Stores Procedures to read activities based on activity type 
---------------------------------------------------
-- Stored Procedure to Read All Investigation Activities not in tblActividadCargas for a specific carga horaria
CREATE OR ALTER PROCEDURE [dbo].[spReadAllInvestigationActividadesNotInCargaHoraria]
    @idCargaHoraria int
AS 
BEGIN 
    SELECT act.idActividad AS ID, act.nombreActividad AS 'Actividad'
    FROM tblActividad act
    INNER JOIN tblTipoActividad tp ON act.idTpAct_f = tp.idTpAct
    WHERE (tp.nombreTpAct = 'I' AND act.estadoActividad = 1)
        AND NOT EXISTS (
            SELECT 1
            FROM tblActividadCargas ac
            WHERE ac.idActividad = act.idActividad AND ac.idCrgHoraria = @idCargaHoraria
        )
END
GO
-- Stored Procedure to Read All Investigation Activities not in tblActividadCargas for a specific carga horaria
CREATE OR ALTER PROCEDURE [dbo].[spReadAllInvestigationActividadesNotInCargaHoraria]
    @idCargaHoraria int
AS 
BEGIN 
    SELECT act.idActividad AS ID, act.nombreActividad AS 'Actividad'
    FROM tblActividad act
    INNER JOIN tblTipoActividad tp ON act.idTpAct_f = tp.idTpAct
    WHERE (tp.nombreTpAct = 'D11' AND act.estadoActividad = 1)
        AND NOT EXISTS (
            SELECT 1
            FROM tblActividadCargas ac
            WHERE ac.idActividad = act.idActividad AND ac.idCrgHoraria = @idCargaHoraria
        )
END
GO
-- Stored Procedure to Read All Investigation Activities not in tblActividadCargas for a specific carga horaria
CREATE OR ALTER PROCEDURE [dbo].[spReadAllInvestigationActividadesNotInCargaHoraria]
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
-- Stored Procedure to Read All Investigation Activities not in tblActividadCargas for a specific carga horaria
CREATE OR ALTER PROCEDURE [dbo].[spReadAllActividadesNotInCargaHoraria]
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
---------------------------------------------------
-- READ ALL PROCEDURES
---------------------------------------------------
-- Stored Procedure to Read All Investigation Activities from  "tblActividad"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllInvestigationActividades]
AS 
BEGIN 
    SELECT idActividad AS ID, nombreActividad AS 'Actividad'
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	WHERE (tp.nombreTpAct = 'I' AND estadoActividad = 1)
END
GO
-- Stored Procedure to Read All Docencia D1:1 Activities from  "tblActividad"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllDocenciaD11Actividades]
AS
BEGIN 
    SELECT idActividad AS ID, nombreActividad AS 'Actividad'
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	WHERE (tp.nombreTpAct = 'D11' AND estadoActividad = 1)
END
GO
-- Stored Procedure to Read All Docencia Fuera de 1:1 Activities from  "tblActividad"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllDocenciaF11Actividades]
AS
BEGIN 
    SELECT idActividad AS ID, nombreActividad AS 'Actividad'
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	WHERE (tp.nombreTpAct = 'D' AND estadoActividad = 1)
END
GO
-- Stored Procedure to Read All Gestion Activities from  "tblActividad"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllGestionActividades]
AS 
BEGIN 
    SELECT idActividad AS ID, nombreActividad AS 'Actividad'
    FROM   tblActividad act
	INNER JOIN tblTipoActividad tp  on act.idTpAct_f = tp.idTpAct
	WHERE (tp.nombreTpAct = 'G' AND estadoActividad = 1)
END
GO
-- Stored Procedure to Read All rows from  "tblCarrera"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllCarreras]
AS 
BEGIN 
    SELECT idCarrera AS ID,dep.nombreDepartamento AS 'Departamento', nombreCarrera AS 'Carrera', codigoCarrera AS 'Código',
			pensum AS 'Pensum', estadoCarrera AS 'Estado'
    FROM   tblCarrera car
	INNER JOIN tblDepartamento dep  on car.idDep = dep.idDepartamento
END
GO
-- Stored Procedure to Read All rows from  "tblTipoDocente"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllTipoDocentes]
AS 
BEGIN 
    SELECT idTipoDocente AS ID,nombreTipoDocente AS 'Tipo de Docente', numHorasSemestrales AS 'Horas Semestrales'
    FROM   tblTipoDocente
END
GO
-- Stored Procedure to Read All rows from  "tblDocente"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllDocentes]
AS 
BEGIN 
    SELECT idDocente AS ID,dep.nombreDepartamento AS 'Departamento', CONCAT(nombre1Docente, ' ', nombre2Docente) Nombres,
			CONCAT(apellido1Docente, ' ', apellido2Docente) Apellidos,tituloDocente AS 'Título'
    FROM   tblDocente car
	INNER JOIN tblDepartamento dep  on car.idDepa = dep.idDepartamento
END
GO
-- Stored Procedure to Get Docente Name from  "tblCargaHoraria" based on idCargaHoraria
CREATE OR ALTER PROCEDURE [dbo].[spGetDocenteNameByCrgHoraria]
@idCrgHoraria int
AS 
BEGIN 
    SELECT CONCAT(apellido1Docente, ' ', apellido2Docente, ' ',nombre1Docente, ' ', nombre2Docente) NameDocente
	FROM tblCargaHoraria ch
	INNER JOIN tblDocente doc ON ch.idDocente = doc.idDocente
	WHERE ch.idCargaHoraria = @idCrgHoraria
END
GO
-- Stored Procedure to Read All rows from  "tblDocente"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllDocentesAllNames]
AS 
BEGIN 
    SELECT idDocente AS ID, CONCAT(apellido1Docente, ' ', apellido2Docente,' ', nombre1Docente, ' ', nombre2Docente) NombreDocente
    FROM   tblDocente
	ORDER BY NombreDocente ASC
END
GO
-- Stored Procedure to Read All rows from  "tblSemestre"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllSemestres]
AS 
BEGIN 
    SELECT idSemestre AS ID,codigoSemestre AS 'Código',añoSemestre AS 'Año',
		diaInicio AS 'Fecha Inicio', diaFin AS 'Fecha Fin', numSemanasClase AS 'Semanas de Clase',
		numSemanasSemestre AS 'Semanas Totales del Semestre', estadoSemestre AS Estado
    FROM   tblSemestre
END
GO
-- Stored Procedure to Read All rows from  "tblSemestreTpDocente" by Semestre ID
CREATE OR ALTER PROCEDURE [dbo].[spReadAllDocentesWithHorasExigiblesBySemestre]
	@idSemestre int
AS 
BEGIN 
    SELECT std.idSemestreTpDoc AS ID, CONCAT(apellido1Docente, ' ', apellido2Docente,' ', nombre1Docente, ' ', nombre2Docente) NombreDocente,
	tp.nombreTipoDocente as 'Tipo de Docente',std.numHorasSemestrales as 'Horas Exigibles', sm.codigoSemestre as Semestre
    FROM   tblSemestreTpDocente std
	INNER JOIN tblDocente doc ON std.idDocente = doc.idDocente
	INNER JOIN tblTipoDocente tp ON std.idTipoDoc = tp.idTipoDocente
	INNER JOIN tblSemestre sm ON std.idSemestre = sm.idSemestre
	WHERE std.idSemestre = @idSemestre
	ORDER BY NombreDocente ASC
END
GO
---------------------------------
-- UPDATING PROCEDURES 
---------------------------------
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
-- Stored Procedure to Update specific row from  "tblCarrera"
CREATE PROCEDURE [dbo].[spUpdateCarrera]
	@id int,
	@idDepa	int,
	@nameCarreer varchar(255),
	@codCarrer varchar(50),
	@pensum varchar(255),
	@est bit
AS
	BEGIN
		UPDATE tblCarrera
		SET idDep = @idDepa, nombreCarrera= @nameCarreer, codigoCarrera =@codCarrer,
			pensum = @pensum, estadoCarrera = @est
		WHERE idCarrera = @id;
	END
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
-- Stored Procedure to Update specific row from  "tblDocente"
CREATE PROCEDURE [dbo].[spUpdateDocente]
	@id int,
	@idDepa	int,
	@name1 varchar(255),
	@name2 varchar(255),
	@apellido1 varchar(255),
	@apellido2 varchar(255),
	@tituloDoc varchar(255)
AS
	BEGIN
		UPDATE tblDocente
		SET idDepa = @idDepa, nombre1Docente= @name1, nombre2Docente =@name2,
			apellido1Docente = @apellido1, apellido2Docente = @apellido2, tituloDocente = @tituloDoc
		WHERE idDocente = @id;
	END
GO
-- Stored Procedure to Update specific row from  "tblSemestre"
CREATE PROCEDURE [dbo].[spUpdateSemestre]
	@id int,
	@codSmstr	varchar(50),
	@yrSmstr int,
	@dIni date,
	@dFin date,
	@nSemanaClase int,
	@nSemanaSemestre int,
	@state bit
AS
	BEGIN
		UPDATE tblSemestre
		SET codigoSemestre = @codSmstr, añoSemestre= @yrSmstr, diaInicio =@dIni,
			diaFin = @dFin, numSemanasClase = @nSemanaClase, numSemanasSemestre = @nSemanaSemestre,
			estadoSemestre = @state
		WHERE idSemestre = @id;
	END
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
-- Stored Procedure to Update specific row from  "tblAsignatura"
CREATE PROCEDURE [dbo].[spUpdateAsignatura]
	@id int,
	@nameAsig varchar(255),
	@tpAsig varchar(255),
	@codAsig varchar(255),
	@hAsigTot int,
	@hAsigSem int,
	@lvlAsig varchar(255),
	@state bit
AS
	BEGIN
		UPDATE tblAsignatura
		SET nombreAsignatura = @nameAsig, tipoAsignatura= @tpAsig, codigoAsignatura =@codAsig,
			horasAsignaturaTotales = @hAsigTot, horasAsignaturaSemanales = @hAsigSem, nivelAsignatura = @lvlAsig,
			estadoAsignatura = @state
		WHERE idAsignatura = @id;
	END
GO
-- Stored Procedure to Update specific row from  "tblAsigCarrera"
CREATE PROCEDURE [dbo].[spUpdateAsigCarrera]
	@id int,
	@idCarrera int,
	@idAsig int,
	@state bit
AS
	BEGIN 
		UPDATE tblAsigCarrera
		SET idCarrera = @idCarrera, idAsignatura= @idAsig, estadoSemestreDoc = @state
		WHERE  (idAsigCarrera = @id)
	END
GO
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
		SET idGrAsig = @idGr, horaInicio =@hIni,
			horaFin = @hFin, dia = @day
		WHERE idHorario = @id;
	END
GO
-- Stored Procedure to Update specific one row from  "tblActividad"
CREATE PROCEDURE [dbo].[spUpdateActividad]
	@id int,
	@idTpAct int,
	@nameAct varchar(255),
	@horasAct int,
	@horasTAct int,
	@state bit
AS
	BEGIN
		UPDATE tblActividad
		SET idTpAct_f = @idTpAct, nombreActividad = @nameAct, cantHoraSemana = @horasAct,
			cantHoraTotal = @horasTAct ,estadoActividad = @state
		WHERE idActividad = @id;
	END
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
-- Stored Procedure to update sepecific row from  "tblAsigCrgHoraria"
CREATE or ALTER PROCEDURE [dbo].[spUpdateAsigCrgHoraria]
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
---------------------------------
-- DELETING PROCEDURES 
---------------------------------
-- Stored Procedure to delete one row from  "tblDepartamento"
CREATE OR ALTER PROCEDURE [dbo].[spDeleteDepartamento]
	@id int,
	@nameDepa varchar(50),
	@emailDepa varchar(50)
AS
	BEGIN 
		DELETE tblDepartamento 
		WHERE (idDepartamento = @id)
	END
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
-- Stored Procedure to delete one row from  "tblCarrera"
CREATE PROCEDURE [dbo].[spDeleteCarrera]
	@id	int
AS
	BEGIN
		DELETE FROM tblCarrera 
		WHERE idCarrera = @id 
	END
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
-- Stored Procedure to delete one row from  "tblDocente"
CREATE PROCEDURE [dbo].[spDeleteDocente]
	@id	int
AS
	BEGIN
		DELETE FROM tblDocente 
		WHERE idDocente = @id
	END
GO
-- Stored Procedure to delete one row from  "tblSemestre"
CREATE PROCEDURE [dbo].[spDeleteSemestre]
	@id int
	--@codSmstr	varchar(50),
	--@yrSmstr int,
	--@dIni date,
	--@dFin date,
	--@nSemanaClase varchar(255),
	--@nSemanaSemestre varchar(255),
	--@state bit
AS
	BEGIN
		DELETE FROM tblSemestre 
		WHERE idSemestre = @id
	END
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
-- Stored Procedure to delete one row from  "tblAsignatura"
CREATE PROCEDURE [dbo].[spDeleteAsignatura]
	@id int
AS
	BEGIN 
		DELETE FROM tblAsignatura 
		WHERE idAsignatura = @id
	END
GO
-- Stored Procedure to delete one row from  "tblAsigCarrera"
CREATE PROCEDURE [dbo].[spDeleteAsigCarrera]
	@idCarrera int,
	@idAsig int,
	@state bit
AS
	BEGIN 
		INSERT INTO tblAsigCarrera(idCarrera,idAsignatura,estadoSemestreDoc)
		VALUES(@idCarrera,@idAsig,@state)
		DELETE FROM tblAsigCarrera 
		WHERE (idCarrera = @idCarrera AND idAsignatura = @idAsig AND estadoSemestreDoc = @state)
	END
GO
-- Stored Procedure to delete one row from  "tblGrAsignatura" using idAsingnatura
CREATE PROCEDURE [dbo].[spDeleteGrAsignatura]
	@id int
AS
	BEGIN
		DELETE FROM tblGrAsignatura 
		WHERE (idGrAsig = @id)
	END
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
-- Stored Procedure to delete one row from  "tblHorarioGrAsig"
CREATE PROCEDURE [dbo].[spDeleteHorarioAsig]
	@id int
AS
	BEGIN
		DELETE FROM tblHorarioGrAsig 
		WHERE idHorario = @id
	END
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
-- Stored Procedure to delete one row from  "tblCargaHoraria"
CREATE PROCEDURE [dbo].[spDeleteCargaHoraria]
	@id int
AS
	BEGIN
		DELETE FROM tblCargaHoraria 
		WHERE idCargaHoraria = @id
	END
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
-- Stored Procedure to delete one row from  "tblAsigCrgHoraria"
CREATE PROCEDURE [dbo].[spDeleteAsigCrgHoraria]
	@id int
AS
	BEGIN 
		DELETE FROM tblAsigCrgHoraria WHERE idAsigCrgHoraria = @id
	END
GO
-----------------------------------------
-- Stored Procedures to Fill Data into Windows Forms Tools
-----------------------------------------
-- Stored Procedure to Read All Groups by IdAsignatura from  "tblAsignatura"
IF OBJECT_ID('spReadAllGroupsByAsig') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllGroupsByAsig]
END 
GO
CREATE PROC [dbo].[spReadAllGroupsByAsig]
	@nameAsignatura varchar(150)
AS 
BEGIN 
    SELECT gr.idAsignatura AS ID, gr.grupoAsignatura AS Grupos
    FROM tblGrAsignatura gr
    INNER JOIN tblAsignatura asg ON gr.idAsignatura = asg.idAsignatura
    WHERE asg.nombreAsignatura = @nameAsignatura
    AND NOT EXISTS (
        SELECT 1
        FROM tblAsigCrgHoraria ash
        WHERE ash.idGrAsig = gr.idGrAsig
    )
END
GO
-- Stored Procedure to Read All Rows from  "tblDepartamento" to TreeView
IF OBJECT_ID('spReadAllDepartamentoTV') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllDepartamentoTV]
END 
GO
CREATE PROC [dbo].[spReadDepartamentosById]
AS 
BEGIN 
    SELECT idDepartamento AS ID, nombreDepartamento AS 'Departamento'
    FROM   tblDepartamento  
END
GO
--Tree View 
CREATE PROCEDURE [dbo].[spDocentesByIdTV]
	@id int
AS
	BEGIN 
		SELECT idDocente AS ID, CONCAT(apellido1Docente,' ',apellido2Docente,' ',nombre1Docente,' ',nombre2Docente) AS Docente
		FROM tblDocente WHERE idDepa = @id
		ORDER BY Docente ASC
	END
GO
--Tree View Buscar docentes por Id Departamento y que contengan horas exigibles de un determinado semestre
CREATE PROCEDURE [dbo].[spDocentesByIdDepaWHorasExigiblesTV]
	@idDepa int,
	@idSemestre int
AS
	BEGIN 
		SELECT doc.idDocente AS ID, CONCAT(apellido1Docente,' ',apellido2Docente,' ',nombre1Docente,' ',nombre2Docente) AS Docente
		FROM   tblSemestreTpDocente std
		INNER JOIN tblDocente doc ON std.idDocente = doc.idDocente
		INNER JOIN tblTipoDocente tp ON std.idTipoDoc = tp.idTipoDocente
		INNER JOIN tblSemestre sm ON std.idSemestre = sm.idSemestre
		INNER JOIN tblCargaHoraria ch ON doc.idDocente = ch.idDocente
		WHERE std.idSemestre = @idSemestre AND doc.idDepa = @idDepa
		ORDER BY Docente ASC
	END
GO
--Tree View 
CREATE PROCEDURE [dbo].[spDocentesById]
	@id int
AS
	BEGIN 
		SELECT idDepa AS ID, CONCAT(apellido1Docente,' ',apellido2Docente,' ',nombre1Docente,' ',nombre2Docente) AS Departamento
		FROM tblDocente WHERE idDepa = @id
		ORDER BY Departamento ASC
	END
GO
------------------------------------------------
-- SPs TO MANAGE ACADEMIC LOADS
------------------------------------------------
-- Stored Procedure to Read all Carga Academica from a Specifica Semester from tblAsigCrgHoraria
CREATE PROCEDURE [dbo].[spReadAllCargas]
@idSemestre int
AS
BEGIN 
	SELECT ch.idCargaHoraria AS ID,
		CONCAT(doce.apellido1Docente , ' ' , doce.apellido2Docente, ' ' ,doce.nombre1Docente, ' ' ,doce.nombre2Docente) AS 'Docente'
	FROM   tblCargaHoraria ch
	INNER JOIN tblDocente doce  on ch.idDocente = doce.idDocente
	INNER JOIN tblSemestre sem on ch.idSemestre = sem.idSemestre
	WHERE sem.idSemestre = @idSemestre
	ORDER BY ch.idCargaHoraria
END
GO
-- Stored Procedure to Read all Asignaturas from a Specifica Academic Load from tblAsigCrgHoraria
CREATE PROCEDURE [dbo].[spReadAllCargaAsignaturas]
@idCrgHoraria int
AS
BEGIN 
	SELECT interAsig.idAsigCrgHoraria AS ID,gr.grupoAsignatura as GR,asig.nombreAsignatura AS 'Asignatura',
		asig.horasAsignaturaSemanales AS 'Horas Semanales', asig.horasAsignaturaTotales AS 'Horas Totales'
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig  on gr.idAsignatura = asig.idAsignatura
	WHERE idCrgHoraria = @idCrgHoraria
END
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
-- Stored Procedure to Read all Actividades D11 from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spReadAllCargaActividadesD11]
@idCrgHoraria int
AS
BEGIN 
	SELECT 
    interActiv.idActivCrgs AS ID, 
    activ.nombreActividad AS 'Actividad',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'Horas Semanales',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'Horas Totales'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f = 1);
END
GO
-- Stored Procedure to Read all Actividades F11 from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spReadAllCargaActividadesF11]
@idCrgHoraria int
AS
BEGIN 
	SELECT 
    interActiv.idActivCrgs AS ID, 
    activ.nombreActividad AS 'Actividad',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'Horas Semanales',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'Horas Totales'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f = 2);
END
GO
-- Stored Procedure to Read all Actividades de Gestion from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spReadAllCargaActividadesG]
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
    activ.nombreActividad AS 'Actividad',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'Horas Semanales',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'Horas Totales'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f = 4);
END
GO

-- Stored Procedure to Read all Actividades de Investigacion from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spReadAllCargaActividadesI]
@idCrgHoraria int
AS
BEGIN 
	--SELECT interActiv.idActivCrgs AS ID,activ.nombreActividad AS 'Actividad',
	--	interActiv.horasSemana AS 'Horas Semanales'
	--FROM   tblActividadCargas interActiv
	--INNER JOIN tblActividad activ  on interActiv.idActividad = activ.idActividad
	--WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f=3)
	SELECT 
    interActiv.idActivCrgs AS ID, 
    activ.nombreActividad AS 'Actividad',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'Horas Semanales',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA' 
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'Horas Totales'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f = 3);
END
GO
-- Stored Procedure to Read all Actividades from a Specifica Academic Load from tblActividadCargas
CREATE PROCEDURE [dbo].[spReadAllCargaActividades]
@idCrgHoraria int
AS
BEGIN 
	SELECT 
    interActiv.idActivCrgs AS ID, tpActiv.nombreTpAct AS Tipo,
    activ.nombreActividad AS 'Actividad',
    CASE 
        WHEN interActiv.horasSemana IS NULL OR interActiv.horasSemana = 0 
        THEN 'NA'
        ELSE CAST(interActiv.horasSemana AS VARCHAR(10))
    END AS 'Horas Semanales',
    CASE 
        WHEN interActiv.horaTotal IS NULL OR interActiv.horaTotal = 0 
        THEN 'NA'
        ELSE CAST(interActiv.horaTotal AS VARCHAR(10))
    END AS 'Horas Totales'
	FROM tblActividadCargas interActiv
	INNER JOIN tblActividad activ on interActiv.idActividad = activ.idActividad
	INNER JOIN tblTipoActividad tpActiv on activ.idTpAct_f = tpActiv.idTpAct
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria)
	ORDER BY Tipo;
END
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
-- Stored Procedure to get Asignature Level from tblAsignatura based on Asignature Name
CREATE PROCEDURE [dbo].[spGetLevelAsignatura]
@nameAsignatura varchar(250)
AS
BEGIN 
	SELECT nivelAsignatura FROM tblAsignatura
	WHERE nombreAsignatura = @nameAsignatura
END
GO
-- Stored Procedure to get Asignature type from tblAsignatura based on Asignature Name
CREATE PROCEDURE [dbo].[spGetTypeAsignatura]
@nameAsignatura varchar(250)
AS
BEGIN 
	SELECT tipoAsignatura FROM tblAsignatura
	WHERE nombreAsignatura = @nameAsignatura
END
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
-- Stored Procedure to Add multiple   "tblSemestreTpDocente"
CREATE OR ALTER PROCEDURE [dbo].[spAddDocentesToTypeDocente]
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
-- Stored Procedure to copy data from other semester to another semester into "tblSemestreTpDocente"
CREATE OR ALTER PROCEDURE [dbo].[spCopiarRegistrosHorasExigibles]
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
--TEST
--select * from tblTipoDocente
--select * from tblSemestre
--select * from tblSemestreTpDocente

--exec spAddDocentesToTypeDocente 1,1,144
-----------------------------------------
-- Validation Stored Procedures
-----------------------------------------
-- SP to validate if activity exists in an specific academic Load
CREATE OR ALTER PROCEDURE [dbo].[spActivityValidation]
@idCrgHoraria int,
@actividadName varchar(255)
AS
BEGIN 
	SELECT COUNT(*) FROM tblActividadCargas ac
	INNER JOIN tblActividad a ON ac.idActividad = a.idActividad
	WHERE (a.nombreActividad = @actividadName AND ac.idCrgHoraria = @idCrgHoraria)
END
GO
-- SP to validate if asignature exists in an specific academic Load
CREATE OR ALTER PROCEDURE [dbo].[spAsignatureValidation]
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
-----------------------------------------
-- REPORTS Stored Procedures
-----------------------------------------
-- SP to get a list of Docentes with Activity Hours
CREATE OR ALTER PROCEDURE [dbo].[spGetDocentesLst_CargaAcademica_BySemestre]
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
        ELSE 'NO CUMPLE'
    END AS 'Cumple Horas Exigibles?'
	FROM 
		tblDocente d
		LEFT JOIN tblSemestreTpDocente std ON d.idDocente = std.idDocente
		LEFT JOIN tblTipoDocente td ON std.idTipoDoc = td.idTipoDocente
		LEFT JOIN (
			SELECT ac.idCrgHoraria,
				   SUM(CASE WHEN a.idTpAct_f = 2 THEN ac.horaTotal ELSE 0 END) AS 'horasActividadDocencia',
				   SUM(CASE WHEN a.idTpAct_f = 4 THEN ac.horaTotal ELSE 0 END) AS 'horasActividadGestion',
				   SUM(CASE WHEN a.idTpAct_f = 3 THEN ac.horaTotal ELSE 0 END) AS 'horasActividadInvestigacion'
			FROM tblActividadCargas ac
			INNER JOIN tblActividad a ON ac.idActividad = a.idActividad
			GROUP BY ac.idCrgHoraria
		) dh ON d.idDocente = dh.idCrgHoraria
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
		) sh ON d.idDocente = sh.idCrgHoraria
		WHERE std.idSemestre = @idSemestre
END
GO

----------------------------------------
-- CREATION TRIGGERS  SECTION
----------------------------------------
GO
-- Trigger to automatically create default teaching activities when creating an academic load for a teacher
CREATE TRIGGER tr_insertar_actividades11CargaH
ON tblCargaHoraria
AFTER INSERT
AS
BEGIN
	DECLARE @id_CargaH INT;
	-- Asignar el valor del id_tabla2 insertado a la variable
    SELECT @id_CargaH = idCargaHoraria
    FROM inserted;
    -- Insertar el registro en tabla1 con el id generado en tabla2
    INSERT INTO tblActividadCargas (idCrgHoraria, idActividad, horasSemana, horaTotal,estadoActivCrgDocencia)
    VALUES
	(@id_CargaH, 1,0,0,1),
	(@id_CargaH, 2,0,0,1),
	(@id_CargaH, 3,0,0,1),
	(@id_CargaH, 4,0,0,1)
END;
GO
--Trigger to recalculate hours of the DOCENCIA component of an academic load when adding a subject
CREATE TRIGGER tr_recalcularHorasDocencia_CargaH
ON tblAsigCrgHoraria
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @id_CargaH INT;
	DECLARE @horasSemanalesAsignaturas INT;
	DECLARE @horaSemana1 INT;
	DECLARE @horaSemana2 INT;
	DECLARE @horaSemana3 INT;
	DECLARE @horaSemana4 INT;
	-- Se recupera el id de la Carga Horaria
    SELECT @id_CargaH = idCrgHoraria
    FROM inserted;

	-- Se obtiene la suma de horasAsignatura semestrales mediante el procedimiento almacenado
	SELECT @horasSemanalesAsignaturas = COALESCE(SUM(asig.horasAsignaturaSemanales),0)
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr  on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig on gr.idAsignatura = asig.idAsignatura
	WHERE (interAsig.idCrgHoraria = @id_CargaH AND (asig.tipoAsignatura='Semestral'));

	 ---- Se verifica que las actividades 1, 2, 3 y 4 existan en la tabla tblActividadCargas
  --  IF NOT EXISTS (SELECT 1 FROM tblActividadCargas WHERE idCrgHoraria = @id_CargaH AND idActividad IN (1, 2, 3, 4))
  --  BEGIN
  --      RAISERROR('No se encuentran las actividades por defecto de Docencia 1:1 en la Carga Horaria.', 16, 1)
  --      ROLLBACK TRANSACTION
  --      RETURN
  --  END

	-- Calcular horas por actividad
    DECLARE @horasPorActividad DECIMAL(10, 2);
    SET @horasPorActividad = CAST(@horasSemanalesAsignaturas / 4.0 AS DECIMAL(10, 2));
    
    -- Distribuir horas en variables
	IF @horasSemanalesAsignaturas > 0
		BEGIN
			SET @horaSemana1 = CEILING(@horasPorActividad);
			IF @horaSemana1 <= 0 SET @horaSemana1 = 0;
			SET @horaSemana2 = FLOOR(@horasPorActividad);
			IF @horaSemana2 <= 0 SET @horaSemana2 = 0;
			SET @horaSemana3 = FLOOR(@horasPorActividad);
			IF @horaSemana3 <= 0 SET @horaSemana3 = 0;
			SET @horaSemana4 = @horasSemanalesAsignaturas - @horaSemana1 - @horaSemana2 - @horaSemana3;
			IF @horaSemana4 <= 0 SET @horaSemana4 = 0;
		END
    ELSE
		BEGIN
			SET @horaSemana1 = 0;
			SET @horaSemana2 = 0;
			SET @horaSemana3 = 0;
			SET @horaSemana4 = 0;
		END
	--PRINT '@horaSemana1 = ' + CAST(@horaSemana1 AS VARCHAR(10));
	--PRINT '@horaSemana2 = ' + CAST(@horaSemana2 AS VARCHAR(10));
	--PRINT '@horaSemana3 = ' + CAST(@horaSemana3 AS VARCHAR(10));
	--PRINT '@horaSemana4 = ' + CAST(@horaSemana4 AS VARCHAR(10));

    -- Recalcular horas de actividades de Docencia por defecto
	UPDATE tblActividadCargas
	SET horasSemana = @horaSemana1
	WHERE idCrgHoraria = @id_CargaH AND idActividad = 1
	UPDATE tblActividadCargas
	SET horasSemana = @horaSemana2
	WHERE idCrgHoraria = @id_CargaH AND idActividad = 2
	UPDATE tblActividadCargas
	SET horasSemana = @horaSemana3
	WHERE idCrgHoraria = @id_CargaH AND idActividad = 3
	UPDATE tblActividadCargas
	SET horasSemana = @horaSemana4
	WHERE idCrgHoraria = @id_CargaH AND idActividad = 4
END;
--tblAsigCrgHoraria
-----------------------------------------
-- Default Data Insert into DataBase Section
-----------------------------------------
GO
-- DATA INSERT -- Table: Departamento
-- TABLA: Departamento      DATOS    ('Nombre Departamento','correo Departamento')
INSERT INTO tblDepartamento VALUES('DETRI','detri@epn.edu.ec'); -- Id Departamento = 1    ---> ID autogenerado
GO
--  TABLA: Carrera       DATOS    ('Id Departamento','Nombre de la carrra','Codigo Carrera','Pensum','Estado')
INSERT INTO tblCarrera VALUES(1,'Ingenieria en Tecnologias de la Informacion','IT','2020',1);
INSERT INTO tblCarrera VALUES(1,'Ingenieria en Telecomunicaciones','TELE','2020',1);
GO
-- Table: Tipo Actividad
-- DATA INSERT
-- TABLA: Tipo Actividad    DATOS    ('Codigo Tipo Actividad','Nombre del tipo de Actividad')
INSERT INTO tblTipoActividad VALUES('D11','Actividades Docente dentro del 1:1'); --Id=1
INSERT INTO tblTipoActividad VALUES('D','Actividades Docente fuera del 1:1');    --Id=2
INSERT INTO tblTipoActividad VALUES('I','Actividades de Investigacion'); --Id=3
INSERT INTO tblTipoActividad VALUES('G','Actividades de Gestion');       --Id=4
GO
-- Table: Tipo Docente
-- DATA INSERT
--  TABLA: TipoDocente   DATOS    ('Nombre del TipoDocente','Estado')
INSERT INTO tblTipoDocente VALUES('Profesor Titular a Tiempo Completo',928,1);--Id=1
INSERT INTO tblTipoDocente VALUES('Profesor Titular a Tiempo Parcial',928,1); --Id=2
INSERT INTO tblTipoDocente VALUES('Profesor Ocasional a Tiempo Completo',928,1); --Id=3
INSERT INTO tblTipoDocente VALUES('Profesor Ocasional a Tiempo Parcial',928,1); --Id=4
INSERT INTO tblTipoDocente VALUES('Tecnico Docente a Tiempo Completo',928,1); --Id=5
INSERT INTO tblTipoDocente VALUES('Tecnico Docente a Tiempo Parcial',928,1); --Id=6
GO
-- Table: Docente
-- DATA INSERT
--  TABLA: Docente- DATOS    (Id departamento,'Nombre1','Nombre2','Apellido1','Apellido2','Titulo Docente')
INSERT INTO tblDocente VALUES(1,'Ana','Maria','Zambrano','Vizuete','PhD');
INSERT INTO tblDocente VALUES(1,'Carlos','Francisco','Cevallos','Zambrano','MSc');
INSERT INTO tblDocente VALUES(1,'Tania','Aleyda','Acosta','Hurtado','PhD');
INSERT INTO tblDocente VALUES(1,'Robin','Gerardo','Alvarez','Rueda','PhD');
INSERT INTO tblDocente VALUES(1,'Hernan','Vinicio','Barba','Molina','PhD');
INSERT INTO tblDocente VALUES(1,'Pablo','Andres','Barbecho','Bautista','PhD');
INSERT INTO tblDocente VALUES(1,'Ivan','Marcelo','Bernal','Carrillo','PhD');
INSERT INTO tblDocente VALUES(1,'Julio','Cesar','Caiza','Ñacato','PhD');
INSERT INTO tblDocente VALUES(1,'Xavier','Alexander','Calderon','Hinojosa','MSc');
INSERT INTO tblDocente VALUES(1,'Luis','Fernando','Carrera','Suarez','PhD');
INSERT INTO tblDocente VALUES(1,'Jorge','Eduardo','Carvajal','Rodriguez','MSc');
INSERT INTO tblDocente VALUES(1,'William','Santiago','Coloma','Gomez','Ingeniería');
INSERT INTO tblDocente VALUES(1,'Michael','Alexander','Curipallo','Martinez','Ingeniería');
INSERT INTO tblDocente VALUES(1,'Luis','Efren','Diaz','Villacis','MSc');
INSERT INTO tblDocente VALUES(1,'Carlos','Roberto','Egas','Acosta','MSc');
INSERT INTO tblDocente VALUES(1,'Jose','Antonio','Estrada','Jimenez','PhD');	
INSERT INTO tblDocente VALUES(1,'Luis','Antonio','Flores','Asimbaya','MSc');
INSERT INTO tblDocente VALUES(1,'William','Fernando','Flores','Cifuentes','MSc');  			
INSERT INTO tblDocente VALUES(1,'Fabio','Matias','Gonzalez','Gonzalez','MSc');
INSERT INTO tblDocente VALUES(1,'Felipe','Leonel','Grijalva','Arevalo','PhD'); 
INSERT INTO tblDocente VALUES(1,'Danny','Santiago','Guaman','Loachamin','PhD');
INSERT INTO tblDocente VALUES(1,'Melany','Paola','Herrera','Herrera','Ingeniería');
INSERT INTO tblDocente VALUES(1,'Carlos','Alfonso','Herrera','Muñoz','MSc');
INSERT INTO tblDocente VALUES(1,'Pablo','Wilian','Hidalgo','Lascano','MSc'); 
INSERT INTO tblDocente VALUES(1,'Marco','Fernando','Lara','Mina','MSc');
INSERT INTO tblDocente VALUES(1,'Ricardo','Xavier','Llugsi','Cañar','MSc'); 
INSERT INTO tblDocente VALUES(1,'Gabriel','Roberto','Lopez','Fonseca','MSc');
INSERT INTO tblDocente VALUES(1,'Pablo','Anibal','Lupera','Morillo','PhD');
INSERT INTO tblDocente VALUES(1,'Raul','David','Mejia','Navarrete','MSc'); 
INSERT INTO tblDocente VALUES(1,'Ricardo','Ivan','Mena','Villacis',',MSc');
INSERT INTO tblDocente VALUES(1,'Ramiro','Eduardo','Morejon','Tobar','MSc');
INSERT INTO tblDocente VALUES(1,'Diana','Veronica','Navarro','Mendez','PhD');
INSERT INTO tblDocente VALUES(1,'Martha','Cecilia','Paredes','Paredes','PhD');
INSERT INTO tblDocente VALUES(1,'Viviana','Cristina','Parraga','Villamar','MSc');
INSERT INTO tblDocente VALUES(1,'Maria','Cristina','Ramos','Lopez','MSc')
INSERT INTO tblDocente VALUES(1,'Diego','Javier','Reinoso','Chisaguano','PhD');
INSERT INTO tblDocente VALUES(1,'Aldrin','Paul','Reyes','Narvaez','MSc');
INSERT INTO tblDocente VALUES(1,'Ana','Fernanda','Rodriguez','Hoyos','PhD');
INSERT INTO tblDocente VALUES(1,'Tarquino','Fabian','Sanchez','Almeida','PhD');
INSERT INTO tblDocente VALUES(1,'Franklin','Leonel','Sanchez','Catota','MSc');
INSERT INTO tblDocente VALUES(1,'Marco','Fabian','Serrano','Gomez','Ingeniería');
INSERT INTO tblDocente VALUES(1,'Soraya','Lucia','Sinche','Maita','PhD');
INSERT INTO tblDocente VALUES(1,'Edison','Ramiro','Tatayo','Vinueza','MSc');
INSERT INTO tblDocente VALUES(1,'Christian','Jose','Tipantuña','Tenelema','MSc');
INSERT INTO tblDocente VALUES(1,'Luis','Felipe','Urquiza','Aguiar','PhD');
INSERT INTO tblDocente VALUES(1,'Jose','David','Vega','Sanchez','PhD');
INSERT INTO tblDocente VALUES(1,'Monica','De Lourdes','Vinueza','Rhor','MSc');
INSERT INTO tblDocente VALUES(1,'Francisco','Javier','Vizuete','Bassante','Ingeniería');
INSERT INTO tblDocente VALUES(1,'Jose','Adrian','Zambrano','Miranda','MSc');
GO
-- Table: Semestre 
-- DATA INSERT
--  TABLA: Semestre   DATOS    ('Codigo Semestre',AñoSemestre,diaInicio,diaFin,numSemanasClase,numSemanasSemestre,'Estado')
INSERT INTO tblSemestre VALUES('2022B',2022,'2022-10-03','2023-03-31',18,26,1);
GO
INSERT INTO tblSemestreTpDocente(idTipoDoc, idSemestre, idDocente, numHorasSemestrales, estadoSemestreDoc)
VALUES(1,1,1,950,1)
GO
-- Table: Actividad
-- DATA INSERT
--  TABLA: Actividad   DATOS    (idTipoActividad,'Nombre Actividad',horas actividad, estado)
INSERT INTO tblActividad VALUES(1,'Preparación y actualización de clases, seminarios, talleres, entre otros.',5,0,1);--Id=1
INSERT INTO tblActividad VALUES(1,'Preparación, elaboración, aplicación y calificación de exámenes, trabajos y prácticas; consultas académicas.', 5,0,1);--Id=2
INSERT INTO tblActividad VALUES(1,'Diseño y elaboración de material didáctico, guías docentes o syllabus.', 5,0,1);--Id=3
INSERT INTO tblActividad VALUES(1,'Dirección, orientación y acompañamiento a través de tutorías presenciales o virtuales, individuales o grupales (seguimiento académico, seguimiento y evaluación de prácticas o pasantías preprofesionales).', 5,0,1);--Id=4
INSERT INTO tblActividad VALUES(1,'Dirigir los aprendizajes prácticos y de laboratorio, bajo la coordinación de un profesor.', 5,0,1);--Id=5
INSERT INTO tblActividad VALUES(2,'Dirección, codirección de trabajos de titulación para carreras y maestrías profesionalizantes.', 5,0,1);--Id=6
INSERT INTO tblActividad VALUES(2,'Calificación de trabajos de titulación para carreras y maestrías profesionalizantes.', 5,0,1);--Id=7
INSERT INTO tblActividad VALUES(2,'Participación en cursos de capacitación y actualización profesional debidamente autorizados por el Consejo de Departamento.', 5,0,1);--Id=8
INSERT INTO tblActividad VALUES(2,'Escritura, elaboración y edición del libro.', 5,0,1);--Id=9
INSERT INTO tblActividad VALUES(2,'Diseño e impartición de cursos de educación continua, capacitación y actualización profesional, inducción al personal académico vinculado al curso de nivelación.', 5,0,1);--Id=10
INSERT INTO tblActividad VALUES(2,'Apoyo a las actividades de docencia que realiza el personal académico.', 5,0,1);--Id=11
INSERT INTO tblActividad VALUES(3,'Revisor de artículos en revistas indexadas.', 5,0,1);--Id=12
INSERT INTO tblActividad VALUES(3,'Publicación de artículo científico.', 5,0,1);--Id=13
INSERT INTO tblActividad VALUES(3,'Tutoría estudiante doctorado FIEE.', 5,0,1);--Id=14
INSERT INTO tblActividad VALUES(3,'Escritura - Proyecto de investigación interno sin financiamiento.',5,0,1);--Id=15
INSERT INTO tblActividad VALUES(3,'Director de Proyecto de Investigación.', 5,0,1);--Id=16
INSERT INTO tblActividad VALUES(3,'Colaborador de Proyecto de Investigación.', 5,0,1);--Id=17
INSERT INTO tblActividad VALUES(3,'Propuesta - Proyecto de Investigación Interno sin financiamiento.', 5,0,1);--Id=18
INSERT INTO tblActividad VALUES(3,'Elaboración de proyecto de investigación.', 5,0,1);--Id=19
INSERT INTO tblActividad VALUES(3,'Co-Director de Proyecto de Investigación.', 5,0,1);--Id=20
INSERT INTO tblActividad VALUES(3,'Apoyo a la Comisión organizadora ETCM.', 5,0,1);--Id=21
INSERT INTO tblActividad VALUES(3,'Co-Director Tesis Doctoral.', 5,0,1);--Id=22
INSERT INTO tblActividad VALUES(3,'Dirección proyecto externo.', 5,0,1);--Id=23
INSERT INTO tblActividad VALUES(3,'Participación en Comité editorial ACOFI', 5,0,1);--Id=24
INSERT INTO tblActividad VALUES(3,'Director Tesis Doctoral.', 5,0,1);--Id=25
INSERT INTO tblActividad VALUES(3,'Comité Editorial EPN.', 5,0,1);--Id=26
INSERT INTO tblActividad VALUES(3,'Estudiante Doctorado.', 5,0,1);--Id=27
INSERT INTO tblActividad VALUES(4,'Miembro alterno Comisión de Evaluación Interna CEI.', 5,0,1);--Id=28
INSERT INTO tblActividad VALUES(4,'Comisión de exámenes de autoevaluación.', 5,0,1);--Id=29
INSERT INTO tblActividad VALUES(4,'CODEI.', 5,0,1);--Id=30
INSERT INTO tblActividad VALUES(4,'Vicerrectorado de Docencia.', 5,0,1);--Id=31
INSERT INTO tblActividad VALUES(4,'Coordinador - Comisión de Diseño de Maestría Profesional.', 5,0,1);--Id=32
INSERT INTO tblActividad VALUES(4,'Representante de profesores ante Consejo de Facultad.', 5,0,1);--Id=33
INSERT INTO tblActividad VALUES(4,'Comisión de Vinculación y Promoción DETRI.',5,0,1);--Id=34
INSERT INTO tblActividad VALUES(4,'Responsable de Club', 5,0,1);--Id=35
INSERT INTO tblActividad VALUES(4,'Administración de Laboratorio.', 5,0,1);--Id=36
INSERT INTO tblActividad VALUES(4,'Comisión de propuesta de Maestría Profesional.', 5,0,1);--Id=37
INSERT INTO tblActividad VALUES(4,'Comisión de Unidad de Titulación de Posgrado.', 5,0,1);--Id=38
INSERT INTO tblActividad VALUES(4,'Comision Nueva Carrera.', 5,0,1);--Id=39
INSERT INTO tblActividad VALUES(4,'Technical Chair - ETCM.', 5,0,1);--Id=40
INSERT INTO tblActividad VALUES(4,'Coordinador - Maestría.', 5,0,1);--Id=41
INSERT INTO tblActividad VALUES(4,'Coordinador de Carrera.', 5,0,1);--Id=42,0
INSERT INTO tblActividad VALUES(4,'Comisión de propuesta de nueva Carrera.', 5,0,1);--Id=43
INSERT INTO tblActividad VALUES(4,'Representante de la FIEE a la ESFOT.', 5,0,1);--Id=44
INSERT INTO tblActividad VALUES(4,'Comisión Permanente de Gestión de Integración Curricular CPGIC', 5,0,1);--Id=45
INSERT INTO tblActividad VALUES(4,'Consejo de Departamento DETRI.', 5,0,1);--Id=46
INSERT INTO tblActividad VALUES(4,'Coordinador CPPP.', 5,0,1);--Id=47
INSERT INTO tblActividad VALUES(4,'Coordinación de Maestría.', 5,0,1);--Id=48
INSERT INTO tblActividad VALUES(4,'Director de Docencia.', 5,0,1);--Id=49
INSERT INTO tblActividad VALUES(4,'Comisión de Seguimiento a Graduados.', 5,0,1);--Id=50
INSERT INTO tblActividad VALUES(4,'Unidad de Mantenimiento electrónico (UME).', 5,0,1);--Id=51
INSERT INTO tblActividad VALUES(4,'Decanato FIEE.', 5,0,1);--Id=52
INSERT INTO tblActividad VALUES(4,'Comisión de Examen de Fin de Carrera.', 5,0,1);--Id=53
INSERT INTO tblActividad VALUES(4,'Miembro Consejo de Departamento.', 5,0,1);--Id=54
INSERT INTO tblActividad VALUES(4,'Comisión de Prácticas preprofesionales FIEE.', 5,0,1);--Id=55
INSERT INTO tblActividad VALUES(4,'Comisión de Trabajo de Titulación.', 5,0,1);--Id=56
INSERT INTO tblActividad VALUES(4,'Miembro comité doctoral.', 5,0,1);--Id=57
INSERT INTO tblActividad VALUES(4,'Director de Investigación.', 5,0,1);--Id=58
INSERT INTO tblActividad VALUES(4,'Directora de la ESFOT.', 5,0,1);--Id=59
INSERT INTO tblActividad VALUES(4,'Jefe del DETRI.', 5,0,1);--Id=60
INSERT INTO tblActividad VALUES(4,'Apoyo a las actividades de gestión.', 5,0,1);--Id=61
INSERT INTO tblActividad VALUES(4,'Colaboración en la Comisión de Prácticas Preprofesionales y Pasantías.', 5,0,1);--Id=62
INSERT INTO tblActividad VALUES(4,'Otras actividades.', 5,0,1);--Id=63
GO
--  TABLA: Asignaturas   DATOS    (nombreAsignatura,'tipoAsignatura','codigoAsignatura',horasAsignaturaTotales,horasAsignaturaSemanales,nivelAsignatura, estadoAsignatura)
--INSERTAR DATOS EN MATERIA---
--Malla TICs
INSERT INTO tblAsignatura(nombreAsignatura,tipoAsignatura,codigoAsignatura,horasAsignaturaTotales,horasAsignaturaSemanales,
						nivelAsignatura,estadoAsignatura)
VALUES
('TEORÍA DE INFORMACIÓN Y CODIFICACIÓN','Semestral','TELD522',96,3,'Tercer Nivel',1),
('DISEÑO Y PROGRAMACIÓN DE SOFTWARE','Semestral','ITID543',144,5,'TercerNivel',1),
('SISTEMAS EMBEBIDOS','Semestral','ITID553',144,5,'TercerNivel',1),
('GESTIÓN ORGANIZACIONAL','Semestral','ADMD511',48,2,'TercerNivel',1),
('CABLEADO ESTRUCTURADO AVANZADO','Semestral','ITID612',96,3,'TercerNivel',1),
('REDES DE ÁREA LOCAL','Semestral','ITID623',144,5,'TercerNivel',1),
('ENRUTAMIENTO','Semestral','ITID633',144,5,'TercerNivel',1),
('SISTEMAS INALÁMBRICOS','Semestral','ITID643',144,5,'TercerNivel',1),
('ALMACENAMIENTO Y PROCESAMIENTO DE DATOS','Semestral','ITID653',144,5,'TercerNivel',1),
('GESTIÓN DE PROCESOS Y CALIDAD','Semestral','ADMD611',48,2,'TercerNivel',1),
('APLICACIONES DISTRIBUIDAS','Semestral','ITID713',144,5,'TercerNivel',1),
('REDES DE ÁREA EXTENDIDA','Semestral','ITID723',144,5,'TercerNivel',1),
('SEGURIDAD EN REDES','Semestral','ITID733',144,5,'TercerNivel',1),
('REDES E INTRANETS','Semestral','ITID742',96,3,'TercerNivel',1),
('APLICACIONES WEB Y MÓVILES','Semestral','ITID753',144,5,'TercerNivel',1),
('INGENIERÍA FINANCIERA','Semestral','ADMD711',48,2,'TercerNivel',1),
('ASIGNATURA BÁSICA DE ITINERARIO','Semestral','ITID800',96,3,'TercerNivel',1),
('EVALUACIÓN DE REDES','Semestral','ITID822',96,3,'TercerNivel',1),
('REDES DE ÁREA LOCAL INALÁMBRICAS','Semestral','ITID832',96,3,'TercerNivel',1),
('ADMINISTRACIÓN DE REDES','Semestral','ITID843',144,5,'TercerNivel',1),
('MINERÍA DE DATOS','Semestral','ITID853',96,3,'TercerNivel',1),
('SISTEMAS IoT','Semestral','ITID862',96,3,'TercerNivel',1),
('DISEÑO DE TRABAJO DE INTEGRACIÓN CURRICULAR/PREPARACIÓN EXAMEN DE CARÁCTER COMPLEXIVO','Semestral','ITID871',48,2,'TercerNivel',1),
('ASIGNATURA AVANZADA DE ITINERARIO','','ITID900',96,3,'TercerNivel',1),
('REGULACIÓN DE LAS TECNOLOGÍAS DE LA INFORMACIÓN Y LA COMUNICACIÓN','Semestral','ITID941',48,2,'TercerNivel',1),
('TRABAJO DE INTEGRACIÓN CURRICULAR/ EXAMEN DE CARÁCTER COMPLEXIVO','Semestral','TITD201',240,15,'TercerNivel',1)

GO
--Malla Telecomunicaciones
INSERT INTO tblAsignatura(nombreAsignatura,tipoAsignatura,codigoAsignatura,horasAsignaturaTotales,horasAsignaturaSemanales,
						nivelAsignatura,estadoAsignatura)
VALUES
('CIRCUITOS ELECTRÓNICOS','Semestral','IEED433',144,5,'TercerNivel',1),
('SISTEMA OPERATIVO LINUX','Semestral','TELD452',96,3,'TercerNivel',1),
('FUNDAMENTOS DE COMUNICACIONES','Semestral','TELD513',144,5,'TercerNivel',1),
('PROCESAMIENTO DIGITAL DE SEÑALES','Semestral','TELD532',96,3,'TercerNivel',1),
('SISTEMAS DE TRANSMISIÓN','Semestral','TELD553',144,5,'TercerNivel',1),
('COMUNICACIÓN DIGITAL','Semestral','TELD613',144,5,'TercerNivel',1),
('TELEMÁTICA BÁSICA','Semestral','TELD623',144,5,'TercerNivel',1),
('ELECTRÓNICA DE RADIOFRECUENCIA','Semestral','TELD633',144,5,'TercerNivel',1),
('APLICACIONES CON SISTEMAS EMBEBIDOS','Semestral','TELD642',96,3,'TercerNivel',1),
('PROPAGACIÓN Y ANTENAS','Semestral','TELD654',144,5,'TercerNivel',1),
('COMUNICACIONES ÓPTICAS','Semestral','TELD713',144,5,'TercerNivel',1),
('TELEMÁTICA AVANZADA','Semestral','TELD723',144,5,'TercerNivel',1),
('COMUNICACIONES INALÁMBRICAS','Semestral','TELD733',144,5,'TercerNivel',1),
('TELEFONÍA IP','Semestral','TELD743',144,5,'TercerNivel',1),
('INGENIERÍA DE MICROONDAS','Semestral','TELD752',96,3,'TercerNivel',1),
('ITINERARIO BÁSICO','Semestral','TELD800',96,3,'TercerNivel',1),
('REDES ÓPTICAS','Semestral','TELD823',144,5,'TercerNivel',1),
('INTRODUCCIÓN A DISEÑO DE REDES','Semestral','TELD833',144,5,'TercerNivel',1),
('SISTEMAS CELULARES','Semestral','TELD843',144,5,'TercerNivel',1),
('FUNDAMENTOS DE SEGURIDAD','Semestral','TELD852',96,3,'TercerNivel',1),
('DISEÑO DE PROYECTOS DE TELECOMUNICACIONES','Semestral','TELD871',48,2,'TercerNivel',1),
('ITINERARIO AVANZADO','Semestral','TELD900',96,3,'TercerNivel',1),
('MARCO REGULATORIO DE LOS SERVICIOS DE TELECOMUNICACIONES','Semestral','TELD941',48,2,'TercerNivel',1)
GO
--AGREGAR GRUPOS A ASIGNATURAS
INSERT INTO tblGrAsignatura(idAsignatura,grupoAsignatura)
VALUES
--TI Carreer
(1, 'GR1'),--TEORÍA DE INFORMACIÓN Y CODIFICACIÓN
(2, 'GR1'),--DISEÑO Y PROGRAMACIÓN DE SOFTWARE
(3, 'GR1'),--SISTEMAS EMBEBIDOS{..
(3, 'GR2'),--.. }
(4, 'GR1'),--GESTIÓN ORGANIZACIONAL{..
(4, 'GR2'),--
(4, 'GR3'),--
(4, 'GR4'),--..}
(5, 'GR1'),--CABLEADO ESTRUCTURADO AVANZADO
(6, 'GR1'),--REDES DE ÁREA LOCAL
(7, 'GR1'),--ENRUTAMIENTO
(8, 'GR1'),--SISTEMAS INALÁMBRICOS
(9, 'GR1'),--ALMACENAMIENTO Y PROCESAMIENTO DE DATOS
(10, 'GR1'),--GESTIÓN DE PROCESOS Y CALIDAD{...
(10, 'GR2'),--
(10, 'GR3'),--..}
(11, 'GR1'),--APLICACIONES DISTRIBUIDAS
(12, 'GR1'),--REDES DE ÁREA EXTENDIDA
(13, 'GR1'),--SEGURIDAD EN REDES
(14, 'GR1'),--REDES E INTRANETS
(15, 'GR1'),--APLICACIONES WEB Y MÓVILES
(16, 'GR1'),--INGENIERÍA FINANCIERA{...
(16, 'GR2'),--
(16, 'GR3'),--..}
--(17, 'GR1'),--ASIGNATURA BÁSICA DE ITINERARIO  ???????
(18, 'GR1'),--EVALUACIÓN DE REDES
(19, 'GR1'),--REDES DE ÁREA LOCAL INALÁMBRICAS
(20, 'GR1'),--ADMINISTRACIÓN DE REDES
(21, 'GR1'),--MINERÍA DE DATOS
(22, 'GR1'),--SISTEMAS IoT
--(23, 'GR1'),--REDES DE ÁREA LOCAL INALÁMBRICAS
--(24, 'GR1'),--ADMINISTRACIÓN DE REDES
(25, 'GR1')--REGULACIÓN DE LAS TECNOLOGÍAS DE LA INFORMACIÓN Y LA COMUNICACIÓN


-- END SCRIPT