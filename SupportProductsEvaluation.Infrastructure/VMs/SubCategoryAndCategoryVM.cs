using SupportProductsEvaluation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class SubCategoryAndCategoryVM
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
