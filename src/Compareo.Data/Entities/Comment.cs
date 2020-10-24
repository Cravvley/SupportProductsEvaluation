using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compareo.Data.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime UpdateAt { get; set; }

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