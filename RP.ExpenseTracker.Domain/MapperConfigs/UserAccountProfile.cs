using AutoMapper;
using RP.ExpenseTracker.DataAccess.Models;
using RP.ExpenseTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RP.ExpenseTracker.Domain.MapperConfigs
{
    public class UserAccountProfile: Profile
    {
        public UserAccountProfile()
        {
            CreateMap<UserAccounts, UserAccountDTO>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(d => d.Id))
                .ForMember(d => d.UserAccountId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.UserAccountName, opt => opt.MapFrom(s => $"{s.AccountOrg}({s.AccountNo})"));
        }
    }
}
