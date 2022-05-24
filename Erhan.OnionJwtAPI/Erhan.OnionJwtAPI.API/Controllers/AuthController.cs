using Erhan.MovieTicketSystem.Application.Dto;
using Erhan.MovieTicketSystem.Application.Dto.AppUserDtos;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Extensions;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Queries;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Responses;
using Erhan.MovieTicketSystem.Application.ValidationRules;
using Erhan.MovieTicketSystem.Infrastructure.Tools;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AppUserCreateDto> _userCreateDtoValidator;
        private readonly IValidator<LoginAppUserQueryRequest> _loginQueryValidator;

        public AuthController(IMediator mediator, IValidator<AppUserCreateDto> userCreateDtoValidator, IValidator<LoginAppUserQueryRequest> loginQueryValidator)
        {
            _mediator = mediator;
            _userCreateDtoValidator = userCreateDtoValidator;
            _loginQueryValidator = loginQueryValidator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(AppUserCreateDto dto)
        {
            var result = _userCreateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                CreateAppUserCommandRequest request = new CreateAppUserCommandRequest
                {
                    Email = dto.Email,
                    Fullname = dto.Fullname,
                    Password = dto.Password,
                    Username = dto.Username
                };

                await _mediator.Send(request);
                return Created("", new Response(ResponseType.Success, "Kullanıcı başarıyla kayıt oldu."));
            }

            return BadRequest(new Response<AppUserCreateDto>(result.ConvertToCustomValidationError()));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginAppUserQueryRequest request)
        {
            var result = _loginQueryValidator.Validate(request);
            if(result.IsValid)
            {
                CheckUserResponseDto userDto = await _mediator.Send(request);
                if (userDto.IsExist == false)
                {
                    return BadRequest(new Response(ResponseType.NotFound, "Username veya password hatalı"));
                }

                JwtTokenResponse token = JwtTokenGenerator.GenerateToken(userDto);
                return Created("", token);
            }

            return BadRequest(new Response<AppUserCreateDto>(result.ConvertToCustomValidationError()));
        }

    }
}
