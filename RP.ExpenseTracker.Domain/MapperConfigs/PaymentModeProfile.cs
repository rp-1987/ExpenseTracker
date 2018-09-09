using AutoMapper;
using RP.ExpenseTracker.DataAccess.Models;
using RP.ExpenseTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RP.ExpenseTracker.Domain.MapperConfigs
{
    public class PaymentModeProfile: Profile
    {
        public PaymentModeProfile()
        {
            CreateMap<PaymentModes, PaymentModeDTO>()
                .ForMember(d => d.PaymentModeId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.PaymentMode, opt => opt.MapFrom(s => s.PaymentMode));
        }
    }
}
