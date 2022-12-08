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
    public class ProfesionistaController : ApiController
    {
        public List<Profesionista> Get()
        {
            return ProfesionistaData.Listar();
        }
        // GET api/<controller>/5
        public List<Profesionista> Get(int id)
        {
            return ProfesionistaData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Profesionista prof)
        {
            return ProfesionistaData.Registrar(prof);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Profesionista prof)
        {
            return ProfesionistaData.Modificar(prof);
        }

        public bool Delete(int idProf, int iduser)
        {
            return ProfesionistaData.Eliminar(idProf, iduser);
        }
    }
}