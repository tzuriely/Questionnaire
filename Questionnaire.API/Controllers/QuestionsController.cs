using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Application.Queries;
using Questionnaire.Application.Responses;
using System.Net;


namespace Questionnaire.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionsVm>>> Get()
        {
            var query = new GetQuestionsQuery(10);
            var questions = await _mediator.Send(query);
            return Ok(questions);
        }
        
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                    