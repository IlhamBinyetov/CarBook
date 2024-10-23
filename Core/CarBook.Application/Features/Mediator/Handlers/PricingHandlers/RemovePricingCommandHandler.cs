using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var deletedItem = await _unitOfWork.Repository<Pricing>().GetByIdAsync(request.Id);
            await _unitOfWork.Repository<Pricing>().RemoveAsync(deletedItem);
            _unitOfWork.Commit();
        }
    }
}
