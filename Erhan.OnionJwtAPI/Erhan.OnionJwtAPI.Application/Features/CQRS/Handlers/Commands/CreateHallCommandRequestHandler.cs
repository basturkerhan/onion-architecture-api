using AutoMapper;
using Erhan.MovieTicketSystem.Application.CustomMessages;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Responses;
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
    public class CreateHallCommandRequestHandler : IRequestHandler<CreateHallCommandRequest, Response>
    {
        private readonly IUow _uow;

        public CreateHallCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateHallCommandRequest request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Hall>().CreateAsync(new Hall
            {
                Hallname = request.Hallname,
                Chairs = new List<Chair>(),
                MovieHalls = new List<MovieHall>()
            });
            await _uow.SaveChangesAsync();

            return new Response(ResponseType.Success, HandlerMessages.SucceededAddMessage);
        }
    }
}
