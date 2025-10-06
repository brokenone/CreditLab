using Shared.Core.DTOs;
using Shared.Core.Interfaces;

namespace BankingEmulator.API.Services
{
    public class BankSimulatorService : IBankSimulatorService
    {
        private readonly List<string> _bankNames = new List<string>() { "Bank1", "Bank2", "Bank3", "Bank4" };

        public async Task<List<CreditOfferDto>> ProcessCreditRequestAsync(CreditRequestDto request)
        {
            await Task.Delay(50); // Bank Work Emulation

            var offers = new List<CreditOfferDto>();
            var random = new Random();

            foreach(var bank in  _bankNames)
            {
                bool approved = request.Score >= 600 && random.NextDouble() > 0.2; // 80% chance
                var amount = approved ? request.RequestedAmmount * ((decimal)random.NextDouble() * 0.5m + 0.75m) : 0;
                var rate = approved ? (decimal)(random.NextDouble() * 5 + 5) : 0; // 5-10%

                offers.Add(new CreditOfferDto
                {
                    BankName = bank,
                    Approved = approved,
                    OfferedAmount = Math.Round(amount, 2),
                    InterestRate = Math.Round(rate, 2),
                    Message = approved ? "Approved" : "Declined"
                });
            }

            return offers;
        }
    }
}
