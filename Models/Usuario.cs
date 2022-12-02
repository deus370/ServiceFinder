using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApi.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
<<<<<<< HEAD
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public string nombre { get; set; }

        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }

        public int estatus { get; set; }
        public int idRol { get; set; }
=======
        public string nombre { get; set; }
        public string apePaterno { get; set; }
        public string apeMaterno { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public int estatus { get; set; }
>>>>>>> main
    }
}