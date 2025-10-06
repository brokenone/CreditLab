using Microsoft.AspNetCore.Mvc;
using Shared.Core.DTOs;
using Shared.Core.Interfaces;

namespace MediatorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditController : ControllerBase
    {
        private readonly IMediatorService _mediatorService;

        public CreditController(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        [HttpGet("check")]
        public async Task<ActionResult<MediatorResultDto>> CheckCredit([FromQuery] string ssn, [FromQuery] decimal amount)
        {
            try
            {
                var result = await _mediatorService.ProcessCreditCheckAsync(ssn, amount);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
