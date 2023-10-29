using CodeChallenge.Contracts;
using System;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        CompensationStructure GetCompensation(String id);
        CompensationStructure CreateCompensation(String id, int salary);
    }
}
