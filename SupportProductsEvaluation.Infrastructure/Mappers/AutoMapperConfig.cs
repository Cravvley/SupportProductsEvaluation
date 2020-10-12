using AutoMapper;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.DTOs;

namespace SupportProductsEvaluation.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<Shop,ShopDto>();
                 cfg.CreateMap<Product, ProductDto>().ReverseMap();
             }).CreateMapper();
    }
}
