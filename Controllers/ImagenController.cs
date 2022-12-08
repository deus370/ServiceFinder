using ServicioApi.Data;
using ServicioApi.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ServicioApi.Controllers
{
    public class ImagenController : ApiController
    {
        // GET: api/Imagen
        public HttpResponseMessage Get([FromUri] int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            byte[] b = (ImagenData.ObtenerImagen(id));
            if (b == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            response.Content = new ByteArrayContent(b);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            response.Content.LoadIntoBufferAsync(b.Length).Wait();
            return response;
        }

        // POST: api/Imagen
        public bool Post([FromBody]Imagen imagen)
        {
            return ImagenData.Registrar(imagen);
        }

        // PUT: api/Imagen/5
        public bool Put([FromBody] Imagen imagen)
        {
            return ImagenData.Modificar(imagen);
        }

        // DELETE: api/Imagen/5
        public bool Delete(int idProfesionista)
        {
            return ImagenData.Eliminar(idProfesionista);
        }
    }
}
