using Microsoft.AspNetCore.Mvc;
using Shared.Core.DTOs;
using Shared.Core.Interfaces;

namespace FiscoEmulator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly IFiscoScoreService _fiscoService;

        public ScoreController(IFiscoScoreService fiscoScore)
        {
            _fiscoService = fiscoScore;
        }

        [HttpPost]
        public async Task<ActionResult<FiscoScoreResultDto>> CalculateScore([FromBody] CustomerProfileDto profile)
        {
            if (profile == null)
                return BadRequest();

            var result = await _fiscoService.CalculateScoreAsync(profile);
            return Ok(result);
        }
    }
}
