using System;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.Entities;

namespace Questionnaire.Infrastructure
{
    public class QuestionnaireContext : DbContext
    {
        public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options) : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
