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
    public class DeleteHallMovieCommandRequestHandler : IRequestHandler<DeleteHallMovieCommandRequest, Response>
    {
        private readonly IUow _uow;
        public DeleteHallMovieCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(DeleteHallMovieCommandRequest request, CancellationToken cancellationToken)
        {
            MovieHall deletedItem = await _uow.GetRepository<MovieHall>().FindAsync(request.MovieHallId);
            if (deletedItem != null)
            {
                _uow.GetRepository<MovieHall>().Remove(deletedItem);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success, HandlerMessages.SucceededDeleteMessage);
            }

            return new Response(ResponseType.NotFound, HandlerMessages.NotFoundMessage);
        }
    }
}
