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
    public class GetAllHallsQueryRequestHandler : IRequestHandler<GetAllHallsQueryRequest, List<HallListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public GetAllHallsQueryRequestHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<HallListDto>> Handle(GetAllHallsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Hall> halls = await _uow.GetRepository<Hall>().GetAllAsync();
            return _mapper.Map<List<HallListDto>>(halls);
        }
    }
}
