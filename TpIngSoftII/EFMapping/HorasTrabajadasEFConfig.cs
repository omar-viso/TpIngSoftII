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
            
            this.Property(p => p.CantHoras).IsRequired();
            this.Property(p => p.Fecha).IsRequired();
            this.Property(p => p.HorasTrabajadasEstadoID).IsRequired();
            this.Property(p => p.ProyectoID).IsRequired();
            this.Property(p => p.TareaID).IsRequired();


            /* Un HorasTrabajadas tiene un HorasTrabajadasEstado, un HorasTrabajadasEstado pertece a 1 o muchos HorasTrabajadas */
            this.HasRequired(x => x.HorasTrabajadasEstado)
                .WithMany(y => y.HorasTrabajadas)
                .HasForeignKey(x => x.HorasTrabajadasEstadoID)
                .WillCascadeOnDelete(true);

            /* Un HorasTrabajadas tiene un Tarea, un Tarea pertece a 1 o muchos HorasTrabajadas */
            this.HasRequired(x => x.Tarea)
                .WithMany(y => y.HorasTrabajadas)
                .HasForeignKey(x => x.TareaID)
                .WillCascadeOnDelete(true);

        }
    }
}
