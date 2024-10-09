using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;

        public CarsController(GetCarByIdQueryHandler getCarByIdQueryHandler, 
                              GetCarQueryHandler getCarQueryHandler, 
                              CreateCarCommandHandler createCarCommandHandler, 
                              UpdateCarCommandHandler updateCarCommandHandler, 
                              RemoveCarCommandHandler removeCarCommandHandler)
        {
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandsList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Brand added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok($"Brand Id with {command.BrandId} has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok($"Brand with {id} has been deleted");
        }
    }
}
