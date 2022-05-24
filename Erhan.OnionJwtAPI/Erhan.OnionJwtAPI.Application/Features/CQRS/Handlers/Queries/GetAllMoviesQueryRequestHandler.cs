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
        private readonly IRepository<Movie> _repository;
        private readonly IMapper _mapper;

        public GetAllMoviesQueryRequestHandler(IRepository<Movie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MovieListDto>> Handle(GetAllMoviesQueryRequest request, CancellationToken cancellationToken)
        {
            List<Movie> movies = await _repository.GetAllAsync();
            if(movies != null)
            {
                return _mapper.Map<List<MovieListDto>>(movies);
            }

            return _mapper.Map<List<MovieListDto>>(new List<MovieListDto>());
        }
    }
}
