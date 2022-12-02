go
use ServiceFinder
go
--******** VALIDAMOS SI EXISTE EL PROCEDIMIENTO ********--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'user_registrar')
DROP PROCEDURE user_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'user_modificar')
DROP PROCEDURE user_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'user_obtener')
DROP PROCEDURE user_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'user_listar')
DROP PROCEDURE user_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'user_eliminar')
DROP PROCEDURE user_eliminar

go

--******** PROCEDIMIENTOS PARA CREAR ********--
create procedure user_registrar(
@correo varchar(100),
@contrasenia varchar(100),
@nombre varchar(100),
@apellidoPaterno varchar(100),
@apellidoMaterno varchar(100)
)
as
begin

insert into Usuario(correo,contrasenia,nombre,apellidoPaterno,apellidoMaterno,estatus,idRol)
values
(
@correo,
@contrasenia,
@nombre,
@apellidoPaterno,
@apellidoMaterno,
1,
1
)

end

--******** PROCEDIMIENTOS PARA MODIFICAR ********--
go

create procedure user_modificar(
@idUsuario int,
@correo varchar(100),
@contrasenia varchar(100),
@nombre varchar(100),
@apellidoP varchar(100),
@apellidoM varchar(100),
@estatus int,
@idRol int
)
as
begin

update Usuario set 
correo = @correo,
contrasenia = @contrasenia,
nombre = @nombre,
apellidoPaterno = @apellidoP,
apellidoMaterno = @apellidoM,
estatus = @estatus,
idRol = @idRol
where idUsuario = @idUsuario

end

--******** PROCEDIMIENTOS PARA OBTENER PROFESIONISTA********--

go

create procedure user_obtener(@idUsuario int)
as
begin

select * from Usuario where idUsuario = @idUsuario
end

--******** PROCEDIMIENTOS PARA LISTAR TODO********--

go
create procedure user_listar
as
begin

select * from Usuario
end

go

--******** PROCEDIMIENTOS PARA Eliminar********--

go

create procedure user_eliminar(
@idUsuario int
)
as
begin

update Usuario set 
estatus = 0
where idUsuario = @idUsuario

end

go