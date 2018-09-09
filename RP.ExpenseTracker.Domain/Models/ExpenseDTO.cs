using System;
using System.Collections.Generic;
using System.Text;

namespace RP.ExpenseTracker.Domain.Models
{
    public class ExpenseDTO
    {
        public int ExpenseId { get; set; }
        public int UserAccountId { get; set; }
        public string UserAccount { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public int ExpenseSubTypeId { get; set; }
        public string ExpenseType { get; set; }
        public string ExpenseSubType { get; set; }
        public string DateOfExpenditure { get; set; }
        public string Amount { get; set; }
        public string AcknowledgmentNo { get; set; }
        public bool IsActive { get; set; }
    }
}
