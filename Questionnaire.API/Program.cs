using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Questionnaire.API.Extensions;
using Questionnaire.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Questionnaire.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase<QuestionnaireContext>((context, services) =>
                {
                    var logger = services.GetService<ILogger<QuestionnaireContextSeed>>();
                    QuestionnaireContextSeed
                        .SeedAsync(context, logger)
                        .Wait();
                }).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
