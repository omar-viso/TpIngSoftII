using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class ProyectoEFConfig : EntityTypeConfiguration<Proyecto>
    {
        public ProyectoEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("Proyectos");
            this.Property(p => p.ClienteID).IsRequired();
            this.Property(p => p.Nombre).HasMaxLength(50).IsRequired();
            this.Property(p => p.EstadoProyecto).IsRequired();

            /* El Cliente - Nombre del Proyecto es UNICO (no puede repetirse) */
            this.HasIndex(x => new { x.ClienteID, x.Nombre });

            /* Se definen las relaciones y cardinalidades */

            /* Un Proyecto tiene un Cliente, un Cliente pertece a 1 o muchos Proyectos */
            this.HasRequired(x => x.Cliente)
                .WithMany(y => y.Proyectos)
                .HasForeignKey(x => x.ClienteID)
                .WillCascadeOnDelete(true);

        }
    }
}
