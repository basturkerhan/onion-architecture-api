using AutoMapper;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class CreateAppUserCommandRequestHandler : IRequestHandler<CreateAppUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;
        public CreateAppUserCommandRequestHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                Email = request.Email,
                Fullname = request.Fullname,
                AppRoleId = (int)RoleType.Member,
                Username = request.Username,
                Password = request.Password,
                GenderId = (int)GenderType.Unknown
            });

            return Unit.Value;
        }
    }
}
