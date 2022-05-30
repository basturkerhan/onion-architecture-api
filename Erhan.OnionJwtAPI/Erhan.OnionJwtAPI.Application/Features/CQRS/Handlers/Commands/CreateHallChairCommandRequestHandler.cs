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
    public class CreateHallChairCommandRequestHandler : IRequestHandler<CreateHallChairCommandRequest, Response>
    {
        private readonly IUow _uow;

        public CreateHallChairCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateHallChairCommandRequest request, CancellationToken cancellationToken)
        {
            Hall hall = await _uow.GetRepository<Hall>().FindAsync(request.HallId);
            if(hall == null)
            {
                return new Response(ResponseType.NotFound, "Böyle bir salon mevcut değil");
            }

            Chair chair = new Chair
            {
                HallId = request.HallId
            };

            await _uow.GetRepository<Chair>().CreateAsync(chair);
            await _uow.SaveChangesAsync();

            return new Response(ResponseType.Success, HandlerMessages.SucceededAddMessage);
        }
    }
}
