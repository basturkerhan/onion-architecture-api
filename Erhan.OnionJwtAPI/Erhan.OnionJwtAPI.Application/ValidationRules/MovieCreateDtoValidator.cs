using Erhan.MovieTicketSystem.Application.Dto.MovieDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.ValidationRules
{
    public class MovieCreateDtoValidator : AbstractValidator<MovieCreateDto>
    {
        public MovieCreateDtoValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Film ismi alanı boş geçilemez");
            this.RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş geçilemez");
            this.RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
            this.RuleFor(x => x.Actors).NotEmpty().WithMessage("Aktörler alanı boş geçilemez");
        }
    }
}
