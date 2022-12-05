using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioApi.Data
{
    public class UsuarioController : ApiController
    {
        public List<Usuario> Get()
        {
            return UsuarioData.Listar();
        }
        // GET api/<controller>/5
        public List<Usuario> Get(int id)
        {
            return UsuarioData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Usuario usuario)
        {
            return UsuarioData.Registrar(usuario);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Usuario usuario)
        {
            return UsuarioData.Modificar(usuario);
        }

        public bool Put([FromBody] int idUsuario)
        {
            return UsuarioData.Eliminar(idUsuario);
        }


    }
}