using CarBook.Application.Features.Mediator.AboutCommands;
using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _mediator.Send(new GetAboutQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _mediator.Send(new GetAboutByIdQuery(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok("New Feature added successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return Ok($"FeAboutature Deleted Successfully. The deleted item id is {id}");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok($"About Id with {command.AboutId} has been updated");
        } 

    }
}
