using Microsoft.AspNetCore.Mvc;
using Shared.Core.DTOs;
using Shared.Core.Interfaces;

namespace BankingEmulator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController: ControllerBase
    {
        private readonly IBankSimulatorService _bankService;

        public BankController(IBankSimulatorService bankService)
        {
            _bankService = bankService;
        }

        [HttpPost("request")]
        public async Task<ActionResult<List<CreditOfferDto>>> SubmitCreditRequest([FromBody] CreditRequestDto request)
        {
            if (request == null)
                return BadRequest();

            var offers = await _bankService.ProcessCreditRequestAsync(request);
            return Ok(offers);
        }
    }
}
