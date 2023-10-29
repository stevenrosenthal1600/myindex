using CodeChallenge.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation GetByEmployeeId(String id);
        List<Compensation> GetAllByEmployeeId(String id);
        Compensation Add(Compensation compensation);
        Task SaveAsync();
    }
}
