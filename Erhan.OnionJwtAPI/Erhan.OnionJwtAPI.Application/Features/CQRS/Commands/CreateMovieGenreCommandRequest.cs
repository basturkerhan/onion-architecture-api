using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Commands
{
    public class CreateMovieGenreCommandRequest : IRequest<Response>
    {
        public CreateMovieGenreCommandRequest(int genreId, int movieId)
        {
            GenreId = genreId;
            MovieId = movieId;
        }
        public int GenreId { get; set; }
        public int MovieId { get; set; }
    }
}
