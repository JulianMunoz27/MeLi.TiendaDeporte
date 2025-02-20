using MeLi.TiendaDeporte.Data.Repositories;
using MeLi.TiendaDeporte.Domain.Services.ProductosDomain;
using Unity;
using Unity.Lifetime;

namespace MeLi.TiendaDeporte.Data.IoC
{
    public static class IoCFactory
    {
        /// <summary>
        /// Container relationships dictionary.
        /// </summary>
        private static IDictionary<string, IUnityContainer> _containersDictionary;

        /// <summary>
        /// Static constructor that loads the dictionary of relationships.
        /// </summary>               
        static IoCFactory()
        {
            InitContainers();
        }

        /// <summary>
        /// Return a requested instance according to the interfaces dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                string containerName = "RealAppContext";

                if (string.IsNullOrEmpty(containerName) || string.IsNullOrWhiteSpace(containerName))
                {
                    throw new ArgumentNullException("Default Container not found.");
                }

                return Resolve<T>(containerName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns the implementation for the required interface.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public static T Resolve<T>(string containerName)
        {
            try
            {
                if (string.IsNullOrEmpty(containerName) || string.IsNullOrWhiteSpace(containerName))
                {
                    throw new ArgumentNullException("Default Container not found.");
                }

                if (!_containersDictionary.ContainsKey(containerName))
                {
                    throw new InvalidOperationException("Container Not Found");
                }

                IUnityContainer container = _containersDictionary[containerName];
                return container.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method that initializes the dictionary, to wire relationships.
        /// </summary>
        private static void InitContainers()
        {
            _containersDictionary = new Dictionary<string, IUnityContainer>();

            // Creates the root container.
            IUnityContainer rootContainer = new UnityContainer();
            _containersDictionary.Add("RootContext", rootContainer);

            // Creates a real container only if its necessary to do tests with another container.
            IUnityContainer realAppContainer = rootContainer.CreateChildContainer();
            _containersDictionary.Add("RealAppContext", realAppContainer);

            ConfigureRootContainer(rootContainer);
            ConfigureRealContainer(realAppContainer);
        }

        /// <summary>
        /// Configure the root container and register the data types.
        /// </summary>
        /// <param name="container"></param>
        private static void ConfigureRootContainer(IUnityContainer container)
        {
            RegisterRepositories(container);
            RegisterServices(container);
        }

        /// <summary>
        /// Register data types related with services.
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterServices(IUnityContainer container)
        {
            
            container.RegisterType<IProductosServices, ProductosServices>(new TransientLifetimeManager());
        }

        /// <summary>
        /// Registers data types related with repositories.
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<IProductosRepository, ProductosRepository>(new TransientLifetimeManager());
            
        }
        /// <summary>
        /// Configures a Real Container.
        /// </summary>
        /// <param name="container"></param>
        private static void ConfigureRealContainer(IUnityContainer container)
        {
            container.RegisterType<Context>();
        }
    }
}
