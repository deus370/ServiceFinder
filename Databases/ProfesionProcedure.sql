go
use ServiceFinder
go
--******** VALIDAMOS SI EXISTE EL PROCEDIMIENTO ********--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'profesion_registrar')
DROP PROCEDURE profesion_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'profesion_modificar')
DROP PROCEDURE profesion_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'profesion_obtener')
DROP PROCEDURE profesion_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'profesion_listar')
DROP PROCEDURE profesion_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'profesion_eliminar')
DROP PROCEDURE profesion_eliminar

go

--******** PROCEDIMIENTOS PARA CREAR ********--
create procedure profesion_registrar(
@profesion varchar(100)
)
as
begin

insert into Profesion(profesion, estatus)
values
(
@profesion,
1
1,
1
)

end

--******** PROCEDIMIENTOS PARA MODIFICAR ********--
go

create procedure profesion_modificar(
@idProfesion int,
@profesion varchar(100)
)
as
begin

update Profesion set 
profesion = @profesion
where idProfesion = @idProfesion

end

--******** PROCEDIMIENTOS PARA OBTENER PROFESIONISTA********--

go

create procedure profesion_obtener(@idProf int)
as
begin

select * from Profesion where idProfesion = @idProf
end

--******** PROCEDIMIENTOS PARA LISTAR TODO********--

go
create procedure profesion_listar
as
begin

select * from Profesion
end

go

--******** PROCEDIMIENTOS PARA Eliminar********--

go

create procedure profesion_eliminar(
@idProf int
)
as
begin

update Profesion set 
estatus = 0
where idProfesion = @idProf

end

go