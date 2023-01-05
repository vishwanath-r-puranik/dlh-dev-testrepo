using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestPermitMicroFrontEnd.Utils.Logging;

namespace TestPermitMicroFrontEnd
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
                })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();

                string logFolder = "/Users/stevechua/Documents/Projects/Cloud/OpenShift/Sandbox/";
                if (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("TESTPERMIT_MICROSERVICES_LOG_FOLDER_PATH")))
                {
                    logFolder = Environment.GetEnvironmentVariable("TESTPERMIT_MICROSERVICES_LOG_FOLDER_PATH");
                }

                int maxSize;
                if(int.TryParse(Environment.GetEnvironmentVariable("TESTPERMIT_MICROSERVICES_LOG_MAX_SIZE"), out maxSize))
                {
                    maxSize = 50;
                }

                int fileCount;
                if (int.TryParse(Environment.GetEnvironmentVariable("TESTPERMIT_MICROSERVICES_LOG_FILE_COUNT"), out fileCount))
                {
                    fileCount = 10;
                }

                logging.AddFileLogger(options => {
                    options.Folder = logFolder;
                    options.MaxFileSizeInMB = maxSize;
                    options.RetainPolicyFileCount = fileCount;
                });
            });
    }
}
