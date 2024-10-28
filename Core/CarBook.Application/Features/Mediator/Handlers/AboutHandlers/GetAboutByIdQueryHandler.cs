using CarBook.Application.Abstractions.UnitOfWork;
using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Results.AboutResults;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
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
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAboutByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<About>().GetByIdAsync(request.Id);
            return new GetAboutByIdQueryResult
            {
             Description = result.Description,
             Title = result.Title,
             ImageUrl = result.ImageUrl,
            };
        }
    }
}
