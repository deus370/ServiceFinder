using ServicioApi.Data;
using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioApi.Controllers
{
    public class ServicioController : ApiController
    {
        public List<Servicio> Get()
        {
            return ServicioData.Listar();
        }
        // GET api/<controller>/5
        public List<Servicio> Get(int id)
        {
            return ServicioData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Servicio servicio)
        {
            return ServicioData.Registrar(servicio);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Servicio servicio)
        {
            return ServicioData.Modificar(servicio);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ServicioData.Eliminar(id);
        }
    }
}