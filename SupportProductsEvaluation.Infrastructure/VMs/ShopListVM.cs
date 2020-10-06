using SupportProductsEvaluation.Infrastructure.Pagination;
using System.Collections.Generic;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class ShopListVM
    {
        public IList<ShopVM> Shops{ get; set; }
        public PagingInfo PagingInfo{ get; set; }
    }
}
