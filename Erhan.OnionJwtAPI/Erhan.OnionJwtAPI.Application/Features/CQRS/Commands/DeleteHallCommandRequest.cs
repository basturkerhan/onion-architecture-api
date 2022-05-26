using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Commands
{
    public class DeleteHallCommandRequest : IRequest<Response>
    {
        public int Id { get; set; }
        public DeleteHallCommandRequest(int id)
        {
            Id = id;
        }
    }
}
