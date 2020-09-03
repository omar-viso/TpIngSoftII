﻿namespace TpIngSoftII.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TpIngSoftII.Models.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<TpIngSoftII.Models.DBGestionDeProyectosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TpIngSoftII.Models.DBGestionDeProyectosContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

        }
    }

}

