using AutoMapper;

namespace RP.ExpenseTracker.Domain.MapperConfigs
{
    public static class ETMappingProfile
    {
        public static MapperConfiguration InitializeAutomapper()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {
                c.AddProfile(new ExpenseProfile());
                c.AddProfile(new PaymentModeProfile());
                c.AddProfile(new UserAccountProfile());
            });

            return config;
        }
    }
}
