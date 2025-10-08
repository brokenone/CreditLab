using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditDataHub.Shared.Interfaces;
using CreditDataHub.Shared.Enums;
using CreditDataHub.Shared.DTOs.Response;

namespace CreditDataHub.Core.Models
{
    public class CreditRecord : IToDto<CreditRecordDto>
    {
        public string CreditId { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PrincipalAmount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalAmount { get; set; }
        public Currency Currency { get; set; }
        public List<CreditHistoryRecord> History { get; set; } = [];

        public CreditRecordDto ToDto()
        {
            return new CreditRecordDto
            {
                CreditId = this.CreditId,
                BankName = this.BankName,
                Description = this.Description,
                PrincipalAmount = this.PrincipalAmount,
                InterestRate = this.InterestRate,
                TotalAmount = this.TotalAmount,
                Currency = this.Currency,
                History = this.History.Select(h => h.ToDto()).ToList()
            };
        }
    }
}
