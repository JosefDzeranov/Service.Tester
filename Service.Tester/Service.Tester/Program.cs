using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace Service.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
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
