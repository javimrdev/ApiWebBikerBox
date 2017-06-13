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
    public class UsuarioController : ApiController
    {
        [Route("login/iniciarSesion/{correo}/{contrasena}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult iniciarSesion([FromUri] string correo, [FromUri] string contrasena)
        {
            var a = new Usuario();
            var usuarios = a.comprobarExistencia(correo,contrasena);
            
            return Json(usuarios);
        }

        [Route("login/registrarUsuario/{correo}/{contrasena}/{nombre}/{apellidos}/{localidad}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult registrarUsuario([FromUri] string correo, [FromUri] string contrasena, [FromUri]
            string nombre, [FromUri] string apellidos, [FromUri] string localidad)
        {
            var a = new Usuario();
            try
            {
                Usuarios usuario = new Usuarios();
                usuario.correo = correo;
                usuario.contrasena = contrasena;
                usuario.nombre = nombre;
                usuario.apellidos = apellidos;
                usuario.localidad = localidad;

                var result = a.registrarUsuario(usuario);
                if (result)
                    return Json(usuario);
                else
                    return null;
            }catch(Exception e)
            {
                return null;
            }
        }

        [Route("usuario/obtenerUsuario/{id}")]
        [HttpGet] //Always explicitly state the accepted HTTP method
        public IHttpActionResult obtenerUsuario([FromUri] int id)
        {
            var a = new Usuario();
            var usuario = a.obtenerUsuario(id);

            return Json(usuario);
        }
    }
}