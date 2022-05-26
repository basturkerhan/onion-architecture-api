using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.GenreDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Queries
{
    public class GetGenreDetailsQueryRequestHandler : IRequestHandler<GetGenreDetailsQueryRequest, GenreDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public GetGenreDetailsQueryRequestHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<GenreDetailsDto> Handle(GetGenreDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            Genre genre = await _uow.GetRepository<Genre>().FindAsync(request.Id);
            return _mapper.Map<GenreDetailsDto>(genre);
        }
    }
}
