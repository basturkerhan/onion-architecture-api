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
    public class UpdateMovieCommandRequestHandler : IRequestHandler<UpdateMovieCommandRequest>
    {
        private readonly IRepository<Movie> _repository;
        private readonly IMapper _mapper;

        public UpdateMovieCommandRequestHandler(IRepository<Movie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            Movie unchangedMovie = await _repository.FindAsync(request.Id);
            if (unchangedMovie != null)
            {
                _repository.Update(_mapper.Map<Movie>(request), unchangedMovie);
            }

            return Unit.Value;
        }
    }
}
