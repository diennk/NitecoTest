using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp
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
                    webBuilder.ConfigureLogging(logBuilder =>
                     {
                         logBuilder.ClearProviders(); // removes all providers from LoggerFactory
                         logBuilder.AddConsole();
                         logBuilder.AddTraceSource("Information, ActivityTracing"); // Add Trace listener provider
                     });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
