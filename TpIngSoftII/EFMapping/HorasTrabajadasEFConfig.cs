using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class HorasTrabajadasEFConfig : EntityTypeConfiguration<HorasTrabajadas>
    {
        public HorasTrabajadasEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("HorasTrabajadas");
            this.Property(p => p.ProyectoID).IsRequired();
            this.Property(p => p.TareaID).IsRequired();
            this.Property(p => p.CantHoras).IsRequired();
            this.Property(p => p.Fecha).IsRequired();
            this.Property(p => p.EstadoHoras).IsRequired();

            
        }
    }
}
