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
using CarBook.Application.Features.Mediator.Commands.AboutCommands;

namespace CarBook.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAboutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        

        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Repository<About>().CreateAsync(new About
            {
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Title = request.Title
            });
            _unitOfWork.Commit();
        }
    }
}
