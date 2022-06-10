using Erhan.MovieTicketSystem.Application.Dto.MovieDtos;
using Erhan.MovieTicketSystem.Application.Dto.MovieGenreDtos;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Extensions;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Responses;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : BaseController
    {
        private readonly IValidator<CreateMovieCommandRequest> _createMovieCommandValidator;
        private readonly IValidator<UpdateMovieCommandRequest> _updateMovieCommandValidator;
        public MoviesController(IValidator<CreateMovieCommandRequest> createMovieCommandValidator, IValidator<UpdateMovieCommandRequest> updateMovieCommandValidator)
        {
            _createMovieCommandValidator = createMovieCommandValidator;
            _updateMovieCommandValidator = updateMovieCommandValidator;
        }

        [HttpGet]
        //[Authorize(Roles = "Member,Admin")]
        public async Task<IActionResult> GetAll()
        {
            List<MovieListDto> movieListDto = await Mediator.Send(new GetAllMoviesQueryRequest());
            if(movieListDto.Count > 0)
            {
                return Ok(movieListDto);
            }
            return NotFound(new Response(ResponseType.NotFound, "Film bilgisi bulunamadı"));
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Member,Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            MovieDetailsDto movieDetailsDto = await Mediator.Send(new GetMovieDetailsQueryRequest(id));
            if(movieDetailsDto != null)
            {
                return Ok(movieDetailsDto);
            }

            return NotFound(new Response(ResponseType.NotFound, "Film bilgisi bulunamadı"));
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateMovieCommandRequest request)
        {
            var result = _createMovieCommandValidator.Validate(request);
            if(result.IsValid)
            {
                Response response = await Mediator.Send(request);
                return Created("", response);
            }

            return BadRequest(new Response<CreateMovieCommandRequest>(request, result.ConvertToCustomValidationError()));
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            Response response = await Mediator.Send(new DeleteMovieCommandRequest(id));
            return response.Equals(ResponseType.Success) ? Ok(response) : NotFound(response);
        }

        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateMovieCommandRequest request)
        {
            var result = _updateMovieCommandValidator.Validate(request);
            if (result.IsValid)
            {
                Response response = await Mediator.Send(request);
                return response.Equals(ResponseType.Success) ? Ok(response) : NotFound(response);
            }

            return BadRequest(new Response<UpdateMovieCommandRequest>(request, result.ConvertToCustomValidationError()));
        }

        // -------------------------- GENRE ENDPOINTS --------------------------
        [HttpGet("{movieId}/genre")]
        public async Task<IActionResult> GetHallMovies(int movieId)
        {
            List<MovieGenreListDto> genres = await Mediator.Send(new GetAllMovieGenreQueryRequest(movieId));
            if (genres.Count > 0)
            {
                return Ok(genres);
            }

            return NotFound(new Response(ResponseType.NotFound, "Filme ait herhangi bir tür bilgisi bulunamadı"));
        }

    }
}
