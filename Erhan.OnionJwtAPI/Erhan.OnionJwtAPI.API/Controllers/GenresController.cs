﻿using Erhan.MovieTicketSystem.Application.Dto.GenreDtos;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Extensions;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Responses;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IValidator<UpdateGenreCommandRequest> _updateValidator;
        private readonly IValidator<CreateGenreCommandRequest> _createValidator;
        private readonly IMediator _mediator;

        public GenresController(IValidator<CreateGenreCommandRequest> createValidator, IMediator mediator, IValidator<UpdateGenreCommandRequest> updateValidator)
        {
            _createValidator = createValidator;
            _mediator = mediator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        [Authorize(Roles = "Member,Admin")]
        public async Task<IActionResult> GetAll()
        {
            List<GenreListDto> dto = await _mediator.Send(new GetAllGenresQueryRequest());
            if (dto == null)
            {
                return BadRequest(new Response(ResponseType.NotFound, "Kayıt bulunamadı"));
            }
            return Ok(dto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Member,Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            GenreListDto dto = await _mediator.Send(new GetGenreDetailsQueryRequest(id));
            if (dto != null)
            {
                return Ok(dto);
            }
            return BadRequest(new Response(ResponseType.NotFound, "Kayıt bulunamadı"));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateGenreCommandRequest request)
        {
            var result = _createValidator.Validate(request);
            if (result.IsValid)
            {
                await _mediator.Send(request);
                return Created("", request);
            }

            return BadRequest(new Response<CreateGenreCommandRequest>(request, result.ConvertToCustomValidationError()));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteGenreCommandRequest(id));
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(UpdateGenreCommandRequest request)
        {
            var result = _updateValidator.Validate(request);
            if (result.IsValid)
            {
                await _mediator.Send(request);
                return Ok();
            }

            return BadRequest(new Response<UpdateGenreCommandRequest>(request, result.ConvertToCustomValidationError()));
        }

    }
}