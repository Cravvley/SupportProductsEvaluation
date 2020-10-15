using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SupportProductsEvaluation.Core.Entities
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "Product name")]
        public string ProductName { get; set; }
       
        [Required,Display(Name = "Category name")]
        public string CategoryName { get; set; }
        
        [Required,Display(Name = "Subcategory name")]
        public string SubCategoryName { get; set; }
        
        [Required]
        public double AvgPrice { get; set; }
        
        [Required]
        public double AvgRate { get; set; }
        
        [Required]
        public double MinPrice { get; set; }
        
        [Required]
        public double MaxPrice { get; set; }
        
        [Required, Display(Name = "Update at")]
        public DateTime UpdateAt { get; set; }
    }
}
