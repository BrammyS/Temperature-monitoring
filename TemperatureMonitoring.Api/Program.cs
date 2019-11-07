using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

[assembly: AssemblyInformationalVersion("1.0.*")]
[assembly: AssemblyProduct("TemperatureMonitoring Api")]
[assembly: AssemblyTitle("TemperatureMonitoring.Api")]
[assembly: AssemblyCompany("TemperatureMonitoring")]
[assembly: AssemblyVersion("1.0.*")]

namespace TemperatureMonitoring.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
