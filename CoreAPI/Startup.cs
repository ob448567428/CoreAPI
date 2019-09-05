using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Log;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Login;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Repository = LogManager.CreateRepository("");
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
        }
        /// <summary>
        /// //log4net
        /// </summary>
        public static ILoggerRepository Repository;
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            var connection = Configuration.GetConnectionString("ConnectionString");
            //TODO: register dbcontext
            //services.AddDbContext<EFContext>(options =>
            //    options.UseSqlServer(connection, b => b.MigrationsAssembly("CoreAPI")));

            //register login service
            services.AddSingleton<ILoginService, LoginService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //custom APi Documents
            //Install-Package Swashbuckle.AspNetCore -Version 4.0.1
            //using Swashbuckle.AspNetCore
            services.AddSwaggerGen(
                opt =>
                {
                    opt.SwaggerDoc("v1", new Info { Title = "API Documents", Version = "1.0.0.0" });
                    opt.CustomSchemaIds(type => type.FullName);// resolve the same class name
                    //config Generating project xml file 
                    opt.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), "CoreAPI.xml"));
                });
            //add memory cache
            services.AddMemoryCache();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)//, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelpPage Version 1.0.0.0");
            });
            app.UseMvc();
        }
    }
}
