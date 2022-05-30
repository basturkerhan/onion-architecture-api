using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.ValidationRules
{
    public class CreateMovieHallCommandValidator : AbstractValidator<CreateMovieHallCommandRequest>
    {
        public CreateMovieHallCommandValidator()
        {
            this.RuleFor(x => x.MovieId).NotEmpty().WithMessage("Eklenecek film bilgisi verilmelidir");
            this.RuleFor(x => x.HallId).NotEmpty().WithMessage("Eklenecek salon bilgisi verilmelidir");
            this.RuleFor(x => x.MovieId).NotEmpty().WithMessage("Eklenecek filmin tarih bilgisi verilmelidir");
        }
    }
}
