using AutoMapper;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Responses;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class CreateGenreCommandRequestHandler : IRequestHandler<CreateGenreCommandRequest, Response>
    {

        private readonly IUow _uow;

        public CreateGenreCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Genre>().CreateAsync(new Genre
            {
                Definition = request.Definition,
            });
            await _uow.SaveChangesAsync();

            return new Response(ResponseType.Success, "Tür ekleme işlemi başarılı");
        }
    }
}
