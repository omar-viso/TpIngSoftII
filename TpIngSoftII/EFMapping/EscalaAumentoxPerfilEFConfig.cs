using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class EscalaAumentoxPerfilEFConfig : EntityTypeConfiguration<EscalaAumentoxPerfil>
    {
        public EscalaAumentoxPerfilEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("EscalaAumentoxPerfiles");
            this.Property(p => p.LimitecantPerfiles).IsRequired();
            this.Property(p => p.PorcentajeAumento).IsRequired();
        }
    }
}
