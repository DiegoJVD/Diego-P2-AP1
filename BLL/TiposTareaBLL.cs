using Microsoft.EntityFrameworkCore;
using Diego_P2_AP1.DAL;
using Diego_P2_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Diego_P2_AP1.BLL
{
    public class TiposTareaBLL
    {
       
        public static List<TiposTarea> GetList(Expression<Func<TiposTarea, bool>> criterio)
        {
            List<TiposTarea> list = new List<TiposTarea>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.TiposTarea.Where(criterio).AsNoTracking().ToList<TiposTarea>();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return list;
        }

        public static TiposTarea Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TiposTarea tipos;

            try
            {
                tipos = contexto.TiposTarea
                    .Include(p => p.Detalle)
                    .Where(p => p.TipoId == id)
                    .SingleOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tipos;
        }
    }
}