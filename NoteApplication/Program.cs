using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Serilog;
using Serilog.Events;
//using Serilog.Formatting.Compact;
using Serilog.Extensions.Logging;

namespace NoteApplication
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        public static int Main(string[] args)
        {


            CreateWebHostBuilder(args).Run();

            try
            {
                Log.Information("Starting web host");
                CreateWebHostBuilder(args).Run();
                return 1;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 0;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder()
                .UseSerilog()
                .UseStartup<Startup>()
                .Build();
        }
    }





    //For Logging
    /*     .ConfigureLogging((hostingContext, logging) =>
      {
         // logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
          //logging.AddConsole();
          //logging.AddDebug();
          //logging.AddEventSourceLogger();
          //logging.AddNLog();
          logging.AddSerilog();
      }) */


    //}
}
