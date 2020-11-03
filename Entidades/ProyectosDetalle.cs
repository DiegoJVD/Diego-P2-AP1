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


         public ProyectosDetalle(int ProyectoId, String Requerimiento, int Tiempo, int TipoId)
        {
            Id = 0;
            this.ProyectoId = ProyectoId;
            this.Requerimiento = Requerimiento;
            this.Tiempo = Tiempo;
            this.TipoId = TipoId;
        }

        
    



    }
}