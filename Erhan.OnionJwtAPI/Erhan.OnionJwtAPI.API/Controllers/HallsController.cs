using Erhan.MovieTicketSystem.Application.Dto.ChairDto;
using Erhan.MovieTicketSystem.Application.Dto.HallDto;
using Erhan.MovieTicketSystem.Application.Dto.MovieHallDtos;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Extensions;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Responses;
using FluentValidation;
using MediatR;
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
    public class HallsController : BaseController
    {
        private readonly IValidator<CreateHallCommandRequest> _createHallValidator;
        private readonly IValidator<UpdateHallCommandRequest> _updateHallValidator;
        public HallsController(IValidator<CreateHallCommandRequest> createHallValidator, IValidator<UpdateHallCommandRequest> updateHallValidator)
        {
            _createHallValidator = createHallValidator;
            _updateHallValidator = updateHallValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<HallListDto> halls = await Mediator.Send(new GetAllHallsQueryRequest());
            if(halls.Count > 0)
            {
                return Ok(halls);
            }

            return NotFound(new Response(ResponseType.NotFound, "Herhangi bir salon bilgisi bulunamadı"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            HallDetailsDto hall = await Mediator.Send(new GetHallDetailsQueryRequest(id));
            if (hall == null)
            {
                return NotFound(new Response(ResponseType.NotFound, "Salon bilgisi bulunamadı"));
            }

            return Ok(hall);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHallCommandRequest request)
        {
            var result = _createHallValidator.Validate(request);
            if(result.IsValid)
            {
                Response response = await Mediator.Send(request);
                return Created("", response);
            }

            return BadRequest(new Response<CreateHallCommandRequest>(request, result.ConvertToCustomValidationError()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Response response = await Mediator.Send(new DeleteHallCommandRequest(id));
            return response.Equals(ResponseType.Success) ? Ok(response) : NotFound(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateHallCommandRequest request)
        {
            var result = _updateHallValidator.Validate(request);
            if(result.IsValid)
            {
                Response response = await Mediator.Send(request);
                return response.Equals(ResponseType.Success) ? Ok(response) : NotFound(response);
            }

            return BadRequest(new Response<UpdateHallCommandRequest>(request, result.ConvertToCustomValidationError()));
        }


        // -------------------------- CHAIR ENDPOINTS --------------------------
        [HttpGet("{hallId}/chairs")]
        public async Task<IActionResult> GetHallChairs(int hallId)
        {
            List<ChairListDto> hallChairs = await Mediator.Send(new GetAllHallChairsQueryRequest(hallId));
            if (hallChairs.Count > 0)
            {
                return Ok(hallChairs);
            }

            return NotFound(new Response(ResponseType.NotFound, "Bu salona ait herhangi bir koltuk bilgisi bulunamadı"));
        }

        [HttpPost("{hallId}/chairs/add")]
        public async Task<IActionResult> Create(int hallId)
        {
            Response response = await Mediator.Send(new CreateHallChairCommandRequest(hallId));
            return response.Equals(ResponseType.Success) ? Created("", response) : NotFound(response);
        }

        // -------------------------- MOVIE ENDPOINTS --------------------------
        [HttpGet("{hallId}/movies")]
        public async Task<IActionResult> GetHallMovies(int hallId)
        {
            List<MovieHallListDto> movies = await Mediator.Send(new GetAllMovieHallQueryRequest(hallId));
            if (movies.Count > 0)
            {
                return Ok(movies);
            }

            return NotFound(new Response(ResponseType.NotFound, "Salona ait herhangi bir film bilgisi bulunamadı"));
        }


    }
}
