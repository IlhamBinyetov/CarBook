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
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveLocationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var deletedItem = await _unitOfWork.Repository<Location>().GetByIdAsync(request.Id);
            await _unitOfWork.Repository<Location>().RemoveAsync(deletedItem);
            _unitOfWork.Commit();

        }
    }
}
