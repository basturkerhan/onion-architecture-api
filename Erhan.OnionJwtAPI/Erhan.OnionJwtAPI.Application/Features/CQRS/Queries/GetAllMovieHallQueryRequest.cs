using Erhan.MovieTicketSystem.Application.Dto.MovieHallDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries
{
    public class GetAllMovieHallQueryRequest : IRequest<List<MovieHallListDto>>
    {
        public int HallId { get; set; }

        public GetAllMovieHallQueryRequest(int hallId)
        {
            HallId = hallId;
        }
    }
}
