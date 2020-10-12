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
            this.Property(p => p.TipoPerfil).IsRequired();
            this.Property(p => p.ValorHorario).IsRequired();
        }
    }
}
