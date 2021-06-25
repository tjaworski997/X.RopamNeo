using Microsoft.Extensions.Configuration;
using System;

namespace X.RopamNeo.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .Build();

            configuration.Bind(Config.Settings);

            new Neo().Start();
        }
    }
}