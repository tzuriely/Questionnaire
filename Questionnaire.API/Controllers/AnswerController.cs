using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Application.Commands;
using Questionnaire.Application.Responses;

namespace Questionnaire.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResultVm>> Post(CalculateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}