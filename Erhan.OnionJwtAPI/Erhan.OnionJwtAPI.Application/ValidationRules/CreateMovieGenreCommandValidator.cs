using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.ValidationRules
{
    public class CreateMovieGenreCommandValidator : AbstractValidator<CreateMovieGenreCommandRequest>
    {
        public CreateMovieGenreCommandValidator()
        {
            this.RuleFor(x => x.GenreId).NotEmpty().WithMessage("Tür kimliği zorunludur");
            this.RuleFor(x => x.MovieId).NotEmpty().WithMessage("Film kimliği zorunludur");
        }
    }
}
