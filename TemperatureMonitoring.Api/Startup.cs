using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TemperatureMonitor.Persistence.MongoDb;
using TemperatureMonitor.Persistence.MongoDb.Repositories;
using TemperatureMonitor.Persistence.MongoDb.UnitsOfWork;
using TemperatureMonitor.Persistence.Repositories;
using TemperatureMonitor.Persistence.UnitsOfWorks;
using TemperatureMonitoring.Api.Core.Services;
using TemperatureMonitoring.Api.Core.Services.Implementation;

namespace TemperatureMonitoring.Api
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
            services.AddSingleton<MongoContext>();
            services.AddScoped<IMeasurementService, MeasurementService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMeasurementRepository, MeasurementRepository>();
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}