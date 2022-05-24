using AutoMapper;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
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
    public class DeleteMovieCommandRequestHandler : IRequestHandler<DeleteMovieCommandRequest>
    {
        private readonly IRepository<Movie> _repository;
        private readonly IMapper _mapper;

        public DeleteMovieCommandRequestHandler(IRepository<Movie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteMovieCommandRequest request, CancellationToken cancellationToken)
        {
            Movie deletedItem = await _repository.FindAsync(request.id);
            if (deletedItem != null)
            {
                _repository.Remove(deletedItem);
            }

            return Unit.Value;
        }
    }
}
