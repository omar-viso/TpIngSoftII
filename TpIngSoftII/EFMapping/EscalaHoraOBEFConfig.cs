using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class EscalaHoraOBEFConfig : EntityTypeConfiguration<EscalaHoraOB>
    {
        public EscalaHoraOBEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("EscalaHorasOB");
            this.Property(p => p.PorcentajeAumento).IsRequired();
        }
    }
}
