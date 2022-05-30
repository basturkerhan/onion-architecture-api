using Erhan.MovieTicketSystem.Application.Dto.MovieGenreDtos;
using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries
{
    public class GetAllMovieGenreQueryRequest : IRequest<List<MovieGenreListDto>>
    {
        public int MovieId { get; set; }

        public GetAllMovieGenreQueryRequest(int movieId)
        {
            MovieId = movieId;
        }
    }
}
