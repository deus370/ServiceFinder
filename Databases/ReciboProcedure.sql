go
use ServiceFinder
go
--******** VALIDAMOS SI EXISTE EL PROCEDIMIENTO ********--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rec_registrar')
DROP PROCEDURE rec_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rec_modificar')
DROP PROCEDURE rec_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rec_obtener')
DROP PROCEDURE rec_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rec_listar')
DROP PROCEDURE rec_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rec_eliminar')
DROP PROCEDURE rec_eliminar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rec_obtenerResenaProfesionista')
DROP PROCEDURE rec_obtenerResenaProfesionista

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'rec_obtenerResenaCliente')
DROP PROCEDURE rec_obtenerResenaCliente

go

--******** PROCEDIMIENTOS PARA CREAR ********--
create procedure rec_registrar(
@total decimal(15,2),
@idServicio int,
@idCliente int,
@idProfesionista int,
@idSolicitud int
)
as
begin

insert into Recibo(total,idServicio,idCliente,idProfesionista,idSolicitud)
values
(
@total,
@idServicio,
@idCliente,
@idProfesionista,
@idSolicitud
)

end

--******** PROCEDIMIENTOS PARA MODIFICAR ********--
go

create procedure rec_modificar(
@idRecibo int,
@total decimal(15,2),
@idServicio int,
@idCliente int,
@idProfesionista int,
@idSolicitud int
)
as
begin

update Recibo set 
total = @total,
idServicio = @idServicio,
idCliente = @idCliente,
idProfesionista = @idProfesionista,
idSolicitud = @idSolicitud
where idRecibo = @idRecibo

end

--******** PROCEDIMIENTOS PARA OBTENER PROFESIONISTA********--

go

create procedure rec_obtenerReciboProfesionista(@idProfesionista int)
as
begin

select * from Recibo where idProfesionista = @idProfesionista
end


--******** PROCEDIMIENTOS PARA LISTAR TODO********--

go
create procedure rec_listar
as
begin

select * from Recibo
end

go

--******** PROCEDIMIENTOS PARA Eliminar********--

go

create procedure rec_eliminar(
@idRecibo int
)
as
begin

delete from Recibo where idRecibo = @idRecibo

end

go