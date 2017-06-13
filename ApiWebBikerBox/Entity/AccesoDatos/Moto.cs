using ApiWebBikerBox.Entity.Estructura;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace ApiWebBikerBox.Entity.AccesoDatos
{
    public class Moto
    {
        private BikerBoxDBEntities DBContext;

        public Moto()
        {
            DBContext = new BikerBoxDBEntities();
        }

        #region motos

        public List<Vista_MotoIdUsuario> obtenerMotosIdUsuario(int id)
        {
            List<Vista_MotoIdUsuario> motos = null;
            try
            {
                motos = DBContext.Vista_MotoIdUsuario.Where(w => w.idUsuario == id).ToList();
            }
            catch(Exception e)
            {

            }
            return motos;
        }

        public bool guardarMoto(int idUsuario,string marca,string modelo,string matricula,
            string color,int km,int cilindrada, int ano, string estilo)
        {
            try
            {
                //guardar moto
                Motos moto = new Motos();
                moto.marca = marca;
                moto.modelo = modelo;
                moto.matricula = matricula;
                moto.color = color;
                moto.km = km;
                moto.cilindrada = cilindrada;
                moto.año = ano;
                moto.estilo=estilo;
                DBContext.Motos.Add(moto);
                DBContext.SaveChanges();

                var m = DBContext.Motos.Where(w => w.matricula == matricula).Single();

                DuenoMotos d = new DuenoMotos();
                d.idMoto = m.id;
                d.idUsuario = idUsuario;
                DBContext.DuenoMotos.Add(d);
                DBContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool guardarMotoFoto(int idUsuario, string marca, string modelo, string matricula,
            string color, int km, int cilindrada, int ano, string estilo, string foto)
        {
            try
            {
                //guardar moto
                Motos moto = new Motos();
                moto.marca = marca;
                moto.modelo = modelo;
                moto.matricula = matricula;
                moto.color = color;
                moto.km = km;
                moto.cilindrada = cilindrada;
                moto.año = ano;
                moto.estilo = estilo;
                moto.imagen = Encoding.ASCII.GetBytes(foto);
                DBContext.Motos.Add(moto);
                DBContext.SaveChanges();

                var m = DBContext.Motos.Where(w => w.matricula == matricula).Single();

                DuenoMotos d = new DuenoMotos();
                d.idMoto = m.id;
                d.idUsuario = idUsuario;
                DBContext.DuenoMotos.Add(d);
                DBContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool modificarMoto(int id, string marca, string modelo, string matricula,
            string color, int km, int cilindrada, int ano, string estilo)
        {
            try
            {
                Motos moto = DBContext.Motos.FirstOrDefault(w => w.id == id);
                moto.marca = marca;
                moto.modelo = modelo;
                moto.matricula = matricula;
                moto.color = color;
                moto.km = km;
                moto.cilindrada = cilindrada;
                moto.año = ano;
                moto.estilo = estilo;
                DBContext.Motos.Attach(moto);
                DBContext.Entry(moto).State = EntityState.Modified;
                DBContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminarMoto(int id)
        {
            try
            {
                var moto = DBContext.Motos.SingleOrDefault(w => w.id == id);
                var dueno = DBContext.DuenoMotos.SingleOrDefault(w => w.idMoto == id);
                var anuncio = DBContext.Anuncios.SingleOrDefault(w => w.idMoto == id);
                if(anuncio!=null)
                    DBContext.Anuncios.Remove(anuncio);
                DBContext.DuenoMotos.Remove(dueno);
                DBContext.Motos.Remove(moto);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion


    }
}