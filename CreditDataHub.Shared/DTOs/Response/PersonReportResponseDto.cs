using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Shared.DTOs.Response
{
    public class PersonReportResponseDto
    {
        public string PersonId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public List<CreditRecordDto> CreditHistory { get; set; } = [];
    }
}
