using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compareo.Data.Entities
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "Product name")]
        public string ProductName { get; set; }

        [Required,Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

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
