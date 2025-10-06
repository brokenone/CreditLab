using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.DTOs
{
    public class MediatorResultDto
    {
        public CustomerProfileDto? CustomerProfile { get; set; }
        public FiscoScoreResultDto? FiscoScore { get; set; }
        public List<CreditOfferDto> BankOffers { get; set; } = new();
    }
}
