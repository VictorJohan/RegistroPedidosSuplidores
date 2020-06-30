using Microsoft.EntityFrameworkCore;
using RegistroPedidosSuplidor.DAL;
using RegistroPedidosSuplidor.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroPedidosSuplidor.BLL
{
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidor)
        {
            if (Existe(suplidor.SuplidoreId))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Suplidores.Any(o => o.SuplidoreId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        private static bool Insertar(Suplidores suplidor)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Suplidores.Add(suplidor);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        private static bool Modificar(Suplidores suplidor)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }
            return ok;
        }

        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidor;
            try
            {
                suplidor = contexto.Suplidores.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return suplidor;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var encontrado = contexto.Suplidores.Find(id);
                if(encontrado != null)
                {
                    contexto.Suplidores.Remove(encontrado);
                    ok = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        public static List<Suplidores> GetList()
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Suplidores.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
