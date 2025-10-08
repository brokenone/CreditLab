using CreditDataHub.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Core.Models
{
    public class Payment
    {
        public string PaymentId { get; set; } = string.Empty;
        public string SubjectId { get; set; } = string.Empty;
        public PaymentTransactionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
    }
}
