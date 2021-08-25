using System;
using System.Collections.Generic;
using MediatR;
using Questionnaire.Application.Responses;

namespace Questionnaire.Application.Queries
{
    public class GetQuestionsQuery : IRequest<List<QuestionsVm>>
    {
        public int QuestionsAmount { get; set; }

        public GetQuestionsQuery(int questionsAmount)
        {
            QuestionsAmount = questionsAmount;
        }
    }
}
