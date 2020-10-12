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
        public DBGestionDeProyectosContext() : base("DBGestionDeProyectos")
        {
            Database.SetInitializer<DBGestionDeProyectosContext>(null);
        }
        
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }





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
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Cliente>().ToTable("Empleados");
            modelBuilder.Entity<Cliente>().ToTable("Perfiles");
            modelBuilder.Entity<Cliente>().ToTable("EmpleadosPerfiles");
            modelBuilder.Entity<Cliente>().ToTable("EscalaAumentoxAntiguedades");
            modelBuilder.Entity<Cliente>().ToTable("EscalaAumentoxHoras");
            modelBuilder.Entity<Cliente>().ToTable("EscalaAumentoxPerfiles");

            /* Agregar cada configuracion de EF de las Entities */

            modelBuilder.Configurations.Add(new ProyectoEFConfig());
            modelBuilder.Configurations.Add(new ClienteEFConfig());
            modelBuilder.Configurations.Add(new EmpleadoEFConfig());
            modelBuilder.Configurations.Add(new PerfilEFConfig());
            modelBuilder.Configurations.Add(new EmpleadoPerfilEFConfig());
            modelBuilder.Configurations.Add(new EscalaAumentoxAntiguedadEFConfig());
            modelBuilder.Configurations.Add(new EscalaAumentoxHoraEFConfig());
            modelBuilder.Configurations.Add(new EscalaAumentoxPerfilEFConfig());



        }


    }
}
