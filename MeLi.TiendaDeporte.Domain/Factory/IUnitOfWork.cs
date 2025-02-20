namespace MeLi.TiendaDeporte.Domain.Factory
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commit all changes made in the container.
        /// </summary>
        void Commit();

        /// <summary>
        /// Commit all changes made in the container and refresh the changes.
        /// </summary>
        void CommitAndRefreshChanges();
    }
}
