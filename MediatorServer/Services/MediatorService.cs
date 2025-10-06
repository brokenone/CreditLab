using Shared.Core.DTOs;
using Shared.Core.Interfaces;

namespace MediatorServer.Services
{
    public class MediatorService : IMediatorService
    {
        private readonly HttpClient _creditDataClient;
        private readonly HttpClient _fiscoClient;
        private readonly HttpClient _bankClient;

        public MediatorService(IHttpClientFactory httpClientFactory)
        {
            _creditDataClient = httpClientFactory.CreateClient("CreditDataHub");
            _fiscoClient = httpClientFactory.CreateClient("FiscoEmulator");
            _bankClient = httpClientFactory.CreateClient("BankingEmulator");
        }

        public async Task<MediatorResultDto> ProcessCreditCheckAsync(string ssn, decimal requestedAmount)
        {
            var result = new MediatorResultDto();

            // Get Client Profile
            var profileResponse = await _creditDataClient.GetFromJsonAsync<CustomerProfileDto>($"/api/customer/{ssn}");
            if (profileResponse == null)
                throw new Exception("Customer not found");

            result.CustomerProfile = profileResponse;

            // Get Fisco Score
            var scoreResponse = await _fiscoClient.PostAsJsonAsync("/api/score", profileResponse);
            var fiscoResult = await scoreResponse.Content.ReadFromJsonAsync<FiscoScoreResultDto>();
            result.FiscoScore = fiscoResult;

            // Send Credit Request 
            var creditRequest = new CreditRequestDto
            {
                TempId = Guid.NewGuid().ToString(),
                FullName = profileResponse.FullName,
                SSN = profileResponse.SSN,
                Score = fiscoResult?.Score ?? 0,
                RequestedAmmount = requestedAmount
            };

            var bankResponse = await _bankClient.PostAsJsonAsync("/api/bank/request", creditRequest);
            var bankOffers = await bankResponse.Content.ReadFromJsonAsync<List<CreditOfferDto>>();

            result.BankOffers = bankOffers ?? new List<CreditOfferDto>();

            return result;
        }
    }
}
