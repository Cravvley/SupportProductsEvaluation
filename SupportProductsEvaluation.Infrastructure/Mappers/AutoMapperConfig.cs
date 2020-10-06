using AutoMapper;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.VMs;

namespace SupportProductsEvaluation.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<Shop,ShopVM>();
             }).CreateMapper();
    }
}
