--------------------------------------------
-- Author: Jorge Pérez
-- Description: Script to create database for Academic Load in DETRI Department
-- Database Name: dbCargaHorariaData
--------------------------------------------
--------------------------------------------
-- PRESS F5 to Execute entire script
--------------------------------------------
USE master
--dbCargaHorariaTICtest2  gg
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'dbCargaHorariaTIC_DETRI')
BEGIN
    DROP DATABASE dbCargaHorariaTIC_DETRI;
END
GO
PRINT 'Creating DB';
CREATE DATABASE dbCargaHorariaTIC_DETRI;
GO
USE dbCargaHorariaTIC_DETRI;

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
	estadoDocente int,
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
--CREATE TABLE tblAsigCarrera(
--	idAsigCarrera int  NOT NULL IDENTITY(1, 1),
--	idCarrera int NOT NULL,
--	idAsignatura int NOT NULL,--FK 
--	estadoAsigCarrera bit NOT NULL,
--	PRIMARY KEY (idAsigCarrera),
--	FOREIGN KEY (idCarrera) REFERENCES tblCarrera(idCarrera) ON UPDATE  NO ACTION  ON DELETE  NO ACTION,
--	FOREIGN KEY (idAsignatura) REFERENCES tblAsignatura(idAsignatura) ON UPDATE  NO ACTION  ON DELETE  NO ACTION
--);
--GO
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
-- Table: DiaSemana
CREATE TABLE tblDiaSemana (
    idDiaSemana int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    dia varchar(50) NOT NULL
);
GO
CREATE TABLE tblHorarioGrAsig(
    idHorario int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    idSemestreGrAsignatura int NOT NULL, -- FK
    horaInicio time NOT NULL,
    horaFin time NOT NULL,
    idDiaSemana int NOT NULL,
	isActive bit NOT NULL,
    FOREIGN KEY (idSemestreGrAsignatura) REFERENCES tblSemestreGrAsignatura(idSemestreGrAsignatura) ON UPDATE NO ACTION ON DELETE NO ACTION,
	FOREIGN KEY (idDiaSemana) REFERENCES tblDiaSemana(idDiaSemana) ON UPDATE NO ACTION ON DELETE NO ACTION
); 
--CREATE TABLE tblHorarioGrAsig(  respaldo 10AGO
--    idHorario int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--    idSemestreGrAsignatura int NOT NULL, -- FK
--    horaInicio time NOT NULL,
--    horaFin time NOT NULL,
--    dia varchar(50) NOT NULL,
--	isActive bit NOT NULL,
--    FOREIGN KEY (idSemestreGrAsignatura) REFERENCES tblSemestreGrAsignatura(idSemestreGrAsignatura) ON UPDATE NO ACTION ON DELETE NO ACTION
--);
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
		apellido1Docente,apellido2Docente,tituloDocente, estadoDocente)
		VALUES(@idDepa,@name1,@name2,@apellido1,@apellido2,@tituloDoc,1)
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
		INSERT INTO tblSemestre(codigoSemestre,añoSemestre,diaInicio, diaFin,
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
CREATE OR ALTER PROCEDURE [dbo].[spAddAsignatura]
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
---- Stored Procedure to UPDATE one row into  "tblSemestreDocente"
CREATE OR ALTER PROCEDURE [dbo].[spUpdateHorasExigiblesSemestreTpDocente]
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
CREATE OR ALTER PROCEDURE spGetDocenteIfGrExisteInCargaHoraria
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
-- Stored Procedure to get type Docente Name based on idTipoDocente and idSemestre
CREATE OR ALTER PROCEDURE spGetDataHorasExigiblesDocentesBySemestreAndName
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
-- Stored Procedure to get the number of semester hours based on idTipoDocente and idSemestre
CREATE OR ALTER PROCEDURE spGetHorasExigiblesDocentesBySemestre
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
--SP to create one row from tblGrAsignatura and get those id row
CREATE OR ALTER PROCEDURE [dbo].[spAddGrAsignaturaOut]
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
--SP to verificar si existe GR en tblGrAsignatura
CREATE OR ALTER PROCEDURE [dbo].[spVerificarGRexistente]
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
-- Stored Procedure to create one row from "tblHorarioGrAsig"
CREATE OR ALTER PROCEDURE [dbo].[spVerificarHorarioWithNumHorasAsignatura]
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
-- Stored Procedure to create one row from "tblHorarioGrAsig"
CREATE OR ALTER PROCEDURE [dbo].[spAddHorarioAsig]
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
-- Stored Procedure to create one row from "tblHorarioGrAsig"
CREATE OR ALTER PROCEDURE [dbo].[spAddHorarioAsigNoOut]
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
    SELECT idAsignatura AS ID,c.idCarrera, c.nombreCarrera AS Carrera,nombreAsignatura AS 'Nombre de la Asignatura', tipoAsignatura AS 'Tipo de Asignatura',
	codigoAsignatura AS 'Código',horasAsignaturaTotales AS 'Horas Totales', horasAsignaturaSemanales AS 'Horas Semanales',
	nivelAsignatura as Nivel
    FROM   tblAsignatura a
	INNER JOIN tblCarrera c ON a.idCarrera = c.idCarrera
	WHERE estadoAsignatura = 1
	ORDER BY 'Nombre de la Asignatura'
END
GO
-- Stored Procedure to Read All Rows from  "tblAsignaturas" where had Groups
IF OBJECT_ID('spReadAllAsignaturasWGroupsWHorario') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllAsignaturasWGroupsWHorario]
END 
GO
CREATE OR ALTER PROC [dbo].[spReadAllAsignaturasWGroupsWHorario]
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
	AND SGA.isActive = 1 AND HGA.isActive = 1 AND SGA.idSemestre = 1
	ORDER BY Asignatura ASC
END
GO
-- Stored Procedure to Read All Rows from  "tblAsignaturas" where had Groups
IF OBJECT_ID('spReadAllAsignaturasWGroups') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllAsignaturasWGroups]
END 
GO
CREATE OR ALTER PROC [dbo].[spReadAllAsignaturasWGroups]
@idSemestre int
AS 
BEGIN 
	SELECT DISTINCT a.idAsignatura AS ID,CONCAT(a.nombreAsignatura,' - ',a.codigoAsignatura) AS Asignatura
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
-- Stored Procedure to Read All Rows from  "tblAsignaturas" where had Groups
IF OBJECT_ID('spReadAllAsignaturasCmb') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllAsignaturasCmb]
END 
GO
CREATE PROC [dbo].[spReadAllAsignaturasCmb]
AS 
BEGIN 
    SELECT DISTINCT a.idAsignatura AS ID, CONCAT(a.nombreAsignatura,' - ',a.codigoAsignatura) AS Asignatura
    FROM tblAsignatura a
	ORDER BY Asignatura ASC
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
    SELECT gr.idGrAsig AS ID, asg.nombreAsignatura as ASIGNATURA, gr.grupoAsignatura as GRUPO, asg.codigoAsignatura AS 'CÓDIGO', asg.tipoAsignatura AS TIPO
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
CREATE or ALTER PROC [dbo].[spReadAllHorariosAsignaturas]
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
-- Stored Procedure to GET all HORARIOS from  "tblHorarioGrAsig" based on idGrAsig and idSemestre
CREATE or alter PROC [dbo].[spGetAllHorariosByGRAsig]
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
--SP TO GET HORARIO TO VIEW
CREATE or alter PROC [dbo].[spGetAllHorariosByGRAsigViewer]
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
--SP TO GET DOCENTE HORARIO exec spGetHorarioForCargaHoraria 1
CREATE OR ALTER PROCEDURE spGetHorarioForCargaHoraria
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
--SP PARA VERIFICAR CRUCE DE HORARIO
CREATE OR ALTER PROCEDURE spVerificarConflictoHorario
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
--SP TO GET HORAS SEMANALES FOR ASIGNATURA
CREATE OR ALTER PROCEDURE [dbo].[spGetHoraAsignatura]
@idAsignatura int
AS 
BEGIN 
    SELECT horasAsignaturaSemanales
    FROM   tblAsignatura
	WHERE idAsignatura = @idAsignatura
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
			CONCAT(apellido1Docente, ' ', apellido2Docente) Apellidos,tituloDocente AS 'Título'
    FROM   tblDocente car
	INNER JOIN tblDepartamento dep  on car.idDepa = dep.idDepartamento
	WHERE estadoDocente = 1
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
	WHERE ch.idCargaHoraria = @idCrgHoraria AND doc.estadoDocente = 1
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
	WHERE ch.idCargaHoraria = @idCrgHoraria and  std.idSemestre =@idSemestre and doc.estadoDocente = 1
END
GO
-- Stored Procedure to Read All rows from  "tblDocente"
CREATE OR ALTER PROCEDURE [dbo].[spReadAllDocentesAllNames]
AS 
BEGIN 
    SELECT idDocente AS ID, CONCAT(apellido1Docente, ' ', apellido2Docente,' ', nombre1Docente, ' ', nombre2Docente) NombreDocente
    FROM   tblDocente WHERE estadoDocente = 1
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
	WHERE STP.estadoSemestreDoc = 1 AND STP.idSemestre = @idSemestre AND STP.numHorasSemestrales > 0 AND D.estadoDocente = 1
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
	WHERE STP.idSemestre = @idSemestre AND D.estadoDocente = 1
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
    SELECT idSemestre AS ID,codigoSemestre AS 'Código',añoSemestre AS 'Año',
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
	WHERE std.idSemestre = @idSemestre AND doc.estadoDocente = 1
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
		SET codigoSemestre = @codSmstr, añoSemestre= @yrSmstr, diaInicio =@dIni,
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
CREATE OR ALTER PROCEDURE [dbo].[spUpdateAsignatura]
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
		UPDATE tblDocente
		SET estadoDocente = 0
		WHERE idDocente = @id;
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
CREATE OR ALTER PROCEDURE [dbo].[spDeleteAsignatura]
	@id int
AS
	BEGIN 
		UPDATE tblAsignatura
		SET estadoAsignatura = 0
		WHERE idAsignatura = @id;
	END
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
		UPDATE tblHorarioGrAsig
		SET isActive = 0
		WHERE idHorario = @id;
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
CREATE OR ALTER PROC [dbo].[spReadAllGroupsByAsig]
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
-- Stored Procedure to Read All Groups by IdAsignatura from  "tblAsignatura"
IF OBJECT_ID('spReadAllGroupsByAsigCmb') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[spReadAllGroupsByAsigCmb]
END 
GO
CREATE OR ALTER PROC [dbo].[spReadAllGroupsByAsigCmb]
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
CREATE OR ALTER PROC [dbo].[spReadAllGroupsByAsigBySemestreCmb]
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
CREATE OR ALTER PROC [dbo].[spReadAllGroupsByAsigWithHorario]
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
		FROM tblDocente WHERE idDepa = @id and estadoDocente = 1
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
			WHERE ch.idSemestre = @idSemestre AND doc.idDepa = @idDepa and std.idSemestre = @idSemestre and doc.estadoDocente = 1
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
		FROM tblDocente WHERE idDepa = @id and estadoDocente = 1
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
-- Stored Procedure to Read all Asignaturas from a Specifica Academic Load from tblAsigCrgHoraria
CREATE OR ALTER PROCEDURE [dbo].[spReadAllCargaAsignaturas]
@idCrgHoraria int
AS
BEGIN 
	SELECT interAsig.idAsigCrgHoraria AS ID,asig.tipoAsignatura AS TIPO,ASIG.codigoAsignatura as CÓDIGO,gr.grupoAsignatura as GR,asig.nombreAsignatura AS 'ASIGNATURA',
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
	SELECT interAsig.idAsigCrgHoraria AS ID,asig.codigoAsignatura AS 'Código',asig.nombreAsignatura AS 'Asignatura',gr.grupoAsignatura as GR,
		asig.horasAsignaturaSemanales AS 'Horas / Semana'
	FROM   tblAsigCrgHoraria interAsig
	INNER JOIN tblGrAsignatura gr on interAsig.idGrAsig = gr.idGrAsig
	INNER JOIN tblAsignatura asig  on gr.idAsignatura = asig.idAsignatura
	WHERE idCrgHoraria = 1
END
GO
-- Stored Procedure to Read all Actividades D11 from a Specifica Academic Load from tblActividadCargas
CREATE OR ALTER  PROCEDURE [dbo].[spReadAllCargaActividadesD11]
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
-- Stored Procedure to Read all Actividades F11 from a Specifica Academic Load from tblActividadCargas
CREATE OR ALTER  PROCEDURE [dbo].[spReadAllCargaActividadesF11]
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
-- Stored Procedure to Read all Actividades de Gestion from a Specifica Academic Load from tblActividadCargas
CREATE OR ALTER PROCEDURE [dbo].[spReadAllCargaActividadesG]
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

-- Stored Procedure to Read all Actividades de Investigacion from a Specifica Academic Load from tblActividadCargas
CREATE OR ALTER PROCEDURE [dbo].[spReadAllCargaActividadesI]
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
	WHERE (interActiv.idCrgHoraria = @idCrgHoraria AND activ.idTpAct_f = 3);
END
GO
-- Stored Procedure to Read all Actividades from a Specifica Academic Load from tblActividadCargas
CREATE OR ALTER PROCEDURE [dbo].[spReadAllCargaActividades]
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
CREATE OR ALTER PROCEDURE spCopySemestreHorarios
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
CREATE OR ALTER PROCEDURE spCopySemestreCargas
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
--SP TO GET IDs CARGA HORARIA By SEMESTRE TO EXPORT PDFs
CREATE OR ALTER PROCEDURE [dbo].[spGetIdCargaHorariaLst_BySemestre]
@idSemestre int
AS
BEGIN 
	SELECT DISTINCT idCargaHoraria AS id
	FROM tblCargaHoraria
	WHERE idSemestre = @idSemestre
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
-- Stored Procedure to Get Asignaturas without Docente from  "tblAsigCrgHoraria"
CREATE OR ALTER PROCEDURE [dbo].[spGetAsignaturaGrBySemestreWithOutDocente_Reporte]
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
    SELECT @id_CargaH = COALESCE(i.idCrgHoraria, d.idCrgHoraria)
    FROM inserted i
    LEFT JOIN deleted d ON i.idCrgHoraria = d.idCrgHoraria;

	
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
GO
CREATE TRIGGER tr_recalcularHorasDocencia_CargaH_afterDelete
ON tblAsigCrgHoraria
AFTER DELETE
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
    FROM deleted;
	PRINT 'TRIGGER DELETE'
	PRINT @id_CargaH

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
GO
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
            -- Copiar registros del semestre anterior al recién creado
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
GO
--Trigger para actualizar num de horas semestrales al cambiar registros de la tabla que contiene el num de horas semestrales por semestre
CREATE TRIGGER tr_UpdateSemestreTpDocente
ON dbo.tblTipoDocenteSemestre
AFTER UPDATE
AS
BEGIN
    -- Actualizar los registros en tblSemestreTpDocente basados en los valores actualizados en tblTipoDocenteSemestre
    UPDATE stp
    SET stp.numHorasSemestrales = ins.numHorasSemestrales
    FROM tblSemestreTpDocente stp
    INNER JOIN inserted ins ON stp.idTipoDoc = ins.idTipoDocente AND stp.idSemestre = ins.idSemestre;
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
INSERT INTO tblCarrera VALUES(1,'Maestria TIC I','M-TIC-1','2020',1);
INSERT INTO tblCarrera VALUES(1,'Maestria TIC II','M-TIC-2','2020',1);
INSERT INTO tblCarrera VALUES(1,'Maestria TELE I','M-TELE-2','2020',1);
GO
-- Table: Tipo Actividad
-- DATA INSERT
-- TABLA: Tipo Actividad    DATOS    ('Codigo Tipo Actividad','Nombre del tipo de Actividad')
INSERT INTO tblTipoActividad VALUES('D11','Actividades Docente dentro del 1:1');	--Id=1
INSERT INTO tblTipoActividad VALUES('D','Actividades Docente fuera del 1:1');		--Id=2
INSERT INTO tblTipoActividad VALUES('I','Actividades de Investigacion');			--Id=3
INSERT INTO tblTipoActividad VALUES('G','Actividades de Gestion');					--Id=4
GO
-- Table: Tipo Docente
-- DATA INSERT
--  TABLA: TipoDocente   DATOS    ('Nombre del TipoDocente','Estado')
INSERT INTO tblTipoDocente VALUES('Profesor Titular a Tiempo Completo',928,1);	--Id=1
INSERT INTO tblTipoDocente VALUES('Profesor Titular a Tiempo Parcial',441,1);	--Id=2
INSERT INTO tblTipoDocente VALUES('Profesor Ocasional a Tiempo Completo',928,1);--Id=3
INSERT INTO tblTipoDocente VALUES('Profesor Ocasional a Tiempo Parcial',928,1); --Id=4
INSERT INTO tblTipoDocente VALUES('Tecnico Docente a Tiempo Completo',928,1);	--Id=5
INSERT INTO tblTipoDocente VALUES('Tecnico Docente a Tiempo Parcial',441,1);	--Id=6
INSERT INTO tblTipoDocente VALUES('No asignado',0,1);	--Id=7
INSERT INTO tblTipoDocente VALUES('Invitado',288,1);	--Id=8
GO
-- Table: Docente
-- DATA INSERT
--  TABLA: Docente- DATOS    (Id departamento,'Nombre1','Nombre2','Apellido1','Apellido2','Titulo Docente')
INSERT INTO tblDocente VALUES(1,'Ana','Maria','Zambrano','Vizuete','PhD',1);  --TTC
INSERT INTO tblDocente VALUES(1,'Carlos','Francisco','Cevallos','Zambrano','MSc',1); --TTP
INSERT INTO tblDocente VALUES(1,'Tania','Aleyda','Acosta','Hurtado','PhD',1); --TTC
INSERT INTO tblDocente VALUES(1,'Robin','Gerardo','Alvarez','Rueda','PhD',1); --TTC DESACTIVADO
INSERT INTO tblDocente VALUES(1,'Hernan','Vinicio','Barba','Molina','PhD',1); --Oc TC
INSERT INTO tblDocente VALUES(1,'Pablo','Andres','Barbecho','Bautista','PhD',1);
INSERT INTO tblDocente VALUES(1,'Ivan','Marcelo','Bernal','Carrillo','PhD',1); -- TTC
INSERT INTO tblDocente VALUES(1,'Julio','Cesar','Caiza','Ñacato','PhD',1); -- TTC
INSERT INTO tblDocente VALUES(1,'Xavier','Alexander','Calderon','Hinojosa','MSc',1); -- TTC
INSERT INTO tblDocente VALUES(1,'Luis','Fernando','Carrera','Suarez','PhD',1); -- TTC
INSERT INTO tblDocente VALUES(1,'Jorge','Eduardo','Carvajal','Rodriguez','MSc',1); --TTC desactivado
INSERT INTO tblDocente VALUES(1,'William','Santiago','Coloma','Gomez','Ingeniería',1); -- Tec Doc TC
INSERT INTO tblDocente VALUES(1,'Michael','Alexander','Curipallo','Martinez','Ingeniería',1); -- Tec Doc TC
INSERT INTO tblDocente VALUES(1,'Luis','Efren','Diaz','Villacis','MSc',1); -- Tit TP
INSERT INTO tblDocente VALUES(1,'Carlos','Roberto','Egas','Acosta','MSc',1);--Tit TC
INSERT INTO tblDocente VALUES(1,'Jose','Antonio','Estrada','Jimenez','PhD',1);	--TTC
INSERT INTO tblDocente VALUES(1,'Luis','Antonio','Flores','Asimbaya','MSc',1); --OTP
INSERT INTO tblDocente VALUES(1,'William','Fernando','Flores','Cifuentes','MSc',1);  	 --TTC		
INSERT INTO tblDocente VALUES(1,'Fabio','Matias','Gonzalez','Gonzalez','MSc',1);--TTC
INSERT INTO tblDocente VALUES(1,'Felipe','Leonel','Grijalva','Arevalo','PhD',1); -- Invitado Tiempo Parcial
INSERT INTO tblDocente VALUES(1,'Danny','Santiago','Guaman','Loachamin','PhD',1); --TTC
INSERT INTO tblDocente VALUES(1,'Melany','Paola','Herrera','Herrera','Ingeniería',1); --Tec DocTC
INSERT INTO tblDocente VALUES(1,'Carlos','Alfonso','Herrera','Muñoz','MSc',1);--TTC
INSERT INTO tblDocente VALUES(1,'Pablo','Wilian','Hidalgo','Lascano','MSc',1); --TTC
INSERT INTO tblDocente VALUES(1,'Marco','Fernando','Lara','Mina','MSc',1); --OTP
INSERT INTO tblDocente VALUES(1,'Ricardo','Xavier','Llugsi','Cañar','MSc',1); -- TTC
INSERT INTO tblDocente VALUES(1,'Gabriel','Roberto','Lopez','Fonseca','MSc',1); -- Invitado Tiempo Parcial
INSERT INTO tblDocente VALUES(1,'Pablo','Anibal','Lupera','Morillo','PhD',1); ----TTC
INSERT INTO tblDocente VALUES(1,'Raul','David','Mejia','Navarrete','MSc',1); -- --TTC
INSERT INTO tblDocente VALUES(1,'Ricardo','Ivan','Mena','Villacis',',MSc',1); --OTC
INSERT INTO tblDocente VALUES(1,'Ramiro','Eduardo','Morejon','Tobar','MSc',1); --TTC
INSERT INTO tblDocente VALUES(1,'Diana','Veronica','Navarro','Mendez','PhD',1);--TTC
INSERT INTO tblDocente VALUES(1,'Martha','Cecilia','Paredes','Paredes','PhD',1);--TTC
INSERT INTO tblDocente VALUES(1,'Viviana','Cristina','Parraga','Villamar','MSc',1);--OTP
INSERT INTO tblDocente VALUES(1,'Maria','Cristina','Ramos','Lopez','MSc',1) -- DESACTIVAR
INSERT INTO tblDocente VALUES(1,'Diego','Javier','Reinoso','Chisaguano','PhD',1);--TTC
INSERT INTO tblDocente VALUES(1,'Aldrin','Paul','Reyes','Narvaez','MSc',1);--TCTC
INSERT INTO tblDocente VALUES(1,'Ana','Fernanda','Rodriguez','Hoyos','PhD',1); --TTC
INSERT INTO tblDocente VALUES(1,'Tarquino','Fabian','Sanchez','Almeida','PhD',1); --TTC
INSERT INTO tblDocente VALUES(1,'Franklin','Leonel','Sanchez','Catota','MSc',1); --TTC
INSERT INTO tblDocente VALUES(1,'Marco','Fabian','Serrano','Gomez','Ingeniería',1); --TDTC
INSERT INTO tblDocente VALUES(1,'Soraya','Lucia','Sinche','Maita','PhD',1); --TTC
INSERT INTO tblDocente VALUES(1,'Edison','Ramiro','Tatayo','Vinueza','MSc',1); --TDTC
INSERT INTO tblDocente VALUES(1,'Christian','Jose','Tipantuña','Tenelema','MSc',1); ----TTC
INSERT INTO tblDocente VALUES(1,'Luis','Felipe','Urquiza','Aguiar','PhD',1); --TTC
INSERT INTO tblDocente VALUES(1,'Jose','David','Vega','Sanchez','PhD',1); --OTC
INSERT INTO tblDocente VALUES(1,'Monica','De Lourdes','Vinueza','Rhor','MSc',1); --TTC
INSERT INTO tblDocente VALUES(1,'Francisco','Javier','Vizuete','Bassante','Ingeniería',1);--DESACTIVO --TTC
INSERT INTO tblDocente VALUES(1,'Jose','Adrian','Zambrano','Miranda','MSc',1); --DESACTIVO --TTC
INSERT INTO tblDocente VALUES(1,'Rommel','David','Salgado','Camacas','Ingeniero',1); --TDTC
-- CREATE SEMESTRE PREV
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
--TABLE tblDiaSemana
INSERT INTO tblDiaSemana VALUES
('LUNES'),
('MARTES'),
('MIÉRCOLES'),
('JUEVES'),
('VIERNES'),
('SÁBADO'),
('DOMINGO')
GO
--  TABLA: Asignaturas   DATOS    (nombreAsignatura,'tipoAsignatura','codigoAsignatura',horasAsignaturaTotales,horasAsignaturaSemanales,nivelAsignatura, estadoAsignatura)
--INSERTAR DATOS EN MATERIA---
INSERT INTO tblAsignatura(idCarrera,nombreAsignatura,tipoAsignatura,codigoAsignatura,horasAsignaturaTotales,horasAsignaturaSemanales,
						nivelAsignatura,estadoAsignatura)
VALUES -- id=1  ==> 44   v2 -- id=1  ==> 39
--Malla TICs
(1,'HERRAMIENTAS INFORMÁTICAS', 'Semestral', 'ICOD111', 48, 2, 'Primer Nivel',1),
--(1,'CÁLCULO VECTORIAL', 'Semestral', 'IEED232', 96, 3, 'Segundo Nivel',1), -- BORRAR 2
(1,'PROGRAMACIÓN', 'Semestral', 'IEED252', 96, 3, 'Segundo Nivel',1),
(1,'SISTEMAS DIGITALES', 'Semestral', 'IEED323', 96, 3, 'Tercer Nivel',1),
--(1,'DISPOSITIVOS ELECTRÓNICOS', 'Semestral', 'IEED333', 96, 3, 'Tercer Nivel',1), -- Borrar 4
--(1,'TEORÍA ELECTROMAGNÉTICA', 'Semestral', 'IEED333', 96, 4, 'Tercer Nivel',1),  BORRAR 5
(1,'FUNDAMENTOS DE CIRCUITOS ELÉCTRICOS', 'Semestral', 'IEED342', 96, 3, 'Tercer Nivel',1),
(1,'ASIGNATURA DE ARTES Y HUMANIDADES', 'Semestral', 'CSHD300', 48, 2, 'Tercer Nivel',1),
(1,'MATEMÁTICA DISCRETA', 'Semestral', 'IEED371', 48, 2, 'Tercer Nivel',1),
--(1,'INSTALACIONES ELÉCTRICAS Y COMUNICACIONES', 'Semestral', 'IEED413', 144, 4, 'Cuarto Nivel',1), --BORRAR 9
--(1,'ANÁLISIS DE SEÑALES DISCRETAS PARA COMUNICACIONES', 'Semestral', 'TELD423', 144, 3, 'Cuarto Nivel',1 ), BORRAR 10
(1,'PROGRAMACIÓN AVANZADA', 'Semestral', 'ITID433', 144, 4, 'Cuarto Nivel',1),
(1,'BASES DE DATOS', 'Semestral', 'ITID443', 144, 4, 'Cuarto Nivel',1),
(1,'SISTEMAS OPERATIVOS', 'Semestral', 'ITID452', 96, 5, 'Cuarto Nivel',1),
(1,'ASIGNATURA DE ECONOMÍA Y SOCIEDAD', 'Semestral', 'CSHD400', 48, 2, 'Cuarto Nivel',1),
(1,'SISTEMAS DE CABLEADO ESTRUCTURADO', 'Semestral', 'ITID512', 96, 3, 'Quinto Nivel',1),
(1,'TRANSMISIÓN DIGITAL', 'Semestral', 'ITID524', 144, 5, 'Quinto Nivel',1),
(1,'TEORÍA DE INFORMACIÓN Y CODIFICACIÓN', 'Semestral', 'TELD522', 96, 3, 'Quinto Nivel',1),
(1,'DISEÑO Y PROGRAMACIÓN DE SOFTWARE', 'Semestral', 'ITID543', 144, 4, 'Quinto Nivel',1),
(1,'SISTEMAS EMBEBIDOS', 'Semestral', 'ITID553', 96, 3, 'Quinto Nivel',1),
(1,'GESTIÓN ORGANIZACIONAL', 'Semestral', 'ADMD511', 48, 2, 'Quinto Nivel',1),
(1,'CABLEADO ESTRUCTURADO AVANZADO', 'Semestral', 'ITID612', 96, 3, 'Sexto Nivel',1),
(1,'REDES DE ÁREA LOCAL', 'Semestral', 'ITID623', 96, 3, 'Sexto Nivel',1),
(1,'ENRUTAMIENTO', 'Semestral', 'ITID633', 96, 2, 'Sexto Nivel',1),
(1,'SISTEMAS INALÁMBRICOS', 'Semestral', 'ITID643', 144, 4, 'Sexto Nivel',1),
(1,'ALMACENAMIENTO Y PROCESAMIENTO DE DATOS', 'Semestral', 'ITID653', 144, 4, 'Sexto Nivel',1),
(1,'GESTIÓN DE PROCESOS Y CALIDAD', 'Semestral', 'ADMD611', 48, 2, 'Sexto Nivel',1),
(1,'APLICACIONES DISTRIBUIDAS', 'Semestral', 'ITID713', 144, 4, 'Séptimo Nivel',1),
(1,'REDES DE ÁREA EXTENDIDA', 'Semestral', 'ITID723', 96, 3, 'Séptimo Nivel',1),
(1,'SEGURIDAD EN REDES', 'Semestral', 'ITID733', 144, 4, 'Séptimo Nivel',1),
(1,'REDES E INTRANETS', 'Semestral', 'ITID742', 96, 3, 'Séptimo Nivel',1),
(1,'APLICACIONES WEB Y MÓVILES', 'Semestral', 'ITID753', 144, 5, 'Séptimo Nivel',1),
(1,'INGENIERÍA FINANCIERA', 'Semestral', 'ADMD711', 48, 2, 'Séptimo Nivel',1),
(1,'ASIGNATURA BÁSICA DE ITINERARIO', 'Semestral', 'ITID800', 96, 3, 'Octavo Nivel',1),
(1,'EVALUACIÓN DE REDES', 'Semestral', 'ITID822', 96, 4, 'Octavo Nivel',1),
(1,'REDES DE ÁREA LOCAL INALÁMBRICAS', 'Semestral', 'ITID832', 96, 3, 'Octavo Nivel',1),
(1,'ADMINISTRACIÓN DE REDES', 'Semestral', 'ITID843', 144, 4, 'Octavo Nivel',1),
(1,'MINERIA DE DATOS', 'Semestral', 'ITID853', 144, 5, 'Octavo Nivel',1),
(1,'SISTEMAS IOT', 'Semestral', 'ITID862', 96, 4, 'Octavo Nivel',1),
(1,'ASIGNATURA AVANZADA DE ITINERARIO', 'Semestral', 'ITID900', 96, 3, 'Noveno Nivel',1),
(1,'PRÁCTICAS LABORALES', 'Semestral', 'PRLD105', 240, 15, 'Noveno Nivel',1),
(1,'PRÁCTICAS DE SERVICIO COMUNITARIO', 'Semestral', 'PSCD202', 96, 6, 'Noveno Nivel',1),
(1,'REGULACIÓN DE LAS TECNOLOGÍAS DE IA INFORMACIÓN Y LA COMUNICACIÓN', 'Semestral', 'ITID941', 48, 2, 'Noveno Nivel',1),
(1,'TRABAJO DE INTEGRACIÓN CURRICULAR/EXAMEN DE CARÁCTER COMPLEXIVO', 'Semestral', 'TITD201', 240, 15, 'Noveno Nivel',1),
--LABOS TICs
-- id=45  ==> 52  -- id=40  ==> 47
(1,'LABORATORIO DE SISTEMAS DIGITALES', 'Semestral', 'IEED323', 48, 2, 'Tercer Nivel',1),
(1,'LABORATORIO DE DISPOSITIVOS ELECTRÓNICOS', 'Semestral', 'IEED333', 48, 2, 'Tercer Nivel',1),
(1,'LABORATORIO DE FUNDAMENTOS DE CIRCUITOS ELÉCTRICOS', 'Semestral', 'IEED342', 48, 2, 'Tercer Nivel',1),
(1,'LABORATORIO DE TRANSMISIÓN DIGITAL', 'Semestral', 'ITID524', 48, 2, 'Quinto Nivel',1),
(1,'LABORATORIO DE SISTEMAS EMBEBIDOS', 'Semestral', 'ITID553', 48, 2, 'Quinto Nivel',1),
(1,'LABORATORIO DE REDES DE ÁREA LOCAL', 'Semestral', 'ITID623', 48, 2, 'Sexto Nivel',1),
(1,'LABORATORIO DE ENRUTAMIENTO', 'Semestral', 'ITID633', 48, 2, 'Sexto Nivel',1),
(1,'LABORATORIO DE REDES DE ÁREA EXTENDIDA', 'Semestral', 'ITID723', 48, 2, 'Séptimo Nivel',1),

--Malla Telecomunicaciones
-- id=53  ==> 97 -- id=48  ==> 89
(2,'HERRAMIENTAS INFORMÁTICAS', 'Semestral', 'ICOD111', 48, 2, 'Primer Nivel',1),
(2,'CÁLCULO VECTORIAL ', 'Semestral', 'IEED232', 96, 3, 'Segundo Nivel',1),
(2,'PROGRAMACIÓN ', 'Semestral', 'IEED252', 96, 3, 'Segundo Nivel',1),
(2,'SISTEMAS DIGITALES ', 'Semestral', 'IEED323', 144, 3, 'Tercer Nivel',1),
(2,'DISPOSITIVOS ELECTRÓNICOS ', 'Semestral', 'IEED333', 144, 3, 'Tercer Nivel',1),
(2,'TEORÍA ELECTROMAGNÉTICA ', 'Semestral', 'IEED333', 96, 4, 'Tercer Nivel',1),
(2,'FUNDAMENTOS DE CIRCUITOS ELÉCTRICOS ', 'Semestral', 'IEED342', 144, 5, 'Tercer Nivel',1),
(2,'ASIGNATURA DE ARTES Y HUMANIDADES', 'Semestral', 'CSHD300', 48, 2, 'Tercer Nivel',1),
--(2,'MATEMÁTICA DISCRETA ', 'Semestral', 'IEED371', 48, 2, 'Tercer Nivel',1),-- 61
(2,'INSTALACIONES ELÉCTRICAS Y DE COMUNICACIONES', 'Semestral', 'IEED413', 144, 4, 'Cuarto Nivel',1),
(2,'ANÁLISIS DE SEÑALES DISCRETAS PARA COMUNICACIONES ', 'Semestral', 'TELD423', 144, 3, 'Cuarto Nivel',1),
(2,'CIRCUITOS ELECTRÓNICOS ', 'Semestral', 'IEED433', 144, 5, 'Cuarto Nivel',1),
--(2,'PROGRAMACIÓN AVANZADA ', 'Semestral', 'ITID433', 144, 4, 'Cuarto Nivel',1), 65
(2,'SISTENA OPERATIVO LINUX', 'Semestral', 'TELD452', 96, 3, 'Cuarto Nivel',1),
(2,'ASIGNATURA DE ECONOMÍA Y SOCIEDAD', 'Semestral', 'CSHD400', 48, 2, 'Cuarto Nivel',1),
(2,'FUNDAMENTOS DE COMUNICACIONES ', 'Semestral', 'TELD513', 144, 5, 'Quinto Nivel',1),
(2,'TEORÍA DE LA INFORMACIÓN Y CODIFICACIÓN', 'Semestral', 'TELD522', 96, 3, 'Quinto Nivel',1),
(2,'PROCESAMIENTO DIGITAL DE SEÑALES ', 'Semestral', 'TELD532', 96, 3, 'Quinto Nivel',1),
(2,'SISTEMAS EMBEBIDOS ', 'Semestral', 'ITID553', 144, 5, 'Quinto Nivel',1),
(2,'SISTEMAS DE TRANSMISIÓN ', 'Semestral', 'TELD553', 144, 5, 'Quinto Nivel',1),
--(2,'SISTEMAS DE CABLEADO ESTRUCTURADO', 'Semestral', 'ITID512', 96, 3, 'Quinto Nivel',1),  73
(2,'COMUNICACIÓN DIGITAL ', 'Semestral', 'TELD613', 144, 4, 'Sexto Nivel',1),
(2,'TELEMÁTICA BÁSICA', 'Semestral', 'TELD623', 144, 5, 'Sexto Nivel',1),
(2,'ELECTRÓNICA DE RADIOFRECUENCIA ', 'Semestral', 'TELD633', 144, 5, 'Sexto Nivel',1),
(2,'APLICACIONES CON SISTEMAS EMBEBIDOS ', 'Semestral', 'TELD642', 96, 3, 'Sexto Nivel',1),
(2,'PROPAGACIÓN Y ANTENAS ', 'Semestral', 'TELD654', 144, 5, 'Sexto Nivel',1),
(2,'GESTIÓN ORGANIZACIONAL ', 'Semestral', 'ADMD511 ', 48, 2, 'Sexto Nivel',1),
(2,'COMUNICACIONES ÓPTICAS', 'Semestral', 'TELD713', 144, 5, 'Séptimo Nivel',1),
(2,'TELEMÁTICA AVANZADA', 'Semestral', 'TELD723', 144, 5, 'Séptimo Nivel',1),
(2,'COMUNICACIONES INALÁMBRICAS', 'Semestral', 'TELD733', 144, 5, 'Séptimo Nivel',1),
(2,'TELEFONÍA IP', 'Semestral', 'TELD743', 144, 3, 'Séptimo Nivel',1),
(2,'INGENIERÍA DE MICROONDAS ', 'Semestral', 'TELD752', 96, 5, 'Séptimo Nivel',1),
(2,'GESTIÓN DE PROCESOS Y CALIDAD ', 'Semestral', ' ADMD611', 48, 2, 'Séptimo Nivel',1),
(2,'ITINERARIO BÁSICO', 'Semestral', 'TELD800', 96, 2, 'Octavo Nivel',1),
(2,'REDES ÓPTICAS', 'Semestral', 'TELD823', 144, 4, 'Octavo Nivel',1),
(2,'INTRODUCCIÓN A DISEÑO DE REDES ', 'Semestral', 'TELD833', 144, 3, 'Octavo Nivel',1),
(2,'SISTEMAS CELULARES', 'Semestral', 'TELD843', 144, 3, 'Octavo Nivel',1),
(2,'FUNDAMENTOS DE SEGURIDAD', 'Semestral', 'TELD852', 96, 4, 'Octavo Nivel',1),
(2,'INGENIERÍA FINANCIERA', 'Semestral', 'ADMD711', 48, 2, 'Octavo Nivel',1),
(2,'DISEÑO DE PROYECTOS DE TELECOMUNICACIONES ', 'Semestral', 'TITD101', 48, 1, 'Octavo Nivel',1),
(2,'ITINERARIO AVANZADO', 'Semestral', 'TELD900', 96, 2, 'Noveno Nivel',1),
(2,'PRÁCTICAS LABORALES', 'Semestral', 'PRLD105', 240, 15, 'Noveno Nivel',1),
(2,'PRÁCTICAS DE SERVICIO COMUNITARIO', 'Semestral', 'PSCD202', 96, 6, 'Noveno Nivel',1),
(2,'MARCO REGULATORIO DE LOS SERVICIOS DE TELECOMUNICACIONES', 'Semestral', 'TELD941', 48, 2, 'Noveno Nivel',1),
(2,'TRABAJO DE INTEGRACIÓN CURRICULAR/EXAMEN DE CARÁCTER COMPLEXIVO', 'Semestral', 'TITD201', 240, 15, 'Noveno Nivel',1),
--TICs Maestria I
(3,'FUNDAMENTOS DE SEGURIDAD', 'Modular', 'MPTI113', 48, 6, 'Master Primer Nivel',1),
(3,'FUNDAMENTOS DE INTERNET DE LAS COSAS', 'Modular', 'MPTI133', 64, 8, 'Master Primer Nivel',1),
(3,'SEGURIDAD DE REDES I', 'Modular', 'MPTI133S', 64, 6, 'Master Primer Nivel',1),
(3,'FUNDAMENTOS DE COMPUTACIÓN EN LA NUBE', 'Modular', 'MPTI124', 64, 8, 'Master Primer Nivel',1),
(3,'PROGRAMACIÓN PARA MANIPULACIÓN DE DATOS', 'Modular', 'MPTI143', 48, 6, 'Master Primer Nivel',1),
(3,'SEGURIDAD DE REDES II', 'Modular', 'MPTI143S', 64, 8, 'Master Primer Nivel',1),
(3,'SEMINARIO DE GRADUACIÓN', 'Semestral', 'MPTI152', 32, 2, 'Primer Nivel',1),
(3,'MODELOS DE NEGOCIOS EN LOS ECOSISTEMAS IOT', 'Modular', 'MPTI222', 32, 4, 'Master Segundo Nivel',1),
(3,'APRENDIZAJE AUTOMÁTICO APLICADO', 'Modular', 'MPTI243', 64, 8, 'Master Segundo Nivel',1),
(3,'SEGURIDAD EN ENDPOINTS', 'Modular', 'MPTI224S', 64, 8, 'Segundo Nivel',1),
(3,'MONITOREO Y DETECCIÓN DE INTRUSIÓN DE REDES', 'Modular', 'MPTI242S', 64, 8, 'Master Segundo Nivel',1),
(3,'APLICACIONES PARA INTERNET DE LAS COSAS', 'Modular', 'MPTI234', 64, 8, 'Master Segundo Nivel',1),
(3,'TÓPICOS DE PLANIFICACIÓN Y REGULACIÓN EN TI', 'Modular', 'MPTI213', 48, 6, 'Master Segundo Nivel',1),
(3,'TÉCNICAS DE HACKING', 'Modular', 'MPTI233S', 32, 4, 'Master Segundo Nivel',1),
(3,'TRABAJO DE TITULACIÓN /EXAMEN COMPLEXIVO', 'Semestral', 'MPTI253', 0, 0, 'Master Segundo Nivel',1),
--TICs Maestria II
(4,'MODELOS DE NEGOCIOS EN LOS ECOSISTEMAS IOT', 'Modular', 'MPTI222', 32, 4, 'Master Segundo Nivel',1),
(4,'APRENDIZAJE AUTOMÁTICO APLICADO', 'Modular', 'MPTI243', 64, 8, 'Master Segundo Nivel',1),
(4,'SEGURIDAD EN ENDPOINTS', 'Modular', 'MPTI224S', 64, 8, 'Master Segundo Nivel',1),
(4,'MONITOREO Y DETECCIÓN DE INTRUSIÓN DE REDES', 'Modular', 'MPTI242S', 64, 8, 'Master Segundo Nivel',1),
(4,'APLICACIONES PARA INTERNET DE LAS COSAS', 'Modular', 'MPTI234', 64, 8, 'Master Segundo Nivel',1),
(4,'TÓPICOS DE PLANIFICACIÓN Y REGULACIÓN EN TI', 'Modular', 'MPTI213', 48, 6, 'Master Segundo Nivel',1),
(4,'TÉCNICAS DE HACKING', 'Modular', 'MPTI233S', 32, 4, 'Master Segundo Nivel',1),
(4,'TRABAJO DE TITULACIÓN /EXAMEN COMPLEXIVO', 'Semestral', 'MPTI253', 0, 0, 'Master Segundo Nivel',1),
--TELE Maestria I
(5,'PROBABILIDAD Y ESTADÍSTICA', 'Semestral', 'MITR-113', 144, 3, 'Master Primer Nivel',1),
(5,'PROCESAMIENTO DE SEÑALES', 'Semestral', 'MITR-123', 144, 3, 'Master Primer Nivel',1),
(5,'RADIO FRECUENCIA', 'Semestral', 'MITR-133', 144, 3, 'Master Primer Nivel',1),
(5,'HERRAMIENTAS DE SIMULACIÓN E IMPLEMENTACIÓN EN HARDWARE', 'Semestral', 'MITR-143', 144, 3, 'Master Primer Nivel',1),
(5,'METODOLOGÍA Y DOCUMENTACIÓN CIENTÍFICA', 'Semestral', 'MITR-153', 144, 3, 'Master Primer Nivel',1),
(5,'PROCESAMIENTO AVANZADO DE SEÑALES', 'Semestral', 'MITR-213', 144, 3, 'Master Segundo Nivel',1),
(5,'TÉCNICAS AVANZADAS DE COMUNICACIONES', 'Semestral', 'MITR-224', 192, 4, 'Master Segundo Nivel',1),
(5,'ESTUDIO DEL CANAL INALÁMBRICO Y TÉCNICAS DE MITIGACIÓN', 'Semestral', 'MITR-233', 144, 3, 'Master Segundo Nivel',1),
(5,'COMUNICACIONES MÓVILES DE BANDA ANCHA', 'Semestral', 'MITR-243', 144, 3, 'Master Segundo Nivel',1),
(5,'SEMINARIO', 'Semestral', 'MITR-252', 96, 2, 'Master Segundo Nivel',1),
(5,'TESIS', 'Semestral', 'MITR-3115', 720, 15, 'Master Tercer Nivel',1)
--***************************************************
GO
-- Table: Semestre 
-- DATA INSERT
--  TABLA: Semestre   DATOS    ('Codigo Semestre',AñoSemestre,diaInicio,diaFin,numSemanasClase,numSemanasSemestre,'Estado')
INSERT INTO tblSemestre VALUES('2022B',2022,'2022-10-03','2023-03-31',18,26,1);
--AGREGAR GRUPOS A ASIGNATURAS
INSERT INTO tblGrAsignatura(idAsignatura,grupoAsignatura)
VALUES
--TI Carreer
--INGE HELPER
(1, 'GR1'), (1, 'GR2'),(1, 'GR3'), (1, 'GR4'),(1, 'GR5'), (1, 'GR6'),(1, 'GR7'), (1, 'GR8'),(1, 'GR9'), (1, 'GR10'), -- HERRAMIENTAS INFORMÁTICAS
--(2, 'GR1'), (2, 'GR2'), -- PROGRAMACIÓN ++++-- CÁLCULO VECTORIAL
(2, 'GR1'), (2, 'GR2'), -- CÁLCULO VECTORIAL
(3, 'GR1'), (3, 'GR2'), -- SISTEMAS DIGITALES
--(5, 'GR1'), (5, 'GR2'), -- DISPOSITIVOS ELECTRÓNICOS
--(6, 'GR1'), (6, 'GR2'), -- TEORÍA ELECTROMAGNÉTICA
(4, 'GR1'), (4, 'GR2'), -- FUNDAMENTOS DE CIRCUITOS ELÉCTRICOS
(5, 'GR1'), (5, 'GR2'), -- ASIGNATURA DE ARTES Y HUMANIDADES
(6, 'GR1'), (6, 'GR2'), -- MATEMÁTICA DISCRETA
--(10, 'GR1'), (10, 'GR2'), -- INSTALACIONES ELÉCTRICAS Y COMUNICACIONES
--(11, 'GR1'), (11, 'GR2'), -- ANÁLISIS DE SEÑALES DISCRETAS PARA COMUNICACIONES
(7, 'GR1'), (7, 'GR2'), -- PROGRAMACIÓN AVANZADA
(8, 'GR1'), (8, 'GR2'), -- BASES DE DATOS
(9, 'GR1'), (9, 'GR2'), -- SISTEMAS OPERATIVOS
(10, 'GR1'), (10, 'GR2'), -- ASIGNATURA DE ECONOMÍA Y SOCIEDAD
(11, 'GR1'), (11, 'GR2'), -- SISTEMAS DE CABLEADO ESTRUCTURADO
(12, 'GR1'), (12, 'GR2'), -- TRANSMISIÓN DIGITAL
(13, 'GR1'), (13, 'GR2'), -- TEORÍA DE INFORMACIÓN Y CODIFICACIÓN
(14, 'GR1'), (14, 'GR2'), -- DISEÑO Y PROGRAMACIÓN DE SOFTWARE
(15, 'GR1'), (15, 'GR2'), -- SISTEMAS EMBEBIDOS
(16, 'GR1'), (16, 'GR2'), -- GESTIÓN ORGANIZACIONAL
(17, 'GR1'), (17, 'GR2'), -- CABLEADO ESTRUCTURADO AVANZADO
(18, 'GR1'), (18, 'GR2'), -- REDES DE ÁREA LOCAL
(19, 'GR1'), (19, 'GR2'), -- ENRUTAMIENTO
(20, 'GR1'), (20, 'GR2'), -- SISTEMAS INALÁMBRICOS
(21, 'GR1'), (21, 'GR2'), -- ALMACENAMIENTO Y PROCESAMIENTO DE DATOS
(22, 'GR1'), (22, 'GR2'), -- GESTIÓN DE PROCESOS Y CALIDAD
(23, 'GR1'), (23, 'GR2'), -- APLICACIONES DISTRIBUIDAS
(24, 'GR1'), (24, 'GR2'), -- REDES DE ÁREA EXTENDIDA
(25, 'GR1'), (25, 'GR2'), -- SEGURIDAD EN REDES
(26, 'GR1'), (26, 'GR2'), -- REDES E INTRANETS
(27, 'GR1'), (27, 'GR2'), -- APLICACIONES WEB Y MÓVILES
(28, 'GR1'), (28, 'GR2'), -- INGENIERÍA FINANCIERA
(29, 'GR1'), (29, 'GR2'), -- ASIGNATURA BÁSICA DE ITINERARIO
(30, 'GR1'), (30, 'GR2'), -- EVALUACIÓN DE REDES
(31, 'GR1'), (31, 'GR2'), -- REDES DE ÁREA LOCAL INALÁMBRICAS
(32, 'GR1'), (32, 'GR2'), -- ADMINISTRACIÓN DE REDES
(33, 'GR1'), (33, 'GR2'), -- MINERIA DE DATOS
(34, 'GR1'), (34, 'GR2'), -- SISTEMAS IOT
(35, 'GR1'), (35, 'GR2'), -- ASIGNATURA AVANZADA DE ITINERARIO
(36, 'GR1'), (36, 'GR2'), -- PRÁCTICAS LABORALES
(37, 'GR1'), (37, 'GR2'), -- PRÁCTICAS DE SERVICIO COMUNITARIO
(38, 'GR1'), (38, 'GR2'), -- REGULACIÓN DE LAS TECNOLOGÍAS DE IA INFORMACIÓN Y LA COMUNICACIÓN
(39, 'GR1'), (39, 'GR2'), -- TRABAJO DE INTEGRACIÓN CURRICULAR/EXAMEN DE CARÁCTER COMPLEXIVO
(40, 'GR1'), (40, 'GR2'), (40, 'GR3'), (40, 'GR4'), -- LABORATORIO DE SISTEMAS DIGITALES		
(41, 'GR1'), (41, 'GR2'), (41, 'GR3'), (41, 'GR4'), -- LABORATORIO DE DISPOSITIVOS ELECTRÓNICOS		
(42, 'GR1'), (42, 'GR2'), (42, 'GR3'), (42, 'GR4'), -- LABORATORIO DE FUNDAMENTOS DE CIRCUITOS ELÉCTRICOS		
(43, 'GR1'), (43, 'GR2'), (43, 'GR3'), (43, 'GR4'), -- LABORATORIO DE TRANSMISIÓN DIGITAL		
(44, 'GR1'), (44, 'GR2'), (44, 'GR3'), (44, 'GR4'), -- LABORATORIO DE SISTEMAS EMBEBIDOS		
(45, 'GR1'), (45, 'GR2'), (45, 'GR3'), (45, 'GR4'), -- LABORATORIO DE REDES DE ÁREA LOCAL		
(46, 'GR1'), (46, 'GR2'), (46, 'GR3'), (46, 'GR4'), -- LABORATORIO DE ENRUTAMIENTO		
(47, 'GR1'), (47, 'GR2'), (47, 'GR3'), (47, 'GR4'), -- LABORATORIO DE REDES DE ÁREA EXTENDIDA	
-- TELECOMUNICACIONES
(48, 'GR1'), (48, 'GR2'), -- HERRAMIENTAS INFORMÁTICAS
(49, 'GR1'), (49, 'GR2'), -- CÁLCULO VECTORIAL 
(50, 'GR1'), (50, 'GR2'), -- PROGRAMACIÓN 
(51, 'GR1'), (51, 'GR2'), -- SISTEMAS DIGITALES 
(52, 'GR1'), (52, 'GR2'), -- DISPOSITIVOS ELECTRÓNICOS 
(54, 'GR1'), (54, 'GR2'), -- TEORÍA ELECTROMAGNÉTICA 
(55, 'GR1'), (55, 'GR2'), -- FUNDAMENTOS DE CIRCUITOS ELÉCTRICOS 
(56, 'GR1'), (56, 'GR2'), -- ASIGNATURA DE ARTES Y HUMANIDADES
--(61, 'GR1'), (61, 'GR2'), -- MATEMÁTICA DISCRETA 
(57, 'GR1'), (57, 'GR2'), -- INSTALACIONES ELÉCTRICAS Y DE COMUNICACIONES
(58, 'GR1'), (58, 'GR2'), -- ANÁLISIS DE SEÑALES DISCRETAS PARA COMUNICACIONES 
(59, 'GR1'), (59, 'GR2'), -- CIRCUITOS ELECTRÓNICOS 
--(65, 'GR1'), (65, 'GR2'), -- PROGRAMACIÓN AVANZADA 
(60, 'GR1'), (60, 'GR2'), -- SISTENA OPERATIVO LINUX
(61, 'GR1'), (61, 'GR2'), -- ASIGNATURA DE ECONOMÍA Y SOCIEDAD
(62, 'GR1'), (62, 'GR2'), -- FUNDAMENTOS DE COMUNICACIONES 
(63, 'GR1'), (63, 'GR2'), -- TEORÍA DE LA INFORMACIÓN Y CODIFICACIÓN
(64, 'GR1'), (64, 'GR2'), -- PROCESAMIENTO DIGITAL DE SEÑALES 
(65, 'GR1'), (65, 'GR2'), -- SISTEMAS EMBEBIDOS 
(66, 'GR1'), (66, 'GR2'), -- SISTEMAS DE TRANSMISIÓN 
--(73, 'GR1'), (73, 'GR2'), -- SISTEMAS DE CABLEADO ESTRUCTURADO
(67, 'GR1'), (67, 'GR2'), -- COMUNICACIÓN DIGITAL 
(68, 'GR1'), (68, 'GR2'), -- TELEMÁTICA BÁSICA
(69, 'GR1'), (69, 'GR2'), -- ELECTRÓNICA DE RADIOFRECUENCIA 
(70, 'GR1'), (70, 'GR2'), -- APLICACIONES CON SISTEMAS EMBEBIDOS 
(71, 'GR1'), (71, 'GR2'), -- PROPAGACIÓN Y ANTENAS 
(72, 'GR1'), (72, 'GR2'), -- GESTIÓN ORGANIZACIONAL 
(73, 'GR1'), (73, 'GR2'), -- COMUNICACIONES ÓPTICAS
(74, 'GR1'), (74, 'GR2'), -- TELEMÁTICA AVANZADA
(75, 'GR1'), (75, 'GR2'), -- COMUNICACIONES INALÁMBRICAS
(76, 'GR1'), (76, 'GR2'), -- TELEFONÍA IP
(77, 'GR1'), (77, 'GR2'), -- INGENIERÍA DE MICROONDAS 
(78, 'GR1'), (78, 'GR2'), -- GESTIÓN DE PROCESOS Y CALIDAD 
(79, 'GR1'), (79, 'GR2'), -- ITINERARIO BÁSICO
(80, 'GR1'), (80, 'GR2'), -- REDES ÓPTICAS
(81, 'GR1'), (81, 'GR2'), -- INTRODUCCIÓN A DISEÑO DE REDES 
(82, 'GR1'), (82, 'GR2'), -- SISTEMAS CELULARES
(83, 'GR1'), (83, 'GR2'), -- FUNDAMENTOS DE SEGURIDAD
(84, 'GR1'), (84, 'GR2'), -- INGENIERÍA FINANCIERA
(85, 'GR1'), (85, 'GR2'), -- DISEÑO DE PROYECTOS DE TELECOMUNICACIONES 
(86, 'GR1'), (86, 'GR2'), -- ITINERARIO AVANZADO
(87, 'GR1'), (87, 'GR2'), -- PRÁCTICAS LABORALES
(88, 'GR1'), (88, 'GR2'), -- PRÁCTICAS DE SERVICIO COMUNITARIO
(89, 'GR1'), (89, 'GR2'), -- MARCO REGULATORIO DE LOS SERVICIOS DE TELECOMUNICACIONES
(90, 'GR1'), (90, 'GR2'), -- TRABAJO DE INTEGRACIÓN CURRICULAR/EXAMEN DE CARÁCTER COMPLEXIVO
-- TIC MAESTRIA MATERIAS
(91, 'GR1'), (91, 'GR2'), -- FUNDAMENTOS DE SEGURIDAD
(92, 'GR1'), (92, 'GR2'), -- FUNDAMENTOS DE INTERNET DE LAS COSAS
(93, 'GR1'), (93, 'GR2'), -- SEGURIDAD DE REDES I
(94, 'GR1'), (94, 'GR2'), -- FUNDAMENTOS DE COMPUTACIÓN EN LA NUBE
(95, 'GR1'), (95, 'GR2'), -- PROGRAMACIÓN PARA MANIPULACIÓN DE DATOS
(96, 'GR1'), (96, 'GR2'), -- SEGURIDAD DE REDES II
(97, 'GR1'), (97, 'GR2'), -- SEMINARIO DE GRADUACIÓN
(98, 'GR1'), (98, 'GR2'), -- MODELOS DE NEGOCIOS EN LOS ECOSISTEMAS IOT
(99, 'GR1'), (99, 'GR2'), -- APRENDIZAJE AUTOMÁTICO APLICADO
(100, 'GR1'), (100, 'GR2'), -- SEGURIDAD EN ENDPOINTS
(101, 'GR1'), (101, 'GR2'), -- MONITOREO Y DETECCIÓN DE INTRUSIÓN DE REDES
(102, 'GR1'), (102, 'GR2'), -- APLICACIONES PARA INTERNET DE LAS COSAS
(103, 'GR1'), (103, 'GR2'), -- TÓPICOS DE PLANIFICACIÓN Y REGULACIÓN EN TI
(104, 'GR1'), (104, 'GR2'), -- TÉCNICAS DE HACKING
(105, 'GR1'), (105, 'GR2'); -- TRABAJO DE TITULACIÓN /EXAMEN COMPLEXIVO
--PARTE 2 TIC MAESTRIAS
GO
--ADD HORARIOS
--                             idSemestre, idGrAsig, horaInicio, horaFin, dia
--exec [spAddHorarioAsigNoOut]  1,1,'08:00', '10:00',1
--exec [spAddHorarioAsigNoOut]  1,1,'08:00', '10:00',2
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',3
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',4
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',5
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',6
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',7

--exec [spAddHorarioAsigNoOut]  1,1,'08:00', '10:00',1
--exec [spAddHorarioAsigNoOut]  1,1,'08:00', '10:00',2
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',3
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',4
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',5
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',6
--exec [spAddHorarioAsigNoOut]  1,1,'00:00', '00:00',7

PRINT 'DataBase Created';
-- END SCRIPT

-- NUEVOS SPS AGREGADOS 21-AGO



-------------------------------