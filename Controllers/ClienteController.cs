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
    public class ClienteController : ApiController
    {
        public List<Usuario> Get()
        {
            return ClienteData.Listar();
        }

        public List<Cliente> Get(int id)
        {
            return ClienteData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Usuario oUsuario)
        {
            return ClienteData.Registrar(oUsuario);
        }

        public bool Put([FromBody] Usuario oUsuario)
        {
            return ClienteData.Modificar(oUsuario);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ClienteData.Eliminar(id);
        }

        public List<Cliente> Get(int id)
        {
            return ClienteData.Obtener(id);
        }
    }
}