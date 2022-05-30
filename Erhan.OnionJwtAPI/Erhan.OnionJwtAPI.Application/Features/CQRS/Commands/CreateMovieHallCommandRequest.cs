using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Commands
{
    public  class CreateMovieHallCommandRequest : IRequest<Response>
    {
        public int HallId { get; set; }
        public int MovieId { get; set; }
        public DateTime MovieDate { get; set; }
    }
}
