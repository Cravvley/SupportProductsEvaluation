using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class ProductDetailsVM
    {
        public Product Product{ get; set; }
        public Comment Comment{ get; set; }
        public PagingInfo PagingInfo{ get; set; }

    }
}
