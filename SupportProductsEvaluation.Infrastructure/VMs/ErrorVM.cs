using System;

namespace SupportProductsEvaluation.Infrastructure.VMs
{
    public class ErrorVM
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
