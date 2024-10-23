using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetServiceByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _unitOfWork.Repository<Service>().GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                Title = value.Title,
                ServiceId = value.ServiceId,
                IconUrl = value.IconUrl,
                Description = value.Description
            };
        }
    }
}
