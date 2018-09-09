using System;

namespace RP.ExpenseTracker.Common
{
    public static class ValidationMessages
    {
        public const string InvalidExpense = "Invalid Expense Id";
        public const string InvalidAccount = "Invalid User Account Id";
        public const string InvalidPaymentMode = "Payment Mode is Invalid";
        public const string InvalidSubType = "Expense SubType is invalid";
        public const string InvalidDate = "Invalid Datetime";
        public const string OutOfRangeExpenditureDate = "Expenditure Date cannot be greated than current date";
        public const string InvalidExpenditureAmount = "Invalid Expenditure Amount";
        public const string OutOfRangeExpenditureAmount = "Expenditure Amount cannot be negative";
        public const string InvalidFromDate = "From Date is Invalid";
        public const string InvalidToDate = "To Date is invalid";
        public const string FromDateGreaterThanToDate = "From Date cannot be greater than To Date";
    }
}
