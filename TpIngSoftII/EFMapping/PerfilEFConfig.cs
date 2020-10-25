using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class PerfilEFConfig : EntityTypeConfiguration<Perfil>
    {
        public PerfilEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("Perfiles");
            this.Property(p => p.PerfilTipoID).IsRequired();
            this.Property(p => p.ValorHorario).IsRequired();


            /* Se definen las relaciones y cardinalidades */

            /* Un Perfil tiene un PerfilTipo, un PerfilTipo pertece a 1 o muchos Perfiles */
            this.HasRequired(x => x.PerfilTipo)
                .WithMany(y => y.Perfiles)
                .HasForeignKey(x => x.PerfilTipoID)
                .WillCascadeOnDelete(true);
        }
    }
}
