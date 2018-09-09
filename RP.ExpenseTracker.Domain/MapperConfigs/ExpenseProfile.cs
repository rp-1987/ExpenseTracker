
using AutoMapper;
using RP.ExpenseTracker.DataAccess.Models;
using RP.ExpenseTracker.Domain.Models;
using System;

namespace RP.ExpenseTracker.Domain.MapperConfigs
{
    public class ExpenseProfile: Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expenses, ExpenseDTO>()
                .ForMember(d => d.ExpenseId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount.ToString("N2")))
                .ForMember(d => d.DateOfExpenditure, opt => opt.MapFrom(s => s.DateOfExpenditure.ToString("dd-MM-yyyy")))
                .ForMember(d => d.PaymentMode, opt => opt.MapFrom(s => s.PaymentMode.PaymentMode))
                .ForMember(d => d.UserAccount, opt => opt.MapFrom(s => ($"{s.UserAccount.AccountOrg} ({s.UserAccount.AccountNo})")))
                .ForMember(d => d.ExpenseSubType, opt => opt.MapFrom(s => s.ExpenseSubType.ExpenseSubType))
                .ForMember(d => d.ExpenseType, opt => opt.MapFrom(s => s.ExpenseSubType.Expense.ExpenseType));


            CreateMap<ExpenseDTO, Expenses>()                
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => Convert.ToDecimal(s.Amount)))
                .ForMember(d => d.DateOfExpenditure, opt => opt.MapFrom(s => Convert.ToDateTime(s.DateOfExpenditure)));
        }
    }
}
