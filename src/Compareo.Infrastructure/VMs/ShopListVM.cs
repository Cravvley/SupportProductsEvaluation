using Compareo.Infrastructure.DTOs;
using Compareo.Infrastructure.Pagination;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class ShopListVM
    {
        public IList<ShopDto> Shops{ get; set; }
        public PagingInfo PagingInfo{ get; set; }
    }
}
