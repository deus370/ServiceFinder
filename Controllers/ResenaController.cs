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
    public class resenaController : ApiController
    {
        public List<Resena> Get()
        {
            return ResenaData.Listar();
        }
        // GET api/<controller>/5
        public List<Resena> GetProfesionista(int idProf)
        {
            return ResenaData.ObtenerProfesionista(idProf);
        }

        // GET api/<controller>/5
        public List<Resena> GetUsuario(int id)
        {
            return ResenaData.ObtenerUsuario(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Resena oResena)
        {
            return ResenaData.Registrar(oResena);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Resena oResena)
        {
            return ResenaData.Modificar(oResena);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ResenaData.Eliminar(id);
        }
    }
}