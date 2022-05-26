using Erhan.MovieTicketSystem.Application.Dto.ChairDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries
{
    public class GetAllHallChairsQueryRequest : IRequest<List<ChairListDto>>
    {
        public int HallId { get; set; }

        public GetAllHallChairsQueryRequest(int hallId)
        {
            HallId = hallId;
        }
    }
}
