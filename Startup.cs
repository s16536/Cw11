using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab11.Models;
using lab11.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace lab11
{
    public class Startup
    {
        private readonly string _connectionString = "Data Source=db-mssql;Initial Catalog=s16536;Integrated Security=True";

        public Startup(IConfiguration configuration)
        {
            // SampleData.SampleData.CreateSampleData(new DoctorsDbContext(new DbContextOptionsBuilder()
            //     .UseSqlServer((_connectionString)).Options));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDoctorsDbService, EfDoctorsDbService>();
            services.AddDbContext<DoctorsDbContext>(options =>
            {
                options.UseSqlServer(_connectionString);
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
