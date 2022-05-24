using Erhan.MovieTicketSystem.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries
{
    public class LoginAppUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
