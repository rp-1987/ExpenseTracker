using System;
using System.Collections.Generic;
using System.Text;

namespace RP.ExpenseTracker.Domain.Models
{
    public class UserAccountDTO
    {
        public int UserAccountId { get; set; }
        public int UserId { get; set; }
        public string UserAccountName { get; set; }
    }
}
