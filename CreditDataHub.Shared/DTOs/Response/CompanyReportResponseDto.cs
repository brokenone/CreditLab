using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Shared.DTOs.Response
{
    public class CompanyReportResponseDto
    {
        public string CompanyId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public int EmployeesCount { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CreditRecordDto> CreditRecords { get; set; } = [];
    }
}
