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
            /* Una tarea puede tener varios proyectos, un proyecto pertece a 1 o muchos Tareas */
            this.HasRequired(x => x.Proyecto)
                .WithMany(y => y.Tareas)
                .HasForeignKey(x => x.ProyectoID)
                .WillCascadeOnDelete(true);

            /* Una tarea puede tener un EmpleadoPerfil, un EmpleadoPerfil pertece a 1 o muchos Tareas */
            this.HasRequired(x => x.EmpleadoPerfil)
                .WithMany(y => y.Tareas)
                .HasForeignKey(x => x.EmpleadoPerfilID)
                .WillCascadeOnDelete(true);
        }
    }
}
