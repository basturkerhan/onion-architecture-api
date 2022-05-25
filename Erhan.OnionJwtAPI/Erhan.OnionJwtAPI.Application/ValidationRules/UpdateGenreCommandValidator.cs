using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.ValidationRules
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommandRequest>
    {
        public UpdateGenreCommandValidator()
        {
            this.RuleFor(x => x.Definition).MinimumLength(3).NotEmpty();
        }
    }
}
