using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Application.Abstractions.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var deletedItem = await _unitOfWork.Repository<Service>().GetByIdAsync(request.Id);
            await _unitOfWork.Repository<Service>().RemoveAsync(deletedItem);
            _unitOfWork.Commit();
        }
    }
}
