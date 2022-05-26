using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.ChairDto;
using Erhan.MovieTicketSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Mappings
{
    public class ChairsProfile : Profile
    {
        public ChairsProfile()
        {
            this.CreateMap<Chair, ChairListDto>().ReverseMap();
            //this.CreateMap<Genre, GenreDetailsDto>().ReverseMap();
            //this.CreateMap<UpdateGenreCommandRequest, Genre>();
        }
    }
}
