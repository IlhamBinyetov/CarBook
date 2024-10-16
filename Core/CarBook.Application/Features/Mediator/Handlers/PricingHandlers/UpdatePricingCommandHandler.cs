﻿using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
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
        private readonly IRepository<Pricing> _repository;

        public UpdateServiceCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var updatedItem = await _repository.GetByIdAsync(request.PricingId);
            updatedItem.Name = request.Name;
            await _repository.UpdateAsync(updatedItem);
        }
    }
}
