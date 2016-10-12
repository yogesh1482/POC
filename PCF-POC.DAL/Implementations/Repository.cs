using PCF_POC.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.DAL.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private PcfDatabaseEntities dataContext;
        private readonly IDbSet<T> dbset;
        protected Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected PcfDatabaseEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        {
            try
            {
                dbset.Add(entity);
            }
            catch (Exception e)
            {

            }

        }
        public virtual void Update(T entity)
        {
            //dynamic entry = dataContext.Entry(entity);
            //if (entry.State == System.Data.Entity.EntityState.Detached)
            //{ 
            dbset.Attach(entity);
            //}
            dataContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {

            dynamic entry = dataContext.Entry(entity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                dbset.Attach(entity);
                dbset.Remove(entity);
            }

            //dbset.Attach(entity);
            //dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
    }
}
