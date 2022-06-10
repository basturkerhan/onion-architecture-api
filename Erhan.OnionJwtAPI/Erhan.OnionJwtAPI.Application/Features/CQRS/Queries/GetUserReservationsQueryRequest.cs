using Erhan.MovieTicketSystem.Application.Dto.ReservationDtos;
using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries
{
    public class GetUserReservationsQueryRequest : IRequest<List<GetAllUserReservationsDto>>
    {
        public int UserId { get; set; }

        public GetUserReservationsQueryRequest(int userId)
        {
            UserId = userId;
        }
    }
}
