using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Commands
{
    public class CreateMovieCommandRequest : IRequest<Response>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Actors { get; set; }
        public string ImageUrl { get; set; }
    }
}
