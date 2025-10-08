using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditDataHub.Shared.Enums;

namespace CreditDataHub.Shared.DTOs.Response
{
    public class CreditHistoryRecordDto
    {
        public DateTime Month { get; set; }
        public decimal Amount { get; set; }
        public MonthlyPaymentStatus PaymentStatus { get; set; }
    }
}
