using CodeChallenge.Contracts;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        [HttpGet("{id}", Name = "getCompensation")]
        public IActionResult GetCompensation(String id)
        {
            _logger.LogDebug($"Received get compensation request for employee '{id}'");

            var compensation = _compensationService.GetCompensation(id);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] CompensationStructure compensation)
        {
            _logger.LogDebug($"Received create compensation request of ${compensation.Salary} for employee '{compensation.EmployeeId}'");

            var created = _compensationService.CreateCompensation(compensation.EmployeeId, compensation.Salary);

            return CreatedAtRoute("getCompensation", new { id = compensation.EmployeeId }, created);
        }
    }
}
