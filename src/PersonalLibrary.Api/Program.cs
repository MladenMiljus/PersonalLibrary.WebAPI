using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PersonalLibrary.Api
{
    /// <summary>
    /// Program class is used to setup IHost and start hosting of the application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args">A list of command line arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates an Microsoft.Extensions.Hpsting.IHostBuilder which hosts a web application.
        /// Two logical parts:
        /// CreateDefaultBuilder(args) – ASP.NET Core uses this to configure the app configuration, logging, and DI container
        /// ConfigureWebHostDefaults – This adds everything else required by a typical ASP.NET Core application (kestrel configuration, and using the Startup class, middleware pipeline…)
        /// </summary>
        /// <param name="args">A list of command line arguments.</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
