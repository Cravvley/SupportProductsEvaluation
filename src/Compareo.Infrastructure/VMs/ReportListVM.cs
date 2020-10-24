using Compareo.Data.Entities;
using Compareo.Infrastructure.Pagination;
using System.Collections.Generic;

namespace Compareo.Infrastructure.VMs
{
    public class ReportListVM
    {
        public IList<Report> Reports{ get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
