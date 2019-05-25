// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure_WebJobs_with_SDK_3.x
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .UseEnvironment("Development")
                                .ConfigureAppConfiguration((context, config) =>
                                {
                                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);      //appsettings.json --> Copy Always to True
                                })
                .ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices()
                    .AddAzureStorage();     //This is to register Queue Trigger Function
                })
                 .ConfigureLogging((context, b) =>
                 {
                     b.SetMinimumLevel(LogLevel.Debug);
                 })
                .UseConsoleLifetime();

            var host = builder.Build();

            using (host)
            {
                await host.RunAsync();
            }

        }
    }
}
