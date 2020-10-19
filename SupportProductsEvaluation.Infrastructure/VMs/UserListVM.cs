using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using System.Collections.Generic;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class UserListVM
    {
        public IList<User> Users { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
