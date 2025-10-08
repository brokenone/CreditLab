using CreditDataHub.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Shared.DTOs.Response
{
    public class PaymentResponseDto
    {
        public string PaymentId { get; set; } = string.Empty;
        public PaymentTransactionStatus Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
