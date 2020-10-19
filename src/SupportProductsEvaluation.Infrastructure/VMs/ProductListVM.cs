using SupportProductsEvaluation.Infrastructure.DTOs;
using SupportProductsEvaluation.Infrastructure.Pagination;
using System.Collections.Generic;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class ProductListVM
    {
        public IList<ProductDto> Products{ get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
