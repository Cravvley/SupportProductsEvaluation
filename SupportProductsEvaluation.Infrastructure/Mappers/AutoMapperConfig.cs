using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportProductsEvaluation.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
             {

             }).CreateMapper();
    }
}
