using MeLi.TiendaDeporte.Domain.Dto;
using MeLi.TiendaDeporte.Domain.Models;

namespace MeLi.TiendaDeporte.Domain.Services.ProductosDomain
{
    public interface IProductosServices
    {
        Productos CreateProducto(ProductosDto productosDto);
        List<Productos> GetProductoByCategory(string category);
        Productos GetProductoById(int id);
        List<Productos> GetAllProductos();
        void UpdateProduct(Productos producto);
        void DeleteProduct(int id);
        MetricasDto GetMetricas();
    }
}
