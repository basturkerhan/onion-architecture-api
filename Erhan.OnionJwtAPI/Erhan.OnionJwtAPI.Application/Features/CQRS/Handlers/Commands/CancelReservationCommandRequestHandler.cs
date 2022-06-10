using Erhan.MovieTicketSystem.Application.CustomMessages;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Responses;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class CancelReservationCommandRequestHandler : IRequestHandler<CancelReservationCommandRequest, Response>
    {
        private readonly IUow _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CancelReservationCommandRequestHandler(IUow uow, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response> Handle(CancelReservationCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Reservation reservation = await _uow.GetRepository<Reservation>().FindAsync(request.Id);
                _uow.GetRepository<Reservation>().Remove(reservation);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success, HandlerMessages.SucceededDeleteMessage);
            }
            catch (NullReferenceException)
            {
                return new Response(ResponseType.NotFound, HandlerMessages.ReservationNotFoundMessage);
            }
            catch(Exception ex)
            {
                return new Response(ResponseType.ValidationError, ex.Message);
            }
        }

    }
}
