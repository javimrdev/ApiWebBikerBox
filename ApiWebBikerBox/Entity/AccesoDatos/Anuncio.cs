using ApiWebBikerBox.Entity.Estructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWebBikerBox.Entity.AccesoDatos
{
    public class Anuncio
    {

        private BikerBoxDBEntities DBContext;

        public Anuncio()
        {
            DBContext = new BikerBoxDBEntities();
        }

        public List<Vista_Anuncio> obtenerAnuncioLocalidad(string localidad)
        {
            List<Vista_Anuncio> anuncios = null;
            try
            {
                anuncios = DBContext.Vista_Anuncio.Where(w => w.localidad == localidad).ToList();
                if (anuncios== null)
                {
                    return null;
                }
            }
            catch (Exception e){}
            return anuncios;
        }

        public bool anadirAnuncio(string localidad,string descripcion, int idmoto, int idusuario)
        {
            try
            {
                var anuncio = new Anuncios();
                anuncio.localidad = localidad;
                anuncio.descripcion = descripcion;
                anuncio.idMoto = idmoto;
                anuncio.idUsuario = idusuario;
                DBContext.Anuncios.Add(anuncio);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception e) { return false; }
        }
    }
}