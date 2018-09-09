using System;
using System.Collections.Generic;

namespace RP.ExpenseTracker.DataAccess.Models
{
    public partial class Expenses
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int PaymentModeId { get; set; }
        public int ExpenseSubTypeId { get; set; }
        public DateTime DateOfExpenditure { get; set; }
        public decimal Amount { get; set; }
        public string AcknowledgmentNo { get; set; }
        public bool? IsActive { get; set; }

        public ExpenseSubTypes ExpenseSubType { get; set; }
        public PaymentModes PaymentMode { get; set; }
        public UserAccounts UserAccount { get; set; }
    }
}
