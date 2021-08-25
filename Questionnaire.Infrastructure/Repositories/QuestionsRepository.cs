using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.Entities;
using Questionnaire.Core.Repositories;
using Questionnaire.Core.Repositories.Interfaces;

namespace Questionnaire.Infrastructure.Repositories
{
    public class QuestionsRepository : Repository<Question>, IQuestionsRepository
    {
        public QuestionsRepository(QuestionnaireContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<IReadOnlyList<Question>> GetAllWithAnswers(int amount)
        {
            return await _dbContext.Questions
                .Take(amount)
                .Include(x => x.Answers)
                .ToListAsync();
        }
    }
}
