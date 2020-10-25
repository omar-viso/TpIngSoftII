using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class HorasTrabajadasEstadoEFConfig : EntityTypeConfiguration<HorasTrabajadasEstado>
    {
        public HorasTrabajadasEstadoEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("HorasTrabajadasEstados");
            this.Property(p => p.Descripcion).IsRequired();
        }
    }
}
