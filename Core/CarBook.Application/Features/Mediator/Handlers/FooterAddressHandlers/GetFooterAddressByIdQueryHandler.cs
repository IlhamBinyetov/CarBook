using CarBook.Application.Abstractions.UnitOfWork;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
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
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFooterAddressByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Repository<FooterAddress>().GetByIdAsync(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
                Address = value.Address,
                Description = value.Description,
                Email = value.Email,
                FooterAddressId = value.FooterAddressId,
                Phone = value.Phone
            };
        }
    }
}
