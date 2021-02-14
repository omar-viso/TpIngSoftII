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
            this.Property(p => p.Apellido).HasMaxLength(50).IsRequired();
            this.Property(p => p.Dni).IsRequired();
            this.Property(p => p.Direccion).HasMaxLength(50).IsRequired();
            this.Property(p => p.Email).HasMaxLength(50).IsOptional();
            this.Property(p => p.RazonSocial).HasMaxLength(50).IsRequired();
            this.Property(p => p.TelefonoCelular).IsOptional();
            this.Property(p => p.TelefonoFijo).IsOptional();

            /* El Cliente es UNICO por DNI, no puede repetirse */
            this.HasIndex(x => new { x.Dni }).IsUnique();
        }
    }
}
