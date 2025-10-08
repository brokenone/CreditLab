using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditDataHub.Shared.Interfaces;
using CreditDataHub.Shared.DTOs.Response;

namespace CreditDataHub.Core.Models
{
    public class Person : IToDto<PersonReportResponseDto>
    {
        public string PersonId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public List<CreditRecord> CreditHistory { get; set; } = [];

        public PersonReportResponseDto ToDto()
        {
            return new PersonReportResponseDto
            {
                PersonId = this.PersonId,
                FullName = this.FullName,
                DateOfBirth = this.DateOfBirth,
                Nationality = this.Nationality,
                CreditHistory = this.CreditHistory.Select(cr => cr.ToDto()).ToList()
            };
        }
    }
}
