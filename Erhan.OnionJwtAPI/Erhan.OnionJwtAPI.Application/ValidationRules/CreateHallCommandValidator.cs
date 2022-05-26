using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.ValidationRules
{
    public class CreateHallCommandValidator : AbstractValidator<CreateHallCommandRequest>
    {
        public CreateHallCommandValidator()
        {
            this.RuleFor(x => x.Hallname).NotEmpty().WithMessage("Salon adı boş bırakılamaz");
        }
    }
}
