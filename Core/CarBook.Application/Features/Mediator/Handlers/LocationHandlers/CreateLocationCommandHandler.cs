using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Application.Abstractions.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLocationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location =  _unitOfWork.Repository<Location>().Query().FirstOrDefault(x=>x.Name == request.Name);
            await _unitOfWork.Repository<Location>().CreateAsync(new Location
            {
                Name = request.Name

            });
            _unitOfWork.Commit();
        }
    }
}
