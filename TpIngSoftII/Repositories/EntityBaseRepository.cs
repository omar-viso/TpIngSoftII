using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Models;

namespace TpIngSoftII.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
    {
        private DBGestionDeProyectosContext dataContext;

        #region Properties
        protected IDbFactory<DBGestionDeProyectosContext> DbFactory
        {
            get;
            private set;
        }

        protected DBGestionDeProyectosContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        public EntityBaseRepository (IDbFactory<DBGestionDeProyectosContext> dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion

        
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
        
        public void DeleteById(int id)
        {
            var itemDelete = this.GetSingle(id);
            if (itemDelete != null) this.Delete(itemDelete);
        }

        public void Detached(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Detached;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRange(entities);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
        }
    }
}
