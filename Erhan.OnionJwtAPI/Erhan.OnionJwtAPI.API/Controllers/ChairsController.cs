using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChairsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChairsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/hall/{hallId}")]
        public async Task<IActionResult> Create(int hallId)
        {
            Response response = await _mediator.Send(new CreateHallChairCommandRequest(hallId));
            return response.Equals(ResponseType.Success) ? Created("", response) : NotFound(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChair(int id)
        {
            Response response = await _mediator.Send(new DeleteHallChairCommandRequest(id));
            return response.Equals(ResponseType.Success) ? Created("", response) : NotFound(response);
        }

        //[HttpGet("{id}/reservation")]
        //[Authorize(Roles = "Admin,Member")]
        //public async Task<IActionResult> Reservation(int id)
        //{
        //    Response response = await _mediator.Send(new ReserveChairCommandRequest(id));
        //    return response.Equals(ResponseType.Success) ? Ok(response) : BadRequest(response);
        //}

        //[HttpGet("{id}/cancelreservation")]
        //[Authorize(Roles = "Admin,Member")]
        //public async Task<IActionResult> CancelReservation(int id)
        //{
        //    Response response = await _mediator.Send(new CancelReservationChairCommandRequest(id));
        //    return response.Equals(ResponseType.Success) ? Ok(response) : BadRequest(response);
        //}

    }
}
