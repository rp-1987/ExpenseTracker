using System;
using System.Collections.Generic;

namespace RP.ExpenseTracker.DataAccess.Models
{
    public partial class ExpenseTypes
    {
        public ExpenseTypes()
        {
            ExpenseSubTypes = new HashSet<ExpenseSubTypes>();
        }

        public int Id { get; set; }
        public string ExpenseType { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<ExpenseSubTypes> ExpenseSubTypes { get; set; }
    }
}
