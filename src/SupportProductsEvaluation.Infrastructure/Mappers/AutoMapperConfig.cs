using AutoMapper;
using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Infrastructure.DTOs;
using System;
using System.Linq.Expressions;

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
