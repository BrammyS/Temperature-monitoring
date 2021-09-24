﻿using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TemperatureMonitor.Persistence.MongoDb;
using TemperatureMonitor.Persistence.MongoDb.Repositories;
using TemperatureMonitor.Persistence.MongoDb.UnitsOfWork;
using TemperatureMonitor.Persistence.Repositories;
using TemperatureMonitor.Persistence.UnitsOfWorks;

namespace TemperatureMonitor
{
    public class Program
    {
        static Task Main()
        {
            var serviceProvider = new ServiceCollection()
                                  .AddSingleton<MongoContext>()
                                  .AddSingleton<TemperatureMonitor>()
                                  .AddScoped<IUnitOfWork, UnitOfWork>()
                                  .AddScoped<IMeasurementRepository, MeasurementRepository>()
                                  .BuildServiceProvider();

            serviceProvider.GetRequiredService<TemperatureMonitor>().Start();
            return Task.Delay(-1);
        }
    }
}
