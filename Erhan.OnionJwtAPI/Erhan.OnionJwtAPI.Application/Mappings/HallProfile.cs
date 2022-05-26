using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.HallDto;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Mappings
{
    public class HallProfile : Profile
    {
        public HallProfile()
        {
            this.CreateMap<HallListDto, Hall>().ReverseMap();
            this.CreateMap<HallDetailsDto, Hall>().ReverseMap();
            this.CreateMap<UpdateHallCommandRequest, Hall>();
        }
    }
}
