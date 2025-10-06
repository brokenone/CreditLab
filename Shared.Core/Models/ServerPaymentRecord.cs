using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Models
{
    public class ServerPaymentRecord
    {
        public DateTime Timestamp { get; set; }
        public string Endpoint { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }
    }
}
