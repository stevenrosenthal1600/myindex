using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IReportsService _reportsService;

        public ReportsController(ILogger<ReportsController> logger, IReportsService reportsService)
        {
            _logger = logger;
            _reportsService = reportsService;
        }

        [HttpGet("{id}", Name = "getNumberOfReports")]
        public IActionResult GetNumberOfReports(String id)
        {
            _logger.LogDebug($"Received get number of reports request for employee '{id}'");

            var reports = _reportsService.GetNumberOfReports(id);

            if (reports == null)
                return NotFound();

            return Ok(reports);
        }
    }
}
