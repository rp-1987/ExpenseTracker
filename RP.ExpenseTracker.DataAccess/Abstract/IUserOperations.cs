using RP.ExpenseTracker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RP.ExpenseTracker.DataAccess
{
    public interface IUserOperations
    {
        Task<List<UserAccounts>> GetUserAccounts();
    }
}
