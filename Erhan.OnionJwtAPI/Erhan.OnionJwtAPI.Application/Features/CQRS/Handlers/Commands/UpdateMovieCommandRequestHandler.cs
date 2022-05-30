using AutoMapper;
using Erhan.MovieTicketSystem.Application.CustomMessages;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Responses;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class UpdateMovieCommandRequestHandler : IRequestHandler<UpdateMovieCommandRequest, Response>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdateMovieCommandRequestHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            Movie unchangedEntity = await _uow.GetRepository<Movie>().FindAsync(request.Id);
            if (unchangedEntity != null)
            {
                _uow.GetRepository<Movie>().Update(_mapper.Map<Movie>(request), unchangedEntity);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success, HandlerMessages.SucceededUpdateMessage);
            }

            return new Response(ResponseType.NotFound, HandlerMessages.NotFoundMessage);
        }
    }
}
