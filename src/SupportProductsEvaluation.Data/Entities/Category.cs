using System.Collections.Generic;

namespace SupportProductsEvaluation.Data.Entities
{
    public class Category
    {
        //TODO : remove subcategory model, views, repositories and services
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int? ParentCategoryId { get; set; }
        
        public virtual Category ParentCategory { get; set; }

        public virtual IList<Category> ChildrenCategories { get; set; }
    }
}