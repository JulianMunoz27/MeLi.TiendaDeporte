using AutoMapper;
using MeLi.TiendaDeporte.Domain.Dto;
using MeLi.TiendaDeporte.Domain.Helpers;
using MeLi.TiendaDeporte.Domain.Models;
using MeLi.TiendaDeporte.Domain.Services.ProductosDomain;
using System.Data.Entity;

namespace MeLi.TiendaDeporte.Data.Repositories
{
    public class ProductosRepository : GenericRepository<Productos>, IProductosRepository
    {
        private MapperConfiguration _config;
        private IMapper _mapper;

        public ProductosRepository(Context context) : base(context)
        {
            _config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = _config.CreateMapper();
        }

        public Productos CreateProducto(ProductosDto productosDto)
        {
            try
            {
                var context = new Context();
                var producto = _mapper.Map<Productos>(productosDto);
                context.Productos.Add(producto);
                context.SaveChanges();
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error has ocurred while creating a Producto", ex.InnerException);
            }
        }

        public List<Productos> GetProductoByCategory(string category)
        {
            try
            {
                var context = new Context();
                var productosPorCategoria = context.Productos.Where(p => p.Category == category);
                return productosPorCategoria.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An Error has ocurred while retreaving the Productos by category", ex.InnerException);
            }
        }

        public Productos GetProductoById(int id)
        {
            try
            {
                var context = new Context();
                return context.Productos.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("An Error has ocurred while retreaving the Producto by id", ex.InnerException);
            }
        }

        public List<Productos> GetAllProductos()
        {
            try
            {
                var context = new Context();
                return context.Productos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An Error has ocurred while retreaving the Producto by id", ex.InnerException);
            }
        }

        public void UpdateProduct(Productos producto)
        {
            try
            {
                var context = new Context();
                var productoViejo = context.Productos.FirstOrDefault(p => p.Id == producto.Id);
                context.Entry(productoViejo).CurrentValues.SetValues(producto);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("An Error has ocurred while updating the Producto by id", ex.InnerException);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var context = new Context();
                var producto = context.Productos.FirstOrDefault(p => p.Id == id);
                context.Productos.Remove(producto);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An Error has ocurred while deleting the Producto by id", ex.InnerException);
            }
        }

        public MetricasDto GetMetricas()
        {
            try
            {
                var context = new Context();
                var metricas = context.Database.SqlQuery<MetricasDto>("exec GetMetricas").FirstOrDefault();

                if (metricas != null)
                {
                    metricas.top_categories = metricas.top_categoriesString.Split(",").ToList();
                }
                
                return metricas;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error has ocurred while deleting the Producto by id", ex.InnerException);
            }
        }
    }
}
