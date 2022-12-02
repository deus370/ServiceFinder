USE ServiceFinder
GO
--******** PROCEDIMIENTO PARA ELIMINAR SOLICITUD ********--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_EliminarSolicitud]
	@idSolicitud int
AS
BEGIN

	DELETE FROM Solicitud 
		   
	WHERE idSolicitud = @idSolicitud

END
GO
--******** PROCEDIMIENTO PARA REGISTRAR SOLICITUD ********--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_InsertarSolicitud]
	@fecha datetime,
	@descripcion varchar(5000),
	@telefono varchar(30),
	@idCliente int,
	@idProfesionista int,
	@idEstatus int
AS
BEGIN
	insert into Solicitud ([fecha]
           ,[descripcion]
           ,[telefono]
           ,[idCliente]
           ,[idProfesionista]
           ,[idEstatus]) 
		   
	values (@fecha,@descripcion,@telefono,@idCliente,@idProfesionista,@idEstatus)
END
GO
--******** PROCEDIMIENTO PARA LISTAR SOLICITUDES ********--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ListaTodasSolicitudes]
AS
BEGIN
	SELECT * FROM Solicitud 
END
GO
--******** PROCEDIMIENTO PARA MODIFICAR SOLICITUD ********--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ModificarSolicitud]
	@idSolicitud int,
	@fecha datetime,
	@descripcion varchar(5000),
	@telefono varchar(30),
	@idCliente int,
	@idProfesionista int,
	@idEstatus int
AS
BEGIN

	UPDATE Solicitud 
		   
	SET fecha = @fecha,
	descripcion = @descripcion,
	telefono = @telefono,
	idCliente = @idCliente,
	idProfesionista = @idProfesionista

	WHERE idSolicitud = @idSolicitud

END
GO
--******** PROCEDIMIENTO PARA OBTENER SOLICITUD X IDCLIENTE ********--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ObtenerSolicitudXCliente]
	@idCliente int
AS
BEGIN

	SELECT * FROM Solicitud 
		   
	WHERE idCliente = @idCliente

END
GO
--******** PROCEDIMIENTO PARA OBTENER SOLICITUD X IDSOLICITUD ********--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ObtenerSolicitudXId]
	@idSolicitud int
AS
BEGIN

	SELECT * FROM Solicitud 
		   
	WHERE idSolicitud = @idSolicitud

END
GO
--******** PROCEDIMIENTO PARA OBTENER SOLICITUD X IDPROFESIONISTA ********--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ObtenerSolicitudXProfesionista]
	@idProfesionista int
AS
BEGIN

	SELECT * FROM Solicitud 
		   
	WHERE idProfesionista = @idProfesionista

END
GO