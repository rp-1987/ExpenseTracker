using System;
using System.Collections.Generic;

namespace RP.ExpenseTracker.DataAccess.Models
{
    public partial class ExpenseSubTypes
    {
        public ExpenseSubTypes()
        {
            Expenses = new HashSet<Expenses>();
        }

        public int Id { get; set; }
        public string ExpenseSubType { get; set; }
        public int ExpenseId { get; set; }
        public bool? IsActive { get; set; }

        public ExpenseTypes Expense { get; set; }
        public ICollection<Expenses> Expenses { get; set; }
    }
}
