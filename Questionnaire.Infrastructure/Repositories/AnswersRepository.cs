using Questionnaire.Core.Entities;
using Questionnaire.Core.Repositories;
using Questionnaire.Core.Repositories.Interfaces;

namespace Questionnaire.Infrastructure.Repositories
{
    public class AnswersRepository : Repository<Answer>, IAnswersRepository
    {
        public AnswersRepository(QuestionnaireContext dbContext) : base(dbContext)
        {

        }
    }
}
