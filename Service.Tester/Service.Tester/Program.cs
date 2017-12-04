using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Configuration;

namespace Service.Tester
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            return WebHost.CreateDefaultBuilder(args)

                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 5000);
                    //options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                    //{
                    //    listenOptions.UseHttps("testCert.pfx", "testPassword");
                    //});
                })
                .Build();
        }
    }
}
