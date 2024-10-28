using CarBook.Application.Features.Mediator.Results.AboutResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutByIdQuery : IRequest<GetAboutByIdQueryResult>
    {
        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
