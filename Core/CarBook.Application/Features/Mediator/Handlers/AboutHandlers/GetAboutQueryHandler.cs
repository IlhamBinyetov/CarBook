using CarBook.Application.Abstractions.UnitOfWork;
using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Results.AboutResults;
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
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAboutQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _unitOfWork.Repository<About>().GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutId = x.AboutId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Title = x.Title
            }).ToList();
        }
    }
}
