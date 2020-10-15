using System.ComponentModel.DataAnnotations;

namespace SupportProductsEvaluation.Core.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}