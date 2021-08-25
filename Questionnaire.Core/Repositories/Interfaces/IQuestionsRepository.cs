using System.Collections.Generic;
using System.Threading.Tasks;
using Questionnaire.Core.Entities;

namespace Questionnaire.Core.Repositories.Interfaces
{
    public interface IQuestionsRepository : IRepository<Question>
    {
        Task<IReadOnlyList<Question>> GetAllWithAnswers(int amount);
    }
}
