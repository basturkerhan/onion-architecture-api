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
    public class DeleteGenreCommandRequestHandler : IRequestHandler<DeleteGenreCommandRequest, Response>
    {
        private readonly IUow _uow;

        public DeleteGenreCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(DeleteGenreCommandRequest request, CancellationToken cancellationToken)
        {
            Genre deletedItem = await _uow.GetRepository<Genre>().FindAsync(request.Id);
            if (deletedItem != null)
            {
                _uow.GetRepository<Genre>().Remove(deletedItem);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success, "Silme işlemi başarılı");
            }

            return new Response(ResponseType.NotFound, "Aradığınız kayıt bulunamadı");
        }
    }
}
