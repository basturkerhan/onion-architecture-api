﻿using Erhan.MovieTicketSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Commands
{
    public class UpdateHallCommandRequest : IRequest<Response>
    {
        public int Id { get; set; }
        public string Hallname { get; set; }
    }
}
