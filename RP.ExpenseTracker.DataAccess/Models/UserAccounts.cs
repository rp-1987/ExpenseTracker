using System;
using System.Collections.Generic;

namespace RP.ExpenseTracker.DataAccess.Models
{
    public partial class UserAccounts
    {
        public UserAccounts()
        {
            Expenses = new HashSet<Expenses>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountNo { get; set; }
        public string AccountOrg { get; set; }
        public bool? IsActive { get; set; }

        public Users User { get; set; }
        public ICollection<Expenses> Expenses { get; set; }
    }
}
