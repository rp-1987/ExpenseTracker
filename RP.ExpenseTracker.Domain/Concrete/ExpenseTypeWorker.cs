using RP.ExpenseTracker.Domain.Abstract;
using RP.ExpenseTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RP.ExpenseTracker.Domain.Concrete
{
    public class ExpenseTypeWorker : IExpenseTypeWorker
    {
        public Task<List<ExpenseTypeDTO>> GetActiveExpenseTypes()
        {
            throw new NotImplementedException();
        }
    }
}
