using System;
using System.Collections.Generic;

namespace RP.ExpenseTracker.DataAccess.Models
{
    public partial class Users
    {
        public Users()
        {
            UserAccounts = new HashSet<UserAccounts>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Passkey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserAccounts> UserAccounts { get; set; }
    }
}
