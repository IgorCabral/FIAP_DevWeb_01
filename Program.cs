using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace Fiap01
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            //var intervalo = new Intervalo();
            //intervalo.TempoTotal = 26;
            //Console.WriteLine("Hello World!");
        }

        public static IWebHost BuildWebHost (string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }


    }

}
