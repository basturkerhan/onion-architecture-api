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
        private readonly IUow _uow;

        public CreateAppUserCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<AppUser>().CreateAsync(new AppUser
            {
                Email = request.Email,
                Fullname = request.Fullname,
                AppRoleId = (int)RoleType.Member,
                Username = request.Username,
                Password = request.Password,
                GenderId = (int)GenderType.Unknown
            });
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
