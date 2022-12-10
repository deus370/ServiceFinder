using ServicioApi.Data;
using ServicioApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ServicioApi.Controllers
{
    public class ImagenController : ApiController
    {
        // GET: api/Imagen
        public List<Imagen> Get([FromUri] int id)
        {
 
            return ImagenData.ObtenerImagen(id);
        }

        // POST: api/Imagen
        public bool Post([FromBody] Imagen imagen)
        {
            return ImagenData.Registrar(imagen);
        }

        // PUT: api/Imagen/5
        public bool Put([FromBody] Imagen imagen)
        {
            return ImagenData.Modificar(imagen);
        }

        // DELETE: api/Imagen/5
        public bool Delete(int id)
        {
            return ImagenData.Eliminar(id);
        }
    }
}
