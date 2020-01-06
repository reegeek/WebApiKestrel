using System;
using System.Net;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApiKestrel
{
    public class Program
    {
        private static bool keepRunning = true;
        public static void Main(string[] args)
        {
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                keepRunning = false;
            };
            var host = CreateHostBuilder(args).Build();
            CancellationTokenSource cts = new CancellationTokenSource();
            host.StartAsync(cts.Token);
            while (keepRunning)
            {
                Thread.Sleep(500);
            }
            cts.Cancel();
            host.Dispose();
            Thread.Sleep(2000);
            cts.Dispose();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
