using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class ProyectoEstadoEFConfig : EntityTypeConfiguration<ProyectoEstado>
    {
        public ProyectoEstadoEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("ProyectoEstados");
            this.Property(p => p.Descripcion).HasMaxLength(50).IsRequired();

            this.HasIndex(x => new { x.Descripcion }).IsUnique();
        }
    }
}
