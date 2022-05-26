using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.ChairDto;
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
    public class GetAllHallChairsQueryRequestHandler : IRequestHandler<GetAllHallChairsQueryRequest, List<ChairListDto>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetAllHallChairsQueryRequestHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<ChairListDto>> Handle(GetAllHallChairsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Chair> hallChairs = await _uow.GetRepository<Chair>().GetAllAsync(x => x.HallId == request.HallId);
            return _mapper.Map<List<ChairListDto>>(hallChairs);
        }
    }
}
