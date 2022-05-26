using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Responses;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class CancelReservationChairCommandRequestHandler : IRequestHandler<CancelReservationChairCommandRequest, Response>
    {
        private readonly IUow _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CancelReservationChairCommandRequestHandler(IUow uow, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response> Handle(CancelReservationChairCommandRequest request, CancellationToken cancellationToken)
        {
            int currentUserId = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Chair chair = await _uow.GetRepository<Chair>().FindAsync(request.Id);
            if (chair.IsSuitable == true)
            {
                return new Response(ResponseType.ValidationError, "Bu koltuk zaten boş");
            }

            if(currentUserId != chair.AppUserId)
            {
                return new Response(ResponseType.ValidationError, "Bu koltuğun rezervasyonu size ait olmadığı için iptal edemezsiniz");
            }

            _uow.GetRepository<Chair>().Update(new Chair
            {
                Id = chair.Id,
                HallId = chair.HallId,
                IsSuitable = true,
                AppUserId = null
            }, chair);

            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success, "Koltuk rezervasyonu başarıyla iptal edildi");
        }
    }
}
