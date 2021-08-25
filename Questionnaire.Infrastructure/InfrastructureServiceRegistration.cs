using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Questionnaire.Core.Repositories;
using Questionnaire.Core.Repositories.Interfaces;
using Questionnaire.Infrastructure.Repositories;

namespace Questionnaire.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Console.Write(configuration.GetConnectionString("QuestionnaireConnectionString"));
            services.AddDbContext<QuestionnaireContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("QuestionnaireConnectionString")));

            services.AddTransient<IQuestionsRepository, QuestionsRepository>();
            services.AddTransient<IAnswersRepository, AnswersRepository>();

            return services;
        }
    }
}
