using System.Collections.Generic;

namespace SupportProductsEvaluation.Data.Entities
{
    public class Category
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int? ParentCategoryId { get; set; }
        
        public virtual Category ParentCategory { get; set; }

        public virtual IList<Category> ChildrenCategories { get; set; }
    }
}