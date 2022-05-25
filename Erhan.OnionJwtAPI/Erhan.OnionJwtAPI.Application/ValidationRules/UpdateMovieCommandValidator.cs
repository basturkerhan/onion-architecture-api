using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.ValidationRules
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommandRequest>
    {
        public UpdateMovieCommandValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Film ismi alanı boş geçilemez");
            this.RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş geçilemez");
            this.RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
            this.RuleFor(x => x.Actors).NotEmpty().WithMessage("Aktörler alanı boş geçilemez");
        }
    }
}
