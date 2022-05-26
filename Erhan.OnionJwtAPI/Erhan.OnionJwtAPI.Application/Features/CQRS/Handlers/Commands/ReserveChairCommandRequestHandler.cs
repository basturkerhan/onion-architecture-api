using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Responses;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class ReserveChairCommandRequestHandler : IRequestHandler<ReserveChairCommandRequest, Response>
    {
        private readonly IUow _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReserveChairCommandRequestHandler(IUow uow, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response> Handle(ReserveChairCommandRequest request, CancellationToken cancellationToken)
        {
            Chair chair = await _uow.GetRepository<Chair>().FindAsync(request.Id);
            if (chair.IsSuitable == false)
            {
                return new Response(ResponseType.ValidationError, "Bu koltuğun zaten bir sahibi var");
            }

            _uow.GetRepository<Chair>().Update(new Chair
            {
                Id = chair.Id,
                HallId = chair.HallId,
                IsSuitable = false,
                AppUserId = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value),
            }, chair);

            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success, "Koltuk başarıyla rezerve edildi");
        }
    }
}
