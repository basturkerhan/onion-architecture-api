using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.MovieDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Queries
{
    public class GetAllMoviesQueryRequestHandler : IRequestHandler<GetAllMoviesQueryRequest, List<MovieListDto>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetAllMoviesQueryRequestHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<MovieListDto>> Handle(GetAllMoviesQueryRequest request, CancellationToken cancellationToken)
        {
            List<Movie> movies = await _uow.GetRepository<Movie>().GetAllAsync();
            if(movies != null)
            {
                return _mapper.Map<List<MovieListDto>>(movies);
            }

            return _mapper.Map<List<MovieListDto>>(new List<MovieListDto>());
        }
    }
}
