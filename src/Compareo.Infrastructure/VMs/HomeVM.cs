using Compareo.Data.Entities;
using Compareo.Infrastructure.DTOs;
using Compareo.Infrastructure.Pagination;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class HomeVM
    {
        public IList<ProductDto> Products{ get; set; }

        public ProductProposition ProductProposition { get; set; }

        public ShopProposition ShopProposition { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
