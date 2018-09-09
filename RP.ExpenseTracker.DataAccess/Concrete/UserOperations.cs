using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RP.ExpenseTracker.DataAccess.Models;

namespace RP.ExpenseTracker.DataAccess
{
    public class UserOperations : IUserOperations
    {

        private ExpenseTrackerContext context;

        public UserOperations()
        {
            context = new ExpenseTrackerContext();
        }

        public async Task<List<UserAccounts>> GetUserAccounts()
        {
            return await context.UserAccounts.Where(u => u.IsActive == true).ToListAsync();
        }
    }
}
