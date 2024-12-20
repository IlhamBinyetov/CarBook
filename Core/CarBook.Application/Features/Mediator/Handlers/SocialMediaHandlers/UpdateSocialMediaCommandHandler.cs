﻿using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
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
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSocialMediaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var updatedItem = await _unitOfWork.Repository<SocialMedia>().GetByIdAsync(request.SocialMediaId);
           updatedItem.SocialMediaId = request.SocialMediaId;
           updatedItem.Url = request.Url;
            updatedItem.Name = request.Name;
            updatedItem.Icon = request.Icon;
            await _unitOfWork.Repository<SocialMedia>().UpdateAsync(updatedItem);
            _unitOfWork.Commit();
        }
    }
}
