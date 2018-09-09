using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RP.ExpenseTracker.DataAccess.Models;

namespace RP.ExpenseTracker.DataAccess
{
    public class ExpenseMasterOperations : IExpenseMasterOperations
    {
        private ExpenseTrackerContext context;
        public ExpenseMasterOperations()
        {
            context = new ExpenseTrackerContext();
        }

        public async Task<List<ExpenseTypes>> GetExpensesTypes()
        {
            var res = await context.ExpenseTypes.Where(e => e.IsActive == true).ToListAsync();
            return res;
        }
    }
}
