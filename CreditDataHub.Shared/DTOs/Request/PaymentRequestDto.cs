using CreditDataHub.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Shared.DTOs.Request
{
    public class PaymentRequestDto
    {
        public string TargetId { get; set; } = string.Empty;
        public ReportType ReportType { get; set; }
    }
}
