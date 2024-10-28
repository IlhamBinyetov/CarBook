using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Application.Abstractions.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetServiceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _unitOfWork.Repository<Service>().GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                IconUrl = x.IconUrl,
                Description = x.Description,
                ServiceId = x.ServiceId,
                Title = x.Title
            }).ToList();
        }
    }
}
