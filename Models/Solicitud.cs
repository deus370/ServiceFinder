using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApi.Models
{
    public class Solicitud
    {
        public int idSolicitud { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public string descripcion { get; set; }
        public string telefono { get; set; }
        public int idCliente { get; set; }
        public int idProfesionista { get; set; }
        public int idEstatus { get; set; }

    }
}