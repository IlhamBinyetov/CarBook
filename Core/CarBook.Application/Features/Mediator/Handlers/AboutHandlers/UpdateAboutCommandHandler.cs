using CarBook.Application.Abstractions.UnitOfWork;
using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public  class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAboutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var updatedItem = await _unitOfWork.Repository<About>().GetByIdAsync(request.AboutId);
            updatedItem.Description = request.Description;
            updatedItem.Title = request.Title;
            updatedItem.ImageUrl = request.ImageUrl;
            await _unitOfWork.Repository<About>().UpdateAsync(updatedItem);
        }
    }
}
