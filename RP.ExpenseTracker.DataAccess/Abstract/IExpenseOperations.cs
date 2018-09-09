using RP.ExpenseTracker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RP.ExpenseTracker.DataAccess
{
    public interface IExpenseOperations
    {
        Task AddExpense(Expenses expense);
        Task UpdateExpense(int expenseId, Expenses expense);
        Task DeleteExpense(int expenseId);
        Task<List<Expenses>> GetExpenses();
        Task<Expenses> GetExpense(int id);
        Task<List<Expenses>> GetExpensesByDateRange(DateTime fromDate, DateTime toDate);
        Task<List<Expenses>> GetExpenseByCategory(int categoryId, bool isParentCategory= true);
    }
}
