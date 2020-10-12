using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class EmpleadoEFConfig : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("Empleados");
            this.Property(p => p.Nombre).HasMaxLength(50).IsRequired();
            this.Property(p => p.Clave).HasMaxLength(50).IsRequired();
            this.Property(p => p.FechaIngreso).IsRequired();
            this.Property(p => p.Usuario).HasMaxLength(50).IsRequired();

        }
    }
}
