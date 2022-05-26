using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.HallDto;
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
    public class GetHallDetailsQueryRequestHandler : IRequestHandler<GetHallDetailsQueryRequest, HallDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public GetHallDetailsQueryRequestHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<HallDetailsDto> Handle(GetHallDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            Hall hall = await _uow.GetRepository<Hall>().FindAsync(request.Id);
            return _mapper.Map<HallDetailsDto>(hall);
        }
    }
}
