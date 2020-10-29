using Compareo.Data.Entities;
using Compareo.Infrastructure.Common.Pagination;

namespace Compareo.Infrastructure.VMs
{
    public class ProductDetailsVM
    {
        public Product Product{ get; set; }
        public Comment Comment{ get; set; }
        public Rate Rate{ get; set; }
        public PagingInfo PagingInfo{ get; set; }

    }
}
