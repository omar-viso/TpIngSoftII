using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using TpIngSoftII.EFMapping;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Models
{
    public class DBGestionDeProyectosContext : DbContext
    {
        /* Definir la propiedad "DbSet" para cada entity */

        //public DBGestionDeProyectosContext() : base(@"Data Source=DESKTOP-8PRIJ3M\SQLEXPRESS;Initial Catalog=DBGestionDeProyectos;Integrated Security=True;MultipleActiveResultSets=true")
        public DBGestionDeProyectosContext() : base("DBGestionProyectos")
        {
            Database.SetInitializer<DBGestionDeProyectosContext>(null);
        }
        
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<EmpleadoPerfil> EmpleadosPerfiles { get; set; }
        public DbSet<ProyectoEstado> ProyectoEstados { get; set; }
        public DbSet<EscalaAumentoxAntiguedad> EscalaAumentoxAntiguedades { get; set; }
        public DbSet<EscalaAumentoxHora> EscalaAumentoxHoras { get; set; }
        public DbSet<EscalaAumentoxPerfil> EscalaAumentoxPerfiles { get; set; }
        public DbSet<EscalaHoraOB> EscalaHorasOB { get; set; }
        public DbSet<HorasTrabajadasEstado> HorasTrabajadasEstados { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<HorasTrabajadas> HorasTrabajadas { get; set; }





        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                throw dbEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   /* Mapear cada Entity con la tabala de la base de dato relacionada */
            
            modelBuilder.Entity<Proyecto>().ToTable("Proyectos");
            modelBuilder.Entity<ProyectoEstado>().ToTable("ProyectoEstados");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Empleado>().ToTable("Empleados");
            modelBuilder.Entity<Perfil>().ToTable("Perfiles");
            modelBuilder.Entity<EmpleadoPerfil>().ToTable("EmpleadosPerfiles");
            modelBuilder.Entity<EscalaAumentoxAntiguedad>().ToTable("EscalaAumentoxAntiguedades");
            modelBuilder.Entity<EscalaAumentoxHora>().ToTable("EscalaAumentoxHoras");
            modelBuilder.Entity<EscalaAumentoxPerfil>().ToTable("EscalaAumentoxPerfiles");
            modelBuilder.Entity<EscalaHoraOB>().ToTable("EscalaHorasOB");
            modelBuilder.Entity<HorasTrabajadasEstado>().ToTable("HorasTrabajadasEstados");
            modelBuilder.Entity<Tarea>().ToTable("Tareas");
            modelBuilder.Entity<HorasTrabajadas>().ToTable("HorasTrabajadas");

            /* Agregar cada configuracion de EF de las Entities */
            modelBuilder.Configurations.Add(new ProyectoEstadoEFConfig());
            modelBuilder.Configurations.Add(new ProyectoEFConfig());
            modelBuilder.Configurations.Add(new ClienteEFConfig());
            modelBuilder.Configurations.Add(new EmpleadoEFConfig());
            modelBuilder.Configurations.Add(new PerfilEFConfig());
            modelBuilder.Configurations.Add(new EmpleadoPerfilEFConfig());
            modelBuilder.Configurations.Add(new EscalaAumentoxAntiguedadEFConfig());
            modelBuilder.Configurations.Add(new EscalaAumentoxHoraEFConfig());
            modelBuilder.Configurations.Add(new EscalaAumentoxPerfilEFConfig());
            modelBuilder.Configurations.Add(new EscalaHoraOBEFConfig());
            modelBuilder.Configurations.Add(new HorasTrabajadasEstadoEFConfig());
            modelBuilder.Configurations.Add(new TareaEFConfig());
            modelBuilder.Configurations.Add(new HorasTrabajadasEFConfig());


        }


    }
}
