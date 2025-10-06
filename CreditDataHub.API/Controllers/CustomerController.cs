using Microsoft.AspNetCore.Mvc;
using Shared.Core.DTOs;
using Shared.Core.Interfaces;

namespace CreditDataHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("{ssn}")]
        public async Task<ActionResult<CustomerProfileDto>> GetCustomerProfile(string ssn)
        {
            var profile = await _service.GetCustomerProfileAsync(ssn);
            if(profile == null) 
                return NotFound();
            return Ok(profile);
        }
    }
}
