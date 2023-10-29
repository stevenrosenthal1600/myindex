using CodeChallenge.Models;

namespace CodeChallenge.Contracts
{
    public class ReportingStructure
    {
        public Employee Employee { get; set; }

        /// <summary>
        /// The total number of reports (recursively) under the employee
        /// </summary>
        public int NumberOfReports { get; set; }
    }
}
