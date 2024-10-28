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
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePricingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var pricing =  _unitOfWork.Repository<Pricing>().Query().FirstOrDefault(x => x.Name == request.Name);
            await _unitOfWork.Repository<Pricing>().CreateAsync(new Pricing
            {
                Name = request.Name
                
            });
            _unitOfWork.Commit();
        }
    }
}
