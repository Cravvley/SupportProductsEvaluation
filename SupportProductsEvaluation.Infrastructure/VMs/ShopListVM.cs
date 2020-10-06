using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class ShopListVM
    {
        public IList<Shop> Shops{ get; set; }
        public PagingInfo PagingInfo{ get; set; }
    }
}
