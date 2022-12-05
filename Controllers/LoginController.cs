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
    public class LoginController : ApiController
    {
        // GET api/<controller>


        public List<Usuario> Post([FromBody] Usuario usuario)
        {
            return UsuarioData.LoginUser(usuario);
        }
    }
}