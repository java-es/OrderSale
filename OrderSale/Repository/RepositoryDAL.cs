using System;
using System.Linq;
using System.Data.Entity;

namespace Repository
{
    public abstract class RepositoryDAL<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private ContextOrderSale contextOrderSale = new ContextOrderSale();

        public void Insert(TEntity obj)
        {
            try
            {
                contextOrderSale.Set<TEntity>().Add(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertChanges()
        {
            try
            {
                contextOrderSale.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                contextOrderSale.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            try
            {
                contextOrderSale.Set<TEntity>()
                    .Where(predicate).ToList()
                    .ForEach(del => contextOrderSale.Set<TEntity>().Remove(del));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TEntity Find(params object[] key)
        {
            try
            {
                return contextOrderSale.Set<TEntity>().Find(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            try
            {
                return GetAll().Where(predicate).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return contextOrderSale.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            contextOrderSale.Dispose();
        }
    }
}
