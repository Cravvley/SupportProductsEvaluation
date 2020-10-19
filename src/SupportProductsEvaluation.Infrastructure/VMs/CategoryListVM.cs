using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using System.Collections.Generic;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class CategoryListVM
    {
        public IList<Category> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
