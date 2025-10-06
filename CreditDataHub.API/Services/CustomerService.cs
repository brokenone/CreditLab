using CreditDataHub.API.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Core.DTOs;
using Shared.Core.Entities;
using Shared.Core.Interfaces;
using System.Text.Json;

namespace CreditDataHub.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CreditDataContext _context;
        private readonly Random _random = new();

        private readonly string[] _firstNames = { "Gor", "Anna", "David", "Lilit", "Aram", "Nare" };
        private readonly string[] _lastNames = { "Movsisyan", "Petrosyan", "Sargsyan", "Karapetyan", "Hovhannisyan" };

        public CustomerService(CreditDataContext context)
        {
            _context = context;
        }

        public async Task<CustomerProfileDto?> GetCustomerProfileAsync(string ssn)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(c => c.SSN == ssn);

            if(entity != null)
            {
                return new CustomerProfileDto
                {
                    SSN = entity.SSN,
                    FullName = entity.FullName,
                    Income = entity.Income,
                    Debt = entity.Debt,
                    CreditHistoryYears = entity.CreditHistoryYears,
                    PaymentHistory = JsonSerializer.Deserialize<List<string>>(entity.PaymentHistoryJson) ?? new List<string>()
                };
            }

            var profile = new CustomerProfileDto
            {
                SSN = ssn,
                FullName = $"{_firstNames[_random.Next(_firstNames.Length)]} {_lastNames[_random.Next(_lastNames.Length)]}",
                Income = _random.Next(200000, 1500000),
                Debt = _random.Next(0, 50000),
                CreditHistoryYears = _random.Next(0, 15),
                PaymentHistory = GeneratePaymantHistory(12)
            };

            var newEntity = new CustomerProfileEntity
            {
                SSN = profile.SSN,
                FullName = profile.FullName,
                Income = profile.Income,
                Debt = profile.Debt,
                CreditHistoryYears = profile.CreditHistoryYears,
                PaymentHistoryJson = JsonSerializer.Serialize(profile.PaymentHistory)
            };

            _context.Customers.Add(newEntity);
            await _context.SaveChangesAsync();

            return profile;
        }

        private List<string> GeneratePaymantHistory(int months)
        {
            var history = new List<string>();

            for(int i = 0; i < months; i++)
            {
                double roll = _random.NextDouble();
                if (roll < 0.75)
                    history.Add("OnTime");
                else if (roll < 0.95)
                    history.Add("Late");
                else
                    history.Add("Missed");
            }

            return history;
        }
    }
}
