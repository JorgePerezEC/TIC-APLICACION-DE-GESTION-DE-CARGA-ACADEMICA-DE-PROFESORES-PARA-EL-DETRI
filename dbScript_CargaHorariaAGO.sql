--------------------------------------------
-- Author: Jorge P�rez
-- Description: Script to create database for Academic Load in DETRI Department
-- Database Name: dbCargaHorariaData
--------------------------------------------
--------------------------------------------
-- PRESS F5 to Execute entire script
--------------------------------------------
USE master
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'dbCargaHorariaAgo')
BEGIN
    DROP DATABASE dbCargaHorariaAgo;
END
GO
PRINT 'Creating DB';
CREATE DATABASE dbCargaHorariaAgo;
GO
USE dbCargaHorariaAgo;

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
	a�oSemestre int NOT NULL,
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
--CREATE TABLE tblTipoAsignatura (
--	idTpAsig int  NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--	nombreTpAct varchar(20) NOT NULL,
--	descripcionTpAct varchar(255) NOT NULL
--);
GO
-- Table: Asignatura
CREATE TABLE tblAsignatura (
	idAsignatura int  NOT NULL IDENTITY(1, 1),--PK
	idCarrera int NOT NULL, --FK
	nombreAsignatura varchar(150) NOT NULL,
	tipoAsignatura varchar(50) NOT NULL,
	codigoAsignatura varchar(30) NOT NULL,
	horasAsignaturaTotales int NOT NULL,
	horasAsignaturaSemanales int NOT NULL,
	nivelAsignatura varchar(50) NOT NULL,
	estadoAsignatura bit NOT NULL,
	FOREIGN KEY (idCarrera) REFERENCES tblCarrera(idCarrera) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
    CONSTRAINT PK_Asignatura PRIMARY KEY  (idAsignatura)
);
GO
-- Table: AsignaturaCarrera intermedia
CREATE TABLE tblAsigCarrera(
	idAsigCarrera int  NOT NULL IDENTITY(1, 1),
	idCarrera int NOT NULL,
	idAsignatura int NOT NULL,--FK 
	estadoAsigCarrera bit NOT NULL,
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
-- Table: SemestreGrupoAsignatura intermedia
CREATE TABLE tblSemestreGrAsignatura (
    idSemestreGrAsignatura int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    idSemestre int NOT NULL,
    idGrAsig int NOT NULL,
	isActive bit NOT NULL,
    CONSTRAINT FK_SemestreGrAsignatura_Semestre FOREIGN KEY (idSemestre) REFERENCES tblSemestre(idSemestre) ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT FK_SemestreGrAsignatura_GrAsignatura FOREIGN KEY (idGrAsig) REFERENCES tblGrAsignatura(idGrAsig) ON UPDATE NO ACTION ON DELETE NO ACTION
);
GO
-- Table: SemestreAsignatura intermedia
CREATE TABLE tblSemestreAsignatura (
    idSemestreAsignatura int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    idSemestre int NOT NULL,
    idAsignatura int NOT NULL,
	isActive bit NOT NULL,
    CONSTRAINT FK_SemestreAsignatura_Semestre FOREIGN KEY (idSemestre) REFERENCES tblSemestre(idSemestre) ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT FK_SemestreAsignatura_Asignatura FOREIGN KEY (idAsignatura) REFERENCES tblAsignatura(idAsignatura) ON UPDATE NO ACTION ON DELETE NO ACTION
);
GO
-- Tabla: TipoDocenteSemestre intermedia
CREATE TABLE tblTipoDocenteSemestre (
    idTipoDocenteSemestre int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    idTipoDocente int NOT NULL,
    idSemestre int NOT NULL,
    numHorasSemestrales int NOT NULL,
    CONSTRAINT FK_TipoDocenteSemestre_TipoDocente FOREIGN KEY (idTipoDocente) REFERENCES tblTipoDocente(idTipoDocente) ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT FK_TipoDocenteSemestre_Semestre FOREIGN KEY (idSemestre) REFERENCES tblSemestre(idSemestre) ON UPDATE NO ACTION ON DELETE NO ACTION
);
--GO
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
CREATE OR ALTER PROCEDURE [dbo].[spAddCarrera]
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
CREATE OR ALTER PROCEDURE [dbo].[spAddSemestre]
	@codSmstr	varchar(50),
	@yrSmstr int,
	@dIni date,
	@dFin date,
	@nSemanaClase int,
	@nSemanaSemestre int
AS
	BEGIN 
		INSERT INTO tblSemestre(codigoSemestre,a�oSemestre,diaInicio, diaFin,
		numSemanasClase,numSemanasSemestre,estadoSemestre)
		VALUES(@codSmstr, @yrSmstr, @dIni, @dFin, @nSemanaClase, @nSemanaSemestre, 1)
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
		INSERT INTO tblAsigCarrera(idCarrera,idAsignatura,estadoAsigCarrera)
		VALUES(@idCarrera,@idAsig,@state)
	END
GO
---- Stored Procedure to create one row into  "tblSemestreDocente"
CREATE OR ALTER PROCEDURE [dbo].[spAddOrUpdateSemestreTpDocente]
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
---- Stored Procedure to create or update one row into  "tblSemestreAsignatura"
CREATE OR ALTER PROCEDURE [dbo].[spAddOrUpdateSemestreAsignatura]
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
CREATE OR ALTER PROCEDURE [dbo].[spAddActividad]
	@idTpAct int,
	@nameAct varchar(255),
	@horasAct int,
	@horasTAct int
AS
	BEGIN 
		INSERT INTO tblActividad(idTpAct_f,nombreActividad,cantHoraSemana,cantHoraTotal, estadoActividad)
		VALUES(@idTpAct, @nameAct, @horasAct,@horasTAct,1)
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
    SELECT idDepartamento AS ID, nombreDepartamento AS 'Nombre del Departamento', emailDepartamento AS 'Correo electr�nico del Departamento'
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
	codigoAsignatura AS 'C�digo',horasAsignaturaTotales AS 'Horas Totales', horasAsignaturaSemanales AS 'Horas Semanales',
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
@idSemestre int
AS 
BEGIN 
 --   SELECT DISTINCT a.idAsignatura AS ID, a.nombreAsignatura AS Asignatura
 --   FROM tblAsignatura a
 --   INNER JOIN tblGrAsignatura g ON a.idAsignatura = g.idAsignatura
 --   LEFT JOIN tblAsigCrgHoraria c ON g.idGrAsig = c.idGrAsig
	--LEFT JOIN tblSemestreAsignatura sa ON a.idAsignatura = sa.idAsignatura
 --   WHERE c.idAsigCrgHoraria IS NULL AND g.grupoAsignatura IS NOT NULL AND sa.isActive = 1
	--ORDER BY a.nombreAsignatura ASC
	SELECT DISTINCT a.idAsignatura AS ID,  CONCAT(a.codigoAsignatura,' - ',a.nombreAsignatura) AS Asignatura
    FROM tblAsignatura a
    INNER JOIN tblGrAsignatura g ON a.idAsignatura = g.idAsignatura
    LEFT JOIN tblAsigCrgHoraria c ON g.idGrAsig = c.idGrAsig
	LEFT JOIN tblSemestreAsignatura sa ON a.idAsignatura = sa.idAsignatura
    WHERE c.idAsigCrgHoraria IS NULL AND g.grupoAsignatura IS NOT NULL AND sa.isActive = 1 AND sa.idSemestre = @idSemestre
	ORDER BY Asignatura ASC
END
GO
-- Stored Procedure to Read All Rows from  "tblAsignaturas" where had Groups
IF OBJECT_ID('spReadAllAsignaturasWGroups_ByCarrera') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllAsignaturasWGroups_ByCarrera]
END 
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
	SELECT DISTINCT a.idAsignatura AS ID,   CONCAT(a.codigoAsignatura,' - ',a.nombreAsignatura) AS Asignatura
    FROM tblAsignatura a
    INNER JOIN tblGrAsignatura g ON a.idAsignatura = g.idAsignatura
    LEFT JOIN tblAsigCrgHoraria c ON g.idGrAsig = c.idGrAsig
	LEFT JOIN tblSemestreAsignatura sa ON a.idAsignatura = sa.idAsignatura
    WHERE c.idAsigCrgHoraria IS NULL AND g.grupoAsignatura IS NOT NULL AND sa.isActive = 1 AND sa.idSemestre = @idSemestre
	AND a.idCarrera = @idCarrera
	ORDER BY Asignatura ASC
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
	ORDER BY a.nombreAsignatura ASC
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
		gr.horaInicio AS 'Hora de Inicio', gr.horaFin AS 'Hora de Fin', gr.dia AS 'D�a'
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
    SELECT idTpAct AS ID,nombreTpAct AS 'Tipo de Actividad', descripcionTpAct AS 'Descripci�n'
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
    SELECT idCarrera AS ID,dep.nombreDepartamento AS 'Departamento', nombreCarrera AS 'Carrera', codigoCarrera AS 'C�digo',
			pensum AS 'Pensum'
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
-- Stored Procedure to Read All rows from  "tblTipoDocente"
CREATE OR ALTER PROCEDURE [dbo].[spReadTipoDocentesCmb]
AS 
BEGIN 
    SELECT idTipoDocente AS ID,nombreTipoDocente AS 'TipoDocente'
    FROM   tblTipoDocente
END
GO
-- Stored Procedure to Read All rows from  "tblDocente"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllDocentes]
AS 
BEGIN 
    SELECT idDocente AS ID,dep.nombreDepartamento AS 'Departamento', CONCAT(nombre1Docente, ' ', nombre2Docente) Nombres,
			CONCAT(apellido1Docente, ' ', apellido2Docente) Apellidos,tituloDocente AS 'T�tulo'
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
-- Stored Procedure to Get Docente Type Name from  "tblCargaHoraria" based on idCargaHoraria
CREATE OR ALTER PROCEDURE [dbo].[spGetDocenteNameTypeByCrgHoraria]
@idCrgHoraria int,
@idSemestre int
AS 
BEGIN 
    SELECT td.nombreTipoDocente
	FROM tblCargaHoraria ch
	INNER JOIN tblDocente doc ON ch.idDocente = doc.idDocente
	INNER JOIN tblSemestreTpDocente std ON doc.idDocente = std.idDocente
	INNER JOIN tblTipoDocente td ON std.idTipoDoc = td.idTipoDocente
	WHERE ch.idCargaHoraria = @idCrgHoraria and  std.idSemestre =@idSemestre
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
-- Stored Procedure to Read All rows from  "tblDocente"
CREATE OR ALTER PROCEDURE [dbo].[spReadDocentesNamesWHorasExigibles]
@idSemestre int
AS 
BEGIN 
    SELECT D.idDocente AS ID, CONCAT(D.apellido1Docente, ' ', D.apellido2Docente,' ', D.nombre1Docente, ' ', D.nombre2Docente) NombreDocente
    FROM   tblSemestreTpDocente STP
	INNER JOIN tblDocente D ON STP.idDocente = D.idDocente
	WHERE STP.estadoSemestreDoc = 1 AND STP.idSemestre = @idSemestre AND STP.numHorasSemestrales > 0
	ORDER BY NombreDocente ASC
END
GO
-- Stored Procedure to Read All rows from  "tblSemestreTpDocente"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllSmstreTpDocenteBySemestre]
	@idSemestre int
AS 
BEGIN 
    SELECT STP.idDocente AS ID, CONCAT(D.apellido1Docente, ' ', D.apellido2Docente,' ', D.nombre1Docente, ' ', D.nombre2Docente) NombreDocente,
		STP.estadoSemestreDoc, STP.idTipoDoc
    FROM   tblSemestreTpDocente STP
	INNER JOIN tblDocente D ON STP.idDocente = D.idDocente
	INNER JOIN tblTipoDocente TD ON STP.idTipoDoc = TD.idTipoDocente
	WHERE STP.idSemestre = @idSemestre
	ORDER BY NombreDocente ASC
END
GO
-- Stored Procedure to Read All rows from  "tblSemestreTpDocente"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllSmstreAsignaturaBySemestre]
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
-- Stored Procedure to Read All rows from  "tblSemestre"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllSemestres]
AS 
BEGIN 
    SELECT idSemestre AS ID,codigoSemestre AS 'C�digo',a�oSemestre AS 'A�o',
		diaInicio AS 'Fecha Inicio', diaFin AS 'Fecha Fin', numSemanasClase AS 'Semanas de Clase',
		numSemanasSemestre AS 'Semanas Totales del Semestre'
    FROM   tblSemestre
	WHERE estadoSemestre = 1
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
CREATE OR ALTER PROCEDURE [dbo].[spUpdateCarrera]
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
CREATE OR ALTER PROCEDURE [dbo].[spUpdateSemestre]
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
		SET codigoSemestre = @codSmstr, a�oSemestre= @yrSmstr, diaInicio =@dIni,
			diaFin = @dFin, numSemanasClase = @nSemanaClase, numSemanasSemestre = @nSemanaSemestre,
			estadoSemestre = 1
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
		SET idCarrera = @idCarrera, idAsignatura= @idAsig, estadoAsigCarrera = @state
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
CREATE OR ALTER PROCEDURE [dbo].[spUpdateActividad]
	@id int,
	@idTpAct int,
	@nameAct varchar(255),
	@horasAct int,
	@horasTAct int
AS
	BEGIN
		UPDATE tblActividad
		SET idTpAct_f = @idTpAct, nombreActividad = @nameAct, cantHoraSemana = @horasAct,
			cantHoraTotal = @horasTAct ,estadoActividad = 1
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
		INSERT INTO tblAsigCarrera(idCarrera,idAsignatura,estadoAsigCarrera)
		VALUES(@idCarrera,@idAsig,@state)
		DELETE FROM tblAsigCarrera 
		WHERE (idCarrera = @idCarrera AND idAsignatura = @idAsig AND estadoAsigCarrera = @state)
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
	@idAsignatura varchar(150)
AS 
BEGIN 
    SELECT gr.idAsignatura AS ID, gr.grupoAsignatura AS Grupos
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
CREATE OR ALTER PROCEDURE [dbo].[spDocentesByIdDepaWHorasExigiblesTV]
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
			WHERE ch.idSemestre = @idSemestre 
			AND doc.idDepa = @idDepa 
			and std.idSemestre = @idSemestre
			AND std.estadoSemestreDoc = 1
		) AS subquery
		GROUP BY ID, Docente, codigoSemestre
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
CREATE OR ALTER PROCEDURE [dbo].[spReadAllCargas]
@idSemestre int
AS
BEGIN 
	SET NOCOUNT ON;

	SELECT ch.idCargaHoraria AS ID,CONCAT(d.apellido1Docente, ' ', d.apellido2Docente, ' ', d.nombre1Docente, ' ', d.nombre2Docente) AS Docente
	FROM tblCargaHoraria ch
	INNER JOIN tblDocente d ON ch.idDocente = d.idDocente
	INNER JOIN tblSemestreTpDocente std ON std.idDocente = d.idDocente
	WHERE ch.idSemestre = @idSemestre
		AND std.estadoSemestreDoc = 1 AND std.numHorasSemestrales > 0 AND std.idSemestre = @idSemestre
		AND std.estadoSemestreDoc = 1
	ORDER BY Docente;
END
GO
-- Stored Procedure to Read all Asignaturas from a Specifica Academic Load from tblAsigCrgHoraria
CREATE OR ALTER PROCEDURE [dbo].[spReadAllCargaAsignaturas]
@idCrgHoraria int
AS
BEGIN 
	SELECT interAsig.idAsigCrgHoraria AS ID,asig.tipoAsignatura AS TIPO,ASIG.codigoAsignatura as C�DIGO,gr.grupoAsignatura as GR,asig.nombreAsignatura AS 'ASIGNATURA',
		asig.horasAsignaturaSemanales AS 'HORAS SEMANALES', asig.horasAsignaturaTotales AS 'HORAS TOTALES'
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
	SELECT interAsig.idAsigCrgHoraria AS ID,asig.codigoAsignatura AS 'C�digo',asig.nombreAsignatura AS 'Asignatura',gr.grupoAsignatura as GR,
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
CREATE OR ALTER PROCEDURE [dbo].[spGetLevelAsignatura]
@idAsignatura int
AS
BEGIN 
	SELECT nivelAsignatura FROM tblAsignatura
	WHERE idAsignatura = @idAsignatura
END
GO
-- Stored Procedure to get Asignature type from tblAsignatura based on Asignature Name
CREATE OR ALTER PROCEDURE [dbo].[spGetTypeAsignatura]
@idAsignatura int
AS
BEGIN 
	SELECT tipoAsignatura FROM tblAsignatura
	WHERE idAsignatura = @idAsignatura
END
GO
-- Stored Procedure to get Asignature Code from tblAsignatura based on Asignature Name
CREATE OR ALTER PROCEDURE [dbo].[spGetCodeAsignatura]
@idAsignatura int
AS
BEGIN 
	SELECT codigoAsignatura FROM tblAsignatura
	WHERE idAsignatura = @idAsignatura
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
--test--
--exec CopiarAllCargasAcademicasConNuevoSemestre 2, 4
---
-- Stored Procedure to copy ALL data from other semester to another semester
CREATE OR ALTER PROCEDURE CopiarAllCargasAcademicasConNuevoSemestre
    @idSemestreExistente int,
    @idSemestreNuevo int
AS
BEGIN
    -- Insertar las nuevas cargas acad�micas con el semestre especificado
    INSERT INTO tblCargaHoraria (idDocente, idSemestre)
    SELECT idDocente, @idSemestreNuevo
    FROM tblCargaHoraria
    WHERE idSemestre = @idSemestreExistente;

    -- Obtener los ID de las nuevas cargas acad�micas insertadas
    DECLARE @idCargaAcademicaExistente int;
    DECLARE @idCargaAcademicaNueva int;
    SET @idCargaAcademicaExistente = (SELECT MIN(idCargaHoraria) FROM tblCargaHoraria WHERE idSemestre = @idSemestreExistente);
    SET @idCargaAcademicaNueva = (SELECT MAX(idCargaHoraria) FROM tblCargaHoraria WHERE idSemestre = @idSemestreNuevo);

    -- Copiar las asignaturas de las cargas acad�micas existentes a las nuevas cargas acad�micas
    INSERT INTO tblAsigCrgHoraria (idCrgHoraria, idGrAsig, estadoAsigCrgDocencia)
    SELECT @idCargaAcademicaNueva, idGrAsig, estadoAsigCrgDocencia
    FROM tblAsigCrgHoraria
    WHERE idCrgHoraria = @idCargaAcademicaExistente;

    -- Copiar las actividades de las cargas acad�micas existentes a las nuevas cargas acad�micas
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
        WHEN (std.numHorasSemestrales - (COALESCE(dh.horasActividadDocencia, 0) + COALESCE(sh.horasActividadSemestre, 0) + COALESCE(dh.horasActividadGestion, 0) + COALESCE(sh.horasActividadGestionSemestre, 0) + COALESCE(dh.horasActividadInvestigacion, 0) + COALESCE(sh.horasActividadInvestigacionSemestre, 0))) < 0 THEN 'HORAS SOBRANTES'
		WHEN crg.idCargaHoraria IS NULL THEN 'CARGA ACAD�MICA INEXISTENTE'
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
--SP TO GET IDs CARGA HORARIA By SEMESTRE TO EXPORT PDFs
CREATE OR ALTER PROCEDURE [dbo].[spGetIdCargaHorariaLst_BySemestre]
@idSemestre int
AS
BEGIN 
	SELECT DISTINCT ch.idCargaHoraria AS id, std.estadoSemestreDoc
	FROM tblCargaHoraria ch
	INNER JOIN tblSemestreTpDocente std ON ch.idDocente = std.idDocente
	WHERE ch.idSemestre = @idSemestre
	AND std.estadoSemestreDoc = 1
	ORDER BY id
END
GO
--SP TO GET ACTIVIDADES D11 y F11 DE CARGA HORARIA By SEMESTRE TO REPORT
CREATE OR ALTER PROCEDURE [dbo].[spGetActividadesD11D_BySemestre_Reporte]
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
--SP TO GET ACTIVIDADES DE COMISIONES G y I DE CARGA HORARIA By SEMESTRE TO REPORT
CREATE OR ALTER PROCEDURE [dbo].[spGetActividadesComisiones_BySemestre_Reporte]
@idSemestre int
AS
BEGIN 
	SELECT ac.idActivCrgs AS ID, ta.nombreTpAct AS TIPO,a.nombreActividad AS 'ACTIVIDAD'
	, CONCAT(d.apellido1Docente, ' ', d.apellido2Docente, ' ', d.nombre1Docente, ' ', d.nombre2Docente) AS 'DOCENTE ASIGNADO', 
	(CASE WHEN ac.horaTotal = 0 THEN ac.horasSemana * s.numSemanasClase * 2 WHEN ac.horasSemana = 0 THEN ac.horaTotal  ELSE 0 END) AS 'HORAS TOTALES'
	FROM tblActividadCargas ac
	LEFT JOIN tblCargaHoraria ch ON ac.idCrgHoraria = ch.idCargaHoraria
	INNER JOIN tblActividad a ON ac.idActividad = a.idActividad
	INNER JOIN tblTipoActividad ta ON a.idTpAct_f = ta.idTpAct
	INNER JOIN tblDocente d ON ch.idDocente = d.idDocente
	INNER JOIN tblSemestre s ON ch.idSemestre = s.idSemestre
	WHERE ch.idSemestre = @idSemestre
	AND (a.idTpAct_f = 3 OR a.idTpAct_f = 4)
	ORDER BY TIPO
END
GO
--SP TO GET DATA TO EXPORT PDFs
CREATE OR ALTER PROCEDURE [dbo].[spGetDocentesLst_CargaAcademica_BySemestre_To_Pdf]
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
-- Stored Procedure to Get Asignaturas with Docente Name from  "tblAsigCrgHoraria"
CREATE OR ALTER PROCEDURE [dbo].[spGetAsignaturaGrBySemestreWithDocente_Reporte]
	@idSemestre int
AS 
BEGIN 
    SELECT ach.idAsigCrgHoraria AS ID,a.codigoAsignatura AS C�DIGO,ga.grupoAsignatura AS GRUPO ,a.nombreAsignatura AS ASIGNATURA,a.tipoAsignatura AS TIPO, 
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
-- Stored Procedure to Get Asignaturas without Docente from  "tblAsigCrgHoraria"
CREATE OR ALTER PROCEDURE [dbo].[spGetAsignaturaGrBySemestreWithOutDocente_Reporte]
	@idSemestre int
AS 
BEGIN 
    SELECT a.idAsignatura AS ID, a.codigoAsignatura AS C�DIGO, ga.grupoAsignatura AS GRUPO, a.nombreAsignatura AS ASGINATURA, a.tipoAsignatura AS TIPO
FROM tblAsignatura a
INNER JOIN tblGrAsignatura ga ON a.idAsignatura = ga.idAsignatura
WHERE a.idAsignatura IN (
    SELECT sa.idAsignatura
    FROM tblSemestreAsignatura sa
    WHERE sa.isActive = 1 AND sa.idSemestre = @idSemestre
) AND ga.idGrAsig NOT IN (
    SELECT ach.idGrAsig
    FROM tblAsigCrgHoraria ach
)
ORDER BY ASGINATURA ASC
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
--Trigger to recalculate hours of the DOCENCIA component of an academic load when adding a subject
CREATE TRIGGER tr_recalcularHorasDocencia_CargaH
ON tblAsigCrgHoraria
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @id_CargaH INT;
	DECLARE @horasSemanalesAsignaturas INT;
	DECLARE @horasTotalesAsigModulares INT;
	DECLARE @horaSemana1 INT;
	DECLARE @horaSemana2 INT;
	DECLARE @horaSemana3 INT;
	DECLARE @horaSemana4 INT;

	DECLARE @horaSemana1Mod INT;
	DECLARE @horaSemana2Mod INT;
	DECLARE @horaSemana3Mod INT;
	DECLARE @horaSemana4Mod INT;
	-- Se recupera el id de la Carga Horaria
    SELECT @id_CargaH = idCrgHoraria
    FROM inserted;

	-- Se obtiene la suma de horasAsignatura semestrales mediante el procedimiento almacenado
	SELECT @horasSemanalesAsignaturas = COALESCE(SUM(asig.horasAsignaturaSemanales),0)
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr  on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig on gr.idAsignatura = asig.idAsignatura
	WHERE (interAsig.idCrgHoraria = @id_CargaH AND (asig.tipoAsignatura='Semestral'));

	SELECT @horasTotalesAsigModulares = COALESCE(SUM(asig.horasAsignaturaTotales),0)
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr  on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig on gr.idAsignatura = asig.idAsignatura
	WHERE (interAsig.idCrgHoraria = @id_CargaH AND (asig.tipoAsignatura='Modular'));
	
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

	-- Distribuir horas en variables  -SEMESTRALES
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

	DECLARE @horasPorActividadModular DECIMAL(10, 2);
    SET @horasPorActividadModular = CAST(@horasTotalesAsigModulares / 4.0 AS DECIMAL(10, 2));
    
    -- Distribuir horas en variables  -MODULAR
	IF @horasTotalesAsigModulares > 0
		BEGIN
			SET @horaSemana1Mod = CEILING(@horasPorActividadModular);
			IF @horaSemana1Mod <= 0 SET @horaSemana1Mod = 0;
			SET @horaSemana2Mod = FLOOR(@horasPorActividadModular);
			IF @horaSemana2Mod <= 0 SET @horaSemana2Mod = 0;
			SET @horaSemana3Mod = FLOOR(@horasPorActividadModular);
			IF @horaSemana3Mod <= 0 SET @horaSemana3Mod = 0;
			SET @horaSemana4Mod = @horasTotalesAsigModulares - @horaSemana1Mod - @horaSemana2Mod - @horaSemana3Mod;
			IF @horaSemana4Mod <= 0 SET @horaSemana4Mod = 0;
		END
    ELSE
		BEGIN
			SET @horaSemana1Mod = 0;
			SET @horaSemana2Mod = 0;
			SET @horaSemana3Mod = 0;
			SET @horaSemana4Mod = 0;
		END

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

	-- Recalcular horas de actividades de Docencia por defecto PARA ASIG MODULARES
	UPDATE tblActividadCargas
	SET horaTotal = @horaSemana1Mod
	WHERE idCrgHoraria = @id_CargaH AND idActividad = 1
	UPDATE tblActividadCargas
	SET horaTotal = @horaSemana2Mod
	WHERE idCrgHoraria = @id_CargaH AND idActividad = 2
	UPDATE tblActividadCargas
	SET horaTotal = @horaSemana3Mod
	WHERE idCrgHoraria = @id_CargaH AND idActividad = 3
	UPDATE tblActividadCargas
	SET horaTotal = @horaSemana4Mod
	WHERE idCrgHoraria = @id_CargaH AND idActividad = 4
END;
--tblAsigCrgHoraria
GO
GO
----Trigger to recalculate hours of the DOCENCIA component of an academic load when adding a subject
--CREATE TRIGGER tr_recalcularHorasDocencia_CargaH_afterDisableAsignatura
--ON tblSemestreAs
--AFTER INSERT, UPDATE, DELETE
--AS
--BEGIN
--	DECLARE @id_CargaH INT;
--	DECLARE @horasSemanalesAsignaturas INT;
--	DECLARE @horaSemana1 INT;
--	DECLARE @horaSemana2 INT;
--	DECLARE @horaSemana3 INT;
--	DECLARE @horaSemana4 INT;
--	-- Se recupera el id de la Carga Horaria
--    SELECT @id_CargaH = idCrgHoraria
--    FROM inserted;

--	-- Se obtiene la suma de horasAsignatura semestrales mediante el procedimiento almacenado
--	SELECT @horasSemanalesAsignaturas = COALESCE(SUM(asig.horasAsignaturaSemanales),0)
--	FROM   tblAsigCrgHoraria interAsig
--	INNER JOIN tblGrAsignatura gr  on interAsig.idGrAsig = gr.idGrAsig
--	INNER JOIN tblAsignatura asig on gr.idAsignatura = asig.idAsignatura
--	WHERE (interAsig.idCrgHoraria = @id_CargaH AND (asig.tipoAsignatura='Semestral'));


--	-- Calcular horas por actividad
--    DECLARE @horasPorActividad DECIMAL(10, 2);
--    SET @horasPorActividad = CAST(@horasSemanalesAsignaturas / 4.0 AS DECIMAL(10, 2));
    
--    -- Distribuir horas en variables
--	IF @horasSemanalesAsignaturas > 0
--		BEGIN
--			SET @horaSemana1 = CEILING(@horasPorActividad);
--			IF @horaSemana1 <= 0 SET @horaSemana1 = 0;
--			SET @horaSemana2 = FLOOR(@horasPorActividad);
--			IF @horaSemana2 <= 0 SET @horaSemana2 = 0;
--			SET @horaSemana3 = FLOOR(@horasPorActividad);
--			IF @horaSemana3 <= 0 SET @horaSemana3 = 0;
--			SET @horaSemana4 = @horasSemanalesAsignaturas - @horaSemana1 - @horaSemana2 - @horaSemana3;
--			IF @horaSemana4 <= 0 SET @horaSemana4 = 0;
--		END
--    ELSE
--		BEGIN
--			SET @horaSemana1 = 0;
--			SET @horaSemana2 = 0;
--			SET @horaSemana3 = 0;
--			SET @horaSemana4 = 0;
--		END
--    -- Recalcular horas de actividades de Docencia por defecto
--	UPDATE tblActividadCargas
--	SET horasSemana = @horaSemana1
--	WHERE idCrgHoraria = @id_CargaH AND idActividad = 1
--	UPDATE tblActividadCargas
--	SET horasSemana = @horaSemana2
--	WHERE idCrgHoraria = @id_CargaH AND idActividad = 2
--	UPDATE tblActividadCargas
--	SET horasSemana = @horaSemana3
--	WHERE idCrgHoraria = @id_CargaH AND idActividad = 3
--	UPDATE tblActividadCargas
--	SET horasSemana = @horaSemana4
--	WHERE idCrgHoraria = @id_CargaH AND idActividad = 4
--END;
--GO
-- TRIGGER PARA AGREGAR LOS DOCENTES AL NUEVO SEMESTRE CREADO
CREATE TRIGGER tr_AddDocentesSemestreTpDocente
ON tblSemestre
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON

    -- Insertar los docentes existentes en la tabla tblDocente
    -- con el idTipoDoc = 1 y estadoSemestreDoc en true para el nuevo semestre insertado
    
    -- Obtener el id del semestre insertado
    DECLARE @idSemestre INT
    SELECT @idSemestre = idSemestre FROM inserted

	--Obtener valor de horas tipo docente = 1
	DECLARE @numHorasSemestrales int

	SELECT @numHorasSemestrales = numHorasSemestrales
	FROM tblTipoDocenteSemestre
	WHERE idTipoDocente = 1 AND idSemestre = @idSemestre

	IF @numHorasSemestrales IS NULL
	BEGIN
		SELECT @numHorasSemestrales = numHorasSemestrales
		FROM tblTipoDocente
		WHERE idTipoDocente = 1
	END
	ELSE
	BEGIN
	SELECT @numHorasSemestrales = 0
	END
    
    -- Insertar los docentes en tblSemestreTpDocente solo si no existen previamente para el semestre
    INSERT INTO tblSemestreTpDocente (idTipoDoc, idSemestre, idDocente, numHorasSemestrales, estadoSemestreDoc)
    SELECT 
        1,
        @idSemestre,
        d.idDocente,
        @numHorasSemestrales,
        1
    FROM tblDocente d
    WHERE NOT EXISTS (
        SELECT 1
        FROM tblSemestreTpDocente std
        WHERE std.idSemestre = @idSemestre
        AND std.idDocente = d.idDocente
    )
END
GO

CREATE TRIGGER tr_AddDocenteToSemestreTpDocente
ON tblDocente
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON
    
    -- Obtener el id del docente insertado
    DECLARE @idDocente INT
    SELECT @idDocente = idDocente FROM inserted

	--Obtener valor de horas tipo docente = 1
	DECLARE @numHorasSemestrales int

	SELECT @numHorasSemestrales = numHorasSemestrales
	FROM tblTipoDocente
	WHERE idTipoDocente = 1

	IF @numHorasSemestrales IS NULL
	BEGIN
		SELECT @numHorasSemestrales = 0
	END
    
    -- Insertar el docente en tblSemestreTpDocente solo si no existe previamente
    INSERT INTO tblSemestreTpDocente (idTipoDoc, idSemestre, idDocente, numHorasSemestrales, estadoSemestreDoc)
    SELECT 1, s.idSemestre, @idDocente, 0, 0
    FROM tblSemestre s
    WHERE NOT EXISTS (
        SELECT 1
        FROM tblSemestreTpDocente std
        WHERE std.idSemestre = s.idSemestre
        AND std.idDocente = @idDocente
    )
END
GO
-- TRIGGER PARA AGREGAR ASIGNATURAS DE LA BASE AL NUEVO SEMESTRE CREADO COMO ACTIVAS O COPIANDO DEL SEMESTRE PREVIO
CREATE TRIGGER trgAgregarAsignaturas
ON tblSemestre
AFTER INSERT
AS
BEGIN
    DECLARE @idSemestre INT;
    DECLARE @idSemestreAnterior INT;
    
    SELECT @idSemestre = idSemestre FROM inserted;
    SELECT @idSemestreAnterior = MAX(idSemestre) FROM tblSemestre WHERE idSemestre < @idSemestre;
    
    -- Verificar si el semestre es activo
    IF EXISTS (SELECT 1 FROM inserted WHERE estadoSemestre = 1)
    BEGIN
        IF @idSemestreAnterior IS NOT NULL
        BEGIN
            -- Copiar registros del semestre anterior al reci�n creado
            INSERT INTO tblSemestreAsignatura (idSemestre, idAsignatura, isActive)
            SELECT @idSemestre, idAsignatura, isActive
            FROM tblSemestreAsignatura
            WHERE idSemestre = @idSemestreAnterior;
        END
        ELSE
        BEGIN
            -- Crear todos los registros en true
            INSERT INTO tblSemestreAsignatura (idSemestre, idAsignatura, isActive)
            SELECT @idSemestre, idAsignatura, 1
            FROM tblAsignatura;
        END
    END
END;
GO
-- TRIGGER PARA AGREGAR ASIGNATURA CREADA AL SEMESTRES DE LA DB
CREATE TRIGGER trgAgregarAsignaturaSemestre
ON tblAsignatura
AFTER INSERT
AS
BEGIN
    DECLARE @idAsignatura INT;
    
    SELECT @idAsignatura = idAsignatura FROM inserted;
    
    -- Agregar la asignatura a todos los semestres existentes
    INSERT INTO tblSemestreAsignatura (idSemestre, idAsignatura, isActive)
    SELECT idSemestre, @idAsignatura, 0
    FROM tblSemestre;
END;
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
INSERT INTO tblTipoDocente VALUES('Profesor Titular a Tiempo Completo',928,1);	--Id=1
INSERT INTO tblTipoDocente VALUES('Profesor Titular a Tiempo Parcial',928,1);	--Id=2
INSERT INTO tblTipoDocente VALUES('Profesor Ocasional a Tiempo Completo',928,1);--Id=3
INSERT INTO tblTipoDocente VALUES('Profesor Ocasional a Tiempo Parcial',928,1); --Id=4
INSERT INTO tblTipoDocente VALUES('Tecnico Docente a Tiempo Completo',928,1);	--Id=5
INSERT INTO tblTipoDocente VALUES('Tecnico Docente a Tiempo Parcial',928,1);	--Id=6
INSERT INTO tblTipoDocente VALUES('No asignado',0,1);	--Id=7
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
INSERT INTO tblDocente VALUES(1,'Julio','Cesar','Caiza','�acato','PhD');
INSERT INTO tblDocente VALUES(1,'Xavier','Alexander','Calderon','Hinojosa','MSc');
INSERT INTO tblDocente VALUES(1,'Luis','Fernando','Carrera','Suarez','PhD');
INSERT INTO tblDocente VALUES(1,'Jorge','Eduardo','Carvajal','Rodriguez','MSc');
INSERT INTO tblDocente VALUES(1,'William','Santiago','Coloma','Gomez','Ingenier�a');
INSERT INTO tblDocente VALUES(1,'Michael','Alexander','Curipallo','Martinez','Ingenier�a');
INSERT INTO tblDocente VALUES(1,'Luis','Efren','Diaz','Villacis','MSc');
INSERT INTO tblDocente VALUES(1,'Carlos','Roberto','Egas','Acosta','MSc');
INSERT INTO tblDocente VALUES(1,'Jose','Antonio','Estrada','Jimenez','PhD');	
INSERT INTO tblDocente VALUES(1,'Luis','Antonio','Flores','Asimbaya','MSc');
INSERT INTO tblDocente VALUES(1,'William','Fernando','Flores','Cifuentes','MSc');  			
INSERT INTO tblDocente VALUES(1,'Fabio','Matias','Gonzalez','Gonzalez','MSc');
INSERT INTO tblDocente VALUES(1,'Felipe','Leonel','Grijalva','Arevalo','PhD'); 
INSERT INTO tblDocente VALUES(1,'Danny','Santiago','Guaman','Loachamin','PhD');
INSERT INTO tblDocente VALUES(1,'Melany','Paola','Herrera','Herrera','Ingenier�a');
INSERT INTO tblDocente VALUES(1,'Carlos','Alfonso','Herrera','Mu�oz','MSc');
INSERT INTO tblDocente VALUES(1,'Pablo','Wilian','Hidalgo','Lascano','MSc'); 
INSERT INTO tblDocente VALUES(1,'Marco','Fernando','Lara','Mina','MSc');
INSERT INTO tblDocente VALUES(1,'Ricardo','Xavier','Llugsi','Ca�ar','MSc'); 
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
INSERT INTO tblDocente VALUES(1,'Marco','Fabian','Serrano','Gomez','Ingenier�a');
INSERT INTO tblDocente VALUES(1,'Soraya','Lucia','Sinche','Maita','PhD');
INSERT INTO tblDocente VALUES(1,'Edison','Ramiro','Tatayo','Vinueza','MSc');
INSERT INTO tblDocente VALUES(1,'Christian','Jose','Tipantu�a','Tenelema','MSc');
INSERT INTO tblDocente VALUES(1,'Luis','Felipe','Urquiza','Aguiar','PhD');
INSERT INTO tblDocente VALUES(1,'Jose','David','Vega','Sanchez','PhD');
INSERT INTO tblDocente VALUES(1,'Monica','De Lourdes','Vinueza','Rhor','MSc');
INSERT INTO tblDocente VALUES(1,'Francisco','Javier','Vizuete','Bassante','Ingenier�a');
INSERT INTO tblDocente VALUES(1,'Jose','Adrian','Zambrano','Miranda','MSc');
-- CREATE SEMESTRE PREV
GO
-- Table: Actividad
-- DATA INSERT
--  TABLA: Actividad   DATOS    (idTipoActividad,'Nombre Actividad',horas actividad, estado)
INSERT INTO tblActividad VALUES(1,'Preparaci�n y actualizaci�n de clases, seminarios, talleres, entre otros.',5,0,1);--Id=1
INSERT INTO tblActividad VALUES(1,'Preparaci�n, elaboraci�n, aplicaci�n y calificaci�n de ex�menes, trabajos y pr�cticas; consultas acad�micas.', 5,0,1);--Id=2
INSERT INTO tblActividad VALUES(1,'Dise�o y elaboraci�n de material did�ctico, gu�as docentes o syllabus.', 5,0,1);--Id=3
INSERT INTO tblActividad VALUES(1,'Direcci�n, orientaci�n y acompa�amiento a trav�s de tutor�as presenciales o virtuales, individuales o grupales (seguimiento acad�mico, seguimiento y evaluaci�n de pr�cticas o pasant�as preprofesionales).', 5,0,1);--Id=4
INSERT INTO tblActividad VALUES(1,'Dirigir los aprendizajes pr�cticos y de laboratorio, bajo la coordinaci�n de un profesor.', 5,0,1);--Id=5
INSERT INTO tblActividad VALUES(2,'Direcci�n, codirecci�n de trabajos de titulaci�n para carreras y maestr�as profesionalizantes.', 5,0,1);--Id=6
INSERT INTO tblActividad VALUES(2,'Calificaci�n de trabajos de titulaci�n para carreras y maestr�as profesionalizantes.', 5,0,1);--Id=7
INSERT INTO tblActividad VALUES(2,'Participaci�n en cursos de capacitaci�n y actualizaci�n profesional debidamente autorizados por el Consejo de Departamento.', 5,0,1);--Id=8
INSERT INTO tblActividad VALUES(2,'Escritura, elaboraci�n y edici�n del libro.', 5,0,1);--Id=9
INSERT INTO tblActividad VALUES(2,'Dise�o e impartici�n de cursos de educaci�n continua, capacitaci�n y actualizaci�n profesional, inducci�n al personal acad�mico vinculado al curso de nivelaci�n.', 5,0,1);--Id=10
INSERT INTO tblActividad VALUES(2,'Apoyo a las actividades de docencia que realiza el personal acad�mico.', 5,0,1);--Id=11
INSERT INTO tblActividad VALUES(3,'Revisor de art�culos en revistas indexadas.', 5,0,1);--Id=12
INSERT INTO tblActividad VALUES(3,'Publicaci�n de art�culo cient�fico.', 5,0,1);--Id=13
INSERT INTO tblActividad VALUES(3,'Tutor�a estudiante doctorado FIEE.', 5,0,1);--Id=14
INSERT INTO tblActividad VALUES(3,'Escritura - Proyecto de investigaci�n interno sin financiamiento.',5,0,1);--Id=15
INSERT INTO tblActividad VALUES(3,'Director de Proyecto de Investigaci�n.', 5,0,1);--Id=16
INSERT INTO tblActividad VALUES(3,'Colaborador de Proyecto de Investigaci�n.', 5,0,1);--Id=17
INSERT INTO tblActividad VALUES(3,'Propuesta - Proyecto de Investigaci�n Interno sin financiamiento.', 5,0,1);--Id=18
INSERT INTO tblActividad VALUES(3,'Elaboraci�n de proyecto de investigaci�n.', 5,0,1);--Id=19
INSERT INTO tblActividad VALUES(3,'Co-Director de Proyecto de Investigaci�n.', 5,0,1);--Id=20
INSERT INTO tblActividad VALUES(3,'Apoyo a la Comisi�n organizadora ETCM.', 5,0,1);--Id=21
INSERT INTO tblActividad VALUES(3,'Co-Director Tesis Doctoral.', 5,0,1);--Id=22
INSERT INTO tblActividad VALUES(3,'Direcci�n proyecto externo.', 5,0,1);--Id=23
INSERT INTO tblActividad VALUES(3,'Participaci�n en Comit� editorial ACOFI', 5,0,1);--Id=24
INSERT INTO tblActividad VALUES(3,'Director Tesis Doctoral.', 5,0,1);--Id=25
INSERT INTO tblActividad VALUES(3,'Comit� Editorial EPN.', 5,0,1);--Id=26
INSERT INTO tblActividad VALUES(3,'Estudiante Doctorado.', 5,0,1);--Id=27
INSERT INTO tblActividad VALUES(4,'Miembro alterno Comisi�n de Evaluaci�n Interna CEI.', 5,0,1);--Id=28
INSERT INTO tblActividad VALUES(4,'Comisi�n de ex�menes de autoevaluaci�n.', 5,0,1);--Id=29
INSERT INTO tblActividad VALUES(4,'CODEI.', 5,0,1);--Id=30
INSERT INTO tblActividad VALUES(4,'Vicerrectorado de Docencia.', 5,0,1);--Id=31
INSERT INTO tblActividad VALUES(4,'Coordinador - Comisi�n de Dise�o de Maestr�a Profesional.', 5,0,1);--Id=32
INSERT INTO tblActividad VALUES(4,'Representante de profesores ante Consejo de Facultad.', 5,0,1);--Id=33
INSERT INTO tblActividad VALUES(4,'Comisi�n de Vinculaci�n y Promoci�n DETRI.',5,0,1);--Id=34
INSERT INTO tblActividad VALUES(4,'Responsable de Club', 5,0,1);--Id=35
INSERT INTO tblActividad VALUES(4,'Administraci�n de Laboratorio.', 5,0,1);--Id=36
INSERT INTO tblActividad VALUES(4,'Comisi�n de propuesta de Maestr�a Profesional.', 5,0,1);--Id=37
INSERT INTO tblActividad VALUES(4,'Comisi�n de Unidad de Titulaci�n de Posgrado.', 5,0,1);--Id=38
INSERT INTO tblActividad VALUES(4,'Comision Nueva Carrera.', 5,0,1);--Id=39
INSERT INTO tblActividad VALUES(4,'Technical Chair - ETCM.', 5,0,1);--Id=40
INSERT INTO tblActividad VALUES(4,'Coordinador - Maestr�a.', 5,0,1);--Id=41
INSERT INTO tblActividad VALUES(4,'Coordinador de Carrera.', 5,0,1);--Id=42,0
INSERT INTO tblActividad VALUES(4,'Comisi�n de propuesta de nueva Carrera.', 5,0,1);--Id=43
INSERT INTO tblActividad VALUES(4,'Representante de la FIEE a la ESFOT.', 5,0,1);--Id=44
INSERT INTO tblActividad VALUES(4,'Comisi�n Permanente de Gesti�n de Integraci�n Curricular CPGIC', 5,0,1);--Id=45
INSERT INTO tblActividad VALUES(4,'Consejo de Departamento DETRI.', 5,0,1);--Id=46
INSERT INTO tblActividad VALUES(4,'Coordinador CPPP.', 5,0,1);--Id=47
INSERT INTO tblActividad VALUES(4,'Coordinaci�n de Maestr�a.', 5,0,1);--Id=48
INSERT INTO tblActividad VALUES(4,'Director de Docencia.', 5,0,1);--Id=49
INSERT INTO tblActividad VALUES(4,'Comisi�n de Seguimiento a Graduados.', 5,0,1);--Id=50
INSERT INTO tblActividad VALUES(4,'Unidad de Mantenimiento electr�nico (UME).', 5,0,1);--Id=51
INSERT INTO tblActividad VALUES(4,'Decanato FIEE.', 5,0,1);--Id=52
INSERT INTO tblActividad VALUES(4,'Comisi�n de Examen de Fin de Carrera.', 5,0,1);--Id=53
INSERT INTO tblActividad VALUES(4,'Miembro Consejo de Departamento.', 5,0,1);--Id=54
INSERT INTO tblActividad VALUES(4,'Comisi�n de Pr�cticas preprofesionales FIEE.', 5,0,1);--Id=55
INSERT INTO tblActividad VALUES(4,'Comisi�n de Trabajo de Titulaci�n.', 5,0,1);--Id=56
INSERT INTO tblActividad VALUES(4,'Miembro comit� doctoral.', 5,0,1);--Id=57
INSERT INTO tblActividad VALUES(4,'Director de Investigaci�n.', 5,0,1);--Id=58
INSERT INTO tblActividad VALUES(4,'Directora de la ESFOT.', 5,0,1);--Id=59
INSERT INTO tblActividad VALUES(4,'Jefe del DETRI.', 5,0,1);--Id=60
INSERT INTO tblActividad VALUES(4,'Apoyo a las actividades de gesti�n.', 5,0,1);--Id=61
INSERT INTO tblActividad VALUES(4,'Colaboraci�n en la Comisi�n de Pr�cticas Preprofesionales y Pasant�as.', 5,0,1);--Id=62
INSERT INTO tblActividad VALUES(4,'Otras actividades.', 5,0,1);--Id=63
GO
--  TABLA: Asignaturas   DATOS    (nombreAsignatura,'tipoAsignatura','codigoAsignatura',horasAsignaturaTotales,horasAsignaturaSemanales,nivelAsignatura, estadoAsignatura)
--INSERTAR DATOS EN MATERIA---
INSERT INTO tblAsignatura(nombreAsignatura,tipoAsignatura,codigoAsignatura,horasAsignaturaTotales,horasAsignaturaSemanales,
						nivelAsignatura,estadoAsignatura)
VALUES -- id=1  ==> 44

--('TEOR�A DE INFORMACI�N Y CODIFICACI�N','Semestral','TELD522',96,3,'Tercer Nivel',1),
--('TEOR�A DE INFORMACI�N Y CODIFICACI�N','Semestral','TELD522',96,3,'Tercer Nivel',1),
--('DISE�O Y PROGRAMACI�N DE SOFTWARE','Semestral','ITID543',144,5,'TercerNivel',1),
--('SISTEMAS EMBEBIDOS','Semestral','ITID553',144,5,'TercerNivel',1),
--('GESTI�N ORGANIZACIONAL','Semestral','ADMD511',48,2,'TercerNivel',1),
--('CABLEADO ESTRUCTURADO AVANZADO','Semestral','ITID612',96,3,'TercerNivel',1),
--('REDES DE �REA LOCAL','Semestral','ITID623',144,5,'TercerNivel',1),
--('ENRUTAMIENTO','Semestral','ITID633',144,5,'TercerNivel',1),
--('SISTEMAS INAL�MBRICOS','Semestral','ITID643',144,5,'TercerNivel',1),
--('ALMACENAMIENTO Y PROCESAMIENTO DE DATOS','Semestral','ITID653',144,5,'TercerNivel',1),
--('GESTI�N DE PROCESOS Y CALIDAD','Semestral','ADMD611',48,2,'TercerNivel',1),
--('APLICACIONES DISTRIBUIDAS','Semestral','ITID713',144,5,'TercerNivel',1),
--('REDES DE �REA EXTENDIDA','Semestral','ITID723',144,5,'TercerNivel',1),
--('SEGURIDAD EN REDES','Semestral','ITID733',144,5,'TercerNivel',1),
--('REDES E INTRANETS','Semestral','ITID742',96,3,'TercerNivel',1),
--('APLICACIONES WEB Y M�VILES','Semestral','ITID753',144,5,'TercerNivel',1),
--('INGENIER�A FINANCIERA','Semestral','ADMD711',48,2,'TercerNivel',1),
--('ASIGNATURA B�SICA DE ITINERARIO','Semestral','ITID800',96,3,'TercerNivel',1),
--('EVALUACI�N DE REDES','Semestral','ITID822',96,3,'TercerNivel',1),
--('REDES DE �REA LOCAL INAL�MBRICAS','Semestral','ITID832',96,3,'TercerNivel',1),
--('ADMINISTRACI�N DE REDES','Semestral','ITID843',144,5,'TercerNivel',1),
--('MINER�A DE DATOS','Semestral','ITID853',96,3,'TercerNivel',1),
--('SISTEMAS IoT','Semestral','ITID862',96,3,'TercerNivel',1),
--('DISE�O DE TRABAJO DE INTEGRACI�N CURRICULAR/PREPARACI�N EXAMEN DE CAR�CTER COMPLEXIVO','Semestral','ITID871',48,2,'TercerNivel',1),
--('ASIGNATURA AVANZADA DE ITINERARIO','','ITID900',96,3,'TercerNivel',1),
--('REGULACI�N DE LAS TECNOLOG�AS DE LA INFORMACI�N Y LA COMUNICACI�N','Semestral','ITID941',48,2,'TercerNivel',1),
--('TRABAJO DE INTEGRACI�N CURRICULAR/ EXAMEN DE CAR�CTER COMPLEXIVO','Semestral','TITD201',240,15,'TercerNivel',1)
--Malla TICs
('HERRAMIENTAS INFORM�TICAS', 'Semestral', 'ICOD111', 48, 2, 'Primer Nivel',1),
('C�LCULO VECTORIAL', 'Semestral', 'IEED232', 96, 3, 'Segundo Nivel',1),
('PROGRAMACI�N', 'Semestral', 'IEED252', 96, 3, 'Segundo Nivel',1),
('SISTEMAS DIGITALES', 'Semestral', 'IEED323', 96, 3, 'Tercer Nivel',1),
('DISPOSITIVOS ELECTR�NICOS', 'Semestral', 'IEED333', 96, 3, 'Tercer Nivel',1),
('TEOR�A ELECTROMAGN�TICA', 'Semestral', 'IEED333', 96, 4, 'Tercer Nivel',1),
('FUNDAMENTOS DE CIRCUITOS EL�CTRICOS', 'Semestral', 'IEED342', 96, 3, 'Tercer Nivel',1),
('ASIGNATURA DE ARTES Y HUMANIDADES', 'Semestral', 'CSHD300', 48, 2, 'Tercer Nivel',1),
('MATEM�TICA DISCRETA', 'Semestral', 'IEED371', 48, 2, 'Tercer Nivel',1),
('INSTALACIONES EL�CTRICAS Y COMUNICACIONES', 'Semestral', 'IEED413', 144, 4, 'Cuarto Nivel',1),
('AN�LISIS DE SE�ALES DISCRETAS PARA COMUNICACIONES', 'Semestral', 'TELD423', 144, 3, 'Cuarto Nivel',1),
('PROGRAMACI�N AVANZADA', 'Semestral', 'ITID433', 144, 4, 'Cuarto Nivel',1),
('BASES DE DATOS', 'Semestral', 'ITID443', 144, 4, 'Cuarto Nivel',1),
('SISTEMAS OPERATIVOS', 'Semestral', 'ITID452', 96, 5, 'Cuarto Nivel',1),
('ASIGNATURA DE ECONOM�A Y SOCIEDAD', 'Semestral', 'CSHD400', 48, 2, 'Cuarto Nivel',1),
('SISTEMAS DE CABLEADO ESTRUCTURADO', 'Semestral', 'ITID512', 96, 3, 'Quinto Nivel',1),
('TRANSMISI�N DIGITAL', 'Semestral', 'ITID524', 144, 5, 'Quinto Nivel',1),
('TEOR�A DE INFORMACI�N Y CODIFICACI�N', 'Semestral', 'TELD522', 96, 3, 'Quinto Nivel',1),
('DISE�O Y PROGRAMACI�N DE SOFTWARE', 'Semestral', 'ITID543', 144, 4, 'Quinto Nivel',1),
('SISTEMAS EMBEBIDOS', 'Semestral', 'ITID553', 96, 3, 'Quinto Nivel',1),
('GESTI�N ORGANIZACIONAL', 'Semestral', 'ADMD511', 48, 2, 'Quinto Nivel',1),
('CABLEADO ESTRUCTURADO AVANZADO', 'Semestral', 'ITID612', 96, 3, 'Sexto Nivel',1),
('REDES DE �REA LOCAL', 'Semestral', 'ITID623', 96, 3, 'Sexto Nivel',1),
('ENRUTAMIENTO', 'Semestral', 'ITID633', 96, 2, 'Sexto Nivel',1),
('SISTEMAS INAL�MBRICOS', 'Semestral', 'ITID643', 144, 4, 'Sexto Nivel',1),
('ALMACENAMIENTO Y PROCESAMIENTO DE DATOS', 'Semestral', 'ITID653', 144, 4, 'Sexto Nivel',1),
('GESTI�N DE PROCESOS Y CALIDAD', 'Semestral', 'ADMD611', 48, 2, 'Sexto Nivel',1),
('APLICACIONES DISTRIBUIDAS', 'Semestral', 'ITID713', 144, 4, 'S�ptimo Nivel',1),
('REDES DE �REA EXTENDIDA', 'Semestral', 'ITID723', 96, 3, 'S�ptimo Nivel',1),
('SEGURIDAD EN REDES', 'Semestral', 'ITID733', 144, 4, 'S�ptimo Nivel',1),
('REDES E INTRANETS', 'Semestral', 'ITID742', 96, 3, 'S�ptimo Nivel',1),
('APLICACIONES WEB Y M�VILES', 'Semestral', 'ITID753', 144, 5, 'S�ptimo Nivel',1),
('INGENIER�A FINANCIERA', 'Semestral', 'ADMD711', 48, 2, 'S�ptimo Nivel',1),
('ASIGNATURA B�SICA DE ITINERARIO', 'Semestral', 'ITID800', 96, 3, 'Octavo Nivel',1),
('EVALUACI�N DE REDES', 'Semestral', 'ITID822', 96, 4, 'Octavo Nivel',1),
('REDES DE �REA LOCAL INAL�MBRICAS', 'Semestral', 'ITID832', 96, 3, 'Octavo Nivel',1),
('ADMINISTRACI�N DE REDES', 'Semestral', 'ITID843', 144, 4, 'Octavo Nivel',1),
('MINERIA DE DATOS', 'Semestral', 'ITID853', 144, 5, 'Octavo Nivel',1),
('SISTEMAS IOT', 'Semestral', 'ITID862', 96, 4, 'Octavo Nivel',1),
('ASIGNATURA AVANZADA DE ITINERARIO', 'Semestral', 'ITID900', 96, 3, 'Noveno Nivel',1),
('PR�CTICAS LABORALES', 'Semestral', 'PRLD105', 240, 15, 'Noveno Nivel',1),
('PR�CTICAS DE SERVICIO COMUNITARIO', 'Semestral', 'PSCD202', 96, 6, 'Noveno Nivel',1),
('REGULACI�N DE LAS TECNOLOG�AS DE IA INFORMACI�N Y LA COMUNICACI�N', 'Semestral', 'ITID941', 48, 2, 'Noveno Nivel',1),
('TRABAJO DE INTEGRACI�N CURRICULAR/EXAMEN DE CAR�CTER COMPLEXIVO', 'Semestral', 'TITD201', 240, 15, 'Noveno Nivel',1),
--LABOS TICs
-- id=45  ==> 52
('LABORATORIO DE SISTEMAS DIGITALES', 'Semestral', 'IEED323', 48, 2, 'Tercer Nivel',1),
('LABORATORIO DE DISPOSITIVOS ELECTR�NICOS', 'Semestral', 'IEED333', 48, 2, 'Tercer Nivel',1),
('LABORATORIO DE FUNDAMENTOS DE CIRCUITOS EL�CTRICOS', 'Semestral', 'IEED342', 48, 2, 'Tercer Nivel',1),
('LABORATORIO DE TRANSMISI�N DIGITAL', 'Semestral', 'ITID524', 48, 2, 'Quinto Nivel',1),
('LABORATORIO DE SISTEMAS EMBEBIDOS', 'Semestral', 'ITID553', 48, 2, 'Quinto Nivel',1),
('LABORATORIO DE REDES DE �REA LOCAL', 'Semestral', 'ITID623', 48, 2, 'Sexto Nivel',1),
('LABORATORIO DE ENRUTAMIENTO', 'Semestral', 'ITID633', 48, 2, 'Sexto Nivel',1),
('LABORATORIO DE REDES DE �REA EXTENDIDA', 'Semestral', 'ITID723', 48, 2, 'S�ptimo Nivel',1),

--Malla Telecomunicaciones
-- id=53  ==> 97
('HERRAMIENTAS INFORM�TICAS', 'Semestral', 'ICOD111', 48, 2, 'Primer Nivel',1),
('C�LCULO VECTORIAL ', 'Semestral', 'IEED232', 96, 3, 'Segundo Nivel',1),
('PROGRAMACI�N ', 'Semestral', 'IEED252', 96, 3, 'Segundo Nivel',1),
('SISTEMAS DIGITALES ', 'Semestral', 'IEED323', 144, 3, 'Tercer Nivel',1),
('DISPOSITIVOS ELECTR�NICOS ', 'Semestral', 'IEED333', 144, 5, 'Tercer Nivel',1),
('TEOR�A ELECTROMAGN�TICA ', 'Semestral', 'IEED333', 96, 4, 'Tercer Nivel',1),
('FUNDAMENTOS DE CIRCUITOS EL�CTRICOS ', 'Semestral', 'IEED342', 144, 5, 'Tercer Nivel',1),
('ASIGNATURA DE ARTES Y HUMANIDADES', 'Semestral', 'CSHD300', 48, 2, 'Tercer Nivel',1),
('MATEM�TICA DISCRETA ', 'Semestral', 'IEED371', 48, 2, 'Tercer Nivel',1),
('INSTALACIONES EL�CTRICAS Y DE COMUNICACIONES', 'Semestral', 'IEED413', 144, 4, 'Cuarto Nivel',1),
('AN�LISIS DE SE�ALES DISCRETAS PARA COMUNICACIONES ', 'Semestral', 'TELD423', 144, 3, 'Cuarto Nivel',1),
('CIRCUITOS ELECTR�NICOS ', 'Semestral', 'IEED433', 144, 5, 'Cuarto Nivel',1),
('PROGRAMACI�N AVANZADA ', 'Semestral', 'ITID433', 144, 4, 'Cuarto Nivel',1),
('SISTENA OPERATIVO LINUX', 'Semestral', 'TELD452', 96, 3, 'Cuarto Nivel',1),
('ASIGNATURA DE ECONOM�A Y SOCIEDAD', 'Semestral', 'CSHD400', 48, 2, 'Cuarto Nivel',1),
('FUNDAMENTOS DE COMUNICACIONES ', 'Semestral', 'TELD513', 144, 5, 'Quinto Nivel',1),
('TEOR�A DE LA INFORMACI�N Y CODIFICACI�N', 'Semestral', 'TELD522', 96, 3, 'Quinto Nivel',1),
('PROCESAMIENTO DIGITAL DE SE�ALES ', 'Semestral', 'TELD532', 96, 3, 'Quinto Nivel',1),
('SISTEMAS EMBEBIDOS ', 'Semestral', 'ITID553', 144, 5, 'Quinto Nivel',1),
('SISTEMAS DE TRANSMISI�N ', 'Semestral', 'TELD553', 144, 5, 'Quinto Nivel',1),
('SISTEMAS DE CABLEADO ESTRUCTURADO', 'Semestral', 'ITID512', 96, 3, 'Quinto Nivel',1),
('COMUNICACI�N DIGITAL ', 'Semestral', 'TELD613', 144, 4, 'Sexto Nivel',1),
('TELEM�TICA B�SICA', 'Semestral', 'TELD623', 144, 5, 'Sexto Nivel',1),
('ELECTR�NICA DE RADIOFRECUENCIA ', 'Semestral', 'TELD633', 144, 5, 'Sexto Nivel',1),
('APLICACIONES CON SISTEMAS EMBEBIDOS ', 'Semestral', 'TELD642', 96, 3, 'Sexto Nivel',1),
('PROPAGACI�N Y ANTENAS ', 'Semestral', 'TELD654', 144, 5, 'Sexto Nivel',1),
('GESTI�N ORGANIZACIONAL ', 'Semestral', 'ADMD511 ', 48, 2, 'Sexto Nivel',1),
('COMUNICACIONES �PTICAS', 'Semestral', 'TELD713', 144, 5, 'S�ptimo Nivel',1),
('TELEM�TICA AVANZADA', 'Semestral', 'TELD723', 144, 5, 'S�ptimo Nivel',1),
('COMUNICACIONES INAL�MBRICAS', 'Semestral', 'TELD733', 144, 5, 'S�ptimo Nivel',1),
('TELEFON�A IP', 'Semestral', 'TELD743', 144, 3, 'S�ptimo Nivel',1),
('INGENIER�A DE MICROONDAS ', 'Semestral', 'TELD752', 96, 5, 'S�ptimo Nivel',1),
('GESTI�N DE PROCESOS Y CALIDAD ', 'Semestral', ' ADMD611', 48, 2, 'S�ptimo Nivel',1),
('ITINERARIO B�SICO', 'Semestral', 'TELD800', 96, 2, 'Octavo Nivel',1),
('REDES �PTICAS', 'Semestral', 'TELD823', 144, 4, 'Octavo Nivel',1),
('INTRODUCCI�N A DISE�O DE REDES ', 'Semestral', 'TELD833', 144, 3, 'Octavo Nivel',1),
('SISTEMAS CELULARES', 'Semestral', 'TELD843', 144, 3, 'Octavo Nivel',1),
('FUNDAMENTOS DE SEGURIDAD', 'Semestral', 'TELD852', 96, 4, 'Octavo Nivel',1),
('INGENIER�A FINANCIERA', 'Semestral', 'ADMD711', 48, 2, 'Octavo Nivel',1),
('DISE�O DE PROYECTOS DE TELECOMUNICACIONES ', 'Semestral', 'TITD101', 48, 1, 'Octavo Nivel',1),
('ITINERARIO AVANZADO', 'Semestral', 'TELD900', 96, 2, 'Noveno Nivel',1),
('PR�CTICAS LABORALES', 'Semestral', 'PRLD105', 240, 15, 'Noveno Nivel',1),
('PR�CTICAS DE SERVICIO COMUNITARIO', 'Semestral', 'PSCD202', 96, 6, 'Noveno Nivel',1),
('MARCO REGULATORIO DE LOS SERVICIOS DE TELECOMUNICACIONES', 'Semestral', 'TELD941', 48, 2, 'Noveno Nivel',1),
('TRABAJO DE INTEGRACI�N CURRICULAR/EXAMEN DE CAR�CTER COMPLEXIVO', 'Semestral', 'TITD201', 240, 15, 'Noveno Nivel',1),
--TICs Maestria I
('FUNDAMENTOS DE SEGURIDAD', 'Modular', 'MPTI113', 48, 6, 'Master Primer Nivel',1),
('FUNDAMENTOS DE INTERNET DE LAS COSAS', 'Modular', 'MPTI133', 64, 8, 'Master Primer Nivel',1),
('SEGURIDAD DE REDES I', 'Modular', 'MPTI133S', 64, 6, 'Master Primer Nivel',1),
('FUNDAMENTOS DE COMPUTACI�N EN LA NUBE', 'Modular', 'MPTI124', 64, 8, 'Master Primer Nivel',1),
('PROGRAMACI�N PARA MANIPULACI�N DE DATOS', 'Modular', 'MPTI143', 48, 6, 'Master Primer Nivel',1),
('SEGURIDAD DE REDES II', 'Modular', 'MPTI143S', 64, 8, 'Master Primer Nivel',1),
('SEMINARIO DE GRADUACI�N', 'Semestral', 'MPTI152', 32, 2, 'Primer Nivel',1),
('MODELOS DE NEGOCIOS EN LOS ECOSISTEMAS IOT', 'Modular', 'MPTI222', 32, 4, 'Master Segundo Nivel',1),
('APRENDIZAJE AUTOM�TICO APLICADO', 'Modular', 'MPTI243', 64, 8, 'Master Segundo Nivel',1),
('SEGURIDAD EN ENDPOINTS', 'Modular', 'MPTI224S', 64, 8, 'Segundo Nivel',1),
('MONITOREO Y DETECCI�N DE INTRUSI�N DE REDES', 'Modular', 'MPTI242S', 64, 8, 'Master Segundo Nivel',1),
('APLICACIONES PARA INTERNET DE LAS COSAS', 'Modular', 'MPTI234', 64, 8, 'Master Segundo Nivel',1),
('T�PICOS DE PLANIFICACI�N Y REGULACI�N EN TI', 'Modular', 'MPTI213', 48, 6, 'Master Segundo Nivel',1),
('T�CNICAS DE HACKING', 'Modular', 'MPTI233S', 32, 4, 'Master Segundo Nivel',1),
('TRABAJO DE TITULACI�N /EXAMEN COMPLEXIVO', 'Semestral', 'MPTI253', 0, 0, 'Master Segundo Nivel',1),
--TICs Maestria II
('MODELOS DE NEGOCIOS EN LOS ECOSISTEMAS IOT', 'Modular', 'MPTI222', 32, 4, 'Master Segundo Nivel',1),
('APRENDIZAJE AUTOM�TICO APLICADO', 'Modular', 'MPTI243', 64, 8, 'Master Segundo Nivel',1),
('SEGURIDAD EN ENDPOINTS', 'Modular', 'MPTI224S', 64, 8, 'Master Segundo Nivel',1),
('MONITOREO Y DETECCI�N DE INTRUSI�N DE REDES', 'Modular', 'MPTI242S', 64, 8, 'Master Segundo Nivel',1),
('APLICACIONES PARA INTERNET DE LAS COSAS', 'Modular', 'MPTI234', 64, 8, 'Master Segundo Nivel',1),
('T�PICOS DE PLANIFICACI�N Y REGULACI�N EN TI', 'Modular', 'MPTI213', 48, 6, 'Master Segundo Nivel',1),
('T�CNICAS DE HACKING', 'Modular', 'MPTI233S', 32, 4, 'Master Segundo Nivel',1),
('TRABAJO DE TITULACI�N /EXAMEN COMPLEXIVO', 'Semestral', 'MPTI253', 0, 0, 'Master Segundo Nivel',1),
--TELE Maestria I
('PROBABILIDAD Y ESTAD�STICA', 'Semestral', 'MITR-113', 144, 3, 'Master Primer Nivel',1),
('PROCESAMIENTO DE SE�ALES', 'Semestral', 'MITR-123', 144, 3, 'Master Primer Nivel',1),
('RADIO FRECUENCIA', 'Semestral', 'MITR-133', 144, 3, 'Master Primer Nivel',1),
('HERRAMIENTAS DE SIMULACI�N E IMPLEMENTACI�N EN HARDWARE', 'Semestral', 'MITR-143', 144, 3, 'Master Primer Nivel',1),
('METODOLOG�A Y DOCUMENTACI�N CIENT�FICA', 'Semestral', 'MITR-153', 144, 3, 'Master Primer Nivel',1),
('PROCESAMIENTO AVANZADO DE SE�ALES', 'Semestral', 'MITR-213', 144, 3, 'Master Segundo Nivel',1),
('T�CNICAS AVANZADAS DE COMUNICACIONES', 'Semestral', 'MITR-224', 192, 4, 'Master Segundo Nivel',1),
('ESTUDIO DEL CANAL INAL�MBRICO Y T�CNICAS DE MITIGACI�N', 'Semestral', 'MITR-233', 144, 3, 'Master Segundo Nivel',1),
('COMUNICACIONES M�VILES DE BANDA ANCHA', 'Semestral', 'MITR-243', 144, 3, 'Master Segundo Nivel',1),
('SEMINARIO', 'Semestral', 'MITR-252', 96, 2, 'Master Segundo Nivel',1),
('TESIS', 'Semestral', 'MITR-3115', 720, 15, 'Master Tercer Nivel',1)


---OLD *****************************************
--('CIRCUITOS ELECTR�NICOS','Semestral','IEED433',144,5,'TercerNivel',1),
--('SISTEMA OPERATIVO LINUX','Semestral','TELD452',96,3,'TercerNivel',1),
--('FUNDAMENTOS DE COMUNICACIONES','Semestral','TELD513',144,5,'TercerNivel',1),
--('PROCESAMIENTO DIGITAL DE SE�ALES','Semestral','TELD532',96,3,'TercerNivel',1),
--('SISTEMAS DE TRANSMISI�N','Semestral','TELD553',144,5,'TercerNivel',1),
--('COMUNICACI�N DIGITAL','Semestral','TELD613',144,5,'TercerNivel',1),
--('TELEM�TICA B�SICA','Semestral','TELD623',144,5,'TercerNivel',1),
--('ELECTR�NICA DE RADIOFRECUENCIA','Semestral','TELD633',144,5,'TercerNivel',1),
--('APLICACIONES CON SISTEMAS EMBEBIDOS','Semestral','TELD642',96,3,'TercerNivel',1),
--('PROPAGACI�N Y ANTENAS','Semestral','TELD654',144,5,'TercerNivel',1),
--('COMUNICACIONES �PTICAS','Semestral','TELD713',144,5,'TercerNivel',1),
--('TELEM�TICA AVANZADA','Semestral','TELD723',144,5,'TercerNivel',1),
--('COMUNICACIONES INAL�MBRICAS','Semestral','TELD733',144,5,'TercerNivel',1),
--('TELEFON�A IP','Semestral','TELD743',144,5,'TercerNivel',1),
--('INGENIER�A DE MICROONDAS','Semestral','TELD752',96,3,'TercerNivel',1),
--('ITINERARIO B�SICO','Semestral','TELD800',96,3,'TercerNivel',1),
--('REDES �PTICAS','Semestral','TELD823',144,5,'TercerNivel',1),
--('INTRODUCCI�N A DISE�O DE REDES','Semestral','TELD833',144,5,'TercerNivel',1),
--('SISTEMAS CELULARES','Semestral','TELD843',144,5,'TercerNivel',1),
--('FUNDAMENTOS DE SEGURIDAD','Semestral','TELD852',96,3,'TercerNivel',1),
--('DISE�O DE PROYECTOS DE TELECOMUNICACIONES','Semestral','TELD871',48,2,'TercerNivel',1),
--('ITINERARIO AVANZADO','Semestral','TELD900',96,3,'TercerNivel',1),
--('MARCO REGULATORIO DE LOS SERVICIOS DE TELECOMUNICACIONES','Semestral','TELD941',48,2,'TercerNivel',1)
--GO
----Asignaturas B�sicas FIEE
--INSERT INTO tblAsignatura(nombreAsignatura,tipoAsignatura,codigoAsignatura,horasAsignaturaTotales,horasAsignaturaSemanales,
--						nivelAsignatura,estadoAsignatura)
--VALUES -- id=50  ==> 66
--('�LGEBRA LINEAL','Semestral','MATD113',144,5,'Tercer Nivel',1),
--('C�LCULO EN UNA VARIABLE','Semestral','MATD123',144,5,'TercerNivel',1),
--('MEC�NICA NEWTONIANA','Semestral','FISD134',192,6,'TercerNivel',1),
--('QU�MICA GENERAL','Semestral','QUID143',144,5,'TercerNivel',1),
--('COMUNICACI�N ORAL Y ESCRITA','Semestral','CSHD111',48,2,'TercerNivel',1),
--('HERRAMIENTAS INFORM�TICAS','Semestral','ICOD111',48,2,'TercerNivel',1),
--('ECUACIONES DIFERENCIALES ORDINARIAS','Semestral','MATD213',144,5,'TercerNivel',1),
--('PROBABILIDAD Y ESTAD�STICA B�SICAS','Semestral','MATD223',144,5,'TercerNivel',1),
--('C�LCULO VECTORIAL','Semestral','IEED232',96,3,'TercerNivel',1),
--('FUNDAMENTOS DE ELECTROMAGNETISMO','Semestral','IEED242',96,2,'TercerNivel',1),
--('PROGRAMACI�N','Semestral','IEED252',96,3,'TercerNivel',1),
--('AN�LISIS SOCIOECON�MICO Y POL�TICO DEL ECUADOR','Semestral','CSHD211',48,2,'TercerNivel',1),
--('ELECTROTECNIA','Semestral','IEED272',96,3,'TercerNivel',1),
--('PROGRAMACI�N AVANZADA','Semestral','ITID433',144,5,'TercerNivel',1),
----CPs de ASIGNATURAS
----Asignaturas B�sicas FIEE
--('CP-�LGEBRA LINEAL','Semestral','MATD113-CP',48,2,'Tercer Nivel',1),
--('CP-C�LCULO EN UNA VARIABLE','Semestral','MATD123-CP',48,2,'TercerNivel',1)
--***************************************************
GO
GO
-- Table: Semestre 
-- DATA INSERT
--  TABLA: Semestre   DATOS    ('Codigo Semestre',A�oSemestre,diaInicio,diaFin,numSemanasClase,numSemanasSemestre,'Estado')
INSERT INTO tblSemestre VALUES('2022B',2022,'2022-10-03','2023-03-31',18,26,1);
--AGREGAR GRUPOS A ASIGNATURAS
INSERT INTO tblGrAsignatura(idAsignatura,grupoAsignatura)
VALUES
--TI Carreer
--INGE HELPER
(1, 'GR1'), (1, 'GR2'), -- HERRAMIENTAS INFORM�TICAS
(2, 'GR1'), (2, 'GR2'), -- C�LCULO VECTORIAL
(3, 'GR1'), (3, 'GR2'), -- PROGRAMACI�N
(4, 'GR1'), (4, 'GR2'), -- SISTEMAS DIGITALES
(5, 'GR1'), (5, 'GR2'), -- DISPOSITIVOS ELECTR�NICOS
(6, 'GR1'), (6, 'GR2'), -- TEOR�A ELECTROMAGN�TICA
(7, 'GR1'), (7, 'GR2'), -- FUNDAMENTOS DE CIRCUITOS EL�CTRICOS
(8, 'GR1'), (8, 'GR2'), -- ASIGNATURA DE ARTES Y HUMANIDADES
(9, 'GR1'), (9, 'GR2'), -- MATEM�TICA DISCRETA
(10, 'GR1'), (10, 'GR2'), -- INSTALACIONES EL�CTRICAS Y COMUNICACIONES
(11, 'GR1'), (11, 'GR2'), -- AN�LISIS DE SE�ALES DISCRETAS PARA COMUNICACIONES
(12, 'GR1'), (12, 'GR2'), -- PROGRAMACI�N AVANZADA
(13, 'GR1'), (13, 'GR2'), -- BASES DE DATOS
(14, 'GR1'), (14, 'GR2'), -- SISTEMAS OPERATIVOS
(15, 'GR1'), (15, 'GR2'), -- ASIGNATURA DE ECONOM�A Y SOCIEDAD
(16, 'GR1'), (16, 'GR2'), -- SISTEMAS DE CABLEADO ESTRUCTURADO
(17, 'GR1'), (17, 'GR2'), -- TRANSMISI�N DIGITAL
(18, 'GR1'), (18, 'GR2'), -- TEOR�A DE INFORMACI�N Y CODIFICACI�N
(19, 'GR1'), (19, 'GR2'), -- DISE�O Y PROGRAMACI�N DE SOFTWARE
(20, 'GR1'), (20, 'GR2'), -- SISTEMAS EMBEBIDOS
(21, 'GR1'), (21, 'GR2'), -- GESTI�N ORGANIZACIONAL
(22, 'GR1'), (22, 'GR2'), -- CABLEADO ESTRUCTURADO AVANZADO
(23, 'GR1'), (23, 'GR2'), -- REDES DE �REA LOCAL
(24, 'GR1'), (24, 'GR2'), -- ENRUTAMIENTO
(25, 'GR1'), (25, 'GR2'), -- SISTEMAS INAL�MBRICOS
(26, 'GR1'), (26, 'GR2'), -- ALMACENAMIENTO Y PROCESAMIENTO DE DATOS
(27, 'GR1'), (27, 'GR2'), -- GESTI�N DE PROCESOS Y CALIDAD
(28, 'GR1'), (28, 'GR2'), -- APLICACIONES DISTRIBUIDAS
(29, 'GR1'), (29, 'GR2'), -- REDES DE �REA EXTENDIDA
(30, 'GR1'), (30, 'GR2'), -- SEGURIDAD EN REDES
(31, 'GR1'), (31, 'GR2'), -- REDES E INTRANETS
(32, 'GR1'), (32, 'GR2'), -- APLICACIONES WEB Y M�VILES
(33, 'GR1'), (33, 'GR2'), -- INGENIER�A FINANCIERA
(34, 'GR1'), (34, 'GR2'), -- ASIGNATURA B�SICA DE ITINERARIO
(35, 'GR1'), (35, 'GR2'), -- EVALUACI�N DE REDES
(36, 'GR1'), (36, 'GR2'), -- REDES DE �REA LOCAL INAL�MBRICAS
(37, 'GR1'), (37, 'GR2'), -- ADMINISTRACI�N DE REDES
(38, 'GR1'), (38, 'GR2'), -- MINERIA DE DATOS
(39, 'GR1'), (39, 'GR2'), -- SISTEMAS IOT
(40, 'GR1'), (40, 'GR2'), -- ASIGNATURA AVANZADA DE ITINERARIO
(41, 'GR1'), (41, 'GR2'), -- PR�CTICAS LABORALES
(42, 'GR1'), (42, 'GR2'), -- PR�CTICAS DE SERVICIO COMUNITARIO
(43, 'GR1'), (43, 'GR2'), -- REGULACI�N DE LAS TECNOLOG�AS DE IA INFORMACI�N Y LA COMUNICACI�N
(44, 'GR1'), (44, 'GR2'), -- TRABAJO DE INTEGRACI�N CURRICULAR/EXAMEN DE CAR�CTER COMPLEXIVO
(45, 'GR1'), (45, 'GR2'), (45, 'GR3'), (45, 'GR4'), -- LABORATORIO DE SISTEMAS DIGITALES		
(46, 'GR1'), (46, 'GR2'), (46, 'GR3'), (46, 'GR4'), -- LABORATORIO DE DISPOSITIVOS ELECTR�NICOS		
(47, 'GR1'), (47, 'GR2'), (47, 'GR3'), (47, 'GR4'), -- LABORATORIO DE FUNDAMENTOS DE CIRCUITOS EL�CTRICOS		
(48, 'GR1'), (48, 'GR2'), (48, 'GR3'), (48, 'GR4'), -- LABORATORIO DE TRANSMISI�N DIGITAL		
(49, 'GR1'), (49, 'GR2'), (49, 'GR3'), (49, 'GR4'), -- LABORATORIO DE SISTEMAS EMBEBIDOS		
(50, 'GR1'), (50, 'GR2'), (50, 'GR3'), (50, 'GR4'), -- LABORATORIO DE REDES DE �REA LOCAL		
(51, 'GR1'), (51, 'GR2'), (51, 'GR3'), (51, 'GR4'), -- LABORATORIO DE ENRUTAMIENTO		
(52, 'GR1'), (52, 'GR2'), (52, 'GR3'), (52, 'GR4'), -- LABORATORIO DE REDES DE �REA EXTENDIDA		
-- TELECOMUNICACIONES
(53, 'GR1'), (53, 'GR2'), -- HERRAMIENTAS INFORM�TICAS
(54, 'GR1'), (54, 'GR2'), -- C�LCULO VECTORIAL 
(55, 'GR1'), (55, 'GR2'), -- PROGRAMACI�N 
(56, 'GR1'), (56, 'GR2'), -- SISTEMAS DIGITALES 
(57, 'GR1'), (57, 'GR2'), -- DISPOSITIVOS ELECTR�NICOS 
(58, 'GR1'), (58, 'GR2'), -- TEOR�A ELECTROMAGN�TICA 
(59, 'GR1'), (59, 'GR2'), -- FUNDAMENTOS DE CIRCUITOS EL�CTRICOS 
(60, 'GR1'), (60, 'GR2'), -- ASIGNATURA DE ARTES Y HUMANIDADES
(61, 'GR1'), (61, 'GR2'), -- MATEM�TICA DISCRETA 
(62, 'GR1'), (62, 'GR2'), -- INSTALACIONES EL�CTRICAS Y DE COMUNICACIONES
(63, 'GR1'), (63, 'GR2'), -- AN�LISIS DE SE�ALES DISCRETAS PARA COMUNICACIONES 
(64, 'GR1'), (64, 'GR2'), -- CIRCUITOS ELECTR�NICOS 
(65, 'GR1'), (65, 'GR2'), -- PROGRAMACI�N AVANZADA 
(66, 'GR1'), (66, 'GR2'), -- SISTENA OPERATIVO LINUX
(67, 'GR1'), (67, 'GR2'), -- ASIGNATURA DE ECONOM�A Y SOCIEDAD
(68, 'GR1'), (68, 'GR2'), -- FUNDAMENTOS DE COMUNICACIONES 
(69, 'GR1'), (69, 'GR2'), -- TEOR�A DE LA INFORMACI�N Y CODIFICACI�N
(70, 'GR1'), (70, 'GR2'), -- PROCESAMIENTO DIGITAL DE SE�ALES 
(71, 'GR1'), (71, 'GR2'), -- SISTEMAS EMBEBIDOS 
(72, 'GR1'), (72, 'GR2'), -- SISTEMAS DE TRANSMISI�N 
(73, 'GR1'), (73, 'GR2'), -- SISTEMAS DE CABLEADO ESTRUCTURADO
(74, 'GR1'), (74, 'GR2'), -- COMUNICACI�N DIGITAL 
(75, 'GR1'), (75, 'GR2'), -- TELEM�TICA B�SICA
(76, 'GR1'), (76, 'GR2'), -- ELECTR�NICA DE RADIOFRECUENCIA 
(77, 'GR1'), (77, 'GR2'), -- APLICACIONES CON SISTEMAS EMBEBIDOS 
(78, 'GR1'), (78, 'GR2'), -- PROPAGACI�N Y ANTENAS 
(79, 'GR1'), (79, 'GR2'), -- GESTI�N ORGANIZACIONAL 
(80, 'GR1'), (80, 'GR2'), -- COMUNICACIONES �PTICAS
(81, 'GR1'), (81, 'GR2'), -- TELEM�TICA AVANZADA
(82, 'GR1'), (82, 'GR2'), -- COMUNICACIONES INAL�MBRICAS
(83, 'GR1'), (83, 'GR2'), -- TELEFON�A IP
(84, 'GR1'), (84, 'GR2'), -- INGENIER�A DE MICROONDAS 
(85, 'GR1'), (85, 'GR2'), -- GESTI�N DE PROCESOS Y CALIDAD 
(86, 'GR1'), (86, 'GR2'), -- ITINERARIO B�SICO
(87, 'GR1'), (87, 'GR2'), -- REDES �PTICAS
(88, 'GR1'), (88, 'GR2'), -- INTRODUCCI�N A DISE�O DE REDES 
(89, 'GR1'), (89, 'GR2'), -- SISTEMAS CELULARES
(90, 'GR1'), (90, 'GR2'), -- FUNDAMENTOS DE SEGURIDAD
(91, 'GR1'), (91, 'GR2'), -- INGENIER�A FINANCIERA
(92, 'GR1'), (92, 'GR2'), -- DISE�O DE PROYECTOS DE TELECOMUNICACIONES 
(93, 'GR1'), (93, 'GR2'), -- ITINERARIO AVANZADO
(94, 'GR1'), (94, 'GR2'), -- PR�CTICAS LABORALES
(95, 'GR1'), (95, 'GR2'), -- PR�CTICAS DE SERVICIO COMUNITARIO
(96, 'GR1'), (96, 'GR2'), -- MARCO REGULATORIO DE LOS SERVICIOS DE TELECOMUNICACIONES
(97, 'GR1'), (97, 'GR2'), -- TRABAJO DE INTEGRACI�N CURRICULAR/EXAMEN DE CAR�CTER COMPLEXIVO
-- TIC MAESTRIA MATERIAS
(98, 'GR1'), (98, 'GR2'), -- FUNDAMENTOS DE SEGURIDAD
(99, 'GR1'), (99, 'GR2'), -- FUNDAMENTOS DE INTERNET DE LAS COSAS
(100, 'GR1'), (100, 'GR2'), -- SEGURIDAD DE REDES I
(101, 'GR1'), (101, 'GR2'), -- FUNDAMENTOS DE COMPUTACI�N EN LA NUBE
(102, 'GR1'), (102, 'GR2'), -- PROGRAMACI�N PARA MANIPULACI�N DE DATOS
(103, 'GR1'), (103, 'GR2'), -- SEGURIDAD DE REDES II
(104, 'GR1'), (104, 'GR2'), -- SEMINARIO DE GRADUACI�N
(105, 'GR1'), (105, 'GR2'), -- MODELOS DE NEGOCIOS EN LOS ECOSISTEMAS IOT
(106, 'GR1'), (106, 'GR2'), -- APRENDIZAJE AUTOM�TICO APLICADO
(107, 'GR1'), (107, 'GR2'), -- SEGURIDAD EN ENDPOINTS
(108, 'GR1'), (108, 'GR2'), -- MONITOREO Y DETECCI�N DE INTRUSI�N DE REDES
(109, 'GR1'), (109, 'GR2'), -- APLICACIONES PARA INTERNET DE LAS COSAS
(110, 'GR1'), (110, 'GR2'), -- T�PICOS DE PLANIFICACI�N Y REGULACI�N EN TI
(111, 'GR1'), (111, 'GR2'), -- T�CNICAS DE HACKING
(112, 'GR1'), (112, 'GR2') -- TRABAJO DE TITULACI�N /EXAMEN COMPLEXIVO
--PARTE 2 TIC MAESTRIAS



--**************************************************
--(1, 'GR1'),--TEOR�A DE INFORMACI�N Y CODIFICACI�N
--(2, 'GR1'),--DISE�O Y PROGRAMACI�N DE SOFTWARE
--(3, 'GR1'),--SISTEMAS EMBEBIDOS{..
--(3, 'GR2'),--.. }
--(4, 'GR1'),--GESTI�N ORGANIZACIONAL{..
--(4, 'GR2'),--
--(4, 'GR3'),--
--(4, 'GR4'),--..}
--(5, 'GR1'),--CABLEADO ESTRUCTURADO AVANZADO
--(6, 'GR1'),--REDES DE �REA LOCAL
--(7, 'GR1'),--ENRUTAMIENTO
--(8, 'GR1'),--SISTEMAS INAL�MBRICOS
--(9, 'GR1'),--ALMACENAMIENTO Y PROCESAMIENTO DE DATOS
--(10, 'GR1'),--GESTI�N DE PROCESOS Y CALIDAD{...
--(10, 'GR2'),--
--(10, 'GR3'),--..}
--(11, 'GR1'),--APLICACIONES DISTRIBUIDAS
--(12, 'GR1'),--REDES DE �REA EXTENDIDA
--(13, 'GR1'),--SEGURIDAD EN REDES
--(14, 'GR1'),--REDES E INTRANETS
--(15, 'GR1'),--APLICACIONES WEB Y M�VILES
--(16, 'GR1'),--INGENIER�A FINANCIERA{...
--(16, 'GR2'),--
--(16, 'GR3'),--..}
----(17, 'GR1'),--ASIGNATURA B�SICA DE ITINERARIO  ???????
--(18, 'GR1'),--EVALUACI�N DE REDES
--(19, 'GR1'),--REDES DE �REA LOCAL INAL�MBRICAS
--(20, 'GR1'),--ADMINISTRACI�N DE REDES
--(21, 'GR1'),--MINER�A DE DATOS
--(22, 'GR1'),--SISTEMAS IoT
----(23, 'GR1'),--REDES DE �REA LOCAL INAL�MBRICAS
----(24, 'GR1'),--ADMINISTRACI�N DE REDES
--(25, 'GR1'),--REGULACI�N DE LAS TECNOLOG�AS DE LA INFORMACI�N Y LA COMUNICACI�N
----GRS DE ASIGNATURAS BASICAS
--(50, 'GR1'),--ALGEBRA LINEAL{...
--(50, 'GR2'),--
--(50, 'GR3'),--
--(50, 'GR4'),--
--(50, 'GR5'),--
--(50, 'GR6'),--
--(50, 'GR7'),--
--(50, 'GR8'),--..}
--(51, 'GR1'),--C�LCULO EN UNA VARIABLE{...
--(51, 'GR2'),--
--(51, 'GR3'),--
--(51, 'GR4'),--
--(51, 'GR5'),--
--(51, 'GR6'),--
--(51, 'GR7'),--
--(51, 'GR8'),--..}
--(52, 'GR1'),--MEC�NICA NEWTONIANA{...
--(52, 'GR2'),--
--(52, 'GR3'),--
--(52, 'GR4'),--
--(52, 'GR5'),--
--(52, 'GR6'),--
--(52, 'GR7'),--
--(52, 'GR8'),--..}
--(53, 'GR1'),--QU�MICA GENERAL{...
--(53, 'GR2'),--
--(53, 'GR3'),--
--(53, 'GR4'),--
--(53, 'GR5'),--
--(53, 'GR6'),--
--(53, 'GR7'),--
--(53, 'GR8'),--..}
--(54, 'GR1'),--COMUNICACI�N ORAL Y ESCRITA{...
--(54, 'GR2'),--
--(54, 'GR3'),--
--(54, 'GR4'),--
--(54, 'GR5'),--
--(54, 'GR6'),--
--(54, 'GR7'),--
--(54, 'GR8'),--..}
--(55, 'GR1'),--HERRAMIENTAS INFORM�TICAS{...
--(55, 'GR2'),--
--(55, 'GR3'),--
--(55, 'GR4'),--
--(55, 'GR5'),--
--(55, 'GR6'),--
--(55, 'GR7'),--
--(55, 'GR8'),--..}
--(56, 'GR1'),--ECUACIONES DIFERENCIALES ORDINARIAS{...
--(56, 'GR2'),--
--(56, 'GR3'),--
--(56, 'GR4'),--
--(56, 'GR5'),--
--(56, 'GR6'),--
--(56, 'GR7'),--
--(56, 'GR8'),--..}
--(57, 'GR1'),--PROBABILIDAD Y ESTAD�STICA B�SICAS{...
--(57, 'GR2'),--
--(57, 'GR3'),--
--(57, 'GR4'),--
--(57, 'GR5'),--
--(57, 'GR6'),--
--(57, 'GR7'),--
--(57, 'GR8'),--..}
--(58, 'GR1'),--C�LCULO VECTORIAL{...
--(58, 'GR2'),--
--(58, 'GR3'),--
--(58, 'GR4'),--
--(58, 'GR5'),--
--(58, 'GR6'),--
--(58, 'GR7'),--
--(58, 'GR8'),--..}
--(59, 'GR1'),--FUNDAMENTOS DE ELECTROMAGNETISMO{...
--(59, 'GR2'),--
--(59, 'GR3'),--
--(59, 'GR4'),--
--(59, 'GR5'),--
--(59, 'GR6'),--
--(59, 'GR7'),--
--(59, 'GR8'),--..}
--(60, 'GR1'),--PROGRAMACI�N{...
--(60, 'GR2'),--
--(60, 'GR3'),--
--(60, 'GR4'),--
--(60, 'GR5'),--
--(60, 'GR6'),--
--(60, 'GR7'),--
--(60, 'GR8'),--..}
--(61, 'GR1'),--AN�LISIS SOCIOECON�MICO Y POL�TICO DEL ECUADOR{...
--(61, 'GR2'),--
--(61, 'GR3'),--
--(61, 'GR4'),--
--(61, 'GR5'),--..}
--(62, 'GR1'),--ELECTROTECNIA{...
--(62, 'GR2'),--
--(62, 'GR3'),--
--(62, 'GR4'),--
--(62, 'GR5'),--..}
--(63, 'GR1'),--PROGRAMACI�N AVANZADA{...
--(63, 'GR2'),--
--(63, 'GR3'),--
--(63, 'GR4'),--
--(63, 'GR5'),--
--(63, 'GR6'),--
--(63, 'GR7'),--
--(63, 'GR8'),--..}
----CPS
--(64, 'GR1-CP'),--CP-�LGEBRA LINEAL{...
--(64, 'GR2-CP'),--
--(64, 'GR3-CP'),--
--(64, 'GR4-CP'),--
--(64, 'GR5-CP'),--
--(64, 'GR6-CP'),--
--(64, 'GR7-CP'),--
--(64, 'GR8-CP'),--..}
--(65, 'GR1-CP'),--CP-CALCULO DE UNA VARIABLE{...
--(65, 'GR2-CP'),--
--(65, 'GR3-CP'),--
--(65, 'GR4-CP'),--
--(65, 'GR5-CP'),--
--(65, 'GR6-CP'),--
--(65, 'GR7-CP'),--
--(65, 'GR8-CP')--..}
-- END SCRIPT