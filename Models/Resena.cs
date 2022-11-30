using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApi.Models
{
    public class Resena
    {
        public int idResena { get; set; }
        public int idCliente { get; set; }
        public int idProfesionista { get; set; }
        public string comentario { get; set; }
        public double calificacion { get; set; }

    }
}