go
use ServiceFinder
go
--******** VALIDAMOS SI EXISTE EL PROCEDIMIENTO ********--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rsn_registrar')
DROP PROCEDURE rsn_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rsn_modificar')
DROP PROCEDURE rsn_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rsn_obtener')
DROP PROCEDURE rsn_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rsn_listar')
DROP PROCEDURE rsn_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rsn_eliminar')
DROP PROCEDURE rsn_eliminar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rsn_obtenerResenaProfesionista')
DROP PROCEDURE rsn_obtenerResenaProfesionista

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rsn_obtenerResenaCliente')
DROP PROCEDURE rsn_obtenerResenaCliente

go

--******** PROCEDIMIENTOS PARA CREAR ********--
create procedure rsn_registrar(
@calificacion float,
@comentario varchar(500),
@idProfesionista int,
@idCliente int
)
as
begin

insert into Resena(calificacion,comentario,idProfesionista,idCliente)
values
(
@calificacion,
@comentario,
@idProfesionista,
@idCliente
)

end

--******** PROCEDIMIENTOS PARA MODIFICAR ********--
go

create procedure rsn_modificar(
@idResena int,
@calificacion float,
@comentario varchar(500),
@idProfesionista int,
@idCliente int
)
as
begin

update Resena set 
calificacion = @calificacion,
comentario = @comentario,
idProfesionista = @idProfesionista,
idCliente = @idCliente
where idResena = @idResena

end

--******** PROCEDIMIENTOS PARA OBTENER PROFESIONISTA********--

go

create procedure rsn_obtenerResenaProfesionista(@idProfesionista int)
as
begin

select * from Resena where idProfesionista = @idProfesionista
end

--******** PROCEDIMIENTOS PARA OBTENER POR USUARIO********--

go

create procedure rsn_obtenerResenaCliente(@idCliente int)
as
begin

select * from Resena where idCliente = @idCliente
end

--******** PROCEDIMIENTOS PARA LISTAR TODO********--

go
create procedure rsn_listar
as
begin

select * from Resena
end

go

--******** PROCEDIMIENTOS PARA Eliminar********--

go

create procedure rsn_eliminar(
@idResena int
)
as
begin

delete from Resena where idResena = @idResena

end

go