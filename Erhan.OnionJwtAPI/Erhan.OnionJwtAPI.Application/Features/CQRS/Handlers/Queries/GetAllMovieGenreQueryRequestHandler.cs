using Erhan.MovieTicketSystem.Application.Dto.MovieGenreDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Queries
{
    public class GetAllMovieGenreQueryRequestHandler : IRequestHandler<GetAllMovieGenreQueryRequest, List<MovieGenreListDto>>
    {
        private readonly IUow _uow;

        public GetAllMovieGenreQueryRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<List<MovieGenreListDto>> Handle(GetAllMovieGenreQueryRequest request, CancellationToken cancellationToken)
        {
            List<MovieGenre> movieGenre = await _uow.GetRepository<MovieGenre>().GetAllAsync(x => x.MovieId == request.MovieId);
            List<MovieGenreListDto> listDto = new List<MovieGenreListDto>();
            if (movieGenre != null)
            {
                foreach (MovieGenre entity in movieGenre)
                {
                    Genre genre = await _uow.GetRepository<Genre>().FindAsync(entity.GenreId);
                    listDto.Add(new MovieGenreListDto
                    {
                        Definition = genre.Definition,
                        Id = entity.Id,
                    });
                }
            }

            return listDto;
        }
    }
}
