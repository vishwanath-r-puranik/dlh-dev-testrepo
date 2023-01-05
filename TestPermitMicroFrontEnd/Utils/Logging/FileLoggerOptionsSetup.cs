using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging.Configuration;

namespace TestPermitMicroFrontEnd.Utils.Logging
{
    internal class FileLoggerOptionsSetup : ConfigureFromConfigurationOptions<FileLoggerOptions>
    {
        public FileLoggerOptionsSetup(ILoggerProviderConfiguration<FileLoggerProvider>
                                      providerConfiguration)
            : base(providerConfiguration.Configuration)
        {
        }
    }
}
