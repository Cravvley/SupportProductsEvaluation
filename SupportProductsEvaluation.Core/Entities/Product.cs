using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportProductsEvaluation.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual Article Article { get; set; }

        [Required, Range(0.01, int.MaxValue, ErrorMessage = "Price should be greater than 1 cent")]
        public double Price { get; set; }

        [Display(Name = "Shop")]
        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
        public byte[] Picture { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Rate> Rates { get; set; }
    }
}
