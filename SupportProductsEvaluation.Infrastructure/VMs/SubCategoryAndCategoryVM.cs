using SupportProductsEvaluation.Data.Entities;
using System.Collections.Generic;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class SubCategoryAndCategoryVM
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
