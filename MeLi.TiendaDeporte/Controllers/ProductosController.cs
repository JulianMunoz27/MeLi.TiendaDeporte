using MeLi.TiendaDeporte.Data.IoC;
using MeLi.TiendaDeporte.Domain.Dto;
using MeLi.TiendaDeporte.Domain.Helpers;
using MeLi.TiendaDeporte.Domain.Models;
using MeLi.TiendaDeporte.Domain.Services.ProductosDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeLi.TiendaDeporte.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="productosDto"></param>
        /// <returns>Producto creado.</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] ProductosDto productosDto)
        {
            try
            {
                var producto = IoCFactory.Resolve<IProductosServices>().CreateProducto(productosDto);

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultApiResponse() { Response = ex.Message, HasError = true });
            }
        }

        /// <summary>
        /// Obtiene un producto filtrado por nombre de categoria.
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Producto encontrado.</returns>
        [Authorize]
        [HttpGet]
        [Route("Categorias/{categoria}")]
        public IActionResult GetProductByCategory(string categoria)
        {
            try
            {
                var productosPorCategoria = IoCFactory.Resolve<IProductosServices>().GetProductoByCategory(categoria);

                if (productosPorCategoria.Any())
                {
                    return Ok(productosPorCategoria);
                }

                return Ok(new DefaultApiResponse() { Response = "No hay productos para esa categoria", HasError = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultApiResponse() { Response = ex.Message, HasError = true });
            }
        }

        /// <summary>
        /// Obtiene un producto filtrado por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Producto encontrado.</returns>
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var producto = IoCFactory.Resolve<IProductosServices>().GetProductoById(id);

                if (producto != null)
                {
                    return Ok(producto);
                }

                return Ok(new DefaultApiResponse() { Response = "El producto no existe", HasError = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultApiResponse() { Response = ex.Message, HasError = true });
            }
        }

        /// <summary>
        /// Obtiene todos los productos existentes.
        /// </summary>
        /// <returns>Todos los productos existentes.</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var productos = IoCFactory.Resolve<IProductosServices>().GetAllProductos();

                if (productos.Any())
                {
                    return Ok(productos);
                }

                return Ok(new DefaultApiResponse() { Response = "No hay ningun producto existente", HasError = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultApiResponse() { Response = ex.Message, HasError = true });
            }
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>Mensaje de confirmacion.</returns>
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] Productos producto)
        {
            try
            {
                IoCFactory.Resolve<IProductosServices>().UpdateProduct(producto);

                return Ok(new DefaultApiResponse() { Response = "Producto actualizado correctamente", HasError = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultApiResponse() { Response = ex.Message, HasError = true });
            }
        }

        /// <summary>
        /// Elimina un producto existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Mensaje de confirmacion.</returns>
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                IoCFactory.Resolve<IProductosServices>().DeleteProduct(id);

                return Ok(new DefaultApiResponse() { Response = "Producto eliminado correctamente", HasError = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultApiResponse() { Response = ex.Message, HasError = true });
            }
        }

        /// <summary>
        /// Obtiene las metricas relacionadas a los productos.
        /// </summary>
        /// <returns>Metricas calculadas.</returns>
        [Authorize]
        [HttpGet]
        [Route("Metricas")]
        public IActionResult GetMetricas()
        {
            try
            {
                var metricas = IoCFactory.Resolve<IProductosServices>().GetMetricas();

                if (metricas != null)
                {
                    return Ok(metricas);
                }

                return Ok(new DefaultApiResponse() { Response = "No existe informacion para mostrar las metricas", HasError = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultApiResponse() { Response = ex.Message, HasError = true });
            }
        }
    }
}
