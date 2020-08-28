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

        public DBGestionDeProyectosContext() : base(@"Data Source=DESKTOP-8PRIJ3M\SQLEXPRESS;Initial Catalog=DBGestionDeProyectos;Integrated Security=True")
        //public DBGestionDeProyectosContext() : base("DBGestionDeProyectos")
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

            modelBuilder.Configurations.Add(new ProyectoEFConfig());
            modelBuilder.Configurations.Add(new ClienteEFConfig());



        }


    }
}
