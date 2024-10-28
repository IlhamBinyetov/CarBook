using CarBook.Application.Abstractions.UnitOfWork;
using CarBook.Application.Features.Mediator.Commands.FooterAddresCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveFooterAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var deletedItem =  await _unitOfWork.Repository<FooterAddress>().GetByIdAsync(request.Id);
            if (deletedItem != null) await _unitOfWork.Repository<FooterAddress>().RemoveAsync(deletedItem);
            _unitOfWork.Commit();
        }
    }
}
