using Compareo.Data.Entities;
using Compareo.Infrastructure.Pagination;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class ProductPropositionListVM
    {
        public IList<ProductProposition> ProductPropositions { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
