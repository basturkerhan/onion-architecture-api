using Erhan.MovieTicketSystem.Application.Dto.AppUserDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Queries;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.ValidationRules
{
    public class LoginAppUserQueryValidator : AbstractValidator<LoginAppUserQueryRequest>
    {
        public LoginAppUserQueryValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
        }
    }
}
