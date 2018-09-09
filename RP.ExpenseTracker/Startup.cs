using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RP.ExpenseTracker.DataAccess;
using RP.ExpenseTracker.Domain;
using RP.ExpenseTracker.Domain.Abstract;
using RP.ExpenseTracker.Domain.Concrete;
using RP.ExpenseTracker.Domain.MapperConfigs;
using Swashbuckle.AspNetCore.Swagger;

namespace RP.ExpenseTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(options => {
                options.AddPolicy("Default", 
                    builder => builder.WithOrigins("*"));
            });
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Expense Tracker API", Version = "v1" });
            }
            );

            //Automapper initialization
            var mapper = ETMappingProfile.InitializeAutomapper().CreateMapper();
            services.AddSingleton<IMapper>(mapper);
            services.AddTransient<IExpenseOperations, ExpenseOperations>();
            services.AddTransient<IPaymentOperations, PaymentOperations>();
            services.AddTransient<IExpenseWorker, ExpenseWorker>();
            services.AddTransient<IPaymentModeWorker, PaymentModeWorker>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Default");
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense Tracker Services V1");
            });

            app.UseMvc();
        }
    }
}
