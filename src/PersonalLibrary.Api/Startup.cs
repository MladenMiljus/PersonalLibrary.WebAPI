using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace PersonalLibrary.Api
{
    /// <summary>
    /// The Startup class configures services and the application's request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup class constructor.
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Represents a set of key/value application configuration properties.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Register the Swagger generator, defining 1 or more Swagger documents
            var swaggerConfiguration = Configuration.GetSection("ServiceOptions").GetSection("SwaggerConfiguration");
            var swaggerConfigurationContact = swaggerConfiguration.GetSection("Contact");
            services.AddSwaggerGen(swaggerSetup =>
            {
                swaggerSetup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = Configuration.GetSection("ServiceData")["ServiceName"],
                    Description = Configuration.GetSection("ServiceData")["Description"],
                    Contact = new OpenApiContact
                    {
                        Name = swaggerConfigurationContact["Name"],
                        Email = swaggerConfigurationContact["Email"],
                        Url = string.IsNullOrWhiteSpace(swaggerConfigurationContact["Url"]) ? default : new Uri(swaggerConfigurationContact["Url"])
                    }
                }); ;
                //Configure Swagger to use all generated xml files of projects
                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "PersonalLibrary.*.xml");
                foreach (var xmlFile in xmlFiles)
                {
                    swaggerSetup.IncludeXmlComments(xmlFile);
                }
            });
        }

        // 
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline (by adding middleware components).
        /// </summary>
        /// <param name="app">Defines a class that provides the mechanisms to configure an application's request pipeline</param>
        /// <param name="env">Provides information about the web hosting environment an application is running in</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonalLibrary.API v1");
           });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
