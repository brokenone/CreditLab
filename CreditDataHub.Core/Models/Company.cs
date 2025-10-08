using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditDataHub.Shared.Interfaces;
using CreditDataHub.Shared.DTOs.Response;

namespace CreditDataHub.Core.Models
{
    public class Company : IToDto<CompanyReportResponseDto>
    {
        public string CompanyId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public int EmployeesCount { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CreditRecord> CreditRecords { get; set; } = [];

        public CompanyReportResponseDto ToDto()
        {
            return new CompanyReportResponseDto
            {
                CompanyId = this.CompanyId,
                Name = this.Name,
                Industry = this.Industry,
                Revenue = this.Revenue,
                EmployeesCount = this.EmployeesCount,
                CreatedAt = this.CreatedAt,
                CreditRecords = this.CreditRecords.Select(c => c.ToDto()).ToList()
            };
        }
    }
}
