using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApi.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apePaterno { get; set; }
        public string apeMaterno { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public int estatus { get; set; }
    }
}