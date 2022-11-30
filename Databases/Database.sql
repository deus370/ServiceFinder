CREATE DATABASE ServiceFinder
GO
USE ServiceFinder
GO

CREATE TABLE Rol(
	idRol int primary key identity NOT NULL,
	rol varchar(100) NULL,
)

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
	calificacion float NULL,
	comentario varchar(500) NULL,
	idProfesionista int NULL,
	idCliente int NULL,
)

CREATE TABLE Recibo(
	idRecibo int primary key identity NOT NULL,
	total decimal(15,2) NULL,
	idServicio int NULL,
	idCliente int NULL,
	idProfesionista int NULL,
	idSolicitud int NULL,
)

CREATE TABLE Solicitud(
	idSolicitud int primary key identity NOT NULL,
	fecha datetime NULL,
	descripcion varchar(5000) NULL,
	telefono varchar(30) NULL,
	idCliente int NULL,
	idProfesionista int NULL,
	idEstatus int NULL,
)