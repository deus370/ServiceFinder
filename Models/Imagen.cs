using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApi.Models
{
    public class Imagen
    {
        public int idImagen { get; set; }
        public int idProfesionista { get; set; }
        public string _Imagen { get; set; }
    }
}