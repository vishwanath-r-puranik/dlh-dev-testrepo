using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestPermitMicroAPI.Data;
using Microsoft.EntityFrameworkCore;
using TestPermitMicroAPI.Utils;

namespace TestPermitMicroAPI
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

            var databaseHost = "moves-testpermit-psql";
            if (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE_HOST")))
            {
                databaseHost = Environment.GetEnvironmentVariable("DATABASE_HOST");
            }

            var databaseName = "testpermitdb";
            if (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE_NAME")))
            {
                databaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
            }

            var dbUserName = "test";
            var dbPassword = "test";

            if (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("VAULT_PSQL_PROPERTIES")))
            {
                TestPermitMicroAPI.Utils.Properties testpermitprop = new TestPermitMicroAPI.Utils.Properties(Environment.GetEnvironmentVariable("VAULT_PSQL_PROPERTIES"));

                dbUserName = testpermitprop.get("databaseuser");
                dbPassword = testpermitprop.get("databasepassword");
            }


            //var dbUserName = "user123";
            //if (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE_USER")))
            //{
            //    dbUserName = Environment.GetEnvironmentVariable("DATABASE_USER");
            //}

            //var dbPassword = "HARDpassWORD4Me";
            //if (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE_PASSWORD")))
            //{
            //    dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
            //}

            var connectionString = "Host=" + databaseHost + ";Database=" + databaseName + ";Username=" + dbUserName + ";Password=" + dbPassword;
            //var connectionString = Configuration.GetConnectionString("OperatorMicroServicesContext");

            services.AddControllers();
            services.AddDbContext<TestPermitMicroAPIContext>(options => options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .EnableSensitiveDataLogging()
            );
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
