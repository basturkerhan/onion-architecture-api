using Erhan.MovieTicketSystem.Application.Dto.MovieDtos;
using Erhan.MovieTicketSystem.Application.Enums;
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
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<MovieCreateDto> _movieCreateDtoValidator;
        public MovieController(IMediator mediator, IValidator<MovieCreateDto> movieCreateDtoValidator)
        {
            _mediator = mediator;
            _movieCreateDtoValidator = movieCreateDtoValidator;
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
        public async Task<IActionResult> GetById(MovieCreateDto dto)
        {
            var result = _movieCreateDtoValidator.Validate(dto);
            if(result.IsValid)
            {
                await _mediator.Send(new CreateMovieCommandRequest
                {
                    Actors = dto.Actors,
                    Description = dto.Description,
                    ImageUrl = dto.ImageUrl,
                    Name = dto.Name,
                });

                return Created("", dto);
            }

            return NotFound(new Response(ResponseType.NotFound, "Girdiğiniz verileri kontrol ediniz."));
        }
    }
}
