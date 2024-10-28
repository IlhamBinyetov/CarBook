using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
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

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSocialMediaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _unitOfWork.Repository<SocialMedia>().GetAllAsync();
            return values.Select(x => new GetSocialMediaQueryResult
            {
                Icon = x.Icon,
                Name = x.Name,
                Url = x.Url,
                SocialMediaId = x.SocialMediaId
            }).ToList();
        }
    }
}
