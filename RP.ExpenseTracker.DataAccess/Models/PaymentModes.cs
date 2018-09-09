using System;
using System.Collections.Generic;

namespace RP.ExpenseTracker.DataAccess.Models
{
    public partial class PaymentModes
    {
        public PaymentModes()
        {
            Expenses = new HashSet<Expenses>();
        }

        public int Id { get; set; }
        public string PaymentMode { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<Expenses> Expenses { get; set; }
    }
}
