using MeLi.TiendaDeporte.Domain.Factory;
using System.Data.Entity;
namespace MeLi.TiendaDeporte.Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        private Context context;

        /// <summary>
        /// 
        /// </summary>
        internal DbSet<TEntity> dbSet;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Context to use on this repository.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GenericRepository(Context context)
        {
            this.context = context ?? throw new ArgumentNullException("context", "Container cannot be null");
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        public IContext StoreContext => this.context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Item is null");
            }

            dbSet.Add(item);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddItems(IEnumerable<TEntity> items)
        {
            this.context.Configuration.AutoDetectChangesEnabled = false;
            foreach (var item in items)
            {
                this.Add(item);
            }

            this.context.Configuration.AutoDetectChangesEnabled = true;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="user"></param>
        public void Remove(TEntity item)
        {
            if (item == (TEntity)null)
            {
                throw new ArgumentNullException("item", "Item is null");
            }

            if (context.Entry(item).State == EntityState.Detached)
            {
                dbSet.Attach(item);
            }

            dbSet.Remove(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Modify(TEntity item)
        {
            if (item == (TEntity)null)
            {
                throw new ArgumentNullException("item", "Item is null");
            }

            if (context.Entry(item).State == EntityState.Detached)
            {
                dbSet.Attach(item);
                context.Entry(item).State = EntityState.Modified;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Commit()
        {
            context.Commit();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CommitAndRefreshChanges()
        {
            context.CommitAndRefreshChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RollbackChanges()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
