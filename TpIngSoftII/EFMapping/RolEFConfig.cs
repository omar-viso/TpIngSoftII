using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class RolEFConfig : EntityTypeConfiguration<Rol>
    {
        public RolEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("Roles");
            this.Property(p => p.Descripcion).HasMaxLength(50).IsRequired();

            /* El Perfil es UNICO por Descripcion, no puede repetirse */
            this.HasIndex(x => new { x.Descripcion }).IsUnique();
        }
    }
}
