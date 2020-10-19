using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using System.Collections.Generic;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class SubCategoryListVM
    {
        public IList<SubCategory> SubCategories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
