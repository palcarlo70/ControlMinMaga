using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ControlMinMaga
{
    public class Program
    {
        private System.Timers.Timer timer;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            Timer newTimer = new Timer();
            newTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            newTimer.Interval = 2000;
            newTimer.Start();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });

        public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            Console.Write(" \r{0} ", DateTime.Now);
        }
    }
}
