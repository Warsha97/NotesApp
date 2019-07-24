using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteApplication.DataAccess.DBContext;
using NoteApplication.DataAccess.Repository;
using NoteApplication.BusinessService;
using Microsoft.Extensions.Logging;
//using NLog.Extensions.Logging;
using System;
using System.IO;
using NLog;
using Datalust.SerilogMiddlewareExample.Diagnostics;
using Serilog;
using Serilog.Exceptions;

namespace NoteApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            // LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static string ConnectionString { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appSettings.json")
                            .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            LoggerConfiguration logConfig = new LoggerConfiguration();
            
            //.MinimumLevel.Debug()
            //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //.Enrich.FromLogContext()
            //.ReadFrom.Configuration(Configuration)
            //logConfig.WriteTo.File("E:/Savva/KDU/4th Year/99xInternshipFollowUp/StartUpProject/NoteApplicationLogging/LogsAgain/log-{Date}.txt");
            logConfig.WriteTo.File("E:/Savva/KDU/4th Year/99xInternshipFollowUp/StartUpProject/NoteApplicationLogging/LogsAgain/log-{Date}.txt");
            Log.Logger = logConfig.CreateLogger();

            services.AddDbContext<NotesDBContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("NoteDatabase")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<INotesRepository, NotesRepository>();
            services.AddTransient<INoteService, NoteService>();


            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            ConnectionString = Configuration["ConnectionStrings:NoteDatabase"];

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            loggerFactory.AddSerilog();

            app.UseMiddleware(typeof(SerilogMiddleware));

            app.UseStaticFiles();


        }
    }
}
