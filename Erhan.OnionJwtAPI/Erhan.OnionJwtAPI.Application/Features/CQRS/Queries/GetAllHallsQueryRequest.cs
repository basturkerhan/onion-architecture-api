using Erhan.MovieTicketSystem.Application.Dto.HallDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries
{
    public class GetAllHallsQueryRequest : IRequest<List<HallListDto>>
    {
    }
}
