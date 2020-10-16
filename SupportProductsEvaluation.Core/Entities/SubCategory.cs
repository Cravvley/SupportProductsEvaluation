using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportProductsEvaluation.Core.Entities
{
    public class SubCategory
    {
        //Before you start flame, just go and look into category model :P

        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "SubCategory Name")]
        public string Name { get; set; }

        [Required,Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

    }
}