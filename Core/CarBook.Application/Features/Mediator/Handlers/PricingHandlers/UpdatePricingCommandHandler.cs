using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Application.Abstractions.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var updatedItem = await _unitOfWork.Repository<Pricing>().GetByIdAsync(request.PricingId);
            updatedItem.Name = request.Name;
            await _unitOfWork.Repository<Pricing>().UpdateAsync(updatedItem);
            _unitOfWork.Commit();
        }
    }
}
