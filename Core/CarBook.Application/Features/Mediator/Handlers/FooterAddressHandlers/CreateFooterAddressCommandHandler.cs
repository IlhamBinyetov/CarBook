using CarBook.Application.Features.Mediator.Commands.FooterAddresCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFooterAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = _unitOfWork.Repository<FooterAddress>().Query().FirstOrDefault(x => x.Email == request.Email);

            await _unitOfWork.Repository<FooterAddress>().CreateAsync(new FooterAddress
            {
                Address = request.Address,
                Description = request.Description,
                Email = request.Email,
                Phone = request.Phone
            });
            _unitOfWork.Commit();
        }
    }
}
