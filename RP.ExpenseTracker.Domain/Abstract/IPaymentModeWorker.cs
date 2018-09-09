using RP.ExpenseTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RP.ExpenseTracker.Domain.Abstract
{
    public interface IPaymentModeWorker
    {
        Task<List<PaymentModeDTO>> GetPaymentModes(); 
    }
}
