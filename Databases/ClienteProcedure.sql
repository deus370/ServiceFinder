USE ServiceFinder
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--******** PROCEDIMIENTOS PARA ELIMINAR CLIENTE ********--

create procedure [dbo].[cli_eliminar](
@idUsuario int
)
as
begin

delete from Usuario where idUsuario = @idUsuario
delete from Cliente where idUsuario = @idUsuario 
end


GO
--******** PROCEDIMIENTOS PARA LISTAR CLIENTES ********--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[cli_listar]
as
begin

select * from Usuario us join Cliente cl on us.idUsuario = cl.idUsuario
end


GO
--******** PROCEDIMIENTO PARA MODIFICAR CLIENTE ********--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[cli_modificar](
	@idUsuario int,
	@nombre VARCHAR(50),
	@apePaterno VARCHAR(50),
	@apeMaterno VARCHAR(50),
	@correo VARCHAR(50),
	@contrasenia VARCHAR(50),
	@estatus int
)
as
begin

update Usuario set 
nombre = @nombre,
apellidoPaterno = @apePaterno,
apellidoMaterno = @apeMaterno,
correo = @correo,
contrasenia = @contrasenia,
estatus = @estatus
where idUsuario = @idUsuario

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--******** PROCEDIMIENTOS PARA OBTENER CLIENTE ********--

create procedure [dbo].[cli_obtenerCliente](@idCliente int)
as
begin

select * from Usuario us join Cliente cl on us.idUsuario = cl.idUsuario  where idCliente = @idCliente
end



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--******** PROCEDIMIENTOS PARA REGISTRAR CLIENTE ********--

create procedure [dbo].[cli_registrar](
	@nombre VARCHAR(50),
	@apePaterno VARCHAR(50),
	@apeMaterno VARCHAR(50),
	@correo VARCHAR(50),
	@contrasenia VARCHAR(50),
	@estatus VARCHAR(50),
	@idUsuario int
)
as
begin

insert into Usuario(nombre,apellidoPaterno,apellidoMaterno,correo,contrasenia,estatus)
values
(
	@nombre,
	@apePaterno,
	@apeMaterno,
	@correo,
	@contrasenia,
	@estatus)

insert into Cliente(idUsuario)
values
(@idUsuario)
end
GO
