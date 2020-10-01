using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportProductsEvaluation.Core.Entities
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }

        [Required, Range(0, 5, ErrorMessage = "Grade can't be less than 0 and greater than 5")]
        public int Grade { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}