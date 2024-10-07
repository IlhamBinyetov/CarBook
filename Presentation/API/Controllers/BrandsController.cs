using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandsController(GetBrandByIdQueryHandler getBrandByIdQueryHandler, 
                                GetBrandQueryHandler getBrandQueryHandler, 
                                CreateBrandCommandHandler createBrandCommandHandler, 
                                UpdateBrandCommandHandler updateBrandCommandHandler, 
                                RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandsList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreaeteBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Brand added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok($"Brand Id with {command.BrandId} has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok($"Brand with {id} has been deleted");
        }
    }
}
