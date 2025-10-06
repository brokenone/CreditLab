using Microsoft.AspNetCore.Mvc;
using Shared.Core.DTOs;
using Shared.Core.Interfaces;
using Shared.Infrastructure.Logging;

namespace MediatorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditController : ControllerBase
    {
        private readonly IMediatorService _mediatorService;
        private readonly IAppLogger<CreditController> _logger;

        public CreditController(IMediatorService mediatorService, IAppLogger<CreditController> logger)
        {
            _mediatorService = mediatorService;
            _logger = logger;
        }

        [HttpGet("check")]
        public async Task<ActionResult<MediatorResultDto>> CheckCredit([FromQuery] string ssn, [FromQuery] decimal amount)
        {
            _logger.LogInfo($"Got credit check request for SSN: {ssn}, Amount: {amount}");
            try
            {
                var result = await _mediatorService.ProcessCreditCheckAsync(ssn, amount);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing credit check for SSN: {ssn}. Error: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
