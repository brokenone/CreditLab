using Shared.Core.DTOs;
using Shared.Core.Interfaces;

namespace FiscoEmulator.API.Services
{
    public class FiscoScoreService : IFiscoScoreService
    {
        public async Task<FiscoScoreResultDto> CalculateScoreAsync(CustomerProfileDto profile)
        {
            await Task.Delay(50);

            int score = 300;
            score += (int)(profile.Income / 1000);
            score -= (int)(profile.Debt / 1000);
            score += profile.CreditHistoryYears * 10;

            var risk = score >= 700 ? "Low" : score >= 600 ? "Medium" : "High";

            return new FiscoScoreResultDto
            {
                Score = Math.Clamp(score, 300, 850),
                RiskLevel = risk,
                Factors = new List<string> { "Mock factor 1", "Mock factor 2" }
            };
        }
    }
}
