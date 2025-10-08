using CreditDataHub.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditDataHub.Shared.Enums;
using CreditDataHub.Shared.DTOs.Response;

namespace CreditDataHub.Core.Models
{
    public class CreditHistoryRecord : IToDto<CreditHistoryRecordDto>
    {
        public DateTime Month { get; set; }
        public decimal Amount { get; set; }
        public MonthlyPaymentStatus PaymentStatus { get; set; }

        public CreditHistoryRecordDto ToDto()
        {
            return new CreditHistoryRecordDto
            {
                Month = this.Month,
                Amount = this.Amount,
                PaymentStatus = this.PaymentStatus
            };
        }
    }
}
