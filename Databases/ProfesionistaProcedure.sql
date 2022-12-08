go
use ServiceFinder
go
--******** VALIDAMOS SI EXISTE EL PROCEDIMIENTO ********--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prof_registrar')
DROP PROCEDURE prof_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prof_modificar')
DROP PROCEDURE prof_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prof_obtener')
DROP PROCEDURE prof_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prof_listar')
DROP PROCEDURE prof_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'prof_eliminar')
DROP PROCEDURE prof_eliminar

go

--******** PROCEDIMIENTOS PARA CREAR ********--
create procedure prof_registrar(
@descripcion varchar(5000),
@idProfesion int NULL,

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
3
)

DECLARE @idUsuario int;
SET @idUsuario = (SELECT MAX(idUsuario) AS LastID FROM Usuario);

insert into Profesionista(descripcion,idProfesion,estatus,idUsuario)
values
(
@descripcion,
@idProfesion,
1,
@idUsuario
)

end

--******** PROCEDIMIENTOS PARA MODIFICAR ********--
go

create procedure prof_modificar(
@idProfesionista int,
@descripcion varchar(5000),
@idProfesion int NULL,
@idUsuario int ,

@correo varchar(100),
@contrasenia varchar(100),
@nombre varchar(100),
@apellidoPaterno varchar(100),
@apellidoMaterno varchar(100)
)
as
begin

update Usuario set 
correo = @correo,
contrasenia = @contrasenia,
nombre = @nombre,
apellidoPaterno = @apellidoPaterno,
apellidoMaterno = @apellidoMaterno
where idUsuario = @idUsuario

update Profesionista set 
descripcion = @descripcion,
idProfesion = @idProfesion,
idUsuario = @idUsuario
where idProfesionista = @idProfesionista

end

--******** PROCEDIMIENTOS PARA OBTENER PROFESIONISTA********--

go

create procedure prof_obtener(@idProfesionista int)
as
begin

select * from Usuario us join Profesionista pr on us.idUsuario = pr.idUsuario  where idProfesionista = @idProfesionista
end

--******** PROCEDIMIENTOS PARA LISTAR TODO********--

go

create procedure prof_listar
as
begin

select * from Usuario us join Profesionista pr on us.idUsuario = pr.idUsuario

end

go

--******** PROCEDIMIENTOS PARA Eliminar********--

go

create procedure prof_eliminar(
@idProfesionista int,
@idUsuario int
)
as
begin

update Profesionista set 
estatus = 0
where idProfesionista = @idProfesionista

update Usuario set 
estatus = 0
where idUsuario = @idUsuario

end

go


create procedure prof_obtenerPorUsuario(@idUsuario int)
as
begin

select * from Usuario us join Profesionista pr on us.idUsuario = pr.idUsuario  where pr.idUsuario = @idUsuario
end


go


