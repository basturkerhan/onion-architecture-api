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
    public class CreateMovieGenreCommandRequestHandler : IRequestHandler<CreateMovieGenreCommandRequest, Response>
    {
        private readonly IUow _uow;

        public CreateMovieGenreCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateMovieGenreCommandRequest request, CancellationToken cancellationToken)
        {
            Movie movie = await _uow.GetRepository<Movie>().FindAsync(request.MovieId);
            if (movie == null)
            {
                return new Response(ResponseType.NotFound, HandlerMessages.MovieNotFoundMessage);
            }

            Genre genre = await _uow.GetRepository<Genre>().FindAsync(request.GenreId);
            if (genre == null)
            {
                return new Response(ResponseType.NotFound, HandlerMessages.GenreNotFoundMessage);
            }

            if (_uow.GetRepository<MovieGenre>().GetByFilterAsync(x => (x.GenreId == request.GenreId && x.MovieId == request.MovieId)) != null)
            {
                return new Response(ResponseType.ValidationError, HandlerMessages.GenreAlreadyExistInMovieMessage);
            }

            await _uow.GetRepository<MovieGenre>().CreateAsync(new MovieGenre
            {
                GenreId = request.GenreId,
                MovieId = request.MovieId,
            });
            await _uow.SaveChangesAsync();

            return new Response(ResponseType.Success, HandlerMessages.SucceededAddMessage);
        }
    }
}
