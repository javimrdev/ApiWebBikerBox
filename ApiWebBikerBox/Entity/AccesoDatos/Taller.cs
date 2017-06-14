using ApiWebBikerBox.Entity.Estructura;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool modificarTaller(int id,string nombre, string descripcion)
        {
            try
            {

                Talleres t = DBContext.Talleres.FirstOrDefault(w => w.id == id);
                t.nombre = nombre;
                t.descripcion = descripcion;
                DBContext.Talleres.Attach(t);
                DBContext.Entry(t).State = EntityState.Modified;
                DBContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Talleres> obtenerTalleresLocalidad(string localidad)
        {
            var t = new List<Talleres>();
            try
            {
                t = DBContext.Talleres.Where(w => w.Localidad==localidad).ToList();
            }
            catch (Exception e){}
            return t;
        }

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