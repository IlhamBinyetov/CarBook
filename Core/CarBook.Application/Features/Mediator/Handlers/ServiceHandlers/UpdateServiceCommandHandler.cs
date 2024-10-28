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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var updatedItem = await _unitOfWork.Repository<Service>().GetByIdAsync(request.ServiceId);
            updatedItem.ServiceId = request.ServiceId;
            updatedItem.Title = request.Title;
            updatedItem.Description = request.Description;
            updatedItem.IconUrl = request.IconUrl;
            await _unitOfWork.Repository<Service>().UpdateAsync(updatedItem);
            _unitOfWork.Commit();
        }
    }
}
