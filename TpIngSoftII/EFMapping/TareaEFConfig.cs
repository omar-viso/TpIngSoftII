using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class TareaEFConfig : EntityTypeConfiguration<Tarea>
    {
        public TareaEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("Tareas");
            this.Property(p => p.EmpleadoPerfilID).IsRequired();
            this.Property(p => p.HorasEstimadas).IsRequired();
            this.Property(p => p.HorasOB).IsRequired();
            this.Property(p => p.Nombre).HasMaxLength(50).IsRequired();
            this.Property(p => p.ProyectoID).IsRequired();

        }
    }
}
