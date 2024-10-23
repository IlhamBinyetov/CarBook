using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var pricing = _unitOfWork.Repository<Service>().Query().FirstOrDefault(x => x.Title == request.Title);
            await _unitOfWork.Repository<Service>().CreateAsync(new Service
            {
                IconUrl = request.IconUrl,
                Title = request.Title,
                Description = request.Description,
            });
        }
    }
}
