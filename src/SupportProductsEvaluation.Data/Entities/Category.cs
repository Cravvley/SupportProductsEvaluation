using System.ComponentModel.DataAnnotations;

namespace SupportProductsEvaluation.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
    }
}