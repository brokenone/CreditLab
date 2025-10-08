using CreditDataHub.Shared.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Core.Interfaces
{
    public interface ICreditReportService
    {
        PersonReportResponseDto GeneratePersonReport(string personId);
        CompanyReportResponseDto GenerateCompanyReport(string companyId);
    }
}
