using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compareo.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual IList<Category> ChildrenCategories { get; set; }

    }
}