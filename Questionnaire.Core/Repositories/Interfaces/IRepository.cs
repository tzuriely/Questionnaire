using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Core.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
