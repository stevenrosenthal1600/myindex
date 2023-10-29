using CodeChallenge.Models;
using System;

namespace CodeChallenge.Contracts
{
    public class CompensationStructure
    {
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int Salary { get; set; }

        public DateTime? EffectiveDate { get; set; }
    }
}
