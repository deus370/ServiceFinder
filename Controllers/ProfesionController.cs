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
    public class ProfesionController : ApiController
    {
        public List<Profesion> Get()
        {
            return ProfesionData.Listar();
        }
        // GET api/<controller>/5
        public List<Profesion> Get(int id)
        {
            return ProfesionData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Profesion prof)
        {
            return ProfesionData.Registrar(prof);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Profesion prof)
        {
            return ProfesionData.Modificar(prof);
        }

        public bool Delete(int id)
        {
            return ProfesionData.Eliminar(id);
        }
    }
}