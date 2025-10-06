using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.DTOs
{
    public class CreditRequestDto
    {
        public string TempId {  get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string SSN { get; set; } = string.Empty;
        public int Score { get; set; }
        public decimal RequestedAmmount { get; set; }
    }
}
