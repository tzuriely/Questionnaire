using AutoMapper;
using Questionnaire.Application.Responses;
using Questionnaire.Core.Entities;

namespace Questionnaire.Application.Mappers
{
    public class AnswersProfile : Profile
    {
        public AnswersProfile()
        {
            CreateMap<Answer, AnswersVm>();
        }
    }
}
