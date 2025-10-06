using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.DTOs
{
    public class CustomerProfileDto
    {
        public string SSN { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public decimal Income { get; set; }
        public decimal Debt {  get; set; }
        public int CreditHistoryYears { get; set; }
        public List<string> PaymentHistory { get; set; } = new();
    }
}
