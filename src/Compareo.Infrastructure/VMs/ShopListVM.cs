using Compareo.Infrastructure.Common.Pagination;
using Compareo.Infrastructure.DTOs;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class ShopListVM
    {
        public IList<ShopDto> Shops{ get; set; }
        public PagingInfo PagingInfo{ get; set; }
    }
}
