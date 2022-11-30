go
use ServiceFinder
go
--******** VALIDAMOS SI EXISTE EL PROCEDIMIENTO ********--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rol_registrar')
DROP PROCEDURE rol_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rol_modificar')
DROP PROCEDURE rol_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rol_listar')
DROP PROCEDURE rol_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rol_eliminar')
DROP PROCEDURE rol_eliminar

go



--******** PROCEDIMIENTOS PARA CREAR ********--
create procedure rol_registrar(
@rol varchar(100)
)
as
begin

insert into Rol(rol)
values
(
@rol
)

end

--******** PROCEDIMIENTOS PARA MODIFICAR ********--
go

create procedure rol_modificar(
@idRol int,
@rol varchar(100)
)
as
begin

update Rol set 
rol = @rol
where idRol = @idRol

end

--******** PROCEDIMIENTOS PARA Eliminar********--

go

create procedure rol_eliminar(
@idRol int
)
as
begin

delete from Rol where idRol = idRol

end

go

create procedure rol_listar
as
begin

select * from Rol

end

go