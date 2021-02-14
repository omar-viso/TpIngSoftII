using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.EFMapping
{
    public class EmpleadoPerfilEFConfig : EntityTypeConfiguration<EmpleadoPerfil>
    {
        public EmpleadoPerfilEFConfig()
        {
            /* Se definen las restricciones para cada propiedad en base */

            this.ToTable("EmpleadosPerfiles");
            this.Property(p => p.EmpleadoID).IsRequired();
            this.Property(p => p.PerfilID).IsRequired();

            /* El Cliente - Perfil es UNICO (no puede repetirse) */
            this.HasIndex(x => new { x.EmpleadoID, x.PerfilID }).IsUnique();

            /* Se definen las relaciones y cardinalidades */

            /* Un EmpleadoPerfil tiene un Empleado, un Empleado pertece a 1 o muchos EmpleadoPerfil */
            this.HasRequired(x => x.Empleado)
                .WithMany(y => y.Perfiles)
                .HasForeignKey(x => x.EmpleadoID)
                /* Si se Elimina un Empleado, Se elimina todos los EmpleadoPerfil que le pertenezcan */
                /* PROBAR SI SUCEDE LO COMENTADO EN LINEA DE ARRIBA Y QUE NO BORRE EN LA TABLA PERFILES!! */
                .WillCascadeOnDelete(true);

            /* Un EmpleadoPerfil tiene un Perfil, un Perfil pertece a 1 o muchos EmpleadoPerfil */
            this.HasRequired(x => x.Perfil)
                .WithMany(y => y.Empleados)
                .HasForeignKey(x => x.PerfilID)
                /* Si se Elimina un Perfil, Se elimina todos los EmpleadoPerfil que le pertenezcan */
                /* PROBAR SI SUCEDE LO COMENTADO EN LINEA DE ARRIBA Y QUE NO BORRE EN LA TABLA EMPLEADOS!! */
                .WillCascadeOnDelete(true);
        }
    }
}
