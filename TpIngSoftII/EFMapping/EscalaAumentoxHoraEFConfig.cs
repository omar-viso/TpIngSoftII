using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class EscalaAumentoxHoraEFConfig : EntityTypeConfiguration<EscalaAumentoxHora>
    {
        public EscalaAumentoxHoraEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("EscalaAumentoxHoras");
            this.Property(p => p.LimiteHoras).IsRequired();
            this.Property(p => p.PorcentajeAumento).IsRequired();
        }
    }
}
