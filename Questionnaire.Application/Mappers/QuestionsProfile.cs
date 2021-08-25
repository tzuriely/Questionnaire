using System;
using AutoMapper;
using Questionnaire.Application.Responses;
using Questionnaire.Core.Entities;

namespace Questionnaire.Application.Mappers
{
    public class QuestionsProfile : Profile
    {
        public QuestionsProfile()
        {
            CreateMap<Question, QuestionsVm>();
        }
    }
}
