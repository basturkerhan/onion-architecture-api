using Erhan.MovieTicketSystem.Application.Dto.GenreDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries
{
    public class GetAllGenresQueryRequest : IRequest<List<GenreListDto>>
    {
    }
}
