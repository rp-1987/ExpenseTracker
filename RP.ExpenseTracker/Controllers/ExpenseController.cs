using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RP.ExpenseTracker.Domain;

namespace RP.ExpenseTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/Expense")]
    [EnableCors("Default")]
    public class ExpenseController : Controller
    {
        private IExpenseWorker _worker;

        public ExpenseController(IExpenseWorker worker)
        {
            _worker = worker;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            var result = await _worker.GetExpenses();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenses(int id)
        {
            try
            {
                var result = await _worker.GetExpensesById(id);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet("{subCategoryId}")]
        [ActionName("GetExpensesByCategory")]
        public async Task<IActionResult> GetExpensesByCategory(int subCategoryId)
        {
            try
            {
                var result = await _worker.GetExpensesByCategory(subCategoryId);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("{fromDate}/{toDate}")]
        //[ActionName("GetExpensesByDateRange/{fromDate}/{toDate}")]
        public async Task<IActionResult> GetExpensesByDateRange(string fromDate, string toDate)
        {
            try
            {
                var result = await _worker.GetExpensesByDateRange(fromDate, toDate);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}