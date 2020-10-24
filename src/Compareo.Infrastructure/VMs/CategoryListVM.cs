using Compareo.Data.Entities;
using Compareo.Infrastructure.Pagination;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class CategoryListVM
    {
        public IList<Category> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
