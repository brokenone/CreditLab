using Shared.Core.DTOs;
using Shared.Core.Interfaces;

namespace CreditDataHub.API.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<CustomerProfileDto?> GetCustomerProfileAsync(string ssn)
        {
            await Task.Delay(50);

            return new CustomerProfileDto
            {
                SSN = ssn,
                FullName = "Gor Movsisyan",
                Income = 75000,
                Debt = 15000,
                CreditHistoryYears = 6,
                PaymentHistory = new List<string> { "OnTime", "Late", "OnTime" }
            };
        }
    }
}
