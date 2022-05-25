using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Commands
{
    public class DeleteGenreCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteGenreCommandRequest(int id)
        {
            Id = id;
        }
    }
}
