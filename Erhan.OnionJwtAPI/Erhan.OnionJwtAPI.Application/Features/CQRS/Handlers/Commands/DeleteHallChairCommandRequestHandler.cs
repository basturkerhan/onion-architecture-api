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
    public class DeleteHallChairCommandRequestHandler : IRequestHandler<DeleteHallChairCommandRequest, Response>
    {
        private readonly IUow _uow;

        public DeleteHallChairCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(DeleteHallChairCommandRequest request, CancellationToken cancellationToken)
        {
            Chair chair = await _uow.GetRepository<Chair>().FindAsync(request.ChairId);
            Hall hall = await _uow.GetRepository<Hall>().FindAsync(chair.HallId);
            if(chair == null)
            {
                return new Response(ResponseType.NotFound, HandlerMessages.ChairNotFoundMessage);
            }

            _uow.GetRepository<Chair>().Remove(chair);
            await _uow.SaveChangesAsync();

            return new Response(ResponseType.Success, HandlerMessages.NotFoundMessage);
        }
    }
}
