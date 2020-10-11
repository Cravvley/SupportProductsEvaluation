using SupportProductsEvaluation.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportProductsEvaluation.Infrastructure.DTOs
{
    public class ProductDto
    {
        
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Shop")]
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public byte[] Picture { get; set; }

    }
}
