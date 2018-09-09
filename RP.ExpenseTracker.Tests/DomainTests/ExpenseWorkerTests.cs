using Xunit;
using RP.ExpenseTracker.Domain;
using RP.ExpenseTracker.Domain.Concrete;
using RP.ExpenseTracker.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Moq;

namespace RP.ExpenseTracker.Tests.DomainTests
{
    public class ExpenseWorkerTests
    {
        public readonly IExpenseWorker expenseWorker;

        public ExpenseWorkerTests()
        {
            var expenseWorker = new Mock<IExpenseWorker>();
        }

        #region Example of how to add complex types
        public static IEnumerable<object[]> InvalidExpenseData()
        {

            return new[]
            {
                    new object[] { new ExpenseDTO() },
                    new object[] { new ExpenseDTO { ExpenseId = 0 } },
                    new object[] { new ExpenseDTO { ExpenseId = -1 } },
                    new object[] { new ExpenseDTO { ExpenseId = 1 } }
                };

        }

        [Theory]
        [MemberData(nameof(InvalidExpenseData))]
        public async System.Threading.Tasks.Task AddExpenseInvalidExpense(ExpenseDTO expenseDTO)
        {
            

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => expenseWorker.AddExpense(expenseDTO));
        }
        #endregion

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddExpenseInvalidExpenseId(int expenseId)
        {
            var expenseDto = new ExpenseDTO { ExpenseId = expenseId };
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => expenseWorker.AddExpense(expenseDto));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddExpenseInvalidUserAccountId(int userAccountId)
        {
            var expenseDto = new ExpenseDTO { UserAccountId = userAccountId };
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => expenseWorker.AddExpense(expenseDto));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddExpenseInvalidPaymentModeId(int paymentModeId)
        {
            var expenseDto = new ExpenseDTO { PaymentModeId = paymentModeId };
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => expenseWorker.AddExpense(expenseDto));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddExpenseInvalidExpenseSubTypeId(int expenseSubTypeId)
        {
            var expenseDto = new ExpenseDTO { ExpenseSubTypeId = expenseSubTypeId };
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => expenseWorker.AddExpense(expenseDto));
        }
    }
}
