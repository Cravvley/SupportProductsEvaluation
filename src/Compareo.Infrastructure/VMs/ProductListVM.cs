using Compareo.Infrastructure.Common.Pagination;
using Compareo.Infrastructure.DTOs;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class ProductListVM
    {
        public IList<ProductDto> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
