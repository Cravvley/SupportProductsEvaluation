using Compareo.Data.Entities;
using Compareo.Infrastructure.Common.Pagination;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class UserListVM
    {
        public IList<User> Users { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
