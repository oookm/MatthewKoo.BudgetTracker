using Infrastructure.Repositories;
using MatthewKoo.BudgetTracker.ApplicationCore.Entities;
using MatthewKoo.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using MatthewKoo.BudgetTracker.ApplicationCore.ServiceInterfaces;
using MatthewKoo.BudgetTracker.Infrastructure.Data;
using MatthewKoo.BudgetTracker.Infrastructure.Repositories;
using MatthewKoo.BudgetTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MatthewKoo.BudgetTracker", Version = "v1" });
            });
            services.AddDbContext<BudgetTrackerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BudgetTrackerDbConnection")));
            services.AddHttpContextAccessor();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAsyncRepository<Expenditure>, EfRepository<Expenditure>>();
            services.AddScoped<IExpenditureService, ExpenditureService>();

            services.AddScoped<IAsyncRepository<Income>, EfRepository<Income>>();
            services.AddScoped<IIncomeService, IncomeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatthewKoo.BudgetTracker v1"));
            }
            // for communicating to angular
            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
