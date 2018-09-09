using RP.ExpenseTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP.ExpenseTracker.Domain
{
    public interface IExpenseWorker
    {
        Task<bool> AddExpense(ExpenseDTO expense);
        Task<bool> UpdateExpense(int expenseId, ExpenseDTO expense);
        Task<bool> DeleteExpense(int expenseId);
        Task<List<ExpenseDTO>> GetExpenses();
        Task<ExpenseDTO> GetExpensesById(int id);
        Task<List<ExpenseDTO>> GetExpensesByCategory(int subCatecoryId);
        Task<List<ExpenseDTO>> GetExpensesByDateRange(string fromDate, string toDate);
    }
}
