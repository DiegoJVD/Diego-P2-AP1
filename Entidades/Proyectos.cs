using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diego_P2_AP1.Entidades
{
    public class Proyectos
    {
        [Key]
        public int ProyectoId {get; set;}
        public DateTime Fecha {get; set;}
        public string Descripcion { get; set; }

        public int Total { get; set; }

         [ForeignKey("ProyectoId")]
         public virtual List<ProyectosDetalle> Detalle { get; set; }

        public Proyectos()
        {
            Fecha = DateTime.Now;
            Detalle = new List<ProyectosDetalle>();
            Total = 0;
        }

        

        



    }
}