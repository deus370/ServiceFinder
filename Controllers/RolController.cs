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
    public class RolController : ApiController
    {
        public List<Rol> Get()
        {
            return RolData.Listar();
        }
        // GET api/<controller>/5

        // POST api/<controller>
        public bool Post([FromBody] Rol rol)
        {
            return RolData.Registrar(rol);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Rol rol)
        {
            return RolData.Modificar(rol);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return RolData.Eliminar(id);
        }
    }
}