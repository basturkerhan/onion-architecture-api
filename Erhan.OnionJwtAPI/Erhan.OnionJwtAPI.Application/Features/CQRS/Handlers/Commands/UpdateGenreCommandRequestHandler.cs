using AutoMapper;
using Erhan.MovieTicketSystem.Application.CustomMessages;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Responses;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class UpdateGenreCommandRequestHandler : IRequestHandler<UpdateGenreCommandRequest, Response>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdateGenreCommandRequestHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            Genre unchangedEntity = await _uow.GetRepository<Genre>().FindAsync(request.Id);
            if (unchangedEntity != null)
            {
                _uow.GetRepository<Genre>().Update(_mapper.Map<Genre>(request), unchangedEntity);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success, HandlerMessages.SucceededUpdateMessage);
            }

            return new Response(ResponseType.NotFound, HandlerMessages.NotFoundMessage);
        }
    }
}
