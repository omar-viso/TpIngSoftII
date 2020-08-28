using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Models;

namespace TpIngSoftII.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory<DBGestionDeProyectosContext> dbFactory;
        private DBGestionDeProyectosContext dbContext;

        public UnitOfWork (IDbFactory<DBGestionDeProyectosContext> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DBGestionDeProyectosContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }

    }
}
