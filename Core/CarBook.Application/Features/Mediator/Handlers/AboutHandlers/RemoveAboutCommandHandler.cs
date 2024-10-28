using CarBook.Application.Abstractions.UnitOfWork;
using CarBook.Application.Features.Mediator.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveAboutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
            var deletedItem = await _unitOfWork.Repository<About>().GetByIdAsync(request.Id);
            await _unitOfWork.Repository<About>().RemoveAsync(deletedItem);
            _unitOfWork.Commit();
        }
    }
} 
