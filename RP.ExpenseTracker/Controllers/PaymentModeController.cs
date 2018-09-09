using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RP.ExpenseTracker.Domain.Abstract;

namespace RP.ExpenseTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/PaymentMode")]
    public class PaymentModeController : Controller
    {
        private IPaymentModeWorker worker;

        public PaymentModeController(IPaymentModeWorker worker)
        {
            this.worker = worker;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentModes()
        {
            var result = await worker.GetPaymentModes();
            return Ok(result);
        }
    }
}