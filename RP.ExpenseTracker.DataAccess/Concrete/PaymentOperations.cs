using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RP.ExpenseTracker.DataAccess.Models;

namespace RP.ExpenseTracker.DataAccess
{
    public class PaymentOperations : IPaymentOperations
    {
        private ExpenseTrackerContext context;

        public PaymentOperations()
        {
            context = new ExpenseTrackerContext();
        }

        public Task<List<PaymentModes>> GetAllPaymentModes()
        {
            return context.PaymentModes
                            .Where(p => p.IsActive == true)
                            .ToListAsync();
        }
    }
}
