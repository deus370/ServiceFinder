﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApi.Models
{
    public class Logs
    {
        public int idLog { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public int idUsuario { get; set; }
    }
}