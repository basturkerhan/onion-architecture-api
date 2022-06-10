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
    public class ChairsController : BaseController
    {

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChair(int id)
        {
            Response response = await Mediator.Send(new DeleteHallChairCommandRequest(id));
            return response.Equals(ResponseType.Success) ? Created("", response) : NotFound(response);
        }
    }
}
