using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.ValidationRules
{
    public class UpdateHallCommandValidator : AbstractValidator<UpdateHallCommandRequest>
    {
        public UpdateHallCommandValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Kimlik numarası boş bırakılamaz");
            this.RuleFor(x => x.Hallname).NotEmpty().WithMessage("Salon adı boş bırakılamaz");
        }
    }
}
