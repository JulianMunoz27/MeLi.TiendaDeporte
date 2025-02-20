namespace MeLi.TiendaDeporte.Domain.Factory
{
    public interface IRepository<TEntity> : IUnitOfWork where TEntity : class, new()
    {
        /// <summary>
        /// Get the context of this repository.
        /// </summary>
        IContext StoreContext { get; }

        /// <summary>
        /// Add an item to the repository.
        /// </summary>
        /// <param name="item"></param>
        bool Add(TEntity item);

        /// <summary>
        /// Add a collection of items to the repository.
        /// </summary>
        /// <param name="items"></param>
        bool AddItems(IEnumerable<TEntity> items);

        /// <summary>
        /// Remove an item from the repository.
        /// </summary>
        /// <param name="item"></param>
        void Remove(TEntity item);

        /// <summary>
        /// Apply a modified entity to the repository, When calling commit of the unit of work, these changes will be stored.
        /// </summary>
        /// <param name="item"></param>
        bool Modify(TEntity item);

        /// <summary>
        /// Gets all elements of type {T} that are found in the repository.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
    }
}
