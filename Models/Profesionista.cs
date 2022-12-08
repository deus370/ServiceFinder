using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApi.Models
{
    public class Profesionista
    {
        public int idProfesionista { get; set; }
        public string descripcion { get; set; }
        public int idProfesion { get; set; }
        public int estatus { get; set; }
        public int idUsuario { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public string nombre { get; set; }

        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public int idRol { get; set; }

    }
}