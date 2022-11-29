using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApi.Models
{
    public class Servicio
    {
        public int idServicio { get; set; }
        public string servicio { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int idProfesionista { get; set; }

    }
}