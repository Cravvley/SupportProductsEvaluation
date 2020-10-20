using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Infrastructure.DTOs;
using System.Collections.Generic;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class ProductCreateEditVM
    {
        public ProductDto Product { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<SubCategory> SubCategoryList { get; set; }
        public IEnumerable<Shop> ShopList{ get; set; }
    }
}
