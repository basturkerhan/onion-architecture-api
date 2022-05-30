using Erhan.MovieTicketSystem.Application.Dto.MovieHallDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Queries
{
    public class GetAllMovieHallQueryRequestHandler : IRequestHandler<GetAllMovieHallQueryRequest,List<MovieHallListDto>>
    {
        private readonly IUow _uow;

        public GetAllMovieHallQueryRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<List<MovieHallListDto>> Handle(GetAllMovieHallQueryRequest request, CancellationToken cancellationToken)
        {
            List<MovieHall> movieHall = await _uow.GetRepository<MovieHall>().GetAllAsync(x => x.HallId == request.HallId);
            List<MovieHallListDto> listDto = new List<MovieHallListDto>();
            if (movieHall != null)
            {
                foreach (MovieHall entity in movieHall)
                {
                    Movie movie = await _uow.GetRepository<Movie>().FindAsync(entity.MovieId);
                    listDto.Add(new MovieHallListDto {
                        Actors = movie.Actors,
                        Description = movie.Description,
                        Id = entity.Id,
                        ImageUrl = movie.ImageUrl,
                        MovieDate = entity.MovieDate,
                        Name = movie.Name,
                        ReleaseDate = movie.ReleaseDate,
                        MovieId = entity.MovieId
                    });
                }

            }

            return listDto;
        }
    }
}
