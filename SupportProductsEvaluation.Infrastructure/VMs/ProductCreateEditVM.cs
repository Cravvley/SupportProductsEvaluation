using SupportProductsEvaluation.Core.Entities;
using System.Collections.Generic;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class ProductCreateEditVM
    {
        public Product Product { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<SubCategory> SubCategoryList { get; set; }
        public IEnumerable<Shop> ShopList{ get; set; }
    }
}
