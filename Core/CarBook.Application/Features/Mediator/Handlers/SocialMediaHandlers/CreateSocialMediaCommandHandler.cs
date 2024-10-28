using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
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
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSocialMediaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMedia =  _unitOfWork.Repository<SocialMedia>().Query().FirstOrDefault(x=>x.Name == request.Name);
            await _unitOfWork.Repository<SocialMedia>().CreateAsync(new SocialMedia
            {
              Icon = request.Icon,
              Name = request.Name,
              Url = request.Url,
            });
        }
    }
}
