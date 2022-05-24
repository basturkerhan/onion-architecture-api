using Erhan.MovieTicketSystem.Application.Dto.AppUserDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
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
        public AuthController(IMediator mediator, IValidator<AppUserCreateDto> userCreateDtoValidator)
        {
            _mediator = mediator;
            _userCreateDtoValidator = userCreateDtoValidator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(AppUserCreateDto dto)
        {
            if (_userCreateDtoValidator.Validate(dto).IsValid)
            {
                CreateAppUserCommandRequest request = new CreateAppUserCommandRequest
                {
                    Email = dto.Email,
                    Fullname = dto.Fullname,
                    Password = dto.Password,
                    Username = dto.Username
                };

                await _mediator.Send(request);
                return Created("", request);
            }

            return BadRequest("girilen veriler yanlış");
        }

    }
}
