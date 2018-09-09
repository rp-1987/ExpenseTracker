using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RP.ExpenseTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/ExpenseCategory")]
    public class ExpenseCategoryController : Controller
    {
    }
}