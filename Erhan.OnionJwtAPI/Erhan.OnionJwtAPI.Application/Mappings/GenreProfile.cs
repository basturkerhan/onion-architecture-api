using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.GenreDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Mappings
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            this.CreateMap<Genre, GenreListDto>().ReverseMap();
            this.CreateMap<Genre, GenreDetailsDto>().ReverseMap();
            this.CreateMap<UpdateGenreCommandRequest, Genre>();
        }
    }
}
