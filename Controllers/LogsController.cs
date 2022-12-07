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
    public class LogsController : ApiController
    {
        public List<Logs> Get()
        {
            return LogsData.Listar();
        }
        // GET api/<controller>/5
        public List<Logs> Get(int id)
        {
            return LogsData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Logs log)
        {
            return LogsData.Registrar(log);
        }
    }
}