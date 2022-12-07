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

    }
}