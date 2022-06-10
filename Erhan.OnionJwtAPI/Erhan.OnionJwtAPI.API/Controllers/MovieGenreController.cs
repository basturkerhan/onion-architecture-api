using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Extensions;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Responses;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.API.Controllers
{
    [Route("api/movie/genres")]
    [ApiController]
    public class MovieGenreController : BaseController
    {
        private readonly IValidator<CreateMovieGenreCommandRequest> _createMovieGenreValidator;

        public MovieGenreController(IValidator<CreateMovieGenreCommandRequest> createMovieGenreValidator)
        {
            _createMovieGenreValidator = createMovieGenreValidator;
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(CreateMovieGenreCommandRequest request)
        {
            var result = _createMovieGenreValidator.Validate(request);
            if (result.IsValid)
            {
                Response response = await Mediator.Send(request);
                return response.Equals(ResponseType.Success) ? Ok(response) : BadRequest(response);
            }
            return BadRequest(new Response<CreateMovieGenreCommandRequest>(request, result.ConvertToCustomValidationError()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            Response response = await Mediator.Send(new DeleteMovieGenreCommandRequest(id));
            return response.Equals(ResponseType.Success) ? Ok(response) : NotFound(response);
        }

    }
}
