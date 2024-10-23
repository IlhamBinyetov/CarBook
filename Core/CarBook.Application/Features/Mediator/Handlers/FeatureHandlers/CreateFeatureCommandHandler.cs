using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature =  _unitOfWork.Repository<Feature>().Query().FirstOrDefault(x=>x.Name == request.Name);
           

            await _unitOfWork.Repository<Feature>().CreateAsync(new Feature
            {
                Name = request.Name
            });
            _unitOfWork.Commit();

        }
    }
}
