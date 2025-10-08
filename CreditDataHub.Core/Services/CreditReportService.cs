using CreditDataHub.Core.Interfaces;
using CreditDataHub.Core.Models;
using CreditDataHub.Shared.DTOs.Response;
using CreditDataHub.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Core.Services
{
    public class CreditReportService : ICreditReportService
    {
        private readonly Random _random = new();
        public CompanyReportResponseDto GenerateCompanyReport(string companyId)
        {
            var company = new Company
            {
                CompanyId = companyId,
                Name = $"Company {_random.Next(100, 1000)}",
                Industry = "Technology",
                Revenue = _random.Next(100000, 1000000),
                EmployeesCount = _random.Next(10, 500),
                CreatedAt = DateTime.UtcNow.AddYears(-_random.Next(1, 20)),
                CreditRecords = GenerateRandomCredits()
            };

            return company.ToDto();
        }

        public PersonReportResponseDto GeneratePersonReport(string personId)
        {
            var person = new Person
            {
                PersonId = personId,
                FullName = $"Person {_random.Next(1000, 10000)}",
                DateOfBirth = DateTime.UtcNow.AddYears(-_random.Next(20, 65)),
                Nationality = "Armenian",
                CreditHistory = GenerateRandomCredits()
            };

            return person.ToDto();
        }

        private List<CreditRecord> GenerateRandomCredits()
        {
            int count = _random.Next(1, 5);
            var credits = new List<CreditRecord>();

            for(int i = 0; i < count; i++)
            {
                var principalAmount = _random.Next(1000, 10000);
                var interestRate = (decimal)Math.Round(_random.NextDouble() * 20, 2);

                var credit = new CreditRecord
                {
                    CreditId = Guid.NewGuid().ToString(),
                    BankName = $"Bank {_random.Next(1, 10)}",
                    Description = "Loan",
                    PrincipalAmount = principalAmount,
                    InterestRate = interestRate,
                    TotalAmount = principalAmount + (principalAmount * interestRate),
                    Currency = Currency.USD,
                    History = GenerateCreditHistory(),
                };
                credits.Add(credit);
            }
            return credits;
        }

        private List<CreditHistoryRecord> GenerateCreditHistory()
        {
            int months = _random.Next(3, 13);
            var history = new List<CreditHistoryRecord>();

            for(int i = 0; i < months; i++)
            {
                var record = new CreditHistoryRecord
                {
                    Month = DateTime.UtcNow.AddMonths(-i),
                    Amount = _random.Next(100, 1000),
                    PaymentStatus = (MonthlyPaymentStatus)_random.Next(0, 3)

                };

                history.Add(record);
            }
            return history;
        }
    }
}
