go
use ServiceFinder
go
--******** VALIDAMOS SI EXISTE EL PROCEDIMIENTO ********--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'est_registrar')
DROP PROCEDURE est_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'est_modificar')
DROP PROCEDURE est_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'est_obtener')
DROP PROCEDURE est_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'est_listar')
DROP PROCEDURE est_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'est_eliminar')
DROP PROCEDURE est_eliminar

go

--******** PROCEDIMIENTOS PARA CREAR ********--
create procedure est_registrar(
@estatus int
)
as
begin

insert into Estatus(estatus)
values
(
@estatus
)

end

--******** PROCEDIMIENTOS PARA MODIFICAR ********--
go

create procedure est_modificar(
@idEstatus int,
@estatus int
)
as
begin

update Estatus set 
estatus = @estatus
where idEstatus = @idEstatus

end

--******** PROCEDIMIENTOS PARA OBTENER PROFESIONISTA********--

go

create procedure est_obtener(@idEstatus int)
as
begin

select * from Estatus where idEstatus = @idEstatus
end

--******** PROCEDIMIENTOS PARA LISTAR TODO********--

go
create procedure est_listar
as
begin

select * from Estatus
end

go

--******** PROCEDIMIENTOS PARA Eliminar********--

go

create procedure est_eliminar(
@idEstatus int
)
as
begin

update Estatus set 
estatus = 0
where idEstatus = @idEstatus

end

go