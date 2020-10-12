using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class EscalaAumentoxAntiguedadEFConfig : EntityTypeConfiguration<EscalaAumentoxAntiguedad>
    {
        public EscalaAumentoxAntiguedadEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("EscalaAumentoxAntiguedades");
            this.Property(p => p.Limiteanios).IsRequired();
            this.Property(p => p.PorcentajeAumento).IsRequired();
        }
    }
}
