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
    public class CreateMovieCommandRequestHandler : IRequestHandler<CreateMovieCommandRequest, Response>
    {
        private readonly IUow _uow;

        public CreateMovieCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Movie>().CreateAsync(new Movie
            {
                Actors = request.Actors,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                ReleaseDate = DateTime.UtcNow,
                MovieGenres = new List<MovieGenre>(),
                MovieHalls = new List<MovieHall>()
            });
            await _uow.SaveChangesAsync();

            return new Response(ResponseType.Success, HandlerMessages.SucceededCreateMessage);
        }
    }
}
