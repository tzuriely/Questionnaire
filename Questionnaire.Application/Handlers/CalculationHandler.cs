using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Questionnaire.Application.Commands;
using Questionnaire.Application.Responses;
using Questionnaire.Application.Services;
using Questionnaire.Core.Repositories;
using Questionnaire.Core.Repositories.Interfaces;

namespace Questionnaire.Application.Handlers
{
    public class CalculationHandler : IRequestHandler<CalculateCommand, ResultVm>
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly ICalculatorService _calculatorService;
        public CalculationHandler(IQuestionsRepository questionsRepository, ICalculatorService calculatorService)
        {
            _questionsRepository = questionsRepository;
            _calculatorService = calculatorService;
        }
        public async Task<ResultVm> Handle(CalculateCommand request, CancellationToken cancellationToken)
        {
            var questions = await _questionsRepository.GetAllWithAnswers(10);
            var result = _calculatorService.Calculate(questions, request.AnswersList);
            return new ResultVm() {Score = result};
        }
    }
}