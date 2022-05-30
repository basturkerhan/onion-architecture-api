﻿using Erhan.MovieTicketSystem.Application.CustomMessages;
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
    public class DeleteMovieGenreCommandRequestHandler : IRequestHandler<DeleteMovieGenreCommandRequest, Response>
    {
        private readonly IUow _uow;
        public DeleteMovieGenreCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(DeleteMovieGenreCommandRequest request, CancellationToken cancellationToken)
        {
            MovieGenre deletedItem = await _uow.GetRepository<MovieGenre>().FindAsync(request.Id);
            if (deletedItem != null)
            {
                _uow.GetRepository<MovieGenre>().Remove(deletedItem);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success, HandlerMessages.SucceededDeleteMessage);
            }

            return new Response(ResponseType.NotFound, HandlerMessages.NotFoundMessage);
        }
    }
}
