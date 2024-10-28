using CarBook.Application.Features.Mediator.Commands.FooterAddresCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Application.Abstractions.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFooterAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Repository<FooterAddress>().GetByIdAsync(request.FooterAddressId);
            value.Description = request.Description;
            value.Address = request.Address;
            value.Phone = request.Phone;
            value.Email = request.Email;
            await _unitOfWork.Repository<FooterAddress>().UpdateAsync(value);
            _unitOfWork.Commit();
        }
    }
}
