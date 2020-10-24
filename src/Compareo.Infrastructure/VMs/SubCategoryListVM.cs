using Compareo.Data.Entities;
using Compareo.Infrastructure.Pagination;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class SubCategoryListVM
    {
        public IList<SubCategory> SubCategories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
