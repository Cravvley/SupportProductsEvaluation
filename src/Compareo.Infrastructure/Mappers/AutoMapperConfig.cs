using AutoMapper;
using Compareo.Data.Entities;
using Compareo.Infrastructure.DTOs;
using System;
using System.Linq.Expressions;

namespace Compareo.Infrastructure.Mappers
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
