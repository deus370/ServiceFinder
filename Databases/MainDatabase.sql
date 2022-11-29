CREATE DATABASE ServiceFinder
GO
USE ServiceFinder
GO

CREATE TABLE Usuario(
	idUsuario int primary key identity NOT NULL,
	correo int NULL,
	contrasenia varchar(100) NULL,
	nombre varchar(100) NULL,
	apellidoPaterno varchar(100) NULL,
	apellidoMaterno varchar(100) NULL,
	estatus int NULL,
	idRol int NULL
)

CREATE TABLE Profesion(
	idProfesion int primary key identity NOT NULL,
	profesion varchar(200) NULL,
	estatus int NULL,
)

CREATE TABLE Profesionista(
	idProfesionista int primary key identity NOT NULL,
	descripcion varchar(5000) NULL,
	idProfesion int NULL,
	estatus int NULL,
	idUsuario int NULL,
)

CREATE TABLE Cliente(
	idCliente int primary key identity NOT NULL,
	idUsuario int NULL,
	estatus int NULL,
)

CREATE TABLE Servicio(
	idServicio int primary key identity NOT NULL,
	servicio varchar(100) NULL,
	descripcion varchar(500) NULL,
	precio int,
	idProfesionista int NULL,
)

CREATE TABLE Resena(
	idResena int primary key identity NOT NULL,
	comentario varchar(500) NULL,
	calificacion float NULL,
	idUsuario int NULL,
	idProfesionista int NULL,
)