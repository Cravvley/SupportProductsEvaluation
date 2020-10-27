using AutoMapper;
using Compareo.Data.Entities;
using Compareo.Infrastructure.DTOs;

namespace Compareo.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<Category, CategoryDto>();

                 cfg.CreateMap<Shop,ShopDto>();

                 cfg.CreateMap<ShopProposition,Shop>().

                 ForMember(dest=>dest.Id,act=>act.Ignore());

                 cfg.CreateMap<Product, ProductDto>().ReverseMap();

             }).CreateMapper();
    }
}
