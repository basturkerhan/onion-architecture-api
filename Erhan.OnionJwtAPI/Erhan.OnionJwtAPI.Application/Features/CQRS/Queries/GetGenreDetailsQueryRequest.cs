using Erhan.MovieTicketSystem.Application.Dto.GenreDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries
{
    public class GetGenreDetailsQueryRequest : IRequest<GenreDetailsDto>
    {
        public int Id { get; set; }

        public GetGenreDetailsQueryRequest(int id)
        {
            Id = id;
        }
    }
}
