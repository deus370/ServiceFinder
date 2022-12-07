go
use ServiceFinder
go
--******** VALIDAMOS SI EXISTE EL PROCEDIMIENTO ********--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'logs_registrar')
DROP PROCEDURE logs_registrar

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'logs_obtener')
DROP PROCEDURE logs_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'logs_listar')
DROP PROCEDURE logs_listar

go


--******** PROCEDIMIENTOS PARA CREAR ********--
create procedure logs_registrar(
@fecha datetime,
@descripcion varchar(5000),
@idUsuario int NULL
)
as
begin

insert into Logs(fecha,descripcion,idUsuario)
values
(
@fecha,
@descripcion,
@idUsuario
)

end

--******** PROCEDIMIENTOS PARA MODIFICAR ********--
go



create procedure logs_obtener(@idUsuario int)
as
begin

select * from Logs where idUsuario = @idUsuario
end

--******** PROCEDIMIENTOS PARA LISTAR TODO********--

go
create procedure logs_listar
as
begin

select * from Logs
end

go


