using ServicioApi.Data;
using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ServicioApi.Controllers
{
    public class SolicitudController : ApiController
    {
        // GET: Profesion
        public List<Solicitud> Get()
        {
            return SolicitudData.Listar();
        }

        // GET api/<controller>/5
        public List<Solicitud> GetSolicitudXId(int idSolicitud)
        {
            return SolicitudData.ObtenerSolicitudXId(idSolicitud);
        }

        // GET api/<controller>/5
        public List<Solicitud> GetSolicitudXCliente(int idCte)
        {
            return SolicitudData.ObtenerSolicitudXIdCliente(idCte);
        }
        // GET api/<controller>/5
        public List<Solicitud> GetSolicitudXProfesionista(int idProf)
        {
            return SolicitudData.ObtenerSolicitudXIdProfesionista(idProf);
        }

        // POST api/<controller>
        public bool Post([FromBody] Solicitud oSolicitud)
        {
            return SolicitudData.Registrar(oSolicitud);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Solicitud oSolicitud)
        {
            return SolicitudData.Modificar(oSolicitud);
        }

        // DELETE api/<controller>/5
        public bool Delete([FromBody] Solicitud oSolicitud)
        {
            return SolicitudData.Eliminar(oSolicitud.idSolicitud);
        }
    }
}