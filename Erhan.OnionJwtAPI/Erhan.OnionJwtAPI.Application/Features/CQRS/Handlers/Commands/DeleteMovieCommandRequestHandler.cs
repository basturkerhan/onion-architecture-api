using AutoMapper;
using Erhan.MovieTicketSystem.Application.CustomMessages;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Responses;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class DeleteMovieCommandRequestHandler : IRequestHandler<DeleteMovieCommandRequest, Response>
    {
        private readonly IUow _uow;

        public DeleteMovieCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }
        public async Task<Response> Handle(DeleteMovieCommandRequest request, CancellationToken cancellationToken)
        {
            Movie deletedItem = await _uow.GetRepository<Movie>().FindAsync(request.Id);
            if (deletedItem != null)
            {
                _uow.GetRepository<Movie>().Remove(deletedItem);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success, HandlerMessages.SucceededDeleteMessage);
            }

            return new Response(ResponseType.NotFound, HandlerMessages.NotFoundMessage);
        }
    }
}
