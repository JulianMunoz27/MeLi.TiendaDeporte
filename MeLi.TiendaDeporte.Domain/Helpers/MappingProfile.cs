using AutoMapper;
using MeLi.TiendaDeporte.Domain.Dto;
using MeLi.TiendaDeporte.Domain.Models;

namespace MeLi.TiendaDeporte.Domain.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductosDto, Productos>().ReverseMap();
        }
    }
}
