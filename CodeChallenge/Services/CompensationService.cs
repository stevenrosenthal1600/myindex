using CodeChallenge.Contracts;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository, IEmployeeRepository employeeRepository)
        {
            _compensationRepository = compensationRepository;
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public CompensationStructure GetCompensation(string id)
        {
            var compensation = _compensationRepository.GetByEmployeeId(id);

            return new CompensationStructure
            {
                EmployeeId = compensation.EmployeeId,
                Employee = compensation.Employee,
                Salary = compensation.Salary,
                EffectiveDate = compensation.EffectiveDate
            };
        }

        public CompensationStructure CreateCompensation(string id, int salary)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee == null)
                return null;

            Compensation compensation = new Compensation
            {
                EmployeeId = id,
                Salary = salary
            };

            _compensationRepository.Add(compensation);
            _compensationRepository.SaveAsync().Wait();

            return new CompensationStructure
            {
                EmployeeId = id,
                Employee = employee,
                Salary = salary,
                EffectiveDate = compensation.EffectiveDate
            };
        }

    }
}
