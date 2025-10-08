using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Shared.DTOs.Request
{
    public class PersonReportRequestDto
    {
        public string PersonId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
