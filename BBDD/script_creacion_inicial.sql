IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TP-ROCK')
BEGIN
    CREATE DATABASE [TP-ROCK]
END
GO 

USE [TP-ROCK]
GO
--------------------------Eliminamos las tablas, si existen------------------------------
IF OBJECT_ID('Usuario','U')is not null drop table Usuario;
IF OBJECT_ID('Butaca','U') is not null drop table Butaca;
IF OBJECT_ID('Fila','U') is not null drop table Fila;
IF OBJECT_ID('PrecioEntrada','U') is not null drop table PrecioEntrada;
IF OBJECT_ID('Entrada','U') is not null drop table Entrada;
IF OBJECT_ID('Sector','U') is not null drop table Sector;
IF OBJECT_ID('Estado','U') is not null drop table Estado;
IF OBJECT_ID('TipoEntrada','U') is not null drop table TipoEntrada;
IF OBJECT_ID('GrupoMusical','U') is not null drop table GrupoMusical;
IF OBJECT_ID('DiaFestival','U') is not null drop table DiaFestival;
IF OBJECT_ID('Festival','U') is not null drop table Festival;
------------------------------------------------------------------------------------------

--Crea tabla Festival
CREATE TABLE Festival
(
	id_festival integer PRIMARY KEY IDENTITY(1,1),
	anio_ed integer,
	dto_vta_anticip integer,
	dia_fest integer,
	f_inicio datetime,
	pje_dev_por_anul float
);


--Crea tabla DiaFestival
CREATE TABLE DiaFestival
(
	id_dia integer PRIMARY KEY,
	fecha datetime,
	precio_entr float,
	fecha_vto_anul_entr datetime,
	id_festival integer,
	FOREIGN KEY (id_festival) REFERENCES Festival(id_festival)
);

--Crea tabla GrupoMusical
CREATE TABLE GrupoMusical
(
	id_grupo integer PRIMARY KEY IDENTITY(1,1),
	nombre varchar(100),
	cant_integrantes integer,
	id_dia integer,
	FOREIGN KEY (id_dia) REFERENCES DiaFestival(id_dia)
);

--Crea tabla TipoEntrada
CREATE TABLE TipoEntrada
(
	id_tipo_entrada integer PRIMARY KEY,
	descripcion varchar(200)
);

--Crea tabla Estado
CREATE TABLE Estado
(
	id_estado integer PRIMARY KEY,
	descripcion varchar(200)
);

--Crea tabla Sector
CREATE TABLE Sector
(
	id_sector integer PRIMARY KEY NOT NULL,
	letra varchar(2),
	color varchar(20),
	id_dia integer,
	FOREIGN KEY (id_dia) REFERENCES DiaFestival(id_dia)
);


--Crea tabla Entrada
CREATE TABLE Entrada
(
	id_entrada integer PRIMARY KEY,
	fec_vta datetime,
	monto float,
	nro_ticket integer,
	id_sector integer,
	id_estado integer,
	FOREIGN KEY (id_sector) REFERENCES Sector(id_sector),
	FOREIGN KEY (id_estado) REFERENCES Estado(id_estado)
);

--Crea tabla PrecioEntrada
CREATE TABLE PrecioEntrada
(
	id_precio integer PRIMARY KEY,
	dia_festival integer,
	precio float,
	tipo_entrada integer,
	id_entrada integer,
	id_dia integer,
	id_tipo_entrada integer,
	FOREIGN KEY (id_entrada) REFERENCES Entrada(id_entrada),
	FOREIGN KEY (id_tipo_entrada) REFERENCES TipoEntrada(id_tipo_entrada),
	FOREIGN KEY (id_dia) REFERENCES DiaFestival(id_dia)
);

--Crea tabla Fila
CREATE TABLE Fila
(
	id_fila integer PRIMARY KEY,
	numero integer,
	id_sector integer,
	FOREIGN KEY (id_sector) REFERENCES Sector(id_sector)
);

--Crea tabla Butaca
CREATE TABLE Butaca
(
	id_butaca integer PRIMARY KEY,
	--numero integer, <-- WTF???
	disponibilidad bit,
	id_fila integer,
	id_entrada integer,
	id_dia integer,
	FOREIGN KEY (id_fila) REFERENCES Fila(id_fila),
	FOREIGN KEY (id_dia) REFERENCES DiaFestival(id_dia),
	FOREIGN KEY (id_dia) REFERENCES DiaFestival(id_dia)
);


--Crea tabla Usuario
CREATE TABLE Usuario
(
	nombre varchar(20) PRIMARY KEY,
	password nvarchar(100) NOT NULL
);


GO
--Agrego un usuario
INSERT INTO Usuario (nombre,password) VALUES ('admin','admin');

GO
--Store Procedure para agregar festivales
CREATE PROCEDURE insertarFestival
(@anio int, @dto int, @dia int, @fecha datetime, @dev float)
AS
INSERT
INTO Festival(anio_ed, dto_vta_anticip, dia_fest, f_inicio, pje_dev_por_anul)
VALUES(@anio, @dto, @dia, @fecha, @dev)

GO
--Store Procedure para eliminar festivales
CREATE PROCEDURE eliminarFestival
(@fech datetime)
AS
DELETE Festival
WHERE f_inicio = @fech

GO
--Store Procedure para agregar banda
CREATE PROCEDURE insertarBanda
(@nom varchar(100), @cint int)
AS
INSERT
INTO GrupoMusical(nombre, cant_integrantes)
VALUES(@nom, @cint)

GO
--Store Procedure para eliminar banda
CREATE PROCEDURE eliminarBanda
(@nom varchar(100))
AS
DELETE GrupoMusical
WHERE nombre = @nom

GO
DROP PROCEDURE insertarFestival
GO
DROP PROCEDURE eliminarFestival
GO
DROP PROCEDURE insertarBanda
GO
DROP TABLE Butaca
GO
DROP TABLE Fila
GO
DROP TABLE PrecioEntrada
GO
DROP TABLE Entrada
GO
DROP TABLE Sector
GO
DROP TABLE Estado
GO
DROP TABLE TipoEntrada
GO
DROP TABLE GrupoMusical
GO
DROP TABLE DiaFestival
GO
DROP TABLE Festival
GO

