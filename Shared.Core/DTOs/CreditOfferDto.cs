using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.DTOs
{
    public class CreditOfferDto
    {
        public string BankName { get; set; } = string.Empty;
        public bool Approved { get; set; }
        public decimal OfferedAmount { get; set; }
        public decimal InterestRate { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
