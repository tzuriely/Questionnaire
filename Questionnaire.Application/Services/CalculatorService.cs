using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Questionnaire.Application.Commands;
using Questionnaire.Application.Exceptions;
using Questionnaire.Core.Entities;

namespace Questionnaire.Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        public decimal Calculate(IEnumerable<Question> questions, IEnumerable<SelectedAnswers> selectedAnswers)
        {
            try
            {
                decimal totalResult = 0;
                foreach (var answer in selectedAnswers)
                {
                    Question question = questions.FirstOrDefault(x => x.Id == answer.QuestionId);
                    totalResult += QuestionResult(question, answer.Answers);
                }
                return totalResult;
            }
            catch (Exception e)
            {
                throw new CalculationException("Score Calculation is failed. Please check the data");
            }
        }

        private decimal QuestionResult(Question question, List<int> answers)
        {
            decimal questionResult = 0;
            foreach (var answer in answers)
            {
                questionResult += question.Answers.FirstOrDefault(x => x.Id == answer).Score;
            }

            if (question.ChoiceType == QuestionChoiceType.SingleAnswer && answers.Count == 1)
            {
                questionResult /= 2;
            }

            return questionResult/10;
        }
    }
    
}
