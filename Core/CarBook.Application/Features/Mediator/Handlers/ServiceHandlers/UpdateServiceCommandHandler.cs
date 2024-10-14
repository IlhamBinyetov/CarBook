using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var updatedItem = await _repository.GetByIdAsync(request.ServiceId);
           updatedItem.ServiceId = request.ServiceId;
            updatedItem.Title = request.Title;
            updatedItem.Description = request.Description;
            updatedItem.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(updatedItem);
        }
    }
}
