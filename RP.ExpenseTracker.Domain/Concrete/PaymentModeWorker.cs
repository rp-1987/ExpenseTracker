using AutoMapper;
using RP.ExpenseTracker.DataAccess;
using RP.ExpenseTracker.Domain.Abstract;
using RP.ExpenseTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RP.ExpenseTracker.Domain.Concrete
{
    public class PaymentModeWorker : IPaymentModeWorker
    {
        private IPaymentOperations operations;
        private IMapper mapper;

        public PaymentModeWorker(IPaymentOperations operations, IMapper mapper)
        {
            this.operations = operations;
            this.mapper = mapper;
        }

        public async Task<List<PaymentModeDTO>> GetPaymentModes()
        {
            var res = await operations.GetAllPaymentModes();
            return mapper.Map<List<PaymentModeDTO>>(res);
        }
    }
}
