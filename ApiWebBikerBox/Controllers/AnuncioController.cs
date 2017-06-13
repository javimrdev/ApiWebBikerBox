using ApiWebBikerBox.Entity.AccesoDatos;
using ApiWebBikerBox.Entity.Estructura;
using ApiWebBikerBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWebBikerBox.Controllers
{
    public class AnuncioController : ApiController
    {
        [Route("anuncios/obtenerAnunciosProvincia/{localidad}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult obtenerAnunciosProvincia([FromUri] string localidad)
        {
            var a = new Anuncio();

            var motos = a.obtenerAnuncioLocalidad(localidad);
            return Json(motos);
        }

        [Route("anuncios/publicarAnuncio/{localidad}/{descripcion}/{idmoto}/{idusuario}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult publicarAnuncio([FromUri] string localidad, [FromUri] string descripcion, [FromUri] int idmoto,
            [FromUri] int idusuario)
        {
            var a = new Anuncio();

            var correcto = a.anadirAnuncio(localidad, descripcion, idmoto, idusuario);
            return Json(correcto);
        }
    }
}
