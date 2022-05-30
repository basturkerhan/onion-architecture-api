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
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class ReservationCommandRequestHandler : IRequestHandler<ReservationCommandRequest, Response>
    {
        private readonly IUow _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReservationCommandRequestHandler(IUow uow, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response> Handle(ReservationCommandRequest request, CancellationToken cancellationToken)
        {
            MovieHall mh = await _uow.GetRepository<MovieHall>().GetByFilterAsync(x => x.Id == request.MovieHallId, true);
            if (mh == null)
            {
                return new Response(ResponseType.NotFound, HandlerMessages.MovieNotFoundMessage);
            }

            Chair chair = await _uow.GetRepository<Chair>().FindAsync(request.ChairId);
            if(chair.HallId != mh.HallId)
            {
                return new Response(ResponseType.NotFound, HandlerMessages.ChairNotFoundMessage);
            }

            try
            {
                int userId = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                await _uow.GetRepository<Reservation>().CreateAsync(new Reservation
                {
                    AppUserId = userId,
                    ChairId = request.ChairId,
                    ReservationDate = mh.MovieDate,
                });
                await _uow.SaveChangesAsync();

                return new Response(ResponseType.Success, HandlerMessages.SucceededMessage);
            }
            catch (Exception ex)
            {
                return new Response(ResponseType.ValidationError, ex.Message);
            }
         
        }
    }
}
