using ApiWebBikerBox.Entity.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiWebBikerBox.Controllers
{
    public class MotosController : ApiController
    {
        [Route("motos/obtenermotosusuario/{id}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult registrarUsuario([FromUri] int id)
        {
            var a = new Moto();

            var motos = a.obtenerMotosIdUsuario(id);

            return Json(motos);
        }

        [Route("motos/anunciarMoto/{id}/{precio}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult anunciarMoto([FromUri] int id, [FromUri] float precio)
        {
            var a = new Moto();

            var motos = a.anunciarMoto(id,precio);

            return Json(motos);
        }

        [Route("motos/eliminarMoto/{id}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult eliminarMoto([FromUri] int id)
        {
            var a = new Moto();

            var motos = a.eliminarMoto(id);

            return Json(motos);
        }

        [Route("motos/modificarMoto/{idMoto}/{marca}/{modelo}/{matricula}/{color}/{km}/{cilindrada}/{ano}/{estilo}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult modificarMoto([FromUri] int idMoto, [FromUri] string marca, [FromUri] string modelo, [FromUri] string matricula,
            [FromUri] string color, [FromUri] int km, [FromUri] int cilindrada, [FromUri] int ano,[FromUri] string estilo)
        {
            var a = new Moto();

            var motos = a.modificarMoto(idMoto, marca, modelo, matricula,
            color, km, cilindrada, ano, estilo);

            return Json(motos);
        }

        [Route("motos/anadirmotoUsuario/{idUsuario}/{marca}/{modelo}/{matricula}/{color}/{km}/{cilindrada}/{ano}/{estilo}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult anadirMotoUsuario([FromUri] int idUsuario, [FromUri] string marca, [FromUri] string modelo, [FromUri] string matricula,
            [FromUri] string color, [FromUri] int km, [FromUri] int cilindrada, [FromUri] int ano,[FromUri] string estilo)
        {
            var a = new Moto();

            var motos = a.guardarMoto(idUsuario, marca,modelo,matricula,
            color,km,cilindrada,ano,estilo);

            return Json(motos);
        }

        [Route("motos/anadirmotoUsuarioFoto/moto")]
        [HttpPost] //Always explicitly state the accepted HTTP method
        public IHttpActionResult anadirMotoUsuarioFoto([FromBody] int idUsuario, [FromBody] string marca, [FromBody] string modelo, [FromBody] string matricula,
            [FromBody] string color, [FromBody] int km, [FromBody] int cilindrada, [FromBody] int ano, [FromBody] string estilo,[FromUri] string foto)
        {
            var a = new Moto();

            var motos = a.guardarMotoFoto(idUsuario, marca, modelo, matricula,
            color, km, cilindrada, ano, estilo,foto);

            return Json(motos);
        }
    }
}