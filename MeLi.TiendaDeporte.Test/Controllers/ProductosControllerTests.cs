using MeLi.TiendaDeporte.Data.IoC;
using MeLi.TiendaDeporte.Domain.Dto;
using MeLi.TiendaDeporte.Domain.Helpers;
using MeLi.TiendaDeporte.Domain.Services.ProductosDomain;
using MeLi.TiendaDeporte.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Reflection;
using Xunit;

namespace MeLi.TiendaDeporte.Test.Controllers
{
    public class ProductosControllerTests
    {
        [Fact]
        public void GetMetricas_ReturnsOkWithMetricas_WhenServiceReturnsData()
        {
            //Arrange
            var mockService = new Mock<IProductosServices>();
            var fakeMetricas = new MetricasDto
            {
                top_categoriesString = "Deportes,Electronica,Hogar",
                top_categories = new List<string> { "Deportes", "Electronica", "Hogar" }
            };
            mockService.Setup(s => s.GetMetricas()).Returns(fakeMetricas);

            var iocType = typeof(IoCFactory);
            var method = iocType.GetMethod("Resolve", BindingFlags.Static | BindingFlags.Public);

            method.Invoke(null, new object[] { typeof(IProductosServices) });

            var controller = new ProductosController();

            //Act
            var result = controller.GetMetricas();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedMetricas = Assert.IsType<MetricasDto>(okResult.Value);
            Assert.Equal(3, returnedMetricas.top_categories.Count);
            Assert.Contains("Deportes", returnedMetricas.top_categories);
        }

        [Fact]
        public void GetMetricas_ReturnsOkWithErrorMessage_WhenServiceReturnsNull()
        {
            //Arrange
            var mockService = new Mock<IProductosServices>();
            mockService.Setup(s => s.GetMetricas()).Returns((MetricasDto)null);
            MockIoCFactory(mockService.Object);
            var controller = new ProductosController();

            //Act
            var result = controller.GetMetricas();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<DefaultApiResponse>(okResult.Value);
            Assert.False(response.HasError);
            Assert.Equal("No existe informacion para mostrar las metricas", response.Response);
        }

        [Fact]
        public void GetMetricas_ReturnsBadRequest_WhenServiceThrowsException()
        {
            //Arrange
            var mockService = new Mock<IProductosServices>();
            mockService.Setup(s => s.GetMetricas()).Throws(new System.Exception("Error de prueba"));
            MockIoCFactory(mockService.Object);
            var controller = new ProductosController();

            //Act
            var result = controller.GetMetricas();

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<DefaultApiResponse>(badRequestResult.Value);
            Assert.True(response.HasError);
            Assert.Equal("Error de prueba", response.Response);
        }


        private void MockIoCFactory(IProductosServices mockService)
        {
            var iocType = typeof(IoCFactory);
            var method = iocType.GetMethod("Resolve", BindingFlags.Static | BindingFlags.Public);
            method.Invoke(null, new object[] { typeof(IProductosServices) });
        }
    }
}
