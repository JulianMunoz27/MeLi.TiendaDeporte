using MeLi.TiendaDeporte.Domain.Factory;
using MeLi.TiendaDeporte.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MeLi.TiendaDeporte.Data
{
    public class Context : DbContext, IContext
    {
        /// <summary>
        /// Static Constructor.
        /// </summary>
        static Context()
        {
            Database.SetInitializer<Context>(null);
        }

        /// <summary>
        /// Class constructor connected to the default connection string.
        /// </summary>
        public Context()
            : base("Server=DESKTOP-V5FN81Q\\SQLEXPRESS;Database=MeLiTiendaDeportes;Trusted_Connection=True;")
        {

        }

        public Context(string tenant)
            : base(tenant)
        {

        }

        #region DbSet
        /// <summary>
        /// Gets or sets data on the Productos table
        /// </summary>
        public DbSet<Productos> Productos { get; set; }
        #endregion

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            try
            {
                var cx = ((IObjectContextAdapter)this).ObjectContext;
                this.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Commits the and refresh changes.
        /// </summary>
        public void CommitAndRefreshChanges()
        {
            try
            {
                this.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
