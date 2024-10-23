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
    internal class UpdaterFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdaterFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var updatedItem = await _unitOfWork.Repository<Feature>().GetByIdAsync(request.FeatureId);
            updatedItem.Name = request.Name;

            await _unitOfWork.Repository<Feature>().UpdateAsync(updatedItem);
        }
    }
}
