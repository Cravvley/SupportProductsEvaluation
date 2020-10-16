using System.ComponentModel.DataAnnotations;

namespace SupportProductsEvaluation.Core.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "Category Name")]
        public string Name { get; set; }

      //I know, that code below is much better way for category tree than entity like "subcategory", but, don't blame me for this step please :D
      /*public int ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }*/
    }
}