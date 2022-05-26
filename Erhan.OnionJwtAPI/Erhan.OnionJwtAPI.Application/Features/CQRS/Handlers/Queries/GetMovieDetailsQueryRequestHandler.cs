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
        private readonly IUow _uow;

        public GetMovieDetailsQueryRequestHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<MovieDetailsDto> Handle(GetMovieDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            Movie movie = await _uow.GetRepository<Movie>().FindAsync(request.Id);
            return _mapper.Map<MovieDetailsDto>(movie);
        }
    }
}
