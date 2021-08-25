using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Questionnaire.Application.Queries;
using Questionnaire.Application.Responses;
using Questionnaire.Core.Repositories;
using Questionnaire.Core.Repositories.Interfaces;

namespace Questionnaire.Application.Handlers
{
    public class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, List<QuestionsVm>>
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;

        public GetQuestionsHandler(IQuestionsRepository questionsRepository, IMapper mapper)
        {
            _questionsRepository = questionsRepository;
            _mapper = mapper;
        }

        public async Task<List<QuestionsVm>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questionsList = await _questionsRepository.GetAllWithAnswers(request.QuestionsAmount);
            return _mapper.Map<List<QuestionsVm>>(questionsList);
        }
    }
}
