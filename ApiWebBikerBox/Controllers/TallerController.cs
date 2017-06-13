using ApiWebBikerBox.Entity.AccesoDatos;
using ApiWebBikerBox.Entity.Estructura;
using ApiWebBikerBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;


namespace ApiWebBikerBox.Controllers
{
    public class TallerController : ApiController
    {

        [Route("login/registrarTaller/{nombre}/{correo}/{contrasena}/{descripcion}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult registrarTaller([FromUri] string nombre,[FromUri] string correo,[FromUri] string contrasena,
            [FromUri] string descripcion/*, [FromBody] string foto*/)
        {
            var t = new Taller();
            var a = new Talleres();
            a.nombre = nombre;
            a.correo = correo;
            a.contrasena = contrasena;
            a.descripcion = descripcion;
            /*a.foto = Encoding.ASCII.GetBytes(foto);*/

            var correcto = t.registrarTaller(a);

            return Json(correcto);
        }

        [Route("login/registrarTallerConFoto/{nombre}/{correo}/{contrasena}/{descripcion}/{localidad}/{foto}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult registrarTallerConFoto([FromUri] string nombre, [FromUri] string correo, [FromUri] string contrasena,
            [FromUri] string descripcion, [FromUri] string localidad, [FromUri] string foto)
        {
            var t = new Taller();
            var a = new Talleres();
            a.nombre = nombre;
            a.correo = correo;
            a.contrasena = contrasena;
            a.descripcion = descripcion;
            a.Localidad = localidad;
            a.foto = Encoding.ASCII.GetBytes(foto);

            var correcto = t.registrarTaller(a);

            return Json(correcto);
        }

        [Route("login/iniciarTaller/{correo}/{contrasena}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult iniciarTaller([FromUri] string correo, [FromUri] string contrasena)
        {
            var t = new Taller();
            var a = new Talleres();
            a.contrasena = contrasena;
            a.correo = correo;

            var correcto = t.iniciarSesionTaller(a);

            return Json(correcto);
        }

    }
}