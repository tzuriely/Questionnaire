using System.Collections.Generic;

namespace Questionnaire.Application.Commands
{
    public class SelectedAnswers
    {
        public int QuestionId { get; set; }
        public List<int> Answers { get; set; }
    }
}