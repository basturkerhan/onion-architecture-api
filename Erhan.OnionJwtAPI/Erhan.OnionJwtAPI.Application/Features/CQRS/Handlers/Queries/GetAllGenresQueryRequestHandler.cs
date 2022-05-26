using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.GenreDtos;
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
    public class GetAllGenresQueryRequestHandler : IRequestHandler<GetAllGenresQueryRequest,List<GenreListDto>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetAllGenresQueryRequestHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GenreListDto>> Handle(GetAllGenresQueryRequest request, CancellationToken cancellationToken)
        {
            List<Genre> genres = await _uow.GetRepository<Genre>().GetAllAsync();
            if (genres != null)
            {
                return _mapper.Map<List<GenreListDto>>(genres);
            }

            return _mapper.Map<List<GenreListDto>>(new List<GenreListDto>());
        }
    }
}
