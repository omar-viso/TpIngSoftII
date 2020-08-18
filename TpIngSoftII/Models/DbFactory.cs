using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models
{
    public class DbFactory<TDbContext> : Disposable, IDbFactory<TDbContext> where TDbContext : class, IDisposable, new() 
    {
        TDbContext dbContext;

        public TDbContext Init()
        {
            return dbContext ?? (dbContext = new TDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
