using CodeChallenge.Contracts;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<ReportsService> _logger;

        public ReportsService(ILogger<ReportsService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        /// <summary>
        /// Determine the total number of reports (recursively) under the specified employee.
        /// The values are computed on the fly but not persisted.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>The total number of reports under the employee</returns>
        public ReportingStructure GetNumberOfReports(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var employee = _employeeRepository.GetByIdRecursive(id);

                var numberOfReports = 0;

                if (employee.DirectReports != null)
                {
                    numberOfReports += employee.DirectReports.Count;

                    foreach (var directReport in employee.DirectReports)
                    {
                        numberOfReports += directReport.DirectReports?.Count ?? 0;
                    }
                }

                return new ReportingStructure
                {
                    Employee = employee,
                    NumberOfReports = numberOfReports
                };
            }

            return null;
        }
    }
}
