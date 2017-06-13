using ApiWebBikerBox.Entity.Estructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWebBikerBox.Entity.AccesoDatos
{
    public class Taller
    {
        private BikerBoxDBEntities DBContext;

        public Taller()
        {
            DBContext = new BikerBoxDBEntities();
        }

        #region talleres

        public Talleres registrarTaller(Talleres taller)
        {
            try
            {

                DBContext.Talleres.Add(taller);
                DBContext.SaveChanges();
                return taller;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Talleres iniciarSesionTaller(Talleres taller)
        {
            try
            {
                var a = DBContext.Talleres.Where(w => w.correo == taller.correo && w.contrasena == taller.contrasena).First();
                return a;

            }catch(Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}