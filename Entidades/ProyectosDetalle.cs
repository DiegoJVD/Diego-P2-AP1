using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diego_P2_AP1.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int Id {get; set;}
        public int ProyectoId { get; set; }
        public String Requerimiento {get; set;}
        public int Tiempo { get; set; }
        public int TipoId { get; set; }

        public String Tipo { get; set; }

         public ProyectosDetalle(int ProyectoId, String Requerimiento, int Tiempo, int TipoId)
        {
            
            this.ProyectoId = ProyectoId;
            this.Requerimiento = Requerimiento;
            this.Tiempo = Tiempo;
            this.TipoId = TipoId;
        }

        public ProyectosDetalle(int ProyectoId, String Requerimiento, int Tiempo, int TipoId, String Tipo)
        {
            
            this.ProyectoId = ProyectoId;
            this.Requerimiento = Requerimiento;
            this.Tiempo = Tiempo;
            this.TipoId = TipoId;
            this.Tipo = Tipo;
        }

        
    



    }
}