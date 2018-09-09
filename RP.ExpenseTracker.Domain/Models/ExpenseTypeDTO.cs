using System;
using System.Collections.Generic;
using System.Text;

namespace RP.ExpenseTracker.Domain.Models
{
    public class ExpenseTypeDTO
    {
        public int ExpenseTypeId { get; set; }
        public string ExpenseType { get; set; }
        public List<ExpenseSubTypeDTO> ExpenseSubTypes { get; set; }
    }
}
