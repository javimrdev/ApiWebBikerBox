using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiWebBikerBox.Entity.Estructura;

namespace ApiWebBikerBox.Entity.AccesoDatos
{
    public class Usuario
    {
        private BikerBoxDBEntities DBContext;

        public Usuario()
        {
            DBContext = new BikerBoxDBEntities();
        }


        #region Usuarios
        public Vista_Login comprobarExistencia(string correo, string contrasena)
        {
            var usuario = new Vista_Login();
            try
            {
                usuario = DBContext.Vista_Login.Where(w => w.correo == correo & w.contrasena == contrasena).FirstOrDefault();
            }
            catch (Exception e) {
                usuario = null;
            }
            return usuario;
        }

        public Boolean registrarUsuario(Usuarios u)
        {
            try
            {
                DBContext.Usuarios.Add(u);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Usuarios obtenerUsuario(int id)
        {
            Usuarios u = new Usuarios();
            try
            {
                var usuario = DBContext.Usuarios.Where(w => w.id == id).First();
                u = usuario;
            }
            catch (Exception e){ }

            return u;
        }
        #endregion
    }
}