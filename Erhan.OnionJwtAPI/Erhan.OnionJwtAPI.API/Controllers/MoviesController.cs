using Erhan.MovieTicketSystem.Application.Dto.MovieDtos;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Extensions;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Responses;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateMovieCommandRequest> _createMovieCommandValidator;
        private readonly IValidator<UpdateMovieCommandRequest> _updateMovieCommandValidator;
        public MoviesController(IMediator mediator, IValidator<CreateMovieCommandRequest> createMovieCommandValidator, IValidator<UpdateMovieCommandRequest> updateMovieCommandValidator)
        {
            _mediator = mediator;
            _createMovieCommandValidator = createMovieCommandValidator;
            _updateMovieCommandValidator = updateMovieCommandValidator;
        }

        [HttpGet]
        [Authorize(Roles = "Member,Admin")]
        public async Task<IActionResult> GetAll()
        {
            List<MovieListDto> movieListDto = await _mediator.Send(new GetAllMoviesQueryRequest());
            if(movieListDto.Count > 0)
            {
                return Ok(movieListDto);
            }
            return NotFound(new Response(ResponseType.NotFound, "Film bilgisi bulunamadı"));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Member,Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            MovieDetailsDto movieDetailsDto = await _mediator.Send(new GetMovieDetailsQueryRequest(id));
            if(movieDetailsDto != null)
            {
                return Ok(movieDetailsDto);
            }

            return NotFound(new Response(ResponseType.NotFound, "Film bilgisi bulunamadı"));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(CreateMovieCommandRequest request)
        {
            var result = _createMovieCommandValidator.Validate(request);
            if(result.IsValid)
            {
                await _mediator.Send(request);

                return Created("", request);
            }

            return BadRequest(new Response<CreateMovieCommandRequest>(request, result.ConvertToCustomValidationError()));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteMovieCommandRequest(id));
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateMovieCommandRequest request)
        {
            var result = _updateMovieCommandValidator.Validate(request);
            if (result.IsValid)
            {
                await _mediator.Send(request);
                return Ok(new Response(ResponseType.Success,"Güncelleme işlemi başarılı"));
            }

            return BadRequest(new Response<UpdateMovieCommandRequest>(request, result.ConvertToCustomValidationError()));
        }

    }
}
