using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Unikreativ.Helper.Config
{
    public static class ConfigReader
    {
        public static IConfigurationRoot GetConfigFile()
        {
            var config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json").Build();
            return config;
        }
    }
}
