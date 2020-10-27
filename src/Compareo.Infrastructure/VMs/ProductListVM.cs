using Compareo.Infrastructure.DTOs;
using Compareo.Infrastructure.Pagination;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class ProductListVM
    {
        public IList<ProductDto> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
