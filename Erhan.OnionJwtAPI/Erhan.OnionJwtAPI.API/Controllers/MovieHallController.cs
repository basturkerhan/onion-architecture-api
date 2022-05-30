using Erhan.MovieTicketSystem.Application.Dto.MovieHallDtos;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Extensions;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Responses;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.API.Controllers
{
    [Route("api/hall/movies")]
    [ApiController]
    public class MovieHallController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateMovieHallCommandRequest> _createMovieHallValidator;

        public MovieHallController(IMediator mediator, IValidator<CreateMovieHallCommandRequest> createMovieHallValidator)
        {
            _mediator = mediator;
            _createMovieHallValidator = createMovieHallValidator;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(CreateMovieHallCommandRequest request)
        {
            var result = _createMovieHallValidator.Validate(request);
            if (result.IsValid)
            {
                Response response = await _mediator.Send(request);
                return response.Equals(ResponseType.Success) ? Ok(response) : BadRequest(response);
            }
            return BadRequest(new Response<CreateMovieHallCommandRequest>(request, result.ConvertToCustomValidationError()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Response response = await _mediator.Send(new DeleteHallMovieCommandRequest(id));
            return response.Equals(ResponseType.Success) ? Ok(response) : NotFound(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMovieHallCommandRequest request)
        {
            Response response = await _mediator.Send(request);
            return response.Equals(ResponseType.Success) ? Ok(response) : NotFound(response);
        }

    }
}
