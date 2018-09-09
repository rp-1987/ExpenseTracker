using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RP.ExpenseTracker.DataAccess.Models;

namespace RP.ExpenseTracker.DataAccess
{
    public class ExpenseOperations : IExpenseOperations
    {
        private ExpenseTrackerContext context;

        public ExpenseOperations()
        {
            context = new ExpenseTrackerContext();
        }

        public async Task AddExpense(Expenses expense)
        {
            await context.Expenses.AddAsync(expense);
            await context.SaveChangesAsync();
        }

        public async Task DeleteExpense(int expenseId)
        {
            var result = await GetExpense(expenseId);
            if (result != null)
                context.Expenses.Remove(result);
            await context.SaveChangesAsync();
        }

        public async Task<Expenses> GetExpense(int id)
        {
            return await context.Expenses.FindAsync(id);
        }

        public async Task<List<Expenses>> GetExpenseByCategory(int categoryId, bool isParentCategory)
        {
            var expenses = LoadDependencies(context.Expenses
                          .Where(e => e.ExpenseSubTypeId == categoryId &&
                                      e.IsActive == true));
            return expenses.ToList();
        }

        public async Task<List<Expenses>> GetExpenses()
        {
            var expenses = LoadDependencies(context.Expenses                                    
                                    .Where(e => e.IsActive == true));            
            return expenses.ToList();
        }

        public async Task<List<Expenses>> GetExpensesByDateRange(DateTime fromDate, DateTime toDate)
        {
            var expenses = LoadDependencies(context.Expenses
                          .Where(e => e.DateOfExpenditure >= fromDate && 
                                      e.DateOfExpenditure <= toDate &&
                                      e.IsActive == true));
            return expenses.ToList();
        }

        public async Task UpdateExpense(int expenseId, Expenses expense)
        {
            var result = await GetExpense(expenseId);
            if (result != null)
            {
                result.UserAccountId = expense.UserAccountId;
                result.PaymentModeId = expense.PaymentModeId;
                result.ExpenseSubTypeId = expense.ExpenseSubTypeId;
                result.DateOfExpenditure = expense.DateOfExpenditure;
                result.Amount = expense.Amount;
                result.AcknowledgmentNo = expense.AcknowledgmentNo;
            }
            await context.SaveChangesAsync();            
        }

        private IQueryable<Expenses> LoadDependencies(IQueryable<Expenses> source)
        {
            return source.Include(e => e.PaymentMode)
                         .Include(e => e.ExpenseSubType)
                                .ThenInclude(s => s.Expense)
                         .Include(e => e.UserAccount);
        }
    }
}
