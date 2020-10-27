using Compareo.Data.Entities;
using Compareo.Infrastructure.Pagination;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class ShopPropositionListVM
    {
        public IList<ShopProposition> ShopPropositions{ get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
