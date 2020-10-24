using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Compareo.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.Currency), Required, Range(0.01, double.MaxValue, ErrorMessage = "Price should be greater than 0")]
        public double Price { get; set; }

        [Display(Name = "Shop")]
        public int ShopId { get; set; }

        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public byte[] Picture { get; set; }

        [NotMapped]
        public double AverageGrade => Rates == null || Rates.Count == 0 ? 0.0d : Math.Round(Rates.Average(g => g.Grade), 1);
        
        public virtual IList<Comment> Comments { get; set; }
        
        public virtual IList<Rate> Rates { get; set; }
    }
}
