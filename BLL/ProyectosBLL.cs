using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Diego_P2_AP1.DAL;
using Diego_P2_AP1.Entidades;

namespace Diego_P2_AP1.BLL
{
    public class ProyectosBLL
    {
        public static bool Guardar(Proyectos Proyecto)
        {
           // if(!Existe(Proyecto.ProyectoId))
                return Insertar(Proyecto); 
            // else    
            //     return Modificar(Proyecto);
        }

        private static bool Insertar(Proyectos Proyecto)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {

                context.Proyectos.Add(Proyecto);
                found = context.SaveChanges() > 0;
            } 
            catch
            {
                throw;
            } 
            finally
            {
                context.Dispose();
            }

            return found;
        }

   
     }
}