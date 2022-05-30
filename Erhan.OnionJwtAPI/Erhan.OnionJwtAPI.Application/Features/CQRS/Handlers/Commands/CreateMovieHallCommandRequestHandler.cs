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
    public class CreateMovieHallCommandRequestHandler : IRequestHandler<CreateMovieHallCommandRequest, Response>
    {
        private readonly IUow _uow;

        public CreateMovieHallCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateMovieHallCommandRequest request, CancellationToken cancellationToken)
        {
            Movie movie =  await _uow.GetRepository<Movie>().FindAsync(request.MovieId);
            if (movie == null)
            {
                return new Response(ResponseType.NotFound, HandlerMessages.MovieNotFoundMessage);
            }

            Hall hall = await _uow.GetRepository<Hall>().FindAsync(request.HallId);
            if(hall == null)
            {
                return new Response(ResponseType.NotFound, HandlerMessages.HallNotFoundMessage);
            }

            MovieHall exist = await _uow.GetRepository<MovieHall>().GetByFilterAsync(x => (x.HallId == request.HallId && x.MovieId == request.MovieId));
            if (exist != null)
            {
                return new Response(ResponseType.ValidationError, HandlerMessages.MovieAlreadyExistInHallMessage);
            }

            await _uow.GetRepository<MovieHall>().CreateAsync(new MovieHall
            {
                HallId = request.HallId,
                MovieId = request.MovieId,
                MovieDate = request.MovieDate
            });
            await _uow.SaveChangesAsync();

            return new Response(ResponseType.Success, "Film başarıyla eklendi.");
        }
    }
}
