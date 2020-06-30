
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
    public class OdenesBLL
    {
        public static bool Guardar(Ordenes orden)
        {
            if (!Existe(orden.OrdenId))
                return Insertar(orden);
            else
                return Modificar(orden);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Ordenes.Any(o => o.OrdenId == id);
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

        private static bool Insertar(Ordenes orden)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                if(contexto.Ordenes.Add(orden) != null)
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

        private static bool Modificar(Ordenes orden)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM OdenesDetalle Where OrdenId={orden.OrdenId}");
                foreach (var anterior in orden.OrdenesDetalles)
                {
                    contexto.Entry(orden).State = EntityState.Added;
                }
                contexto.Entry(orden).State = EntityState.Modified;
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

        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes orden;
            try
            {
                orden = contexto.Ordenes.Include(o => o.OrdenesDetalles).Where(p => p.OrdenId == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return orden;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var eliminar = contexto.Ordenes.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;

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

    }
}
