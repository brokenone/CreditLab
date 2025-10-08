using CreditDataHub.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Shared.DTOs.Response
{
    public class CreditRecordDto
    {
        public string CreditId { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PrincipalAmount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalAmount { get; set; }
        public Currency Currency { get; set; }
        public List<CreditHistoryRecordDto> History { get; set; } = [];
    }
}
