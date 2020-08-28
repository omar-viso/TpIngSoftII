using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class ClienteEFConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("Clientes");
            this.Property(p => p.Nombre).HasMaxLength(50).IsRequired();
                        
        }
    }
}
