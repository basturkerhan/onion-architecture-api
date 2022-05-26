using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Commands
{
    public class CreateHallChairCommandRequest : IRequest<Response>
    {
        public int HallId { get; set; }

        public CreateHallChairCommandRequest(int hallId)
        {
            HallId = hallId;
        }
    }
}
