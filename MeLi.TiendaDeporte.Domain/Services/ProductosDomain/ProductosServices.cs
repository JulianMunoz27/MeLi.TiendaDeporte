using MeLi.TiendaDeporte.Domain.Dto;
using MeLi.TiendaDeporte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeLi.TiendaDeporte.Domain.Services.ProductosDomain
{
    public class ProductosServices : IProductosServices
    {
        private IProductosRepository _repository;

        public ProductosServices(IProductosRepository repository)
        {
            _repository = repository;
        }

        public Productos CreateProducto(ProductosDto productosDto)
        {
            try
            {
                return _repository.CreateProducto(productosDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Productos> GetProductoByCategory(string category)
        {
            try
            {
                return _repository.GetProductoByCategory(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Productos GetProductoById(int id)
        {
            try
            {
                return _repository.GetProductoById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Productos> GetAllProductos()
        {
            try
            {
                return _repository.GetAllProductos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProduct(Productos producto)
        {
            try
            {
                _repository.UpdateProduct(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                _repository.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MetricasDto GetMetricas()
        {
            try
            {
                return _repository.GetMetricas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
