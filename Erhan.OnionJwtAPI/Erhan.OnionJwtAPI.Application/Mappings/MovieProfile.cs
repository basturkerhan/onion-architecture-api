using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.MovieDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            this.CreateMap<Movie, MovieListDto>().ReverseMap();
            this.CreateMap<Movie, MovieDetailsDto>().ReverseMap();
            this.CreateMap<UpdateMovieCommandRequest, Movie>();
        }
    }
}
