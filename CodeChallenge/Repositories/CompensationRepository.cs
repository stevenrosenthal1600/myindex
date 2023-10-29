using CodeChallenge.Models;
using System.Threading.Tasks;
using System;
using CodeChallenge.Data;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        /// <summary>
        /// Get the currently effective salary for the employee
        /// </summary>
        /// <param name="id">Emplpoyee ID</param>
        /// <returns>Currently effective salary for the employee</returns>
        public Compensation GetByEmployeeId(String id)
        {
            return _employeeContext.EmployeeCompensations
                .Include(e => e.Employee)
                .Where(e => e.EffectiveDate <= DateTime.UtcNow) // currently effective
                .OrderByDescending(e => e.EffectiveDate)
                .Take(1)
                .SingleOrDefault();
        }

        /// <summary>
        /// Get all (current, future and historical) salaries for the employee
        /// </summary>
        /// <param name="id">Emplpoyee ID</param>
        /// <returns>Set of salaries, descending-sorted by effective date</returns>
        public List<Compensation> GetAllByEmployeeId(String id)
        {
            return _employeeContext.EmployeeCompensations
                .Include(e => e.Employee)
                .OrderByDescending(e => e.EffectiveDate)
                .Where(e => e.EmployeeId == id)
                .ToList();
        }

        public Compensation Add(Compensation compensation)
        {
            compensation.EffectiveDate = DateTime.UtcNow.Date;
            _employeeContext.EmployeeCompensations.Add(compensation);
            return compensation;
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
    }
}
