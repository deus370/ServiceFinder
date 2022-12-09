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
    public class EstatusController : ApiController
    {
        public List<Estatus> Get()
        {
            return EstatusData.Listar();
        }
        // GET api/<controller>/5
        public List<Estatus> Get(int id)
        {
            return EstatusData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Estatus estatus)
        {
            return EstatusData.Registrar(estatus);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Estatus estatus)
        {
            return EstatusData.Modificar(estatus);
        }

        public bool Delete(int id)
        {
            return EstatusData.Eliminar(id);
        }
    }
}