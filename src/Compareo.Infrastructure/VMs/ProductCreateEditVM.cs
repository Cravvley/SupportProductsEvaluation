﻿using Compareo.Data.Entities;
using Compareo.Infrastructure.DTOs;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class ProductCreateEditVM
    {
        public ProductDto Product { get; set; }
        public IEnumerable<Shop> ShopList{ get; set; }
    }
}