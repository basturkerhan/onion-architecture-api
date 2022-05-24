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
    public class GetMovieDetailsQueryRequestHandler : IRequestHandler<GetMovieDetailsQueryRequest, MovieDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Movie> _repository;

        public GetMovieDetailsQueryRequestHandler(IMapper mapper, IRepository<Movie> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<MovieDetailsDto> Handle(GetMovieDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            Movie movie = await _repository.FindAsync(request.Id);
            return _mapper.Map<MovieDetailsDto>(movie);
        }
    }
}
