using Erhan.MovieTicketSystem.Application.Dto.ReservationDtos;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.API.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : BaseController
    {
        [HttpGet("user-reservations/{id}")]
        public async Task<IActionResult> GetUserReservations(int id)
        {
            List<GetAllUserReservationsDto> reservations = await Mediator.Send(new GetUserReservationsQueryRequest(id));
            return Ok(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> Reservation(ReservationCommandRequest request)
        {
            Response response = await Mediator.Send(request);
            return response.Equals(ResponseType.Success) ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Reservation(int id)
        {
            Response response = await Mediator.Send(new CancelReservationCommandRequest(id));
            return response.Equals(ResponseType.Success) ? Ok(response) : BadRequest(response);
        }


    }
}
