using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RP.ExpenseTracker.DataAccess;
using RP.ExpenseTracker.DataAccess.Models;
using RP.ExpenseTracker.Domain.Models;

namespace RP.ExpenseTracker.Domain.Concrete
{
    public class ExpenseWorker : IExpenseWorker
    {
        private IExpenseOperations _operations;
        private IMapper _mapper;

        public ExpenseWorker(IExpenseOperations operations, IMapper mapper)
        {
            _operations = operations;
            _mapper = mapper;
        }

        public async Task<bool> AddExpense(ExpenseDTO expense)
        {
            try
            {
                ValidateExpense(expense);
                var res = _mapper.Map<Expenses>(expense);
                await _operations.AddExpense(res);
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeleteExpense(int expenseId)
        {
            try
            {
                await _operations.DeleteExpense(expenseId);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateExpense(int expenseId, ExpenseDTO expense)
        {
            try
            {
                ValidateExpense(expense);
                var res = _mapper.Map<Expenses>(expense);
                await _operations.UpdateExpense(expenseId, res);
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<List<ExpenseDTO>> GetExpenses()
        {
            try
            {
                var expenses = await _operations.GetExpenses();
                return _mapper.Map<List<ExpenseDTO>>(expenses);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ExpenseDTO> GetExpensesById(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentOutOfRangeException(Common.ValidationMessages.InvalidExpense);
                var expense = await _operations.GetExpense(id);
                return _mapper.Map<ExpenseDTO>(expense);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ExpenseDTO>> GetExpensesByCategory(int subCatecoryId)
        {
            try
            {
                if (subCatecoryId <= 0)
                    throw new ArgumentOutOfRangeException(Common.ValidationMessages.InvalidSubType);
                var expenses = await _operations.GetExpenseByCategory(subCatecoryId, false);
                return _mapper.Map<List<ExpenseDTO>>(expenses);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ExpenseDTO>> GetExpensesByDateRange(string fromDateStr, string toDateStr)
        {
            try
            {
                var fromDate = new DateTime();
                var toDate = new DateTime();
                if (!DateTime.TryParseExact(fromDateStr, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out fromDate))
                    throw new ArgumentException(Common.ValidationMessages.InvalidFromDate);
                if (!DateTime.TryParseExact(toDateStr, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out toDate))
                    throw new ArgumentException(Common.ValidationMessages.InvalidToDate);
                if(fromDate > toDate)
                    throw new ArgumentOutOfRangeException(Common.ValidationMessages.FromDateGreaterThanToDate);
                var expenses = await _operations.GetExpensesByDateRange(fromDate, toDate);
                return _mapper.Map<List<ExpenseDTO>>(expenses);
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void ValidateExpense(ExpenseDTO expense)
        {
            DateTime expenditureDate = new DateTime();
            decimal amount = 0;
            if (expense.ExpenseId <= 0)
                throw new ArgumentOutOfRangeException(Common.ValidationMessages.InvalidExpense);
            if (expense.UserAccountId <= 0)
                throw new ArgumentOutOfRangeException(Common.ValidationMessages.InvalidAccount);
            if (expense.PaymentModeId <= 0)
                throw new ArgumentOutOfRangeException(Common.ValidationMessages.InvalidPaymentMode);
            if (expense.ExpenseSubTypeId <= 0)
                throw new ArgumentOutOfRangeException(Common.ValidationMessages.InvalidSubType);
            if (!DateTime.TryParse(expense.DateOfExpenditure, out expenditureDate))
                throw new ArgumentException(Common.ValidationMessages.InvalidDate);
            if (expenditureDate > DateTime.Now)
                throw new ArgumentOutOfRangeException(Common.ValidationMessages.OutOfRangeExpenditureDate);
            if (!Decimal.TryParse(expense.Amount, out amount))
                throw new ArgumentException(Common.ValidationMessages.InvalidExpenditureAmount);
            if (amount < 0)
                throw new ArgumentOutOfRangeException(Common.ValidationMessages.OutOfRangeExpenditureAmount);
        }
    }
}
