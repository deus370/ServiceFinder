go
use ServiceFinder
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'login')
DROP PROCEDURE login

go

go

create procedure login(
@correo varchar(100),
@contrasenia varchar(100)
)
as
begin

select * from Usuario where correo = @correo and contrasenia = @contrasenia and estatus = 1

end