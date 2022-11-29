go
use ServiceFinder
go
--******** VALIDAMOS SI EXISTE EL PROCEDIMIENTO ********--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ser_registrar')
DROP PROCEDURE ser_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ser_modificar')
DROP PROCEDURE ser_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ser_obtener')
DROP PROCEDURE ser_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ser_listar')
DROP PROCEDURE ser_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ser_eliminar')
DROP PROCEDURE ser_eliminar

go

--******** PROCEDIMIENTOS PARA CREAR ********--
create procedure ser_registrar(
@servicio varchar(100),
@descripcion varchar(500),
@precio int,
@idProfesionista int
)
as
begin

insert into Servicio(servicio,descripcion,precio,idProfesionista)
values
(
@servicio,
@descripcion,
@precio,
@idProfesionista
)

end

--******** PROCEDIMIENTOS PARA MODIFICAR ********--
go

create procedure ser_modificar(
@idServicio int,
@servicio varchar(100),
@descripcion varchar(500),
@precio int,
@idProfesionista int
)
as
begin

update Servicio set 
servicio = @servicio,
descripcion = @descripcion,
precio = @precio,
idProfesionista = @idProfesionista
where idServicio = @idServicio

end

--******** PROCEDIMIENTOS PARA OBTENER PROFESIONISTA********--

go

create procedure ser_obtener(@idServicio int)
as
begin

select * from Servicio where idServicio = @idServicio
end

--******** PROCEDIMIENTOS PARA LISTAR TODO********--

go
create procedure ser_listar
as
begin

select * from Servicio
end

go

--******** PROCEDIMIENTOS PARA Eliminar********--

go

create procedure ser_eliminar(
@idServicio int
)
as
begin

delete from Servicio where idServicio = @idServicio

end

go