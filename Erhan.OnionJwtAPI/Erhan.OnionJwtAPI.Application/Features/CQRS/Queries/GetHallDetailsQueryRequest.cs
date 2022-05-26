using Erhan.MovieTicketSystem.Application.Dto.HallDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries
{
    public class GetHallDetailsQueryRequest : IRequest<HallDetailsDto>
    {
        public int Id { get; set; }
        public GetHallDetailsQueryRequest(int id)
        {
            Id = id;
        }
    }
}
