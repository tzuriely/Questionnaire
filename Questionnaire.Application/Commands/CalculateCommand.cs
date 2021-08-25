using System.Collections.Generic;
using MediatR;
using Questionnaire.Application.Responses;
using Questionnaire.Core.Entities;

namespace Questionnaire.Application.Commands
{
    public class CalculateCommand : IRequest<ResultVm>
    {
        public List<SelectedAnswers> AnswersList { get; set; }
    }
}