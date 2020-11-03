using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diego_P2_AP1.Entidades
{
    public class TiposTarea
    {
        [Key]
        public int TipoId {get; set;}
        public String Descripcion { get; set; }

        [ForeignKey("TipoId")]
        public virtual List<ProyectosDetalle> Detalle { get; set; }

         public TiposTarea(int TipoId, String Descripcion)
        {
            this.TipoId = TipoId;
            this.Descripcion = Descripcion;
        }

    }
}