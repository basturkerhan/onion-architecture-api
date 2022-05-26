using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Commands
{
    public class CreateHallCommandRequest : IRequest<Response>
    {
        public string Hallname { get; set; }
    }
}
