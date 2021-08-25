using System.Collections.Generic;
using System.Threading.Tasks;
using Questionnaire.Application.Commands;
using Questionnaire.Core.Entities;

namespace Questionnaire.Application.Services
{
    public interface ICalculatorService
    {
        decimal Calculate(IEnumerable<Question> questions, IEnumerable<SelectedAnswers> selectedAnswers);
    }
}
