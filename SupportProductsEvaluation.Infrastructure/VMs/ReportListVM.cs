using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using System.Collections.Generic;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class ReportListVM
    {
        public IList<Report> Reports{ get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
