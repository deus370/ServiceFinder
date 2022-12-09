USE ServiceFinder
GO

/****** PROCEDIMIENTO ALMACENADO PARA OBTENER IMAGEN ******/
CREATE PROCEDURE [dbo].[img_obtener]
	(
	@IdProfesionista INT
	)
AS
BEGIN
	
SELECT Imagen from Imagen
    where idProfesionista = @IdProfesionista;

END
GO

/****** PROCEDIMIENTO ALMACENADO PARA REGISTRAR IMAGEN ******/
CREATE PROCEDURE [dbo].[img_registrar] 
	(@Imagen varbinary(MAX),
	@IdProfesionista INT
	)
AS
BEGIN
	
INSERT INTO Imagen
           (imagen
           ,idProfesionista)
     VALUES
           (@Imagen,
           @IdProfesionista)

END
GO

/****** PROCEDIMIENTO ALMACENADO PARA MODIFICAR IMAGEN ******/
CREATE PROCEDURE [dbo].[img_modificar]
	(
	@Imagen varbinary(MAX),
	@IdProfesionista INT
	)
AS
BEGIN
	
UPDATE Imagen
SET Imagen = @Imagen
WHERE idProfesionista = @IdProfesionista

END
GO

/****** PROCEDIMIENTO ALMACENADO PARA ELIMINAR IMAGEN ******/
CREATE PROCEDURE [dbo].[img_eliminar]
	(
	@IdProfesionista INT
	)
AS
BEGIN
	
DELETE FROM Imagen
WHERE idProfesionista = @IdProfesionista

END
GO