using System;
using System.Collections.Generic;
using Questionnaire.Core.Entities;

namespace Questionnaire.Application.Responses
{
    public class QuestionsVm
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public QuestionChoiceType ChoiceType { get; set; }
        public List<AnswersVm> Answers { get; set; }
    }
}
