using CodeChallenge.Contracts;
using System;

namespace CodeChallenge.Services
{
    public interface IReportsService
    {
        ReportingStructure GetNumberOfReports(String id);
    }
}
